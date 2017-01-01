using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace hero_GIS
{
    public delegate void Del_add(xu_Layer lay);
    public partial class ToDataBase : Form
    {
        //private All_Layers hero;
        private zhang_sql sql;
        public Del_add del;
        public ToDataBase(zhang_sql s, Del_add d)
        {
            InitializeComponent();
            sql = s;
            del = d;
            //hero = h;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void query_Click(object sender, EventArgs e)
        {
            int type=0;
            if (comboBox1.Text == "") { MessageBox.Show("请选择图层类型"); return; }
            switch (comboBox1.Text) { 
                case "点图层":
                    type = 1;
                    break;
                case "线图层":
                    type = 2;
                    break;
                case "面图层":
                    type = 3;
                    break;
            }
            if (type == 0) return;
            OracleDataAdapter sd= sql.select("POINT", type);
            DataSet myds = new DataSet();
            sd.Fill(myds);
            dataGridView1.DataSource = myds.Tables[0];
           // MessageBox.Show(type.ToString());
            //dataGridView1
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            int pid = 0;
            pid =Convert.ToInt32(dataGridView1[0, i].Value);
            xu_Layer layer= sql.readblob(pid);
            //hero.addLayer(layer);
            del(layer);
            MessageBox.Show("添加成功");
            this.Close();
        }
    }
}
