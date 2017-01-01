using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hero_GIS
{
    public partial class property : Form
    {
        public property(int id,string name,string type,string saptial,bool edit)
        {
            InitializeComponent();
            label5.Text = id.ToString();
            label6.Text = name;
            label7.Text = type;
            label8.Text = saptial;
            label10.Text = edit.ToString();
        }
    }
}
