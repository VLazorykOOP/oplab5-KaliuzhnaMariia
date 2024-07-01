using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btndraw_Click_1(object sender, EventArgs e)
        {
            float X1 = float.Parse(textBox1.Text);
            float Y1 = float.Parse(textBox2.Text);
            float X2 = float.Parse(textBox3.Text);
            float Y2 = float.Parse(textBox4.Text);
            float Vx1 = float.Parse(textBox5.Text);
            float Vy1 = float.Parse(textBox6.Text);
            float Vx2 = float.Parse(textBox7.Text);
            float Vy2 = float.Parse(textBox8.Text);

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            Pen thickBlackPen = new Pen(Color.Black, 2);
            Pen thickGreenPen = new Pen(Color.Red, 2);

            PointF Hermite(float t)
            {
                float h1 = 2 * t * t * t - 3 * t * t + 1;
                float h2 = -2 * t * t * t + 3 * t * t;
                float h3 = t * t * t - 2 * t * t + t;
                float h4 = t * t * t - t * t;
                float x = h1 * X1 + h2 * X2 + h3 * Vx1 + h4 * Vx2;
                float y = h1 * Y1 + h2 * Y2 + h3 * Vy1 + h4 * Vy2;
                return new PointF(x, y);
            }

            int numPoints = 100;
            PointF[] points = new PointF[numPoints];
            for (int i = 0; i < numPoints; i++)
            {
                float t = (float)i / (numPoints - 1);
                points[i] = Hermite(t);
            }

            g.DrawCurve(thickBlackPen, points);

            g.DrawLine(thickGreenPen, X1, Y1, X1 + Vx1, Y1 + Vy1);
            g.DrawLine(thickGreenPen, X2, Y2, X2 + Vx2, Y2 + Vy2);

            g.DrawLine(thickGreenPen, new PointF(X1, Y1), points[0]);
            g.DrawLine(thickGreenPen, new PointF(X2, Y2), points[numPoints - 1]);

            pictureBox1.Image = bmp;
        }
    }
}
