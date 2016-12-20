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
        private All_Layers  all_hero;//视图对象
        public Graphics g;
        public bool big;
        public xu_mouse mouse_action;
        public Form1()
        {
            InitializeComponent();
            //激活双缓冲技术
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            all_hero = new All_Layers(panel1);
            g= panel1.CreateGraphics();
            
        }

        private void 添加图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //点击弹出对话框
            OpenFileDialog ofd = new OpenFileDialog();
            //设置对话框的标题
            ofd.Title = "请选择要打开的shp文件~";
            //设置对话框的初始目录
            ofd.InitialDirectory = @"C:\Users\xu\Desktop\hero";
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
            //Point[][] Group = m_Shp.GetGeometry(); //单个图层每个要素对应的点数组

            xu_Layer layer = new xu_Layer();//初始化添加的图层信息
            layer.checkbox = true;
            layer.Layer_type = m_Shp.get_shp_Type();
            layer.geo_point = m_Shp.GetGeometry();
            if (layer.geo_point == null) {
                MessageBox.Show("无法读取该文件");
                return; }
            all_hero.addLayer(layer);
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
            
            all_hero.resetLayer(panel1.Width, panel1.Height, who_true);
            all_hero.drawLayer(g);



            //属性问题后期解决
           // List<string> FeildStringList = null;
            //m_Shp.GetFeildContent(0, out FeildStringList);

            // 获取某条FID的数据
            //m_Shp.GetGeometry(0);
            //MessageBox.Show(m_Shp.sCoordiantes);
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {

            treeView.SelectedNode = null;
            foreach (TreeNode node in treeView.Nodes[0].Nodes)
            {
                
                if (node.Checked == false) all_hero.checkbox_clear(node.Index, g);
                else if (node.Checked == true) all_hero.checkbox_add(node.Index, g);
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
                all_hero.removeLayer(tn.Index);
                all_hero.drawLayer(g);
                tn.Remove();
            }
            else{
                MessageBox.Show("未选中");
            
            }
        }

        private void full_extent_Click(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Default;
            
            g.Clear(panel1.BackColor);
            List<int> who_true = new List<int>();
            foreach (TreeNode node in treeView.Nodes[0].Nodes)
            {
                if (node.Checked == true)
                    who_true.Add(node.Index);
            }

            all_hero.resetLayer(panel1.Width, panel1.Height, who_true);
            all_hero.drawLayer(g);
        }



       
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            //坐标信息
            int zuobiao_x = Convert.ToInt32((double)e.X * all_hero.scale)+all_hero.base_point.X;
            int zuobiao_y = all_hero.base_point.Y-Convert.ToInt32((double)(e.Y) * all_hero.scale);
            zuobiao.Text = "("+zuobiao_x+","+zuobiao_y+")";
            label2.Text = "(" +e.X + "," + e.Y + ")";

            if (mouse_action!=null)
            mouse_action.mouse_move(sender,e);

        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Hand;//移动
            mouse_action = new move(panel1, all_hero,g);

        }

        

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouse_action != null)
            mouse_action.mouse_up(sender,e);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouse_action != null)
            mouse_action.mouse_down(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            big = true;
            //panel1.Cursor = new Cursor(@"F:\mygitwork\hero_GIS\big.png");
            //mouse_action = new rectangle(panel1);
            mouse_action = new zoom(panel1,all_hero,g,big);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            big = false;
            mouse_action = new zoom(panel1, all_hero, g,big);
            //panel1.Cursor = new Cursor(@"F:\mygitwork\hero_GIS\small.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);//注册panel鼠标滑动事件
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            //根据鼠标滑动进行快速缩放
            if (e.Delta > 0) {
                big = true;
                all_hero.zoom(e.Location, big);
                all_hero.drawLayer(g);

            }
            else if (e.Delta < 0) {
                big = false;
                all_hero.zoom(e.Location, big);
                all_hero.drawLayer(g);
            
            }
        }
    }


    public class MyPanel : Panel
    {
        public MyPanel()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
