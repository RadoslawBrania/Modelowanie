using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Modelowanie
{
    public partial class Form1 : Form
    {
        MyLine line = new(new MyPoint(-20, 40), new MyPoint(20, 80));
        MyPoint point = new(80,10);
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
            g.FillEllipse(brush, ClientSize.Width/2+(int)point.X, ClientSize.Height/2-(int)point.Y, 5, 5);
            MyLine b = line.Perpendicular(point);
           
            Form1_DrawLine(g, b.start.Makepoint(), b.end.Makepoint());
            MyPoint p1 = Equation.FindIntersection(line,b);
            label1.Text += " distance: " + line.eq.FindClosestPoint(point) ;
            label1.Text += " position: " + line.WherePoint(point) ;
            label1.Text += " Czy Nale¿y: " + line.PointBelongs(point) ;
            g.FillEllipse(brush, ClientSize.Width / 2 + (int)p1.X, ClientSize.Height / 2 - (int)p1.Y, 7, 7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Przesun o wektor 40, 60";
            line.MoveByVector(40, 60);  
            Graphics g = CreateGraphics();
            Form1_DrawLine(g, line.start.Makepoint(), line.end.Makepoint());
           
            

        }
    }
}
