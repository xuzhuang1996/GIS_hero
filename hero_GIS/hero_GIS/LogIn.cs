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
    
    
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private  zhang_sql our_sql;

        private void OK_Click(object sender, EventArgs e)
        {
            //string connection = "Data Source=" + DataBase.Text + ";User ID=" + UserName.Text + ";Password=" + Password.Text+";";
            our_sql = new zhang_sql(UserName.Text, Password.Text, DataBase.Text);
            //bool chinese;
            //if (comboBox1.Text == "汉语") chinese = true;
            //else chinese = false;
            //Form form1 = new Form1(our_sql,chinese);
            Form form1 = new Form1(our_sql);
            this.Hide();
            form1.Show();
            /*OracleConnection xu_connection = new OracleConnection(connection);
            try
            {
                xu_connection.Open();
               // MessageBox.Show(xu_connection.State.ToString());
                Form form1 = new Form1();
                this.Hide();
                form1.Show() ;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                xu_connection.Close();
            }*/
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (sender.Equals(UserName))
            {
                label4.Visible = UserName.Text.Length < 1;
            }
            if (sender.Equals(Password))
            {
                label6.Visible = Password.Text.Length < 1;
            }
            if (sender.Equals(DataBase))
            {
                label5.Visible = DataBase.Text.Length < 1;
            }
        }
    }
}
