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
    public partial class Form6 : Form
    {
        Graphics G;
        const int Vertex_number = 3;
        double curve1 = 0;
        double curve2 = 0;
        double curve3 = 0;
        public Form6()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            int min = 0;
            int max = 369;
            XScrollBar.Minimum = min;
            XScrollBar.Maximum = max;
            YScrollBar.Minimum = min;
            YScrollBar.Maximum = max;
            ZScrollBar.Minimum = min;
            ZScrollBar.Maximum = max;
            x0[0] = 200;
            y0[0] = 100;
            z0[0] = 0;
            x0[1] = 300;
            y0[1] = 300;
            z0[1] = 0;
            x0[2] = 400;
            y0[2] = 100;
            z0[2] = 0;
        }
        double[] x0 = new double[Vertex_number];
        double[] y0 = new double[Vertex_number];
        double[] z0 = new double[Vertex_number];
        double[] newX = new double[Vertex_number] { 200, 300, 400 };
        double[] newY = new double[Vertex_number] { 100, 300, 100 };
        double[] newZ = new double[Vertex_number] { 0, 0, 0 };
        PointF[] Point = new PointF[Vertex_number];
        double x, y, z;
        double factor = Math.PI / 180;


        double RotatePitch(double _x, double _y, double _z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = _x;
            NewY = _y * Math.Cos(alpha) + _z * Math.Sin(alpha);
            NewZ = -_y * Math.Sin(alpha) + _z * Math.Cos(alpha);
            return NewZ;
        }

        double RotateYaw(double _x, double _y, double _z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = _x * Math.Cos(alpha) + _z * Math.Sin(alpha);
            NewY = _y;
            NewZ = -_x * Math.Sin(alpha) + _z * Math.Cos(alpha);
            return NewZ;
        }

        private void XScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            x = factor * XScrollBar.Value - curve1;
            curve1 = factor * XScrollBar.Value;
            DrawShape(G, 0);
        }

        private void YScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            y = factor * YScrollBar.Value - curve2;
            curve2 = factor * YScrollBar.Value;
            DrawShape(G, 1);
        }

        private void ZScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            z = factor * ZScrollBar.Value - curve3;
            curve3 = factor * ZScrollBar.Value;
            DrawShape(G, 2);
        }

        double RotateRoll(double _x, double _y, double _z, double alpha, ref double NewX, ref double NewY)
        {
            double NewZ;
            NewX = _x * Math.Cos(alpha) - _y * Math.Sin(alpha);
            NewY = _x * Math.Sin(alpha) + _y * Math.Cos(alpha);
            NewZ = _z;
            return NewZ;
        }
        void DrawShape(Graphics GraphicObject, int Axis)
        {

            if (Axis == 0)
            {
                newZ[0] = RotatePitch(x0[0], y0[0], z0[0], x, ref newX[0], ref newY[0]);
                newZ[1] = RotatePitch(x0[1], y0[1], z0[1], x, ref newX[1], ref newY[1]);
                newZ[2] = RotatePitch(x0[2], y0[2], z0[2], x, ref newX[2], ref newY[2]);
            }
            else
            if (Axis == 1)
            {
                newZ[0] = RotateYaw(x0[0], y0[0], z0[0], y, ref newX[0], ref newY[0]);
                newZ[1] = RotateYaw(x0[1], y0[1], z0[1], y, ref newX[1], ref newY[1]);
                newZ[2] = RotateYaw(x0[2], y0[2], z0[2], y, ref newX[2], ref newY[2]);
            }
            else if (Axis == 2)
            {
                newZ[0] = RotateRoll(x0[0], y0[0], z0[0], z, ref newX[0], ref newY[0]);
                newZ[1] = RotateRoll(x0[1], y0[1], z0[1], z, ref newX[1], ref newY[1]);
                newZ[2] = RotateRoll(x0[2], y0[2], z0[2], z, ref newX[2], ref newY[2]);
            }

            x0[0] = newX[0];
            y0[0] = newY[0];
            z0[0] = newZ[0];

            x0[1] = newX[1];
            y0[1] = newY[1];
            z0[1] = newZ[1];

            x0[2] = newX[2];
            y0[2] = newY[2];
            z0[2] = newZ[2];

            Point[0] = new PointF((float)newX[0], (float)newY[0]);
            Point[1] = new PointF((float)newX[1], (float)newY[1]);
            Point[2] = new PointF((float)newX[2], (float)newY[2]);
            PointF[] MyCurve = { Point[0], Point[1], Point[2] };

            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush MyBrush = new SolidBrush(Color.Blue);
            G.Clear(Color.White);
            GraphicObject.DrawPolygon(MyPen, MyCurve);
            GraphicObject.FillPolygon(MyBrush, MyCurve);
        }
    }
}
