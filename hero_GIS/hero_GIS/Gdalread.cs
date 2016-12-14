using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.IO;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;
using System.Collections;
using System.Drawing;
namespace hero_GIS
{
    class Gdalread
    {
         /// 保存SHP属性字段
        public OSGeo.OGR.Driver oDerive;
        public List<string> m_FeildList;
        private Layer oLayer;
        public string sCoordiantes;
        public Gdalread()
        {
            m_FeildList = new List<string>();
            oLayer = null;
            sCoordiantes = null;
        }

        /// <summary>
        /// 初始化Gdal
        /// </summary>
        public void InitinalGdal()
        {
            // 为了支持中文路径
            Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
            // 为了使属性表字段支持中文
            Gdal.SetConfigOption("SHAPE_ENCODING", "");
            Gdal.AllRegister();
            Ogr.RegisterAll();
            
            oDerive = Ogr.GetDriverByName("ESRI Shapefile");
            if (oDerive == null)
            {
                MessageBox.Show("文件不能打开，请检查");
            }
        }

        /// <summary>
        /// 获取SHP文件的层
        /// </summary>
        /// <param name="sfilename"></param>
        /// <param name="oLayer"></param>
        /// <returns></returns>
        public bool GetShpLayer(string sfilename)
        {
            if (null == sfilename || sfilename.Length <= 3)
            {
                oLayer = null;
                return false;
            }
            if (oDerive == null)
            {
                MessageBox.Show("文件不能打开，请检查");
            }
            DataSource ds = oDerive.Open(sfilename, 1);
            if (null == ds)
            {
                oLayer = null;
                return false;
            }
            int iPosition = sfilename.LastIndexOf("\\");
            string sTempName = sfilename.Substring(iPosition + 1, sfilename.Length - iPosition - 4 - 1);
            oLayer = ds.GetLayerByName(sTempName);
            if (oLayer == null)
            {
                ds.Dispose();
                MessageBox.Show("图层不能打开");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取所有的属性字段
        /// </summary>
        /// <returns></returns>
        public bool GetFeilds()
        {
            if (null == oLayer)
            {
                return false;
            }
            m_FeildList.Clear();
            wkbGeometryType oTempGeometryType = oLayer.GetGeomType();
            List<string> TempstringList = new List<string>();

            //
            FeatureDefn oDefn = oLayer.GetLayerDefn();
            int iFieldCount = oDefn.GetFieldCount();
            for (int iAttr = 0; iAttr < iFieldCount; iAttr++)
            {
                FieldDefn oField = oDefn.GetFieldDefn(iAttr);
                if (null != oField)
                {
                    m_FeildList.Add(oField.GetNameRef());
                }
            }
            return true;
        }
        /// <summary>
        ///  获取某条数据的字段内容
        /// </summary>
        /// <param name="iIndex"></param>
        /// <param name="FeildStringList"></param>
        /// <returns></returns>
        public bool GetFeildContent(int iIndex, out List<string> FeildStringList)
        {
            FeildStringList = new List<string>();
            Feature oFeature = null;
            if ((oFeature = oLayer.GetFeature(iIndex)) != null)
            {
                
                FeatureDefn oDefn = oLayer.GetLayerDefn();
                int iFieldCount = oDefn.GetFieldCount();
                // 查找字段属性
                for (int iAttr = 0; iAttr < iFieldCount; iAttr++)
                {
                    FieldDefn oField = oDefn.GetFieldDefn(iAttr);
                    string sFeildName = oField.GetNameRef();

                    #region 获取属性字段
                    FieldType Ftype = oFeature.GetFieldType(sFeildName);
                    switch (Ftype)
                    {
                        case FieldType.OFTString:
                            string sFValue = oFeature.GetFieldAsString(sFeildName);
                            string sTempType = "string";
                            FeildStringList.Add(sFValue);
                            break;
                        case FieldType.OFTReal:
                            double dFValue = oFeature.GetFieldAsDouble(sFeildName);
                            sTempType = "float";
                            FeildStringList.Add(dFValue.ToString());
                            break;
                        case FieldType.OFTInteger:
                            int iFValue = oFeature.GetFieldAsInteger(sFeildName);
                            sTempType = "int";
                            FeildStringList.Add(iFValue.ToString());
                            break;
                        default:
                            //sFValue = oFeature.GetFieldAsString(ChosenFeildIndex[iFeildIndex]);
                            sTempType = "string";
                            break;
                    }
                    #endregion
                }
            }
            return true;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        /// 
        public wkbGeometryType get_shp_Type() {
            return oLayer.GetGeomType();
        }

        //获取一个图层的所有要素的点的坐标，返回数组
        public Point [][] GetGeometry()
        {
            int iFeatureCout = oLayer.GetFeatureCount(0);
            Point[][] p = new Point[iFeatureCout][];
            for (int feature_index = 0; feature_index < iFeatureCout; feature_index++)
            {
                Feature oFeature = null;
                oFeature = oLayer.GetFeature(feature_index);//得到第feature_index个要素对象

                Geometry oGeometry = oFeature.GetGeometryRef();
                
                wkbGeometryType oGeometryType = oGeometry.GetGeometryType();
                switch (oGeometryType)
                {
                    case wkbGeometryType.wkbPolygon25D:
                        {
                            p[feature_index] = new Point[oGeometry.GetBoundary().GetPointCount()];//一个要素里面的所有点
                            for (int i = 0; i < oGeometry.GetBoundary().GetPointCount(); i++)
                            {
                                p[feature_index][i].X = Convert.ToInt32(oGeometry.GetBoundary().GetX(i));
                                p[feature_index][i].Y = Convert.ToInt32(oGeometry.GetBoundary().GetY(i));
                            }
                            break;
                        }
                    case wkbGeometryType.wkbLineString: 
                        {
                            p[feature_index] = new Point[oGeometry.GetPointCount()];//一个要素里面的所有点
                            for (int i = 0; i < oGeometry.GetPointCount(); i++)
                            {
                                p[feature_index][i].X = Convert.ToInt32(oGeometry.GetX(i));
                                p[feature_index][i].Y = Convert.ToInt32(oGeometry.GetY(i));

                            }
                            break;
                        }
                    case wkbGeometryType.wkbPoint:
                        {
                            p[feature_index] = new Point[1];//一个要素里面的所有点
                            p[feature_index][0].X = Convert.ToInt32(oGeometry.GetX(0));
                            p[feature_index][0].Y = Convert.ToInt32(oGeometry.GetY(0));
                            break;
                        }
                    default :
                        MessageBox.Show("要素类型不支持");
                        break;
                }

            }
            
            if (p == null) MessageBox.Show("未找到要素");
            return p;
        }

    }//END class
    
}
