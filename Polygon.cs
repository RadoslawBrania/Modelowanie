using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelowanie
{
    internal class Polygon
    {
        public MyPoint[] Points;
        public MyLine[] Lines;
#pragma warning disable CS8618 // Pole niedopuszczające wartości null musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie pola jako dopuszczającego wartość null.
        public Polygon(MyPoint[] points)
#pragma warning restore CS8618 // Pole niedopuszczające wartości null musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie pola jako dopuszczającego wartość null.
        {
            Points = points;
            Lines = new MyLine[Points.Length]; 
            for(int i=0; i<Points.Length; i++)
            {
                Lines[i] = new(points[i], points[(i+1)%(Points.Length-1)]);
            }
            
        }
        public bool IsPointInside(MyPoint point,MyLine ln)
        {
            int left = 0;
            int right = 0;
            foreach (MyLine myLine in Lines)
            {
                MyPoint p1 = Equation.FindIntersection(ln, myLine);
                if (p1.X > Math.Min(myLine.start.X, myLine.end.X) && p1.X < Math.Max(myLine.start.X,myLine.end.X))
                {
                    if (myLine.PointBelongsBool(p1))
                    {
                        if (myLine.Left(point) == 1) left++;
                        else right++;
                    }
                }
            }
            if(left%2==1 | right%2==1) {
                return true;
            }
            return false;
        }

    }
}
