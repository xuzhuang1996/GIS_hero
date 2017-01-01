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
    public partial class ToDataBase : Form
    {
        private xu_Layer layer;
        private zhang_sql sql;
        public ToDataBase(zhang_sql s)
        {
            InitializeComponent();
            sql = s;
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
    }
}
