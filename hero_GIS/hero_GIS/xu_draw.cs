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
        //创建时添加
        public int Layer_ID;
        public string Layer_Name;
        public wkbGeometryType Layer_type;//图层类型
        public string spatial_reference;
        //交互式添加
        public bool checkbox;//图层显示与否
        public bool Layet_edit;//图层编辑与否
        
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
            Layer_pen = new Pen(Color.YellowGreen);
            geo_point = null;
            screen_point = null;
        
        }
        //获取当前图层的点的个数
        public int all_points_count() { 
            int count=0;
            if (geo_point != null)
            {
                for (int i = 0; i < geo_point.Length; i++)
                    for (int j = 0; j < geo_point[i].Length; j++)
                        count++;
            }
            return count;
        
        }


    }//end of class//////////////////////////////////////////////////////////////////////////////

    public class All_Layers {
        public List<xu_Layer> allLayers;//存放所有图层
        public int Layer_count;//图层数
        public double scale;//每像素代表多少米
        public Point base_point;//左上角的真实坐标
        public Pen clear_color;//画板背景色
        public Point yuan_screen;//中心设备坐标

        //public All_Layers(Panel panel)//初始化
        public All_Layers(Control panel)//初始化
        {
            allLayers = new List<xu_Layer>();
            Layer_count = 0;
            scale = 1.0;
            base_point = new Point(0, panel.Height);//左上角原点坐标
            clear_color = new Pen(panel.BackColor);
            yuan_screen = new Point(Convert.ToInt32(panel.Width / 2.0), Convert.ToInt32(panel.Height / 2.0));
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
            //当已经添加的图层已经有地理信息的时候
            if (allLayers[Layer_count].geo_point != null)
            {
                allLayers[Layer_count].screen_point = new Point[allLayers[Layer_count].geo_point.Length][];
                for (int i = 0; i < allLayers[Layer_count].screen_point.Length; i++)
                {
                    allLayers[Layer_count].screen_point[i] = new Point[allLayers[Layer_count].geo_point[i].Length];//每个要素有几个点
                }
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
            g.Clear(clear_color.Color);
            if (Layer_count == 0)
            {
                MessageBox.Show("当前无图层2");
                return;
            }

            if (allLayers != null)
            {
                calculate_screen_by_basepoint();
                for (int i = 0; i < Layer_count; i++)
                    if (allLayers[i].checkbox && allLayers[i].screen_point!=null)
                    {
                        for (int j = 0; j < allLayers[i].screen_point.Length; j++)
                            draw_by_points(allLayers[i].Layer_pen, allLayers[i].screen_point[j], allLayers[i].Layer_type, g);

                    }
            }
            else MessageBox.Show("屏幕坐标计算出错");

        }

        //绘图函数
        public void drawLayer_re(Graphics g)//纯粹为了矩形框而做的更改，属于设计不得利，在Mousemove中用的
        {
            //g.Clear(clear_color.Color);
            if (Layer_count == 0)
            {
                MessageBox.Show("当前无图层2");
                return;
            }

            if (allLayers != null)
            {
                calculate_screen_by_basepoint();
                for (int i = 0; i < Layer_count; i++)
                    if (allLayers[i].checkbox && allLayers[i].screen_point != null)
                    {
                        for (int j = 0; j < allLayers[i].screen_point.Length; j++)
                            draw_by_points(allLayers[i].Layer_pen, allLayers[i].screen_point[j], allLayers[i].Layer_type, g);

                    }
            }
            else MessageBox.Show("屏幕坐标计算出错");

        }

        //根据点来绘图
        private void draw_by_points(Pen p, Point[] points, wkbGeometryType type, Graphics g)
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
                if (allLayers[i].screen_point != null)
                {
                    for (int j = 0; j < allLayers[i].screen_point.Length; j++)
                    {

                        draw_by_points(clear_color, allLayers[i].screen_point[j], allLayers[i].Layer_type, g);

                    }
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

/////////////////////////////////////////////////////////////////////功能函数////////////////////////////////////////////
        //根据左上角的地理坐标的计算所有的点的设备坐标
        private void calculate_screen_by_basepoint() {
            for (int iLayer = 0; iLayer < Layer_count; iLayer++)
            {
                if (allLayers[iLayer].geo_point != null)
                {
                    for (int i0 = 0; i0 < allLayers[iLayer].geo_point.Length; i0++)
                    {
                        if (allLayers[iLayer].geo_point[i0] != null)
                        {
                            for (int j0 = 0; j0 < allLayers[iLayer].geo_point[i0].Length; j0++)
                            {
                                allLayers[iLayer].screen_point[i0][j0].X = Convert.ToInt32((Convert.ToDouble(allLayers[iLayer].geo_point[i0][j0].X - base_point.X)) / scale);
                                allLayers[iLayer].screen_point[i0][j0].Y = Convert.ToInt32((Convert.ToDouble(base_point.Y - allLayers[iLayer].geo_point[i0][j0].Y)) / scale);

                            }
                        }
                    }
                }
            }
        
        }
        //复位函数，根据框的长宽计算屏幕坐标,根据显示的图层求外接矩形
        public void resetLayer(int width, int height, List<int> index)
        {
            //width -= 5;//后期判断是否有用
            //height -= 5;
            if (Layer_count <= 0 || index.Count <= 0 ) return;
            int all_points = 0;
            //获取当前显示图层的点的总个数
            for (int i = 0; i < index.Count; i++)
            {
                all_points += allLayers[index[i]].all_points_count();
            }
            if (all_points == 0) return;
            int []x = new int[all_points];//当前显示图层的所有要素的点
            int []y = new int[all_points];

            all_points = 0;
            for (int iLayer = 0; iLayer < index.Count; iLayer++)
            {
                if (allLayers[index[iLayer]].geo_point != null)
                {
                    for (int i = 0; i < allLayers[index[iLayer]].geo_point.Length; i++)//单个图层里面的要素个数i
                    {
                        for (int j = 0; j < allLayers[index[iLayer]].geo_point[i].Length; j++)//单个要素的点个数j
                        {
                            //初始化xy，将当前显示的图层的所有点放在数组里面
                            x[all_points] = allLayers[index[iLayer]].geo_point[i][j].X;
                            y[all_points] = allLayers[index[iLayer]].geo_point[i][j].Y;
                            all_points++;
                        }
                    }
                }
            }
            Array.Sort(x);
            Array.Sort(y);

            int recltangle_width = x[x.Length - 1] - x[0];//获取实际区域的外包矩形长宽
            int recltangle_height = y[y.Length - 1] - y[0];
            //X轴上每像素代表多少米
            scale = Math.Max(((double)recltangle_width / (double)width), ((double)recltangle_height / (double)height));
           // scale = scale * 1.5;//比例因子控制，默认1.5为比较好的状态
            Point yuan_geo = new Point();
            yuan_geo.X = Convert.ToInt32((double)recltangle_width / scale / 2.0);//获取当前图层所代表的外包矩形范围的中心点
            yuan_geo.Y = Convert.ToInt32((double)recltangle_height / scale / 2.0);
            int adjust_x = yuan_screen.X - yuan_geo.X;//将其调整到中间的调整值
            int adjust_y = yuan_geo.Y-yuan_screen.Y;

            base_point.X = x[0] - Convert.ToInt32((double)adjust_x * scale);//获取左上角原点坐标
            base_point.Y = y[y.Length - 1] - Convert.ToInt32((double)adjust_y * scale);//还没弄清楚为啥减，虽然效果是对的
            calculate_screen_by_basepoint();
        }

        //移动函数,其实是坐标轴在往手势的相反方向移动//////////////////////////////////////////////////////////////////////////////////////////////
        public void move(int change_x,int change_y)
        {
            //改变左上角的真实坐标
            base_point.X -= Convert.ToInt32(scale * (double)change_x);
            base_point.Y += Convert.ToInt32(scale * (double)change_y);
            calculate_screen_by_basepoint();

        }
        //坐标转换，测试时候需要注意
        public Point screen_TO_geo(Point screen) {
            screen.X = Convert.ToInt32((double)screen.X * scale) + base_point.X;
            screen.Y = base_point.Y - Convert.ToInt32((double)(screen.Y) * scale);
            return screen;
        
        }
        public Point geo_TO_screen(Point screen)
        {
            screen.X = Convert.ToInt32((Convert.ToDouble(screen.X - base_point.X)) / scale);
            screen.Y = Convert.ToInt32((Convert.ToDouble(base_point.Y - screen.Y)) / scale) ;
            return screen;

        }
        //根据倍数缩放
        public void zoom(Point change,bool big) {
            int x=  change.X;
            int y = change.Y;
            change = screen_TO_geo(change);//根据鼠标点击位置获取其地理位置
           
            if (big == true)
            {
                scale *= 0.8;
            }
            else {
                scale /= 0.8;
            
            }
            base_point.X = change.X - Convert.ToInt32(scale * (double)x);//根据鼠标地理位置以及屏幕坐标，计算左上角坐标
            base_point.Y = change.Y + Convert.ToInt32(scale * (double)y);
            calculate_screen_by_basepoint();
        
        }

        //选择要素,需要改进。
        public int [] choose(Rectangle choose_rectangle,out int xu_layer_index) {
            if (choose_rectangle == null) {
                MessageBox.Show("当前无选中要素");
                xu_layer_index = -1;
                return null;
            }
            List<int> choose_index = new List<int>();
            int temp = -1; ;
            if (allLayers != null)
            {

                for (int i = 0; i < Layer_count; i++)
                    if (allLayers[i].checkbox && allLayers[i].screen_point != null && allLayers[i].Layet_edit==true)
                    {

                        for (int j = 0; j < allLayers[i].screen_point.Length; j++)
                        {
                            int num = 0;
                            for (int k = 0; k < allLayers[i].screen_point[j].Length; k++)
                            {
                                if (choose_rectangle.Contains(allLayers[i].screen_point[j][k]) == true)
                                    num++;
                            }
                            if (num > 0 && num <= allLayers[i].screen_point[j].Length)
                            {
                                //MessageBox.Show(j.ToString());
                                choose_index.Add(j);
                                temp = i;
                            }
                        }
                    }

            }
            xu_layer_index = temp;
            return choose_index.ToArray();
        }

        //根据选中的要素来进行闪烁
        public void show_time(int[] index, int ilayer, Graphics g)
        {
            Pen p = new Pen(Color.Red, 1);
            for (int i = 0; i < index.Length; i++)
                draw_by_points(p, allLayers[ilayer].screen_point[index[i]], allLayers[ilayer].Layer_type, g);
        
        
        }


        private void showByArray(int[] index, int ilayer,Graphics g) { 
            for(int i=0;i<index.Length;i++)
                draw_by_points(allLayers[ilayer].Layer_pen, allLayers[ilayer].screen_point[index[i]], allLayers[ilayer].Layer_type, g);
        
        }

        private void hideByArray(int[] index, int ilayer, Graphics g)
        {
            for (int i = 0; i < index.Length; i++)
                draw_by_points(clear_color, allLayers[ilayer].screen_point[index[i]], allLayers[ilayer].Layer_type, g);

        }

        
    }//end of class////////////////////////////////////////////////////////////////////////////////
}
