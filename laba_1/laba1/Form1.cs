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

namespace laba1
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch = new Stopwatch();
        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
        }

        public void AlgorithmCDADrawLine(int x1,int y1,int x2,int y2, PictureBox b)
        {
            graphics = b.CreateGraphics();

            stopwatch.Reset();
            stopwatch.Start();
            int l;

            if (Math.Abs(x2 - x1) >= Math.Abs(y2 - y1))
            {
                l = Math.Abs(x2 - x1);
            }
            else
            {
                l = Math.Abs(y2 - y1);
            }

            int del_x = 1;
            int del_y = 1;

            double x = x1 + 0.5 * Math.Sign(del_x);
            double y = y1 + 0.5 * Math.Sign(del_y);

            int i = 1;

            while (i <= l)
            {
                graphics.FillRectangle(new SolidBrush(Color.Blue), Convert.ToInt32(x), Convert.ToInt32(y), 1, 1);
                x += del_x;
                y += del_y;
                i++;
            }
            stopwatch.Stop();
            CDA.Text = "Час: " + stopwatch.Elapsed.TotalMilliseconds.ToString();
        }



        public void BresenhamDrawLine(int x1, int y1, int x2, int y2, PictureBox b)
        {
            stopwatch.Reset();
            stopwatch.Start();

            graphics = b.CreateGraphics();

            int x = x1;
            int y = y1;

            int p1 = Math.Abs(x2 - x1);
            int p2 = Math.Abs(y2 - y1);

            int s1 = Math.Sign(x2 - x1);
            int s2 = Math.Sign(x2 - x1);

            int e = 2 * p2 - p1;

            bool flag = false;

            if (p2 > p1)
            {
                int temp = p1;
                p1 = p2;
                p2 = temp;
                flag = true;
            }

            for (int i = 0; i <= p1; ++i)
            {
                while (e >= 0)
                {
                    if (flag)
                    {
                        x += s1;
                    }
                    else
                    {
                        y += s2;
                    }
                    e -= 2 * p1;
                }
                if (flag)
                {
                    y += s2;
                }
                else
                {
                    x += s1;
                }
                e += 2 * p2;
                graphics.FillRectangle(new SolidBrush(Color.Green), x, y, 1, 1);
            }

            stopwatch.Stop();
            Brez.Text = "Час: " + stopwatch.Elapsed.TotalMilliseconds.ToString();
        }


        public void LibraryDrawLine(int x1, int y1, int x2, int y2, PictureBox b)
        {

            graphics = b.CreateGraphics();

            stopwatch.Reset();
            stopwatch.Start();

            Pen pen = new Pen(Color.Blue);
            graphics.DrawLine(pen, x1, y1, x2, y2);

            stopwatch.Stop();
            my.Text = "Час: " + stopwatch.Elapsed.TotalMilliseconds.ToString();
        }









        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(x1_text.Text) == true || string.IsNullOrEmpty(y1_text.Text) || string.IsNullOrEmpty(x2_text.Text) || string.IsNullOrEmpty(y2_text.Text))
            {
                MessageBox.Show("Ви не ввели координати!");
            }
            else
            {
                BresenhamDrawLine(int.Parse(x1_text.Text), int.Parse(y1_text.Text), int.Parse(x2_text.Text), int.Parse(y2_text.Text), pictureBox3);
                AlgorithmCDADrawLine(int.Parse(x1_text.Text), int.Parse(y1_text.Text), int.Parse(x2_text.Text), int.Parse(y2_text.Text), pictureBox2);
                LibraryDrawLine(int.Parse(x1_text.Text), int.Parse(y1_text.Text), int.Parse(x2_text.Text), int.Parse(y2_text.Text), pictureBox1);
            }



        }
    }
}
