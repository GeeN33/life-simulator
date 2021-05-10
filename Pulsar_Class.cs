using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_live
{
    class Pulsar_Class
    {
        public int x;
        public  int y;
        int xf = 1;
        int yf = 0;
        int W;
        int H;
        public  int color = 5;
        Random rnd = new Random();
        Random rnd2 = new Random();
        int dl = 0;
       

        public  Pulsar_Class(int x, int y, int W, int H)
        {

            this.x = x;
            this.y = y;
            this.W = W - 5;
            this.H = H - 5;

            Random rnd = new Random();
            int value = rnd.Next(1, 4);
            Rand(value);

        }

        public void route()
        {

            if (5 >= x && xf == -1 && yf == 0) { Rand(1); }

            if (5 >= x && xf == -1 && yf == -1) { Rand(1); }

            if (5 >= x && xf == -1 && yf == 1) { Rand(1); }
            ////
            if (5 >= y && xf == 1 && yf == -1) { Rand(2); }

            if (5 >= y && xf == 0 && yf == -1) { Rand(2); }

            if (5 >= y && xf == -1 && yf == -1) { Rand(2); }
            /////
            if (W <= x && xf == 1 && yf == 1) { Rand(3); }

            if (W <= x && xf == 1 && yf == 0) { Rand(3); }

            if (W <= x && xf == 1 && yf == -1) { Rand(3); }
            /////
            if (H <= y && xf == -1 && yf == 1) { Rand(4); }

            if (H <= y && xf == 0 && yf == 1) { Rand(4); }

            if (H <= y && xf == 1 && yf == 1) { Rand(4); }


        }

        public void move()
        {
            int step = 1;
            if (xf == 1 && yf == -1) { x = x + step; y = y - step; }
            if (xf == 1 && yf == 0) { x = x + step; y = y + 0; }
            if (xf == 1 && yf == 1) { x = x + step; y = y + step; }
            ////
            if (xf == -1 && yf == 1) { x = x - step; y = y + step; }
            if (xf == 0 && yf == 1) { x = x + 0; y = y + step; }
            if (xf == 1 && yf == 1) { x = x + step; y = y + step; }
            ///
            if (xf == -1 && yf == -1) { x = x - step; y = y - step; }
            if (xf == -1 && yf == 0) { x = x - step; y = y + 0; }
            if (xf == -1 && yf == 1) { x = x - step; y = y + step; }
            ////
            if (xf == 1 && yf == -1) { x = x + step; y = y - step; }
            if (xf == 0 && yf == -1) { x = x + 0; y = y - step; }
            if (xf == -1 && yf == -1) { x = x - step; y = y - step; }

        }

        void Rand(int t)
        {
            if (1 == t)
            {
              
                int value = rnd.Next(1, 4);
                if (value == 1) { xf = 1; yf = 1; }
                if (value == 2) { xf = 1; yf = 0; }
                if (value == 3) { xf = 1; yf = -1; }
            }

            if (2 == t)
            {
              
                int value = rnd.Next(1, 4);
                if (value == 1) { xf = -1; yf = 1; }
                if (value == 2) { xf = 0; yf = 1; }
                if (value == 3) { xf = 1; yf = 1; }
            }

            if (3 == t)
            {
               
                int value = rnd.Next(1, 4);
                if (value == 1) { xf = -1; yf = -1; }
                if (value == 2) { xf = -1; yf = 0; }
                if (value == 3) { xf = -1; yf = 1; }
            }
            if (4 == t)
            {
               
                int value = rnd.Next(1, 4);
                if (value == 1) { xf = 1; yf = -1; }
                if (value == 2) { xf = 0; yf = -1; }
                if (value == 3) { xf = -1; yf = -1; }
            }

        }

        public void color_(int c, int c2)
        {
            int dd = c - c2;

            dl = dd / (c / 100);

            int value = rnd2.Next(1, 3);
 
            if (value == 1) 
            {
               int value2 = 40;

                if (dl < 0) value2 = rnd2.Next(dl, 100 + dl);
                if (dl > 0) value2 = rnd2.Next(dl, 100 + dl);
                if (dl == 0) value2 = rnd2.Next(0, 100);
                if (value2 >= 66) color = 1;
                if (value2 <= 33) color = 3;
                if (value2 >= 33 && value2 <= 66) color = 2;
            }
        }

        public int creat_clear(int x2,int y2, int cl2)
        {
          //  int dia = 2;

            if (x == x2 && y == y2)
            {
                if (color == 3 && cl2 == 3) {return 3; }
            }
          


            if (x  == x2 && y == y2)
            {
                if (color == 1 && cl2 == 1) { return 1; }
            }

            return 0;
        }
    }
}
