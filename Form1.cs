using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafic_polinom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float pol(float x)
        {//X^3-2X^2-X+2
            return x * x * x - 2 * x * x - x + 2;
        }

        private float d1(float x)
        {//derivata 1
            return 3 * x * x - 4 * x - 1;
        }

        private float d2(float x)
        {//derivata 2
            return 6 * x  - 4 ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics G = pictureBox1.CreateGraphics();
            G.Clear(Color.White);
            int x = pictureBox1.Width / 2;
            int y = pictureBox1.Height / 2;
            //grid
            Pen pg = new Pen(Color.LightGray);
            for (int i = -50; i <= 50; i++)
                G.DrawLine(pg, x - 30 * i, 0, x - 30 * i, pictureBox1.Height);
            for (int j = -50; j <= 50; j++)
                G.DrawLine(pg, 0, y - 30 * j, pictureBox1.Width, y - 30 * j);
            //axele
            Pen pn = new Pen(Color.Black);
            G.DrawLine(pn, 0, y, pictureBox1.Width, y);
            G.DrawLine(pn, x, 0, x, pictureBox1.Height);
            //graficul polinomului
            Pen pr = new Pen(Color.Red);
            for(float i=-3;i<=3;i=i+(float)0.001)
            {
                G.DrawEllipse(pr, x + i * 30, y - 30*pol(i), 1, 1);
            }
            //graficul primei derivate
            Pen pv = new Pen(Color.Green);
            for (float i = -3; i <= 3; i = i + (float)0.001)
            {
                G.DrawEllipse(pv, x + i * 30, y - 30 * d1(i), 1, 1);
            }
            //graficul celei de a doua derivate
            Pen pa = new Pen(Color.Blue);
            for (float i = -3; i <= 3; i = i + (float)0.001)
            {
                G.DrawEllipse(pa, x + i * 30, y - 30 * d2(i), 1, 1);
            }

        }
    }
}
