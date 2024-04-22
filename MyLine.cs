using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelowanie
{
    internal class MyLine(MyPoint a, MyPoint b)
    {
        public MyPoint start = a;
        public MyPoint end = b;
        public Equation eq = new(a,b);
        


        public void GetEquation()
        {
            eq = new Equation(this);
        }

        public void MoveByVector (int  x, int y) 
        {
            start.X += x;
            end.X += x;
            start.Y += y;
            end.Y += y;
        }
        public MyLine Perpendicular(MyPoint crosses)
        {
            GetEquation();
            double b = -eq.ComponentList[1] * crosses.X - crosses.Y;
            int point1 = (int)(-eq.ComponentList[1]*-100-b);
            int point2 = (int)(-eq.ComponentList[1]*100-b);
            return new MyLine(new MyPoint(-100, point1), new MyPoint(100, point2));
        }
        public string WherePoint(MyPoint point)
        {
            if (eq.ComponentList[1] * point.X + eq.ComponentList[0] < point.Y)
            {
                return "lewo";
            }
            return "prawo";
        }
        public int Left(MyPoint point)
        {
            return (b.X - a.X) * (point.Y - a.Y) - (b.Y - a.Y) * (point.X - a.X) > 0 ? 1 : -1;
        }
        public string PointBelongs(MyPoint point)
        {
            if (Math.Abs(eq.ComponentList[1] * point.X + eq.ComponentList[0] - point.Y) < 0.01)
            {
                return " Należy do odcinka";
            }
            return " Nie należy do odcinka";
        }
        public bool PointBelongsBool(MyPoint point)
        {
            if (Math.Abs(eq.ComponentList[1] * point.X + eq.ComponentList[0] - point.Y) < 0.01)
            {
                return true;
            }
            return false;
        }
    }
}
