using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        enum Tools {None, Line, Circle, Elips, ColorFill };
        Tools tool = Tools.None;
        int x0, y0;
        bool mouseDown = false;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool != Tools.None)
            {
                mouseDown = true;
                x0 = e.X; y0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tool != Tools.None && mouseDown==true)
            {
                Bitmap bitmapClone = (Bitmap)bitmap.Clone();
                switch (tool)
                {
                    case Tools.Line:
                        Class1.myline(x0, y0, e.X, e.Y, bitmap, pictureBox1, Color.Red);
                        break;
                    case Tools.Circle:
                        int xm = (x0 + e.X) / 2;
                        int ym = (y0 + e.Y) / 2;
                        float r = (float)Math.Sqrt((e.X - xm) * (e.X - xm) + (e.Y - ym) * (e.Y - ym));
                        Class1.myCircle(xm, ym, r, bitmap, pictureBox1, Color.Red);
                        break;
                    case Tools.Elips:
                        xm = (x0 + e.X) / 2;
                        ym = (y0 + e.Y) / 2;
                        int a = Math.Abs(e.X - xm);
                        int b = Math.Abs(e.Y - ym);
                        Class1.myElips(xm, ym, a, b, bitmap, pictureBox1, Color.Red);
                        break;
                }
                bitmap = bitmapClone;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((tool != Tools.None) && mouseDown)
            {
                switch (tool)
                {
                    case Tools.Line:
                        Class1.myline(x0, y0, e.X, e.Y, bitmap, pictureBox1, Color.Red);
                        break;
                    case Tools.Circle:
                        int xm = (x0 + e.X) / 2;
                        int ym = (y0 + e.Y) / 2;
                        float r = (float)Math.Sqrt((e.X - xm) * (e.X - xm) + (e.Y - ym) * (e.Y - ym));
                        Class1.myCircle(xm, ym, r, bitmap, pictureBox1, Color.Red);
                        break;
                    case Tools.Elips:
                        xm = (x0 + e.X) / 2;
                        ym = (y0 + e.Y) / 2;
                        int a = Math.Abs(e.X - xm);
                        int b = Math.Abs(e.Y - ym);
                        Class1.myElips(xm, ym, a, b, bitmap, pictureBox1, Color.Red);
                        break;

                }
                mouseDown = false;
            }

        }
        
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool != Tools.None && tool != Tools.ColorFill)
            {
                x0 = e.X;
                y0 = e.Y;
                mouseDown = true;
            }
            else if (tool == Tools.ColorFill)
            {
                if (bitmap != null)
                {
                    Color innerColor = bitmap.GetPixel(e.X, e.Y);
                    Class1.myFloodFill(e.X, e.Y, bitmap, Color.Green, innerColor);
                    pictureBox1.Image = bitmap;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.myCircle(100, 100, 20, bitmap, pictureBox1, Color.Blue);
        }
        private void btnLine_Click(object sender, EventArgs e)
        {
            tool = Tools.Line;
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            tool = Tools.None;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tools.ColorFill;
        }
        private void buttonElips_Click(object sender, EventArgs e)
        {
            tool = Tools.Elips;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            tool = Tools.Circle;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
