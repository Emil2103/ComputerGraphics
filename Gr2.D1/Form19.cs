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
    public partial class Form19 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch, Yaw, Roll;
        public Form19()
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
            int x0, y0, z0, R, L, m;
            x0 = 5;
            y0 = 5;
            z0 = 5;
            R = 50;
            L = 100;
            m = 3;
            GraphicsObject.Clear(Color.White);
            int i, j;
            for (i = x0 - R; i < x0 + R; i += m)
            {
                double y1, y2;
                y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
                y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
                double x11 = 0, y11 = 0, z11;
                double x21 = 0, y21 = 0, z21;
                z11 = RotateObject(Pitch, Yaw, Roll, i, y1, z0, ref x11, ref y11);
                z21 = RotateObject(Pitch, Yaw, Roll, i, y2, z0, ref x21, ref y21);
                RectangleF MyBox1 = new RectangleF((float)x11, (float)y11, 7, 7);
                RectangleF MyBox2 = new RectangleF((float)x21, (float)y21, 7, 7);
                SolidBrush myBrush1 = new SolidBrush(Color.Green);
                SolidBrush myBrush2 = new SolidBrush(Color.Orchid);
                Pen MyPen1 = new Pen(Color.Green, 5);
                //Pen MyPen2 = new Pen(Color.Orchid, 1);
                GraphicsObject.DrawLine(MyPen1, (float)x11, (float)y11, (float)x21, (float)y21);
                GraphicsObject.FillEllipse(myBrush1, MyBox1);
                GraphicsObject.FillEllipse(myBrush2, MyBox2);
                //GraphicsObject.DrawEllipse(MyPen1, MyBox1);
                // GraphicsObject.DrawEllipse(MyPen2, MyBox2);

            }
            for (i = z0 - m; i < z0 + L; i += m)
            {
                for (j = x0 - R; j < x0 + R; j += m)
                {
                    double y1, y2;
                    y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((j - x0), 2));
                    y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((j - x0), 2));
                    double x11 = 0, y11 = 0, z11;
                    double x21 = 0, y21 = 0, z21;
                    z11 = RotateObject(Pitch, Yaw, Roll, j, y1, i, ref x11, ref y11);
                    z21 = RotateObject(Pitch, Yaw, Roll, j, y2, i, ref x21, ref y21);
                    RectangleF MyBox1 = new RectangleF((float)x11, (float)y11, 7, 7);
                    RectangleF MyBox2 = new RectangleF((float)x21, (float)y21, 7, 7);
                    SolidBrush myBrush1 = new SolidBrush(Color.Blue);
                    SolidBrush myBrush2 = new SolidBrush(Color.Red);
                    GraphicsObject.FillEllipse(myBrush1, MyBox1);
                    GraphicsObject.FillEllipse(myBrush2, MyBox2);
                    //Pen MyPen1 = new Pen(Color.Blue, 1);
                    //Pen MyPen2 = new Pen(Color.Red, 1);
                    //GraphicsObject.DrawEllipse(MyPen1, MyBox1);
                    //GraphicsObject.DrawEllipse(MyPen2, MyBox2);
                }
            }
            for (i = x0 - R; i < x0 + R; i += m)
            {
                double y1, y2;
                y1 = y0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
                y2 = y0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - x0), 2));
                double x11 = 0, y11 = 0, z11;
                double x21 = 0, y21 = 0, z21;
                z11 = RotateObject(Pitch, Yaw, Roll, i, y1, z0 + L, ref x11, ref y11);
                z21 = RotateObject(Pitch, Yaw, Roll, i, y2, z0 + L, ref x21, ref y21);
                RectangleF MyBox1 = new RectangleF((float)x11, (float)y11, 7, 7);
                RectangleF MyBox2 = new RectangleF((float)x21, (float)y21, 7, 7);
                //SolidBrush myBrush1 = new SolidBrush(Color.Green);
                //SolidBrush myBrush2 = new SolidBrush(Color.Orchid);
                //Pen MyPen1 = new Pen(Color.Green, 1);
                Pen MyPen2 = new Pen(Color.Orchid, 5);
                SolidBrush myBrush1 = new SolidBrush(Color.Green);
                SolidBrush myBrush2 = new SolidBrush(Color.Orchid);
                GraphicsObject.DrawLine(MyPen2, (float)x11, (float)y11, (float)x21, (float)y21);
                //GraphicsObject.DrawEllipse(MyPen1, MyBox1);
                // GraphicsObject.DrawEllipse(MyPen2, MyBox2);
                GraphicsObject.FillEllipse(myBrush1, MyBox1);
                GraphicsObject.FillEllipse(myBrush2, MyBox2);

            }
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            G.Transform = myMatrix;
        }
    }
}
