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
    public partial class Form17 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch, Yaw, Roll;
        public Form17()
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

        void DrawShape(Graphics GraphicsObjet)
        {
            int x0 = 20, y0 = 10, z0 = 5;
            int a = 100, b = 100, c = 100;
            int i, j, k, l;
            // Pen MyPen = new Pen(Color.Red);
            // Pen MyPen1 = new Pen(Color.Blue, 1);
            // Pen MyPen2 = new Pen(Color.Red, 1);
            // Pen MyPen3 = new Pen(Color.Green, 1);
            // Pen MyPen4 = new Pen(Color.Black, 1);
            // Pen MyPen5 = new Pen(Color.Yellow, 1);
            // Pen MyPen6 = new Pen(Color.Orchid, 1);
            SolidBrush MyBrush1 = new SolidBrush(Color.Blue);
            SolidBrush MyBrush2 = new SolidBrush(Color.Red);
            SolidBrush MyBrush3 = new SolidBrush(Color.Green);
            SolidBrush MyBrush4 = new SolidBrush(Color.Black);
            SolidBrush MyBrush5 = new SolidBrush(Color.Yellow);
            SolidBrush MyBrush6 = new SolidBrush(Color.Orchid);

            GraphicsObjet.Clear(Color.White);
            for (i = x0; i < x0 + a; i += 5)
                for (j = y0; j < y0 + b; j += 5)
                {
                    double newx1 = 0, newy1 = 0, newz1;
                    newz1 = RotateObject(Pitch, Yaw, Roll, i, j, z0, ref newx1, ref newy1);
                    Rectangle MyBox = new Rectangle((int)newx1, (int)newy1, 7, 7);
                    GraphicsObjet.FillRectangle(MyBrush5, MyBox);
                    //GraphicsObjet.DrawEllipse(MyPen5, MyBox);
                }
            for (i = z0 + 1; i < z0 + c; i += 5)
            {
                for (j = y0; j < y0 + b; j += 5)
                {
                    double newx1 = 0, newy1 = 0, newz1;
                    double newx2 = 0, newy2 = 0, newz2;
                    newz1 = RotateObject(Pitch, Yaw, Roll, x0, j, i, ref newx1, ref newy1);
                    newz2 = RotateObject(Pitch, Yaw, Roll, x0 + a, j, i, ref newx2, ref newy2);
                    RectangleF MyBox1 = new RectangleF((float)(newx1), (float)(newy1), 7, 7);
                    RectangleF MyBox2 = new RectangleF((float)(newx2), (float)(newy2), 7, 7);
                    GraphicsObjet.FillRectangle(MyBrush1, MyBox1);
                    GraphicsObjet.FillRectangle(MyBrush2, MyBox2);
                    // GraphicsObjet.DrawEllipse(MyPen1, MyBox1);
                    // GraphicsObjet.DrawEllipse(MyPen2, MyBox2);
                }
                for (k = x0; k < x0 + a; k += 5)
                {
                    double newx1 = 0, newy1 = 0, newz1;
                    double newx2 = 0, newy2 = 0, newz2;
                    newz1 = RotateObject(Pitch, Yaw, Roll, k, y0, i, ref newx1, ref newy1);
                    newz2 = RotateObject(Pitch, Yaw, Roll, k, y0 + b, i, ref newx2, ref newy2);
                    RectangleF MyBox3 = new RectangleF((float)(newx1), (float)(newy1), 7, 7);
                    RectangleF MyBox4 = new RectangleF((float)(newx2), (float)(newy2), 7, 7);
                    GraphicsObjet.FillRectangle(MyBrush3, MyBox3);
                    GraphicsObjet.FillRectangle(MyBrush4, MyBox4);
                    //GraphicsObjet.DrawEllipse(MyPen3, MyBox3);
                    // GraphicsObjet.DrawEllipse(MyPen4, MyBox4);
                }
            }
            for (i = x0; i < x0 + a; i += 5)
                for (j = y0; j < y0 + b; j += 5)
                {
                    double newx1 = 0, newy1 = 0, newz1;
                    newz1 = RotateObject(Pitch, Yaw, Roll, i, j, z0 + c, ref newx1, ref newy1);
                    RectangleF MyBox = new RectangleF((float)newx1, (float)newy1, 7, 7);
                    GraphicsObjet.FillRectangle(MyBrush6, MyBox);
                    //GraphicsObjet.DrawEllipse(MyPen6, MyBox);
                }
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            G.Transform = myMatrix;

        }
    }
}
