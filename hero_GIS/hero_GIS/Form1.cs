using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace hero_GIS
{
    public partial class Form1 : Form
    {
        private xu_draw hero;//视图对象
        public Form1()
        {
            InitializeComponent();
            hero=new xu_draw(panel1.Height);
        }

        private void 添加图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //点击弹出对话框
            OpenFileDialog ofd = new OpenFileDialog();
            //设置对话框的标题
            ofd.Title = "请选择要打开的shp文件~";
            //设置对话框的初始目录
            ofd.InitialDirectory = @"C:\Users\xu\Desktop";
            //设置对话框的文件类型
            ofd.Filter = "shapefile文件|*.shp|所有文件|*.*";
            //展示对话框
            ofd.ShowDialog();

            //获得在打开对话框中选中文件的路径
            string sShpFileName = ofd.FileName; 
            if (sShpFileName == "")
            {
                return;
            }
            

            Gdalread m_Shp = new Gdalread();
            // 初始化GDAL和OGR
            m_Shp.InitinalGdal();
            //读取图层
            m_Shp.GetShpLayer(sShpFileName);

            
            Point[][] Group = m_Shp.GetGeometry(); //单个图层每个要素对应的点数组
            hero.addLayer(Group);
            hero.shp_type.Add(m_Shp.get_shp_Type());//获取图层类型信息
            //目录树的操作
            TreeNode tn_root = treeView.Nodes[0];
            tn_root.Checked = true;
            TreeNode tn = tn_root.Nodes.Add(Path.GetFileNameWithoutExtension(sShpFileName));
            tn.Checked = true;
            tn.ContextMenuStrip = contextMenuStrip2;
            treeView.ExpandAll();


            List<int> who_true=new List<int>();
            foreach (TreeNode node in treeView.Nodes[0].Nodes)
            {
                if (node.Checked == true)
                    who_true.Add(node.Index);    
            }
            
            hero.resetLayer(panel1.Width,panel1.Height,who_true);
            hero.drawLayer(panel1);

            

            


            //Point[][] screen = xu_where(Group, this.panel1.Width, this.panel1.Height, all_point_count);
            /*
            Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < Group.Length; i++)
            {
     
                g.DrawPolygon(Pens.Red, screen[i]);
            }
            */



            //属性问题后期解决
           // List<string> FeildStringList = null;
            //m_Shp.GetFeildContent(0, out FeildStringList);

            // 获取某条FID的数据
            //m_Shp.GetGeometry(0);
            //MessageBox.Show(m_Shp.sCoordiantes);
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //还是要靠遍历才能获取
            //TreeNode tn = treeView.SelectedNode;
            //MessageBox.Show(tn.Name);
            //if (tn.Checked == true) MessageBox.Show("ok");
            //else MessageBox.Show("no");
            treeView.SelectedNode = null;
            foreach (TreeNode node in treeView.Nodes[0].Nodes)
            {
                
                if (node.Checked == false) hero.checkbox_clear(node.Index, panel1);
                else if (node.Checked==true) hero.checkbox_add(node.Index, panel1);
            }

        }

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView.SelectedNode;
            if (tn == null||tn==treeView.Nodes[0]) {
                MessageBox.Show("未正确选中移除对象");
                return; }
            if (tn.Index>=0)
            {
                hero.removeLayer(tn.Index);
               // hero.resetLayer(panel1.Width, panel1.Height);
                hero.drawLayer(panel1);
                tn.Remove();
            }
            else{
                MessageBox.Show("未选中");
            
            }
        }

        private void full_extent_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            List<int> who_true = new List<int>();
            foreach (TreeNode node in treeView.Nodes[0].Nodes)
            {
                if (node.Checked == true)
                    who_true.Add(node.Index);
            }

            hero.resetLayer(panel1.Width, panel1.Height, who_true);
            hero.drawLayer(panel1);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            int zuobiao_x = Convert.ToInt32((double)e.X * hero.scale)+hero.base_point.X;
            int zuobiao_y = hero.base_point.Y-Convert.ToInt32((double)(e.Y) * hero.scale);
            zuobiao.Text = "("+zuobiao_x+","+zuobiao_y+")";
            //zuobiao.Text = "(" +e.X + "," + e.Y + ")";
        }


    }
}
