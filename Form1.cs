using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sim_live
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Bar_Class> Bar = new List<Bar_Class>();
        List<Pulsar_Class> Pulsar = new List<Pulsar_Class>();
        int ch_cr = 0;
        int ch_cl = 0;
        DateTime date;
        DateTime date2;
        bool f = false;

        int Count = 500;


        public void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graph = Graphics.FromImage(bmp);
            int Width = pictureBox1.Width;
            int Height = pictureBox1.Height;

            for (int i = 0; i < Pulsar.Count; i++)
            {

                if (Pulsar[i].color == 1) graph.DrawEllipse(new Pen(Color.Green, 5), Pulsar[i].x, Pulsar[i].y, 5, 5);
                if (Pulsar[i].color == 2) graph.DrawEllipse(new Pen(Color.Yellow, 5), Pulsar[i].x, Pulsar[i].y, 5, 5);
                if (Pulsar[i].color == 3) graph.DrawEllipse(new Pen(Color.Red, 5), Pulsar[i].x, Pulsar[i].y, 5, 5);
                if (Pulsar[i].color == 4) graph.DrawEllipse(new Pen(Color.Black, 5), Pulsar[i].x, Pulsar[i].y, 5, 5);
               if (Pulsar[i].color == 5) graph.DrawEllipse(new Pen(Color.Pink, 5), Pulsar[i].x, Pulsar[i].y, 5, 5);

            }

            pictureBox1.Image = bmp;

        }

        public void Draw_Bar2()
        {
            
                Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                Graphics graph = Graphics.FromImage(bmp);

                int Width = pictureBox2.Width;
                int Height = pictureBox2.Height - 20;
              
                int j = 0;
                if (Bar.Count > 0)
                {

                int size = (Width - 100) / Bar.Count;
                double max = Bar[0].open;
                double min = Bar[0].open;
                float y = 0;





                for (int i = 0; i < Bar.Count; i++)
                {
                    if (Bar[i].open > max && Bar[i].open != 0) { max = Bar[i].open; }
                    if (Bar[i].open < min && Bar[i].open != 0) { min = Bar[i].open; }
                }


                if (max == min) return;


                for (int i = 0; i < Bar.Count; i++)
                {

                    j = j + size;


                    Bar[i].point(ref y, Height, max, min);

                    graph.DrawLine(new Pen(Color.Green, size - 3), j, y, j, Height);

                    if (Bar.Count - 1 == i) // тик цены на графеке 
                    {
                        Bar[i].point(ref y, Height, max, min);

                        graph.DrawLine(new Pen(Color.AntiqueWhite, 1), j + (size - 3), y, Width - 40, y);

                        graph.DrawLine(new Pen(Color.White, 20), Width - 100, y + 6, Width - 40, y + 6);

                        graph.DrawString(Pulsar.Count.ToString("#.#0"), new Font("Tahoma", 8, FontStyle.Regular), Brushes.Black, new PointF(Width - 100, y));

                        graph.DrawString(max.ToString("#.#0"), new Font("Tahoma", 8, FontStyle.Regular), Brushes.Black, new PointF(0, 0));
                        graph.DrawString(min.ToString("#.#0"), new Font("Tahoma", 8, FontStyle.Regular), Brushes.Black, new PointF(0, Height + 6));

                    }


                }


                }
        

            #region // отрисовка  рамка 

            graph.DrawLine(new Pen(Color.Black, 2), 0, 0, 0, Height + 20);
            graph.DrawLine(new Pen(Color.Black, 2), 0, 0, Width, 0);
            graph.DrawLine(new Pen(Color.Black, 2), 0, Height + 20, Width, Height + 20);
            graph.DrawLine(new Pen(Color.Black, 2), Width, 0, Width, Height + 20);

            #endregion

            pictureBox2.Image = bmp;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "life simulator " + DateTime.Now.ToString();
            DateTime date1 = new DateTime();
            date = date1;

            panel1.Location = new Point(this.Width - 160, 12);

            pictureBox1.Location = new Point(10, 15);
            pictureBox1.Width = (int)(this.Width - 180);
            pictureBox1.Height = (int)(this.Height * 0.90);


            pictureBox2.Location = new Point(36, -200);
            pictureBox2.Width = 1000;
            pictureBox2.Height = 200;

            Draw();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                int x2 = e.X;
                int y2 = e.Y;
              //  label1.Location = new Point(x2, y2);
              //  label1.Text= x2.ToString()+ "  " +y2.ToString();
                Pulsar.Add(new Pulsar_Class(x2,y2, pictureBox1.Width, pictureBox1.Height));
                Draw();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < Pulsar.Count; i++)
            {
                Pulsar[i].route();
               Pulsar[i].move();

                for (int j = 0; j < Pulsar.Count; j++)
                {
                    if (i != j && Pulsar.Count > j && Pulsar.Count > i)
                    { 
                      
                        if (Pulsar[i].creat_clear(Pulsar[j].x, Pulsar[j].y, Pulsar[j].color) == 1)
                        {
                            Pulsar[j].color = 2;
                            Pulsar[i].x = Pulsar[i].x - 15;
                           Pulsar.Add(new Pulsar_Class(Pulsar[j].x + 15, Pulsar[j].y + 15, pictureBox1.Width, pictureBox1.Height));
                            ch_cr++;
                        }

                        if (Pulsar[i].creat_clear(Pulsar[j].x, Pulsar[j].y, Pulsar[j].color) == 3)
                        {
                            Pulsar[i].color = 4;
                            Pulsar[j].color = 4;

                            Pulsar.RemoveAt(i);
                            ch_cl++;

                        }
                    }

                }

            }
            label1.Text ="Общее число: "+ Pulsar.Count.ToString()+ ",  всего родилось: "+ ch_cr.ToString()+ ",  всего умерло: " + ch_cl.ToString()+",  прошло времени: "+ date2.ToString("HH:mm:ss");
            Draw();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
             date = date2;
             date2 =  date.AddSeconds(3);

        

            for (int i = 0; i < Pulsar.Count; i++)
            {
                Pulsar[i].color_(Count, Pulsar.Count);
              
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(button1.Text == "statistic")
           {
                button1.Text = "statistic_";

                pictureBox2.Location = new Point(36, 200);
                pictureBox2.Width = 1000;
                pictureBox2.Height = 200;

                Draw_Bar2();
                f = true;

            }
            else
           {
                button1.Text = "statistic";

                pictureBox2.Location = new Point(36, -200);
                pictureBox2.Width = 1000;
                pictureBox2.Height = 200;

            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(this.Width - 160, 12);

            pictureBox1.Location = new Point(10, 15);
            pictureBox1.Width = (int)(this.Width - 180);
            pictureBox1.Height = (int)(this.Height * 0.90);

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Pulsar.Count > 2 && f) Bar.Add(new Bar_Class(Pulsar.Count));
            f = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Count = Pulsar.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Count = 500;
            Pulsar.Clear();
            Bar.Clear();
            ch_cr = 0;
            ch_cl = 0;

            DateTime date1 = new DateTime();
            date = date1;
            date2 = date1;

        }
    }
}
