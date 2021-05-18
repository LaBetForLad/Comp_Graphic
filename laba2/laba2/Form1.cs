using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private Stopwatch stopwatch = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        public void LibraryMethod(int x, int y, int radius, PictureBox box)
        {
            stopwatch.Reset();
            stopwatch.Start();

            graphics = box.CreateGraphics();
            graphics.DrawEllipse(new Pen(Color.Red), new Rectangle(x, y,radius*2,radius*2));

            stopwatch.Stop();
            lib.Text = "Час: " + stopwatch.Elapsed.TotalMilliseconds.ToString();
        }



        public void AlgorithmBresenhamCircle(int x, int y, int radius, PictureBox box)
        {
            stopwatch.Reset();
            stopwatch.Start();

            graphics = box.CreateGraphics();
            int _x = 0, _y = radius, gap = 0, delta = 2 - 2 * radius;

            while (_y >= 0)
            {
                graphics.FillRectangle(new SolidBrush(Color.Blue), _x + x,  y + _y, 1, 1);
                graphics.FillRectangle(new SolidBrush(Color.Blue), _x + x,  y - _y, 1, 1);
                graphics.FillRectangle(new SolidBrush(Color.Blue),  x - _x, y - _y, 1, 1);
                graphics.FillRectangle(new SolidBrush(Color.Blue),  x - _x, y + _y, 1, 1);

                gap = 2 * (delta + _y) - 1;

                if (delta < 0 && gap <= 0)
                {
                    _x++;
                    delta += 2 * _x + 1;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    _y--;
                    delta -= 2 * _y + 1;
                    continue;
                }
                _x++;
                delta += 2 * (_x - _y);
                _y--;

            }

            stopwatch.Stop();
            CDA.Text = "Час: " + stopwatch.Elapsed.TotalMilliseconds.ToString();
        }


        private void MyAlgorithm(int x, int y, int radius, PictureBox box)
        {
            stopwatch.Reset();
            stopwatch.Start();

            graphics = box.CreateGraphics();
         

            for (int i = 0; i < 360; i++)
            {
                double x_ = x + Math.Round(radius * Math.Cos(i * Math.PI / 180));
                double y_ = x - Math.Round(radius * Math.Sin(i * Math.PI / 180));

               graphics.FillRectangle(Brushes.Black, (float)x_, (float)y_, 1, 1);

            }
         

            stopwatch.Stop();
            MY.Text = "Час: " + stopwatch.Elapsed.TotalMilliseconds.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_x.Text) == true || string.IsNullOrEmpty(text_y.Text) || string.IsNullOrEmpty(text_raduis.Text) )
            {
                MessageBox.Show("Ви не ввели координати!");
            }

            else
            {
                AlgorithmBresenhamCircle(int.Parse(text_x.Text), int.Parse(text_y.Text), int.Parse(text_raduis.Text), pictureBox1);
                MyAlgorithm(int.Parse(text_x.Text), int.Parse(text_y.Text), int.Parse(text_raduis.Text), pictureBox2);
                LibraryMethod(int.Parse(text_x.Text), int.Parse(text_y.Text), int.Parse(text_raduis.Text), pictureBox3);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
