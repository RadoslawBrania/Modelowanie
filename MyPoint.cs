using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelowanie
{
    internal class MyPoint(double a,double b)
    {
        public double X=a;
        public double Y=b;
        

        public Point Makepoint()
        {
            return new Point((int)X, (int)Y);
        }
    }
}
