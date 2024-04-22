using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Modelowanie
{
    public partial class Form1 : Form
    {
        MyLine line = new(new MyPoint(-20, 40), new MyPoint(20, 80));
        MyPoint point = new(80, 10);
        Equation a = new();

        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_DrawAxis);
            this.Resize += new EventHandler(Form1_Resize);
        }
        private void Form1_DrawAxis(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black, new Point(0, this.ClientSize.Height / 2), new Point(this.ClientSize.Width, this.ClientSize.Height / 2));
            g.DrawLine(Pens.Black, new Point(this.ClientSize.Width / 2, 0), new Point(this.ClientSize.Width / 2, this.ClientSize.Height));
        }
        private void Form1_DrawLine(Graphics g, Point a, Point b)
        {
            g.DrawLine(Pens.Black, new Point(this.ClientSize.Width / 2 + a.X, this.ClientSize.Height / 2 - a.Y), new Point(this.ClientSize.Width / 2 + b.X, this.ClientSize.Height / 2 - b.Y));
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = a.EquationOfLine(line);

            Graphics g = CreateGraphics();
            Form1_DrawLine(g, line.start.Makepoint(), line.end.Makepoint());
            Brush brush = Brushes.Red;
            g.FillEllipse(brush, ClientSize.Width / 2 + (int)point.X, ClientSize.Height / 2 - (int)point.Y, 5, 5);
            MyLine b = line.Perpendicular(point);

            Form1_DrawLine(g, b.start.Makepoint(), b.end.Makepoint());
            MyPoint p1 = Equation.FindIntersection(line, b);
            label1.Text += " distance: " + line.eq.FindClosestPoint(point);
            label1.Text += " position: " + line.WherePoint(point);
            label1.Text += " Czy Nale¿y: " + line.PointBelongs(point);
            g.FillEllipse(brush, ClientSize.Width / 2 + (int)p1.X, ClientSize.Height / 2 - (int)p1.Y, 3, 3);
            MyPoint p2 = Equation.MirrorByLine(line, b, point);
            g.FillEllipse(brush, ClientSize.Width / 2 + (int)p2.X, ClientSize.Height / 2 - (int)p2.Y, 5, 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Przesun o wektor 40, 60";
            line.MoveByVector(40, 60);
            Graphics g = CreateGraphics();
            Form1_DrawLine(g, line.start.Makepoint(), line.end.Makepoint());

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            // 190*190/2 = 18050 area good 
            MyTriangle triangle = new(new MyPoint(10, 10), new MyPoint(10, 200), new MyPoint(200, 10));
            MyTriangle triangle2 = Equation.MakeTriangle(new Equation(1, 10), new Equation(-1, 100), new Equation(2, 200));
            MyPoint p1 = new(20, 40);

            MyTriangle[] triangles = [new(triangle.Points[0], triangle.Points[1], p1), new(triangle.Points[1], triangle.Points[2], p1), new(triangle.Points[2], triangle.Points[0], p1)];

            //Form1_DrawLine(g, triangles[2].Lines[1].start.Makepoint(), triangles[2].Lines[1].end.Makepoint());
            //Form1_DrawLine(g, triangles[2].Lines[2].start.Makepoint(), triangles[2].Lines[2].end.Makepoint());
            Form1_DrawLine(g, triangles[1].Lines[1].start.Makepoint(), triangles[1].Lines[1].end.Makepoint());
            Form1_DrawLine(g, triangles[1].Lines[2].start.Makepoint(), triangles[1].Lines[2].end.Makepoint());
            //Form1_DrawLine(g, triangles[0].Lines[1].start.Makepoint(), triangles[0].Lines[1].end.Makepoint());
            //Form1_DrawLine(g, triangles[0].Lines[2].start.Makepoint(), triangles[0].Lines[2].end.Makepoint());


            g.FillEllipse(Brushes.Black, ClientSize.Width / 2 + (int)p1.X, ClientSize.Height / 2 - (int)p1.Y, 5, 5);
            foreach (MyLine line in triangle2.Lines)
            {
                Form1_DrawLine(g, line.start.Makepoint(), line.end.Makepoint());
            }
            foreach (MyLine line in triangle.Lines)
            {
                Form1_DrawLine(g, line.start.Makepoint(), line.end.Makepoint());
            }
            //label2.Text = "" + triangle.calculateArea() + "   " + Math.Acos((-triangle.Lines[1].eq.ComponentList[1] * -triangle.Lines[2].eq.ComponentList[1] + 1) / (Math.Sqrt(Math.Pow(-triangle.Lines[1].eq.ComponentList[1], 2) + 1) * Math.Sqrt(Math.Pow(-triangle.Lines[2].eq.ComponentList[1], 2) + 1)));
            label2.Text = "" + triangle.calculateArea() + "  " + triangle.isInsideTriangle2(p1) + Equation.GetAngle(triangles[0].Lines[1], triangles[0].Lines[2]) + "   " + triangles[0].Lines[1].eq.ComponentList[1];
            //label2.Text = "" + triangle.calculateArea() + "" + Math.Atan2(-triangle.Lines[1].eq.ComponentList[1] + triangle.Lines[2].eq.ComponentList[1], triangle.Lines[1].eq.ComponentList[1]*triangle.Lines[2].eq.ComponentList[1]+1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Random r = new(); double a = r.Next() % 1000; double b = r.Next() % 1000; double c = r.Next() % 1000; double d = r.Next() % 1000; c *= -1;
            MyLine line1 = new(new MyPoint(d, a), new MyPoint(800, b));
            MyLine line2 = new(new MyPoint(d, a), new MyPoint(800, c));
            Form1_DrawLine(g, line1.start.Makepoint(), line1.end.Makepoint());
            Form1_DrawLine(g, line2.start.Makepoint(), line2.end.Makepoint());
            label3.Text = "Angle(rad): " + Math.Acos((line1.eq.ComponentList[1] * line2.eq.ComponentList[1] + 1) / Math.Sqrt(Math.Pow(line1.eq.ComponentList[1], 2) + 1) / Math.Sqrt(Math.Pow(line2.eq.ComponentList[1], 2) + 1));

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            MyPoint[] pointsArray = {
            new MyPoint(10, 10),
            new MyPoint(60, 0),
            new MyPoint(90, 50),
            new MyPoint(30, 100),
            new MyPoint(-30, 50),
            new MyPoint(11, 10)
        };
            MyPoint a = new(50, 50);
            g.FillEllipse(Brushes.Black, ClientSize.Width / 2 + (int)a.X, ClientSize.Height / 2 - (int)a.Y, 5, 5);

            MyLine line1 = new(new(0,0), new(200,200));

            Form1_DrawLine(g, line1.start.Makepoint(), line1.end.Makepoint());
            Polygon polygon = new Polygon(pointsArray);
            foreach(MyLine line in polygon.Lines)
            {
                Form1_DrawLine(g, line.start.Makepoint(), line.end.Makepoint());
            }
            label4.Text=""+polygon.IsPointInside(a,line1);
        }
    }
}
