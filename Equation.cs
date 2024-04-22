using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelowanie
{
    internal class Equation
    {
        public double[] ComponentList;

        public Equation() { }
        public Equation(double a,double b) {
            ComponentList = new double[2];
            ComponentList = [b,a];
        }
        public Equation(MyLine line) {

                double A = line.end.Y - line.start.Y;
                double B = line.start.X - line.end.X;
                double C = line.start.Y * (line.end.X - line.start.X) - line.start.X * (line.end.Y - line.start.Y);
                ComponentList = new double[2];

                ComponentList[1] = -A / B;

                ComponentList[0] = -C / B;

            }
        public Equation(MyPoint p1, MyPoint p2)
        {

            double A = p2.Y - p1.Y;
            double B = p1.X - p2.X;
            double C = p1.Y * (p2.X - p1.X) - p1.X * (p2.Y - p1.Y);
            ComponentList = new double[2];

            ComponentList[1] = -A / B;

            ComponentList[0] = -C / B;

        }

        public string EquationOfLine(MyLine line)
        {
            double A = line.end.Y - line.start.Y;
            double B = line.start.X - line.end.X;
            double C = line.start.Y * (line.end.X - line.start.X) - line.start.X * (line.end.Y - line.start.Y);
            ComponentList = new double [2];

            ComponentList[1] = - A / B;

            ComponentList[0] = - C / B;

            Console.WriteLine($"Równanie prostej w postaci y = ax + b: y = {ComponentList[1]}x + {ComponentList[0]}");

            return ($"Uproszone równanie prostej: y = {ComponentList[1]} x +  {ComponentList[0]}");
        }

        public double FindClosestPoint(MyPoint point)
        {

            double distance = Math.Abs(ComponentList[1] * point.X + point.Y + ComponentList[0]) / Math.Sqrt(ComponentList[1] * ComponentList[1] + 1);
            return distance;
        }
        public static MyPoint FindIntersection(MyLine a, MyLine b)
        {
            Equation line1 = new();
            Equation line2 = new();
            line1.EquationOfLine(a);
            line2.EquationOfLine(b);
            double x = (line2.ComponentList[0] - line1.ComponentList[0]) / (line1.ComponentList[1] - line2.ComponentList[1]);
            double y = line1.ComponentList[1] * x + line1.ComponentList[0];

            return new MyPoint(x, y);
        }
        public static MyPoint FindIntersection(Equation line1, Equation line2)
        {
            double x = (line2.ComponentList[0] - line1.ComponentList[0]) / (line1.ComponentList[1] - line2.ComponentList[1]);
            double y = line1.ComponentList[1] * x + line1.ComponentList[0];

            return new MyPoint(x, y);
        }


        public static MyPoint MirrorByLine(MyLine a, MyLine b, MyPoint point)
        {
            MyPoint mid = FindIntersection( a,  b);
            return new MyPoint(mid.X+(Math.Abs(mid.X)-Math.Abs(point.X)), mid.Y+(Math.Abs(mid.Y) - Math.Abs(point.Y)));
        }

        public Point ReflectPoint(Point point)
        {

            double x1 = (point.X * (1 - ComponentList[1] * ComponentList[1]) - 2 * ComponentList[1] * (point.Y - ComponentList[0])) / (1 + ComponentList[1] * ComponentList[1]);
            double y1 = (point.Y * (1 + ComponentList[1] * ComponentList[1]) - 2 * ComponentList[0] * ComponentList[1] - ComponentList[0]) / (1 + ComponentList[1] * ComponentList[1]);

            int x = ((int)x1);
            int y = ((int)y1);

            return new Point(1000,500);
        }

        public static MyTriangle MakeTriangle(Equation eq1, Equation eq2, Equation eq3) {
            MyPoint[] point = [Equation.FindIntersection(eq1, eq2), Equation.FindIntersection(eq2, eq3), Equation.FindIntersection(eq3, eq1)];
            MyTriangle triangle = new (point[0], point[1], point[2]);
            return triangle;
        }
        public static double GetAngle(MyLine line1, MyLine line2)
        {
            // return Math.Atan2(-line1.eq.ComponentList[1] + line2.eq.ComponentList[1], line1.eq.ComponentList[1] * line2.eq.ComponentList[1] + 1);
            //return line2.eq.ComponentList[1];
            return Math.Acos((line1.eq.ComponentList[1] * line2.eq.ComponentList[1] + 1) / (Math.Sqrt(Math.Pow(line1.eq.ComponentList[1], 2) + 1) * Math.Sqrt(Math.Pow(line2.eq.ComponentList[1], 2) + 1)));
        }
    }
}
