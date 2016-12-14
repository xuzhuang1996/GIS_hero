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
    class xu_draw
    {
        
        private List<Point[][]> geo_point;//逻辑真实坐标
        private List<Point[][]> screen_point;//显示在屏幕上的坐标
        private int Layer_count;//图层数
        private List<bool>show; //checkbox隐藏显示标记
        public int adjust_x;//用于调整到屏幕中间的值
        public int adjust_y;
        public double scale;//每像素代表多少米
        public Point base_point;//左上角的真实坐标
        public List<wkbGeometryType> shp_type;//获取图层的类型
        public Pen xu_pen;
        public xu_draw(int height)
        {
            geo_point = new List<Point[][]>();
            screen_point = new List<Point[][]>();
            Layer_count = 0;
            scale = 1.0;
            base_point = new Point(0, height);//左上角原点坐标
            show =new List<bool>();
            shp_type=new List<wkbGeometryType>();
            xu_pen= new Pen(Color.Red,1);
        }

        public bool addLayer(Point [][]point){
            if (point == null) {
                MessageBox.Show("加载图层出错");
                return false;
            }
            geo_point.Add(point);
            show.Add(true);
            screen_point.Add(new Point[geo_point[Layer_count].Length][]);//比较麻烦
            for (int i = 0; i < geo_point[Layer_count].Length; i++)
            {
                screen_point[Layer_count][i] = new Point[geo_point[Layer_count][i].Length];//每个要素有几个点
            }
            Layer_count++;
            return true;
        }

        //获取当前下标图层的所有的点的个数
        public int points_counts(int index) {
            if (index < Layer_count && index >= 0)
            {
                int allpoints = 0;
                for (int i = 0; i < geo_point[index].Length; i++)//单个图层里面的要素个数i
                {
                    for (int j = 0; j < geo_point[index][i].Length; j++)//单个要素的点个数j
                    {
                        allpoints++;
                    }
                }
                return allpoints;
            }
            else {
                MessageBox.Show("下标出错");
                return 0; }
        } 


        //复位函数，根据框的长宽计算屏幕坐标,根据显示的图层求外接矩形
        public void resetLayer(int width, int height, List<int> index)
        {
            if (Layer_count <= 0||index.Count<=0) return;
            int all_points = 0;
            for (int i = 0; i < index.Count; i++)
            {
                all_points += points_counts(index[i]);
            }
            
            
            //MessageBox.Show(all_points.ToString());
            int[] x = new int[all_points];//所有要素的点
            int[] y = new int[all_points];

            all_points = 0;
            for (int iLayer = 0; iLayer < index.Count; iLayer++)
            {
                for (int i = 0; i < geo_point[index[iLayer]].Length; i++)//单个图层里面的要素个数i
                {
                    for (int j = 0; j < geo_point[index[iLayer]][i].Length; j++)//单个要素的点个数j
                    {
                        
                        x[all_points] = geo_point[index[iLayer]][i][j].X;
                        y[all_points] = geo_point[index[iLayer]][i][j].Y;
                        all_points++;
                    }
                }
            }
            Array.Sort(x);
            Array.Sort(y);

            int recltangle_width = x[all_points - 1] - x[0];//获取实际区域的外包矩形长宽
            int recltangle_height = y[all_points - 1] - y[0];
            double scaleX = (double) recltangle_width/ (double)width;      //X轴上每像素代表多少米；
            double scaleY = (double) recltangle_height/ (double)height;
            scale = Math.Max(scaleX, scaleY);
            //scale = scale * 1.5;//比例因子控制，默认1.5为比较好的状态
            Point yuan_geo = new Point(Convert.ToInt32((double)recltangle_width / scale / 2.0), Convert.ToInt32((double)recltangle_height / scale / 2.0));
            Point yuan_screen = new Point(Convert.ToInt32(width/2.0), Convert.ToInt32(height/2.0));
            adjust_x = yuan_screen.X - yuan_geo.X;//将其调整到中间的调整值
            adjust_y = yuan_geo.Y -yuan_screen.Y ;
            
            for (int iLayer = 0; iLayer < Layer_count; iLayer++)
            {
                for (int i0 = 0; i0 < geo_point[iLayer].Length; i0++)
                {
                    for (int j0 = 0; j0 < geo_point[iLayer][i0].Length; j0++)
                    {
                        screen_point[iLayer][i0][j0].X = Convert.ToInt32((Convert.ToDouble(geo_point[iLayer][i0][j0].X - x[0])) / scale+(double)adjust_x);
                        screen_point[iLayer][i0][j0].Y = Convert.ToInt32((Convert.ToDouble(y[all_points - 1] - geo_point[iLayer][i0][j0].Y)) / scale - (double)adjust_y);
                        
                    }
                }
            }

            base_point.X = x[0] - Convert.ToInt32((double)adjust_x*scale);//获取左上角原点坐标
            base_point.Y = y[all_points - 1]+Convert.ToInt32((double)adjust_y*scale);
        }

        //绘图函数
        public void drawLayer(Panel panel) {
            Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);
            if (Layer_count == 0)
            {
                MessageBox.Show("当前无图层");
                return;
            }

            if (screen_point != null)
            {
                
                for (int i = 0; i < Layer_count; i++)
                    if (show[i])
                    {
                         for (int j = 0; j < screen_point[i].Length; j++)
                             draw_by_points(xu_pen, screen_point[i][j], shp_type[i], g);
                      
                    }
            }
            else MessageBox.Show("屏幕坐标计算出错");
        
        }
        //隐藏图层代码
        public void checkbox_clear(int i, Panel panel)
        {
                Graphics g = panel.CreateGraphics();
                Pen p=new Pen(panel.BackColor);
                show[i] = false;
                for (int j = 0; j < screen_point[i].Length; j++)
                {
                    //g.DrawPolygon(Pens.Red, screen_point[i][j]);
                    draw_by_points(p, screen_point[i][j], shp_type[i], g);
                }
        
        }
        public void checkbox_add(int i, Panel panel)
        {
            if (screen_point[i] == null) return;
            else
            {
                Graphics g = panel.CreateGraphics();
                show[i] = true;
                for (int j = 0; j < screen_point[i].Length; j++)   
                {
                    //g.DrawPolygon(Pens.Red, screen_point[i][j]);
                    draw_by_points(xu_pen, screen_point[i][j], shp_type[i], g); 
                }

            }

        }


        //移除图层
        public bool removeLayer(int i) {
            if (i < Layer_count && i >= 0)
            {
                geo_point.RemoveAt(i);
                screen_point.RemoveAt(i);
                show.RemoveAt(i);
                shp_type.RemoveAt(i);
                Layer_count--;
                return true;
            }
            else 
            {
                MessageBox.Show("移除图层错误");
                return false; 
            }   
        }

        //根据点数组绘制
        public void draw_by_points(Pen p,Point[]points,wkbGeometryType type,Graphics g) {
            
            if (points != null)
            {
                switch (type) { 
                    case wkbGeometryType.wkbPolygon25D:{
                        g.DrawPolygon(p,points);
                        break;
                    }
                    case wkbGeometryType.wkbLineString: {
                        g.DrawLines(p,points);
                        break;
                    }
                    case wkbGeometryType.wkbPoint:
                    {
                        g.DrawEllipse(p,points[0].X,points[0].Y,7,7);
                        
                        break;
                     }
                    default:
                    {
                        MessageBox.Show("不支持该要素类型");
                        break;
                    }
                        
                
                
                }
            }
        
        }


    }//end of class
}
