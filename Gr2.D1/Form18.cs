using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Math;
using System.Drawing.Drawing2D;

namespace Gr2.D1
{
    public partial class Form18 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch, Yaw, Roll;
        public Form18()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            int Minimum = 0, Maximum = 369;
            HScrollBarPitch.Minimum = Minimum;
            HScrollBarPitch.Maximum = Maximum;
            HScrollBarYaw.Minimum = Minimum;
            HScrollBarYaw.Maximum = Maximum;
            HScrollBarRoll.Minimum = Minimum;
            HScrollBarRoll.Maximum = Maximum;
        }

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            Pitch = Factor * HScrollBarPitch.Value;
            DrawShape(G);
        }

        private void HScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            Yaw = Factor * HScrollBarYaw.Value;
            DrawShape(G);
        }

        private void HScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            Roll = Factor * HScrollBarRoll.Value;
            DrawShape(G);
        }
        double RotateObject(double _Pitch, double _Yaw, double _Roll, double _x, double _y, double _z, ref double NewX, ref double NewY)
        {
            double[,] m = new double[3, 3];
            m[0, 0] = Cos(_Yaw) * Cos(_Roll);
            m[0, 1] = -Cos(_Yaw) * Sin(_Roll);
            m[0, 2] = -Sin(_Yaw);
            m[1, 0] = Sin(_Pitch) * Sin(_Yaw) * Cos(_Roll) + Sin(_Roll) * Cos(_Pitch);
            m[1, 1] = -Sin(_Pitch) * Sin(_Yaw) * Sin(_Roll) + Cos(_Roll) * Cos(_Pitch);
            m[1, 2] = Cos(_Yaw);
            m[2, 0] = -Cos(_Pitch) * Sin(_Yaw) * Cos(_Roll) + Sin(_Pitch) * Sin(_Roll);
            m[2, 1] = Cos(_Pitch) * Sin(_Yaw) * Sin(_Roll) + Sin(_Pitch) * Cos(_Roll);
            m[2, 2] = Cos(_Yaw) * Cos(_Pitch);
            double NewZ;
            NewX = m[0, 0] * _x + m[1, 0] * _y + m[2, 0] * _z;
            NewY = m[0, 1] * _x + m[1, 1] * _y + m[2, 1] * _z;
            NewZ = m[0, 2] * _x + m[1, 2] * _y + m[2, 2] * _z;
            return NewZ;
        }
        void DrawShape(Graphics GraphicsObject)
        {
            int x0, y0, z0, h, d, m;
            x0 = 0;
            y0 = 0;
            z0 = 0;
            h = 150;
            d = 70;
            m = 5;
            GraphicsObject.Clear(Color.White);
            double i, j, k;
            //Pen MyPen1 = new Pen(Color.Blue, 1);
            //Pen MyPen2 = new Pen(Color.Red, 1);
            //Pen MyPen3 = new Pen(Color.Green, 1);
            // Pen MyPen4 = new Pen(Color.Black, 1);
            SolidBrush MyBrush1 = new SolidBrush(Color.Blue);
            SolidBrush MyBrush2 = new SolidBrush(Color.Red);
            SolidBrush MyBrush3 = new SolidBrush(Color.Green);
            SolidBrush MyBrush4 = new SolidBrush(Color.Black);
            double XMin, Xmax;
            for (i = z0; i < z0 + h; i += m)
            {
                XMin = -(z0 + i) * d / (2 * h);
                Xmax = (z0 + i) * d / (2 * h);
                for (j = XMin; j < Xmax; j += m)
                {
                    double newx1 = 0, newy1 = 0, newz1;
                    double newx2 = 0, newy2 = 0, newz2;
                    newz1 = RotateObject(Pitch, Yaw, Roll, XMin, j, i, ref newx1, ref newy1);
                    newz2 = RotateObject(Pitch, Yaw, Roll, Xmax, j, i, ref newx2, ref newy2);
                    RectangleF MyBox1 = new RectangleF((float)(newx1), (float)newy1, 8, 8);
                    RectangleF MyBox2 = new RectangleF((float)(newx2), (float)newy2, 8, 8);
                    GraphicsObject.FillEllipse(MyBrush1, MyBox1);
                    GraphicsObject.FillEllipse(MyBrush2, MyBox2);
                    //GraphicsObject.DrawEllipse(MyPen1, MyBox1);
                    //GraphicsObject.DrawEllipse(MyPen2, MyBox2);
                }
                for (k = XMin; k < Xmax; k += m)
                {
                    double newx1 = 0, newy1 = 0, newz1;
                    double newx2 = 0, newy2 = 0, newz2;
                    newz1 = RotateObject(Pitch, Yaw, Roll, k, Xmax, i, ref newx1, ref newy1);
                    newz2 = RotateObject(Pitch, Yaw, Roll, k, XMin, i, ref newx2, ref newy2);
                    RectangleF MyBox3 = new RectangleF((float)(newx1), (float)newy1, 8, 8);
                    RectangleF MyBox4 = new RectangleF((float)(newx2), (float)newy2, 8, 8);
                    GraphicsObject.FillEllipse(MyBrush3, MyBox3);
                    GraphicsObject.FillEllipse(MyBrush4, MyBox4);
                    //GraphicsObject.DrawEllipse(MyPen3, MyBox3);
                    //GraphicsObject.DrawEllipse(MyPen4, MyBox4);
                }
            }
            XMin = -(z0 + h) * d / (2 * h);
            Xmax = (z0 + h) * d / (2 * h);
            Pen MyPen5 = new Pen(Color.Brown, 1);
            for (j = XMin; j < Xmax; j += 1)
            {
                double newx1 = 0, newy1 = 0, newz1;
                double newx2 = 0, newy2 = 0, newz2;
                newz1 = RotateObject(Pitch, Yaw, Roll, j, XMin, z0 + h, ref newx1, ref newy1);
                newz2 = RotateObject(Pitch, Yaw, Roll, j, Xmax, z0 + h, ref newx2, ref newy2);
                GraphicsObject.DrawLine(MyPen5, (float)newx1, (float)newy1, (float)newx2, (float)newy2);
            }
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            G.Transform = myMatrix;
        }
    }
}
