using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelowanie
{
    internal class MyTriangle(MyLine l1, MyLine l2, MyLine l3)
    {
        public MyLine[] Lines = [l1, l2, l3];

        public double calculateArea()
        {
            MyPoint p1 = Equation.FindIntersection(Lines[0], Lines[1]);
            MyPoint p2 = Equation.FindIntersection(Lines[0], Lines[2]);
            MyPoint p3 = Equation.FindIntersection(Lines[1], Lines[2]);
            double l1 = Math.Sqrt(Math.Pow((p1.X - p2.X),2) + Math.Pow((p1.Y - p2.Y),2));
            double l2 = Math.Sqrt(Math.Pow((p1.X - p3.X),2) + Math.Pow((p1.Y - p3.Y),2));
            double l3 = Math.Sqrt(Math.Pow((p2.X - p3.X),2) + Math.Pow((p2.Y - p3.Y),2));
            double p = (l1 + l2 + l3) / 2;
            
            return Math.Sqrt(p*(p-l1)*(p-l2)*(p-l3));
        }
    }
}
