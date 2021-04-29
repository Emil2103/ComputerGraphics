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
    public partial class Form7 : Form
    {
        Graphics G;
        const int Vertex_number = 3;
        double curve1 = 0;
        double curve2 = 0;
        double curve3 = 0;
        public Form7()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            int min = 1;
            int max = 369;
            XScrollBar.Minimum = min;
            XScrollBar.Maximum = max;
            YScrollBar.Minimum = min;
            YScrollBar.Maximum = max;
            ZScrollBar.Minimum = min;
            ZScrollBar.Maximum = max;
            HScrollBarPitchOffSet.Minimum = 1;
            HScrollBarPitchOffSet.Maximum = pictureBox1.Width;
            HScrollBarYawOffSet.Minimum = 1;
            HScrollBarYawOffSet.Maximum = pictureBox1.Height;
            HScrollBarRollOffSet.Minimum = 1;
            HScrollBarRollOffSet.Maximum = pictureBox1.Height;
            x[0] = 200;
            y[0] = 100;
            x[1] = 300;
            y[1] = 300;
            x[2] = 400;
            y[2] = 100;
        }
        double x0, y0, z0;
        double XAxisAngle, YAxisAngle, ZAxisAngle;
        double[] x = new double[Vertex_number];
        double[] y = new double[Vertex_number];
        double[] z = new double[Vertex_number];
        double[] newX = new double[Vertex_number] { 200, 300, 400 };
        double[] newY = new double[Vertex_number] { 100, 300, 100 };
        double[] newZ = new double[Vertex_number] { 0, 0, 0 };
        PointF[] Point = new PointF[Vertex_number];
        double factor = Math.PI / 180;

        private void XScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            XAxisAngle = factor * XScrollBar.Value - curve1;
            curve1 = factor * XScrollBar.Value;
            DrawShape(G, 0);
        }

        private void YScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            YAxisAngle = factor * YScrollBar.Value - curve2;
            curve2 = factor * YScrollBar.Value;
            DrawShape(G, 1);
        }

        private void ZScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            ZAxisAngle = factor * ZScrollBar.Value - curve3;
            curve3 = factor * ZScrollBar.Value;
            DrawShape(G, 2);
        }

        private void HScrollBarPitchOffSet_Scroll(object sender, ScrollEventArgs e)
        {
            x0 = HScrollBarPitchOffSet.Value;
            DrawShape(G, 3);
        }

        private void HScrollBarYawOffSet_Scroll(object sender, ScrollEventArgs e)
        {
            y0 = HScrollBarYawOffSet.Value;
            DrawShape(G, 4);
        }

        private void HScrollBarRollOffSet_Scroll(object sender, ScrollEventArgs e)
        {
            z0 = HScrollBarRollOffSet.Value;
            DrawShape(G, 5);
        }

        double RotatePitch(double _x, double _y, double _z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = _x;
            NewY = y0 + (_y - y0) * Math.Cos(alpha) + (z0 - _z) * Math.Sin(alpha);
            NewZ = z0 + (_y - y0) * Math.Sin(alpha) + (_z - z0) * Math.Cos(alpha);
            return NewZ;
        }

        double RotateYaw(double _x, double _y, double _z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = x0 + (_x - x0) * Math.Cos(alpha) + (_z - z0) * Math.Sin(alpha);
            NewY = _y;
            NewZ = z0 + (x0 - _x) * Math.Sin(alpha) + (_z - z0) * Math.Cos(alpha);
            return NewZ;
        }

        double RotateRoll(double _x, double _y, double _z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = x0 + (_x - x0) * Math.Cos(alpha) + (y0 - _y) * Math.Sin(alpha);
            NewY = y0 + (_x - x0) * Math.Sin(alpha) + (_y - y0) * Math.Cos(alpha);
            NewZ = _z;
            return NewZ;
        }

        void DrawShape(Graphics GraphicsObject, int Axis)
        {
            if (Axis == 0)
            {
                newZ[0] = RotatePitch(x[0], y[0], z[0], XAxisAngle, ref newX[0], ref newY[0]);
                newZ[1] = RotatePitch(x[1], y[1], z[1], XAxisAngle, ref newX[1], ref newY[1]);
                newZ[2] = RotatePitch(x[2], y[2], z[2], XAxisAngle, ref newX[2], ref newY[2]);
            }
            else
                if (Axis == 1)
            {
                newZ[0] = RotateYaw(x[0], y[0], z[0], YAxisAngle, ref newX[0], ref newY[0]);
                newZ[1] = RotateYaw(x[1], y[1], z[1], YAxisAngle, ref newX[1], ref newY[1]);
                newZ[2] = RotateYaw(x[2], y[2], z[2], YAxisAngle, ref newX[2], ref newY[2]);
            }
            else
                if (Axis == 2)
            {
                newZ[0] = RotateRoll(x[0], y[0], z[0], ZAxisAngle, ref newX[0], ref newY[0]);
                newZ[1] = RotateRoll(x[1], y[1], z[1], ZAxisAngle, ref newX[1], ref newY[1]);
                newZ[2] = RotateRoll(x[2], y[2], z[2], ZAxisAngle, ref newX[2], ref newY[2]);
            }
            x[0] = newX[0];
            y[0] = newY[0];
            z[0] = newZ[0];
            x[1] = newX[1];
            y[1] = newY[1];
            z[1] = newZ[1];
            x[2] = newX[2];
            y[2] = newY[2];
            z[2] = newZ[2];
            Point[0] = new PointF((float)newX[0], (float)newY[0]);
            Point[1] = new PointF((float)newX[1], (float)newY[1]);
            Point[2] = new PointF((float)newX[2], (float)newY[2]);
            PointF[] MyCurve = { Point[0], Point[1], Point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush MyBrush = new SolidBrush(Color.Blue);
            G.Clear(Color.White);
            Pen BlackPen = new Pen(Color.Black, 2);
            Rectangle MyBox = new Rectangle((int)x0, (int)y0, 5, 5);
            GraphicsObject.DrawEllipse(BlackPen, MyBox);
            GraphicsObject.DrawPolygon(MyPen, MyCurve);
            GraphicsObject.FillPolygon(MyBrush, MyCurve);
        }
    }
}
