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

namespace laba3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Graphics graphics;
        private Stopwatch stopwatch = new Stopwatch();

        PointF A;
        PointF B;
        PointF C;
        PointF D;


        public void AlgorithmDrawingOfRectangle(int ax, int ay, int bx, int by, int cx, int cy, PictureBox picture)
        {
            stopwatch.Reset();
            stopwatch.Start();
            graphics = picture.CreateGraphics();

            A = new PointF(ax,ay);
            B = new PointF(bx,by);
            C = new PointF(cx,cy);


            float x1, x2;
          

            for (float sy = A.Y; sy < C.Y; ++sy)
            {
                x1 = A.X + (sy - A.Y) * (C.X - A.X) / (C.Y - A.Y);

                if (sy < B.Y)
                {
                    x2 = A.X + (sy - A.Y) * (B.X - A.X) / (B.Y - A.Y);
                }
                else
                {
                    if (C.Y == B.Y)
                    {
                        x2 = B.X;
                    }
                    else
                    {
                        x2 = B.X + (sy - B.Y) * (C.X - B.X) / (C.Y - B.Y);
                    }

                }

                if (x1 > x2)
                {
                    float tmp = x1;
                    x1 = x2; x2 = tmp;
                }

                graphics.DrawLine(new Pen(Color.Green), x1, sy, x2, sy);
            }

            stopwatch.Stop();
            label11.Text = "Час: " + stopwatch.Elapsed.TotalMilliseconds.ToString();
        }


        public void AlgorithmDrawingAnoutherCollorOf(int ax, int ay, int bx, int by, int cx, int cy, PictureBox picture,Pen p)
        {
            graphics = picture.CreateGraphics();

            A = new PointF(ax, ay);
            B = new PointF(bx, by);
            C = new PointF(cx, cy);

            
           
            float x1, x2;
            
            for (float sy = A.Y; sy < C.Y; ++sy)
            {
                x1 = A.X + (sy - A.Y) * (C.X - A.X) / (C.Y - A.Y);

                if (sy < B.Y)
                {
                    x2 = A.X + (sy - A.Y) * (B.X - A.X) / (B.Y - A.Y);
                }
                else
                {
                    if (C.Y == B.Y)
                    {
                        x2 = B.X;
                    }
                    else
                    {
                        x2 = B.X + (sy - B.Y) * (C.X - B.X) / (C.Y - B.Y);
                    }

                }

                if (x1 > x2)
                {
                    float tmp = x1;
                    x1 = x2; x2 = tmp;
                }
           
                graphics.DrawLine(p, x1, sy, x2, sy);
            }
        }


        public void SearchPoint(int dx,int dy)
        {
            D = new PointF(dx,dy);
           


            if (D.X > 996 || D.X < 0 || D.Y > 426 || D.Y < 0)
            {
                MessageBox.Show("Точка не може знаходиться за межами границь!");
            }
            else
            {
                bool res = false;


                float a = (A.X - D.X) * (B.Y - A.Y) - (B.X - A.X) * (A.Y - D.Y);
                float b = (B.X - D.X) * (C.Y - B.Y) - (C.X - B.X) * (B.Y - D.Y);
                float c = (C.X - D.X) * (A.Y - C.Y) - (A.X - C.X) * (C.Y - D.Y);

                if ((a <= 0 && b <= 0 && c <= 0) || (a >= 0 && b >= 0 && c >= 0))
                {
                    res = true;
                }


                if (res == true)
                {
                    label10.Text = "true";
                }
                else
                {
                    label10.Text = "false";
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(text_Ax.Text) == true || 
                string.IsNullOrEmpty(text_Ay.Text) || 
                string.IsNullOrEmpty(text_Bx.Text) ||
                string.IsNullOrEmpty(text_By.Text) ||
                string.IsNullOrEmpty(text_Cx.Text) ||
                string.IsNullOrEmpty(text_Cy.Text))               
            {
                MessageBox.Show("Ви не ввели координати!");
            }

            else
            {
                AlgorithmDrawingOfRectangle(int.Parse(text_Ax.Text), int.Parse(text_Ay.Text),
                                          int.Parse(text_Bx.Text), int.Parse(text_By.Text),
                                          int.Parse(text_Cx.Text), int.Parse(text_Cy.Text), pictureBox1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (new Random().Next(1, 4))
            {

                case 1:
                    AlgorithmDrawingAnoutherCollorOf(int.Parse(text_Ax.Text), int.Parse(text_Ay.Text),
                                         int.Parse(text_Bx.Text), int.Parse(text_By.Text),
                                          int.Parse(text_Cx.Text), int.Parse(text_Cy.Text), pictureBox1, new Pen(Color.Red));
                    break;

                case 2:
                    AlgorithmDrawingAnoutherCollorOf(int.Parse(text_Ax.Text), int.Parse(text_Ay.Text),
                                      int.Parse(text_Bx.Text), int.Parse(text_By.Text),
                                       int.Parse(text_Cx.Text), int.Parse(text_Cy.Text), pictureBox1, new Pen(Color.Yellow));
                    break;

                case 3:
                    AlgorithmDrawingAnoutherCollorOf(int.Parse(text_Ax.Text), int.Parse(text_Ay.Text),
                                       int.Parse(text_Bx.Text), int.Parse(text_By.Text),
                                        int.Parse(text_Cx.Text), int.Parse(text_Cy.Text), pictureBox1, new Pen(Color.Black));
                    break;
            }
      
        }






        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(text_Dx.Text) == true ||
                string.IsNullOrEmpty(text_Dy.Text))
            {
                MessageBox.Show("Ви не ввели координати!");
            }
            else
            {
                SearchPoint(int.Parse(text_Dx.Text), int.Parse(text_Dy.Text));
            }
        }
    }
}
