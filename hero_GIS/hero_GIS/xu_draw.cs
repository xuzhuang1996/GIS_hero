using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;
namespace hero_GIS
{
    public class xu_Layer
    {
        public int Layer_ID;
        public string Layer_Name;
        public bool checkbox;//图层显示与否
        public bool Layet_edit;//图层编辑与否
        public wkbGeometryType Layer_type;//图层类型
        public Pen Layer_pen;//图层画笔
        public Point[][] geo_point;//逻辑真实坐标
        public Point[][] screen_point;//显示在屏幕上的坐标
       // public int feature_count;//要素个数
        //初始化
        public xu_Layer() {
            Layer_ID = 0;
            Layer_Name = null;
            checkbox = true;
            Layet_edit = false;
            Layer_pen = new Pen(Color.Red);
            geo_point = null;
            screen_point = null;
        
        }
        //获取当前图层的点的个数
        public int all_points_count() { 
            int count=0;
            for (int i = 0; i < geo_point.Length; i++)
                for (int j = 0; j < geo_point[i].Length; j++)
                    count++;
            return count;
        
        }


    }//end of class

    public class All_Layers {
        public List<xu_Layer> allLayers;//存放所有图层
        public int Layer_count;//图层数
        public int adjust_x;//用于调整到屏幕中间的值
        public int adjust_y;
        public double scale;//每像素代表多少米
        public Point base_point;//左上角的真实坐标
        public Pen clear_color;//画板背景色

        public All_Layers(Panel panel)//初始化
        {
            allLayers = new List<xu_Layer>();
            Layer_count = 0;
            scale = 1.0;
            base_point = new Point(0, panel.Height);//左上角原点坐标
            clear_color = new Pen(panel.BackColor);
        }

        //增加图层
        public bool addLayer(xu_Layer layer)
        {
            if (layer == null)
            {
                MessageBox.Show("加载图层出错");
                return false;
            }
            allLayers.Add(layer);
            allLayers[Layer_count].screen_point = new Point[allLayers[Layer_count].geo_point.Length][];
            for (int i = 0; i < allLayers[Layer_count].screen_point.Length; i++)
            {
                allLayers[Layer_count].screen_point[i] = new Point[allLayers[Layer_count].geo_point[i].Length];//每个要素有几个点
            }
            Layer_count++;
            return true;
        }

        //移除图层
        public bool removeLayer(int i)
        {
            if (i < Layer_count && i >= 0)
            {
                allLayers.RemoveAt(i);
                Layer_count--;
                return true;
            }
            else
            {
                MessageBox.Show("移除图层错误");
                return false;
            }
        }

        //绘图函数
        public void drawLayer(Graphics g)
        {
            g.Clear(clear_color.Color);//放在外面自己做
            if (Layer_count == 0)
            {
                MessageBox.Show("当前无图层2");
                return;
            }

            if (allLayers != null)
            {

                for (int i = 0; i < Layer_count; i++)
                    if (allLayers[i].checkbox)
                    {
                        for (int j = 0; j < allLayers[i].screen_point.Length; j++)
                            draw_by_points(allLayers[i].Layer_pen, allLayers[i].screen_point[j], allLayers[i].Layer_type, g);

                    }
            }
            else MessageBox.Show("屏幕坐标计算出错");

        }

        //根据点来绘图
        public void draw_by_points(Pen p, Point[] points, wkbGeometryType type, Graphics g)
        {

            if (points != null)
            {
                switch (type)
                {
                    case wkbGeometryType.wkbPolygon25D:
                        {
                            g.DrawPolygon(p, points);
                            g.FillPolygon(new SolidBrush(p.Color), points);
                            break;
                        }
                    case wkbGeometryType.wkbLineString:
                        {
                            g.DrawLines(p, points);
                            break;
                        }
                    case wkbGeometryType.wkbPoint:
                        {
                            g.DrawEllipse(p, points[0].X, points[0].Y, 7, 7);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("不支持" + type + "要素类型");
                            break;
                        }



                }
            }
        }//根据点的绘图函数结束

        //隐藏图层代码
        public void checkbox_clear(int i, Graphics g)
        {
            if (i < Layer_count && i >= 0)
            {
                allLayers[i].checkbox = false;
                for (int j = 0; j < allLayers[i].screen_point.Length; j++)
                {
                    draw_by_points(clear_color, allLayers[i].screen_point[j], allLayers[i].Layer_type, g);

                }
            }
            else
            {
                MessageBox.Show("隐藏图层错误");
                return;
            }
        }
       
        public void checkbox_add(int i,Graphics g)
        {
            if (allLayers[i].screen_point == null) return;
            else
            {
                allLayers[i].checkbox = true;
                for (int j = 0; j < allLayers[i].screen_point.Length; j++)
                {
                    draw_by_points(allLayers[i].Layer_pen, allLayers[i].screen_point[j], allLayers[i].Layer_type, g);
                }
            }
        }

/////////////////////////////////////////////////////////////////////功能函数///////////////////////////
        //复位函数，根据框的长宽计算屏幕坐标,根据显示的图层求外接矩形
        public void resetLayer(int width, int height, List<int> index)
        {
            //width -= 5;//后期判断是否有用
            //height -= 5;
            if (Layer_count <= 0 || index.Count <= 0) return;
            int all_points = 0;
            //获取当前显示图层的点的总个数
            for (int i = 0; i < index.Count; i++)
            {
                all_points += allLayers[index[i]].all_points_count();
            }
            int[] x = new int[all_points];//显示图层的所有要素的点
            int[] y = new int[all_points];

            all_points = 0;
            for (int iLayer = 0; iLayer < index.Count; iLayer++)
            {
                for (int i = 0; i < allLayers[index[iLayer]].geo_point.Length; i++)//单个图层里面的要素个数i
                {
                    for (int j = 0; j < allLayers[index[iLayer]].geo_point[i].Length; j++)//单个要素的点个数j
                    {

                        x[all_points] = allLayers[index[iLayer]].geo_point[i][j].X;
                        y[all_points] = allLayers[index[iLayer]].geo_point[i][j].Y;
                        all_points++;
                    }
                }
            }
            Array.Sort(x);
            Array.Sort(y);

            int recltangle_width = x[all_points - 1] - x[0];//获取实际区域的外包矩形长宽
            int recltangle_height = y[all_points - 1] - y[0];
            //X轴上每像素代表多少米
            scale = Math.Max(((double)recltangle_width / (double)width), ((double)recltangle_height / (double)height));
            //scale = scale * 1.5;//比例因子控制，默认1.5为比较好的状态
            Point yuan_geo = new Point(Convert.ToInt32((double)recltangle_width / scale / 2.0), Convert.ToInt32((double)recltangle_height / scale / 2.0));
            Point yuan_screen = new Point(Convert.ToInt32(width / 2.0), Convert.ToInt32(height / 2.0));
            adjust_x = yuan_screen.X - yuan_geo.X;//将其调整到中间的调整值
            adjust_y = yuan_geo.Y - yuan_screen.Y;

            for (int iLayer = 0; iLayer < Layer_count; iLayer++)
            {
                for (int i0 = 0; i0 < allLayers[iLayer].geo_point.Length; i0++)
                {
                    for (int j0 = 0; j0 < allLayers[iLayer].geo_point[i0].Length; j0++)
                    {
                        allLayers[iLayer].screen_point[i0][j0].X = Convert.ToInt32((Convert.ToDouble(allLayers[iLayer].geo_point[i0][j0].X - x[0])) / scale + (double)adjust_x);
                        allLayers[iLayer].screen_point[i0][j0].Y = Convert.ToInt32((Convert.ToDouble(y[all_points - 1] - allLayers[iLayer].geo_point[i0][j0].Y)) / scale - (double)adjust_y);

                    }
                }
            }

            base_point.X = x[0] - Convert.ToInt32((double)adjust_x * scale);//获取左上角原点坐标
            base_point.Y = y[all_points - 1] + Convert.ToInt32((double)adjust_y * scale);
        }

        //移动函数
        public void move(Point change)
        {
            for (int i = 0; i < Layer_count; i++)                              //首先改变屏幕坐标
                for (int j = 0; j <allLayers[i].screen_point.Length; j++)
                    for (int k = 0; k < allLayers[i].screen_point[j].Length; k++)
                    {
                        allLayers[i].screen_point[j][k].X += change.X;
                        allLayers[i].screen_point[j][k].Y += change.Y;
                    }
            //改变左上角的真实坐标
            base_point.X -= Convert.ToInt32(scale * (double)change.X);
            base_point.Y += Convert.ToInt32(scale * (double)change.Y);

        }
    }//end of class////////////////////////////////////////////////////////////////////////////////
}
