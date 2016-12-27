using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace hero_GIS
{

    public class xu_mouse {
        public  xu_Layer our_Layer;//用于保存的图层
        public Control panel;
        public Pen clear_pen;//背景色用于擦除
        public xu_mouse(Control panel1)
        {
            panel = panel1;
            clear_pen = new Pen(panel1.BackColor);
        }
        public virtual  void mouse_down(object sender, MouseEventArgs e) { }
        public virtual  void mouse_move(object sender, MouseEventArgs e) { }
        public virtual  void mouse_up(object sender, MouseEventArgs e) { }
        public virtual void paint_again(object sender, MouseEventArgs e) { }
        public virtual void delete_feature() { }
        //public virtual void draw_over() { }
    
    }//end of class//////////////////////////////////////////////////////////////////////////////


    public class rectangle : xu_mouse {
        private Point startP, oldP,endP;//变换的起点和鼠标移动时的当前点
        private bool tag;
        private All_Layers hero;
        public Rectangle choose_rectangle;
        private int i_layer;
        private int[] index;
        public rectangle(Control p,All_Layers h)
            : base(p)
        {
            tag = false;
            hero = h;
            i_layer = -1;
            index = null;
        }
        
        

        public override void mouse_down(object sender, MouseEventArgs e) {
            
            //左键按下，开始画矩形，
            if (e.Button == MouseButtons.Left) {
                    tag = true;//左键按下
                    startP.X = e.X;
                    startP.Y = e.Y;
                    oldP.X = e.X;
                    oldP.Y = e.Y;
                
            }
        }

        public override void mouse_move(object sender, MouseEventArgs e) {
            Graphics g = panel.CreateGraphics();
            Pen curPen = new Pen(Color.Black);
            if (startP != e.Location && tag==true) {
                //用背景色绘制原来的变换
                g.DrawRectangle(clear_pen, Math.Min(startP.X, oldP.X), Math.Min(startP.Y, oldP.Y), Math.Abs(startP.X - oldP.X), Math.Abs(startP.Y - oldP.Y));
                //用当前画笔绘制当前变换
                g.DrawRectangle(curPen, Math.Min(startP.X, e.X), Math.Min(startP.Y, e.Y), Math.Abs(startP.X - e.X), Math.Abs(startP.Y - e.Y));
                oldP.X = e.X;
                oldP.Y = e.Y;
                hero.drawLayer_re(g);
            }
        }


        public override void mouse_up(object sender, MouseEventArgs e) {
            endP.X = e.X;
            endP.Y = e.Y;
            tag = false;
            Graphics g = panel.CreateGraphics();
            choose_rectangle=new Rectangle(Math.Min(startP.X, oldP.X), Math.Min(startP.Y, oldP.Y), Math.Abs(startP.X - oldP.X), Math.Abs(startP.Y - oldP.Y));
            g.DrawRectangle(clear_pen, choose_rectangle);
            hero.drawLayer_re(g);
            //panel.Invalidate();
            //panel.Update();
            
            index=hero.choose(choose_rectangle,out i_layer);
            hero.show_time(index, i_layer, g);
            choose_rectangle = new Rectangle();
        }

        //删除指定的要素
        public override void delete_feature()
        {
            Array.Sort(index);
            if (i_layer != -1 && index.Length > 0)
            {
                List<Point[]> temp = hero.allLayers[i_layer].geo_point.ToList();
                List<Point[]> te = hero.allLayers[i_layer].screen_point.ToList();
                for (int i = 0; i < index.Length; i++)
                {
                        temp.RemoveAt(index[i]-i);
                        te.RemoveAt(index[i]-i);
                }
                hero.allLayers[i_layer].geo_point = temp.ToArray();
                hero.allLayers[i_layer].screen_point = te.ToArray();
                
                Graphics g = panel.CreateGraphics();
                hero.drawLayer(g);
            }
           
        }
    }//end of class//////////////////////////////////////////////////////////////////////////

    public class move : xu_mouse {
        private Point down;//移动的时候鼠标初始点
        private Point up;//移动的时候鼠标的末尾点
        private All_Layers hero;
        private Graphics g;
        public move(Control p, All_Layers h, Graphics gg)
            : base(p)
        {
            hero = h;
            g = gg;
        }

        public override void mouse_down(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                down = e.Location;
            
            }
        }

        public override void mouse_up(object sender, MouseEventArgs e) {
            up.X = e.Location.X - down.X;
            up.Y = e.Location.Y - down.Y;
            hero.move(up.X, up.Y);//计算设备坐标
            hero.drawLayer(g);

        }
    
    }//end of class/////////////////////////////////////////////////////////////////////

    public class zoom : xu_mouse {
        private All_Layers hero;
        private Graphics g;
        private bool big;
        public zoom(Control p, All_Layers h, Graphics gg, bool b)
            : base(p)
        {
            hero = h;
            g = gg;
            big = b;
        }
        public override void mouse_down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                hero.zoom(e.Location, big);
                hero.drawLayer(g);

            }
        }
    
    }//end of class/////////////////////////////////////////////////////////////////////

    //画点类实现
    public class draw_point : xu_mouse {
        private All_Layers hero;
        private Graphics g;
        private List<Point[]> points ;
        private List<Point[]> screen_points;
        //private int index;//几号图层
        public draw_point(Control p, All_Layers h, Graphics gg,xu_Layer layer)
            : base(p)
        {
            hero = h;
            g = gg;
            our_Layer = layer;
            points = new List<Point[]>();
            screen_points = new List<Point[]>();
            
        }

        public override void mouse_down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && our_Layer.Layet_edit == true)
            {
                g.DrawEllipse(our_Layer.Layer_pen, e.X, e.Y, 7, 7);
                Point[] p = new Point[1];
                p[0] = new Point(e.X, e.Y);
                p[0] = hero.screen_TO_geo(p[0]);
                points.Add(p);
                if (our_Layer.geo_point == null)
                {
                    draw_over();
                    return;
                }
                List<Point[]> temp = our_Layer.geo_point.ToList();
                temp.Add(p);
                our_Layer.geo_point = temp.ToArray();
                our_Layer.screen_point = new Point[our_Layer.geo_point.Length][];
                for (int i = 0; i < our_Layer.geo_point.Length; i++)
                    our_Layer.screen_point[i] = new Point[1];
            }
           
           

        }

        public  void draw_over()
        {
            our_Layer.geo_point = points.ToArray();
            our_Layer.screen_point = new Point[our_Layer.geo_point.Length][];
            for(int i=0;i<our_Layer.geo_point.Length;i++)
                our_Layer.screen_point[i]=new Point [1];
        }

        

    }//end of class

    //画线
    public class line : xu_mouse
    {

       // private bool tag;
        private All_Layers hero;
       
        private Point[][] tranGroup = new Point[1000][];//线变换组
      
        private int tranNumb = 0;//变换序号
     
        private int pushNumb = 0;//左键按下情况：0为开始画变换，1为结束
        private Point curP;//存储变换时鼠标的当前点
        private Point startP, oldP;//变换的起点和鼠标移动时的当前点
        private Graphics g0, g3;//窗口绘图面和采用双缓冲时的临时绘图面
        public Pen curPen;//一个变换确定并要绘制时所用的画笔
        private Point endPoint;//存储右键按下时放弃绘制相连变换的鼠标点
        private Color clr;//获取窗体背景色
        private Pen p1;//重画变换时所用的笔
        private Bitmap bitmap = null;//双缓冲时用的位图
        public static int countnumber = 0;
        public static int judgenumber = 0;
        public static int a;
        public List<Point> qwarr = new List<Point>(); 
        public bool Capture;
        public line(Control p, All_Layers h, xu_Layer layer)
            : base(p)
        {
           
            hero = h;
            our_Layer = layer;
            bitmap = new Bitmap(panel.Width, panel.Height, panel.CreateGraphics());//创建临时位图
            g0 = panel.CreateGraphics();
            a = 0;
            curPen = new Pen(Color.YellowGreen, 1);//定义一个变换确定并要绘制时所用的画笔
            clr = panel.BackColor;//获取窗体背景色
            p1 = new Pen(clr, 1);
            for (int i = 0; i < 1000; i++)
            {
                tranGroup[i] = new Point[2];
                
            }

            g3 = Graphics.FromImage(bitmap);//从位图创建绘图面
            //g3.Clear(panel.BackColor);//清除背景色
            paint_again(g3);


            //把临时位图拷贝到窗体绘图面
            g0.DrawImage(bitmap, 0, 0);
            g3.Dispose();
        }



        public override void mouse_down(object sender, MouseEventArgs e)
        {

            Graphics g2 = panel.CreateGraphics();
            //e.Delta;//获取鼠标
            //判断变换数
            if (tranNumb >= 999)
            {
                pushNumb = 0;
                Capture = false;
                return;
            }
            // MessageBox.Show("happy friday");
            //左键按下
            if (e.Button == MouseButtons.Left)
            {
                //开始分类，是谁在用左键case

                if (pushNumb == 0)//判断是否是折线的开始
                {
                    if (endPoint.X != e.X || endPoint.Y != e.Y)
                    {
                        Capture = true;//捕获鼠标
                        pushNumb++;
                        startP.X = e.X;
                        startP.Y = e.Y;
                        oldP.X = e.X;
                        oldP.Y = e.Y;
                       
                    }
                }
                else if (pushNumb == 1)//如果不是一段新的折线的开始
                {
                    curP.X = e.X;
                    curP.Y = e.Y;

                    //把变换存入变换组中
                    //  g2.DrawLine(curPen, startP, new Point(e.X, e.Y));
                    tranGroup[tranNumb][0] = startP;
                    tranGroup[tranNumb][1] = curP;
                    tranNumb++;


                    startP.X = e.X;
                    startP.Y = e.Y;

                    //存储一段折线的最后一个点的坐标
                    endPoint.X = e.X;
                    endPoint.Y = e.Y;

                }
            }

            //右键按下
            Graphics g1 = panel.CreateGraphics();
            if (e.Button == MouseButtons.Right)
            {

                if (our_Layer.geo_point == null)
                {
                    for (int i = 0; i < tranNumb; i++)
                    {

                        qwarr.Add(tranGroup[i][0]);
                        qwarr[i] = hero.screen_TO_geo(tranGroup[i][0]);
                    }
                    if (tranNumb != 0)
                    {
                        qwarr.Add(tranGroup[tranNumb - 1][1]);
                        qwarr[tranNumb] = hero.screen_TO_geo(tranGroup[tranNumb - 1][1]);

                        our_Layer.geo_point = new Point[1][];
                        our_Layer.geo_point[0] = qwarr.ToArray();
                        our_Layer.screen_point = new Point[1][];

                        our_Layer.screen_point[0] = new Point[our_Layer.geo_point[0].Length];
                    }
                }
                else
                {
                    List<Point> q = new List<Point>();//许壮
                    for (int i = a, j = 0; i < tranNumb ; i++, j++)
                    {
                        //qwarr[i] = tranGroup[i][0];
                        //q.Add(tranGroup[i][0]);
                        q.Add(hero.screen_TO_geo(tranGroup[i][0]));
                    }
                    //qwarr[tranNumb + 1] = tranGroup[tranNumb - 1][1];
                    if (q.Count>0)
                    {
                        q.Add(hero.screen_TO_geo(tranGroup[tranNumb - 1][1]));
                        ////////////////////////
                        List<Point[]> temp = our_Layer.geo_point.ToList();

                        temp.Add(q.ToArray());
                        
                        our_Layer.geo_point = temp.ToArray();
                        our_Layer.screen_point = new Point[our_Layer.geo_point.Length][];
                        for (int i = 0; i < our_Layer.geo_point.Length; i++)
                            if (our_Layer.geo_point[i].Length != 1)
                            {
                                our_Layer.screen_point[i] = new Point[our_Layer.geo_point[i].Length];
                            }
                        ///////////////////
                    }
                    //panel.Refresh();
                }
                a = tranNumb;
                hero.drawLayer(g1);
                if (pushNumb == 0) return;
                //右键之后的不画

                //变换数没有超过变换组最大限度
                pushNumb = 0;//一段折线结束
                Capture = false;//释放鼠标
                //panel.Invalidate();
                //panel.Update();
                
                
            }
            //失效重画,Invalidate函数在这里应该没起到作用，因此重新写的再次绘制
            // this.panel.Invalidate();
            
            //用当前绘制已有的变换，防止它们被擦除
            paint_again(g1);
            
        }

        public override void mouse_move(object sender, MouseEventArgs e)
        {
            Graphics g1 = panel.CreateGraphics();
            //左键按下并移动鼠标
            if (pushNumb == 1)
            {
                if (oldP.X != e.X || oldP.Y != e.Y)
                {

                    g1.DrawLine(p1, startP, oldP);//用背景色绘制原来的变换
                    g1.DrawLine(curPen, startP, new Point(e.X, e.Y));//用当前画笔绘制当前变换



                    //存储一个变换的终点，作为下一变换的起点
                    oldP.X = e.X;
                    oldP.Y = e.Y;
                    //用当前绘制已有的变换，防止它们被擦除
                    paint_again(g1);
                }
            }
            g1.Dispose();
        }

        private void paint_again(Graphics g1)
        {

            for (int i = 0; i < tranNumb; i++)
            {
                g1.DrawLine(curPen, tranGroup[i][0], tranGroup[i][1]);
            }
        }
       
    }//end of class//////////////////////////////////////////////////////////////////////////
}
