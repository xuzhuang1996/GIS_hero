using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace hero_GIS
{
    class mouse
    {
        //private MouseEventArgs e;
        public bool capture;//鼠标捕获
        public int type;//鼠标事件类型
        public Point down;//移动的时候鼠标初始点
        public Point up;//移动的时候鼠标的末尾点
        public mouse() {
            //e = init_e;
            capture = false;
            type = 0;
            up = new Point(0,0);
        }

        //还要考虑右键的情况，用switch还是if else看情况选择
        public void mousedown(MouseEventArgs e)
        {
            switch(type){
                case 0:{
                    capture = false;
                    break;
                }
                case 1://移动的时候记下初始点坐标
                {
                    
                    down = e.Location;
                    break;
                }

            }
        }


        public void mouseup(MouseEventArgs e)
        {
            if (type == 1)
            {
                up.X = e.Location.X-down.X;
                up.Y = e.Location.Y - down.Y;
            }
            else//只针对移动时的坐标记录
            {
                return;
            }
        
        }

        //最有趣的一个
        public bool mousemove(MouseEventArgs e)
        {

            if (type == 1 && e.Location != down)
            {
                up.X = e.Location.X - down.X;
                up.Y = e.Location.Y - down.Y;
                down = e.Location;
                return true;
            }
            else return false;

        
        }

    }
}
