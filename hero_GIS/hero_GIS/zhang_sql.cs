using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace hero_GIS
{
    public class zhang_sql
    {
        public OracleConnection conn = new OracleConnection();
        public  zhang_sql(string us,string ps,string so) 
        {
           
            string connString= string.Format("User ID='{0}';Password='{1}';Data Source='{2}'",us,ps,so);
            conn = new OracleConnection(connString);
            conn.Open();
        }
        ~zhang_sql() 
        {
            conn.Close();
        }

        //插入
        public void insert(string tablename,xu_Layer layer)
        {

            String insert = "insert into " + tablename + "(PID,Pname,geo_reference)values(SEQ_EMP.nextval,'" + layer.Layer_Name + "','" + layer.spatial_reference + "')";
            OracleCommand command = new OracleCommand(insert, conn);


            try
            {

                command.ExecuteNonQuery();
                MessageBox.Show("成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误" + ex);
            }
            finally { }
        }
    }
}
