using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OSGeo.OGR;

namespace hero_GIS
{
    public delegate void DelTest(string s1, wkbGeometryType s2, string s3);
    public partial class new_layer : Form
    {
        public DelTest del;
        public new_layer(DelTest d)
        {
            this.del = d;
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (LayerName.Text != "" && comboBox2.SelectedItem != null && comboBox1.SelectedItem != null)
            {
                switch (comboBox1.Text)
                {
                    case "Point":
                        del(LayerName.Text, wkbGeometryType.wkbPoint, comboBox2.Text);
                        break;
                    case "Line":
                        del(LayerName.Text, wkbGeometryType.wkbLineString, comboBox2.Text);
                        break;
                    case "Polygon":
                        del(LayerName.Text, wkbGeometryType.wkbPolygon25D, comboBox2.Text);
                        break;

                }
                MessageBox.Show("新建成功");
                this.Close();
            }
            else MessageBox.Show("请输入完整信息");
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (sender.Equals(LayerName))
            {
                label2.Visible = LayerName.Text.Length < 1;
            }
        }

    }
}
