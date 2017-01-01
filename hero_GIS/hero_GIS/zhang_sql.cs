using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            int type = 0;
            switch (layer.Layer_type) { 
                case OSGeo.OGR.wkbGeometryType.wkbPoint:
                    type = 1;
                    break;
                case OSGeo.OGR.wkbGeometryType.wkbLineString:
                    type = 2;
                    break;
                case OSGeo.OGR.wkbGeometryType.wkbPolygon25D:
                    type = 3;
                    break;
            }
            String insert = "insert into " + tablename + "(PID,Pname,geo_reference,layer_point,type)values(SEQ_EMP.nextval,'" + layer.Layer_Name + "','" + layer.spatial_reference + "','1101','"+ type +"')";
            
            OracleCommand command = new OracleCommand(insert, conn);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("成功1！");

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误1" + ex);
            }
            finally { }
            String q = "SELECT SEQ_EMP.CURRVAL FROM DUAL";
            OracleCommand comman = new OracleCommand(q, conn);
            
            OracleDataReader sd= comman.ExecuteReader();
            int pid = 0;
            if (sd.Read()) pid = Convert.ToInt32(sd[0]);

            try
            {
                OracleCommand cmd = conn.CreateCommand();
                OracleTransaction transaction = cmd.Connection.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.CommandText = "select layer_point from " + tablename + " where PID="+pid+"  FOR UPDATE";
                OracleDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    reader.Read();
                    OracleLob templob = reader.GetOracleLob(0);
                    templob.BeginBatch(OracleLobOpenMode.ReadWrite);

                    byte[] buffer = obj_to_byte(layer.geo_point);
                    
                    templob.Write(buffer, 0, buffer.Length);
                    templob.EndBatch();
                    cmd.Parameters.Clear();

                }
                transaction.Commit();
                MessageBox.Show("成功2！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误2" + ex);
            }
            finally { }
        }

        public OracleDataAdapter select(string tablename,int type)
        {

            string select = "select pname from " + tablename + " where type="+ type +"";
            OracleDataAdapter myda = new OracleDataAdapter(select, conn);
            return myda;

        }





        private byte[] obj_to_byte(object p)
        {
            if (p == null) return null;

            //内存实例
            MemoryStream ms = new MemoryStream();
            //创建序列化的实例
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, p);//序列化对象，写入ms流中 
            ms.Position = 0;
            byte[] bytes = ms.GetBuffer();
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }
        private object byte_to_obj(byte[] bytes)
        {
            object obj = null;
            if (bytes == null)
                return obj;
            //利用传来的byte[]创建一个内存流
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms);//把内存流反序列成对象  
            ms.Close();
            return obj;
        }
    }
}
