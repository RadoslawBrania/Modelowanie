namespace Modelowanie
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_DrawAxis);
            this.Resize += new EventHandler(Form1_Resize);
        }
        private void Form1_DrawAxis(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black, new Point(0, this.ClientSize.Height / 2), new Point(this.ClientSize.Width,this.ClientSize.Height/2));
            g.DrawLine(Pens.Black, new Point(this.ClientSize.Width / 2, 0), new Point(this.ClientSize.Width / 2, this.ClientSize.Height));
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
