using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace Modelowanie
{
    internal class MyTriangle(MyPoint p1, MyPoint p2, MyPoint p3)
    {
        public MyPoint[] Points = [p1, p2, p3];
        public MyLine[] Lines = [new MyLine(p1,p2), new MyLine(p2, p3), new MyLine(p3, p1)];


        public double calculateArea()
        {
            double l1 = Math.Sqrt(Math.Pow((p1.X - p2.X),2) + Math.Pow((p1.Y - p2.Y),2));
            double l2 = Math.Sqrt(Math.Pow((p1.X - p3.X),2) + Math.Pow((p1.Y - p3.Y),2));
            double l3 = Math.Sqrt(Math.Pow((p2.X - p3.X),2) + Math.Pow((p2.Y - p3.Y),2));
            double p = (l1 + l2 + l3) / 2;
            
            return Math.Sqrt(p*(p-l1)*(p-l2)*(p-l3));
        }
        
        public bool isInsideTriangle1(MyPoint point)
        {
            MyTriangle[] triangles = [new(p1,p2,point), new(p2, p3, point), new(p3, p1, point)];
            double sum = 0;
            double area = this.calculateArea();
            foreach (MyTriangle triangle in triangles)
            {
                sum += triangle.calculateArea();
                
                //sum+=Math.Abs(Math.Atan2(-triangle.Lines[1].eq.ComponentList[1] + triangle.Lines[2].eq.ComponentList[1], triangle.Lines[1].eq.ComponentList[1] * triangle.Lines[2].eq.ComponentList[1] + 1));
            }
            if(sum<area+1 && sum > area-1)
            {
                return true;
            }
            return false;
        }
        public bool isInsideTriangle2(MyPoint point)
        {
            int check = 2;
            foreach(var line in Lines)
            {
                if (check == 2) check = line.Left(point);
                if (check != line.Left(point)) return false;
            }
            return true;
        }
    }
}
