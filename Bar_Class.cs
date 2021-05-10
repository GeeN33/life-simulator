using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_live
{
    class Bar_Class
    {
        public string Data;
        public double open = 0;


        public Bar_Class(double open)
        {

            this.open = open;
           

        }


        public void point(ref float open_, int Height, double max, double min)
        {

            open_ = (float)(Height - (open - min) * (Height / (max - min)));

        }

      
    }
}

