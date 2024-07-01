using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form2 : Form
    {
        private Random random = new Random();
        private int K = 10;

        public Form2()
        {
            InitializeComponent();
        }

        
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            for (int i = 0; i < 5; i++)
            {
                int x1 = random.Next(pictureBox1.Width);
                int y1 = random.Next(pictureBox1.Height);
                int x2 = random.Next(pictureBox1.Width);
                int y2 = random.Next(pictureBox1.Height);
                DrawFractal(g, x1, y1, x2, y2, K);
            }

            pictureBox1.Image = bitmap;
        }

        private void DrawFractal(Graphics g, int x1, int y1, int x2, int y2, int depth)
        {
            if (depth > 0)
            {
                int xn = (x1 + x2) / 2 + (y2 - y1) / 2;
                int yn = (y1 + y2) / 2 - (x2 - x1) / 2;

                DrawFractal(g, x2, y2, xn, yn, depth - 1);
                DrawFractal(g, x1, y1, xn, yn, depth - 1);
            }
            else
            {
                g.DrawLine(new Pen(GetRandomBlueColor(), 1), x1, y1, x2, y2);
                FillArea(g, x1, y1, x2, y2);
            }
        }

        private Color GetRandomBlueColor()
        {
            int blueShade = random.Next(100, 256);
            return Color.FromArgb(blueShade, blueShade, 255);
        }

        private void FillArea(Graphics g, int x1, int y1, int x2, int y2)
        {
            Brush brush = new SolidBrush(GetRandomBlueColor());
            Point[] points = {
                new Point(x1, y1),
                new Point(x2, y2),
                new Point(x2 + 5, y2 + 5),
                new Point(x1 + 5, y1 + 5)
            };

            g.FillPolygon(brush, points);
        }
    }
}
