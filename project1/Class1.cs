using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    internal class Class1
    {
        public static void myline(int x0, int y0, int x1, int y1, Bitmap bitmap, PictureBox pictureBox, Color color)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                if (x0 >= 0 && x0 < width && y0 >= 0 && y0 < height)
                {
                    bitmap.SetPixel(x0, y0, color);
                }

                if (x0 == x1 && y0 == y1) break;
                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }

            pictureBox.Image = bitmap;
        }
        public static void myElips(int x0, int y0, int a, int b, Bitmap bitmap, PictureBox pictureBox, Color color)
        {
            int width = bitmap.Width - 1;
            int height = bitmap.Height - 1;

            for (int i = 0; i < 360; i++)
            {
                double angle = i * Math.PI / 180;
                int xi = (int)(x0 + a * Math.Cos(angle));
                int yi = (int)(y0 + b * Math.Sin(angle));

                if (xi >= 0 && xi < width && yi >= 0 && yi < height)
                {
                    bitmap.SetPixel(xi, yi, color);
                }
            }

            pictureBox.Image = bitmap;

        }

        public static void myCircle(int x, int y, float r, Bitmap bitmap, PictureBox pictureBox, Color color)
        {
            int width = bitmap.Width - 1;
            int height = bitmap.Height - 1;

            for (int i = 0; i < 360; i++)
            {
                double angle = i * Math.PI / 180;
                int x_point = (int)(x + r * Math.Cos(angle));
                int y_point = (int)(y + r * Math.Sin(angle));
                if (x_point >= 0 && x_point < width && y_point >= 0 && y_point < height)
                {
                    bitmap.SetPixel(x_point, y_point, color);
                }
            }
            pictureBox.Image = bitmap;
        }

        public static void myFloodFill(int x, int y, Bitmap bitmap, Color fillColor, Color innerColor)
        {
            if (x > 1 && x < bitmap.Width && y >1 && y < bitmap.Height)
            {
                if (bitmap.GetPixel(x, y) == innerColor)
                {
                    bitmap.SetPixel(x, y, fillColor);
                }
                else return;
                myFloodFill(x+1, y, bitmap, fillColor, innerColor);
                myFloodFill(x - 1, y, bitmap, fillColor, innerColor);
                myFloodFill(x, y+1, bitmap, fillColor, innerColor);
                myFloodFill(x, y-1 , bitmap, fillColor, innerColor);

            }
        }
    }
}