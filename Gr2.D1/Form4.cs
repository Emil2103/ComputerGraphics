using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gr2.D1
{
    public partial class Form4 : Form
    {
        double[] x0;
        double[] y0;
        double[] z0;
        double[] newX;
        double[] newY;
        double[] newZ;
        Point[] Point;
        double x, y, z;
        double factor;
        Graphics G;
        public Form4()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            x0 = new double[4];
            y0 = new double[4];
            z0 = new double[4];
            newX = new double[4];
            newY = new double[4];
            newZ = new double[4];
            Point = new Point[4];
            x0[0] = 40;
            x0[1] = -40;
            x0[2] = 40;
            x0[3] = -40;
            y0[0] = 50;
            y0[1] = 50;
            y0[2] = 100;
            y0[3] = 100;
            z0[0] = 0;
            z0[1] = 0;
            z0[2] = 0;
            z0[3] = 0;
            factor = Math.PI / 180;
            G.TranslateTransform(301, 50);
        }
        public double RotateYaw(double x, double y, double z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = x * Math.Cos(alpha) + z * Math.Sin(alpha);
            NewY = y;
            NewZ = -x * Math.Sin(alpha) + z * Math.Cos(alpha);
            return NewZ;
        }
        public void DrawShape(Graphics GraphicObject)
        {
            newZ[0] = RotateYaw(x0[0], y0[0], z0[0], y, ref newX[0], ref newY[0]);
            newZ[1] = RotateYaw(x0[1], y0[1], z0[1], y, ref newX[1], ref newY[1]);
            newZ[2] = RotateYaw(x0[2], y0[2], z0[2], y, ref newX[2], ref newY[2]);
            newZ[3] = RotateYaw(x0[3], y0[3], z0[3], y, ref newX[3], ref newY[3]);
            x0[0] = newX[0];
            y0[0] = newY[0];
            z0[0] = newZ[0];
            x0[1] = newX[1];
            y0[1] = newY[1];
            z0[1] = newZ[1];
            x0[2] = newX[2];
            y0[2] = newY[2];
            z0[2] = newZ[2];
            x0[3] = newX[3];
            y0[3] = newY[3];
            z0[3] = newZ[3];
            Rectangle rect = new Rectangle((int)x0[0], (int)y0[0], (int)(x0[1] - x0[0]), (int)(y0[2] - y0[0]));
            Pen MyPen = new Pen(Color.Red, 1);
            GraphicObject.DrawEllipse(MyPen, rect);
        }
        public double RotatePitch(double x, double y, double z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = x;
            NewY = y * Math.Cos(alpha) - z * Math.Sin(alpha);
            NewZ = y * Math.Sin(alpha) + z * Math.Cos(alpha);
            return NewZ;
        }
        public void DrawShape1(Graphics GraphicObject)
        {
            newZ[0] = RotatePitch(x0[0], y0[0], z0[0], x, ref newX[0], ref newY[0]);
            newZ[1] = RotatePitch(x0[1], y0[1], z0[1], x, ref newX[1], ref newY[1]);
            newZ[2] = RotatePitch(x0[2], y0[2], z0[2], x, ref newX[2], ref newY[2]);
            newZ[3] = RotatePitch(x0[3], y0[3], z0[3], x, ref newX[3], ref newY[3]);
            x0[0] = newX[0];
            y0[0] = newY[0];
            z0[0] = newZ[0];
            x0[1] = newX[1];
            y0[1] = newY[1];
            z0[1] = newZ[1];
            x0[2] = newX[2];
            y0[2] = newY[2];
            z0[2] = newZ[2];
            x0[3] = newX[3];
            y0[3] = newY[3];
            z0[3] = newZ[3];
            Rectangle rect = new Rectangle((int)x0[0], (int)y0[0], (int)(x0[1] - x0[0]), (int)(y0[2] - y0[0]));
            Pen MyPen = new Pen(Color.Red, 2);
            GraphicObject.DrawEllipse(MyPen, rect);
        }

        private void hScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            x = factor * (hScrollBarPitch.Value);
            DrawShape1(G);
        }

        private void hScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            y = factor * (hScrollBarYaw.Value);
            DrawShape(G);
        }

        private void hScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            z = factor * (hScrollBarRoll.Value);
            DrawShape2(G);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                y = i;
                DrawShape(G);
            }
        }

        public double RotateRoll(double x, double y, double z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = x * Math.Cos(alpha) - y * Math.Sin(alpha);
            NewY = x * Math.Sin(alpha) + y * Math.Cos(alpha);
            NewZ = z;
            return NewZ;
        }
        public void DrawShape2(Graphics GraphicObject)
        {

            newZ[0] = RotateRoll(x0[0], y0[0], z0[0], z, ref newX[0], ref newY[0]);
            newZ[1] = RotateRoll(x0[1], y0[1], z0[1], z, ref newX[1], ref newY[1]);
            newZ[2] = RotateRoll(x0[2], y0[2], z0[2], z, ref newX[2], ref newY[2]);
            newZ[3] = RotateRoll(x0[3], y0[3], z0[3], z, ref newX[3], ref newY[3]);
            x0[0] = newX[0];
            y0[0] = newY[0];
            z0[0] = newZ[0];
            x0[1] = newX[1];
            y0[1] = newY[1];
            z0[1] = newZ[1];
            x0[2] = newX[2];
            y0[2] = newY[2];
            z0[2] = newZ[2];
            x0[3] = newX[3];
            y0[3] = newY[3];
            z0[3] = newZ[3];
            Rectangle rect = new Rectangle((int)x0[0], (int)y0[0], (int)(x0[1] - x0[0]), (int)(y0[2] - y0[0]));
            Pen MyPen = new Pen(Color.Red, 2);
            GraphicObject.DrawEllipse(MyPen, rect);
        }
    }
}
