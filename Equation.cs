using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Modelowanie
{
    internal class Equation
    {
        public double[] ComponentList;

        public Equation() { }

        public void GetLinear(Point p1, Point p2)
        {
            this.ComponentList = new double[2];
            this.ComponentList[0] = (p1.Y - p2.Y)/(p1.X-p2.X);
            this.ComponentList[1] = p1.Y - p1.X * this.ComponentList[0];
        }
    }
}
