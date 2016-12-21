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
    
    
    }//end of class//////////////////////////////////////////////////////////////////////////////


    public class rectangle : xu_mouse {
        private Point startP, oldP,endP;//变换的起点和鼠标移动时的当前点
        private bool tag;
        public rectangle(Control p)
            : base(p)
        {
            tag = false;
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
            }
        }


        public override void mouse_up(object sender, MouseEventArgs e) {
            endP.X = e.X;
            endP.Y = e.Y;
            tag = false;
            Graphics g = panel.CreateGraphics();
            g.DrawRectangle(clear_pen, Math.Min(startP.X, oldP.X), Math.Min(startP.Y, oldP.Y), Math.Abs(startP.X - oldP.X), Math.Abs(startP.Y - oldP.Y));
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


}
