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
    public partial class Form11 : Form
    {
        Graphics G;
        const int Vertex_number = 3;    
        public Form11()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            int Minimum = 1, Maximum = 369;
            HScrollBarTheta.Minimum = Minimum;
            HScrollBarTheta.Maximum = Maximum;
            HScrollBarPitch.Minimum = Minimum;
            HScrollBarPitch.Maximum = pictureBox1.Width;
            HScrollBarYaw.Minimum = Minimum;
            HScrollBarYaw.Maximum = pictureBox1.Width;
            HScrollBarRoll.Minimum = Minimum;
            HScrollBarRoll.Maximum = pictureBox1.Width;
            x[0] = 200;
            y[0] = 100;
            x[1] = 300;
            y[1] = 300;
            x[2] = 400;
            y[2] = 100;
        }
        double[] x = new double[Vertex_number];
        double[] y = new double[Vertex_number];
        double[] z = new double[Vertex_number];
        double[] newX = new double[Vertex_number];
        double[] newY = new double[Vertex_number];
        double[] newZ = new double[Vertex_number];
        PointF[] Point = new PointF[Vertex_number];
        double Factor = Math.PI / 180;
        double Theta, u, v, w;
        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            u = HScrollBarPitch.Value;
            DrawShape(G);
        }

        private void HScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            v = HScrollBarYaw.Value;
            DrawShape(G);
        }

        private void HScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            w = HScrollBarRoll.Value;
            DrawShape(G);
        }

        private void HScrollBarTheta_Scroll(object sender, ScrollEventArgs e)
        {
            Theta = Factor * HScrollBarTheta.Value;
            DrawShape(G);
        }
        double RotateObject(double _Theta, double _u, double _v, double _w, double _x, double _y, double _z, ref double NewX, ref double NewY)
        {
            double NewZ;
            double a, b, c, d, e;
            a = _u * _x + _v * _y + _w * _z;
            b = Math.Pow(_u, 2) + Math.Pow(_v, 2) + Math.Pow(_w, 2);
            c = Math.Sqrt(b);
            d = Math.Cos(_Theta);
            e = Math.Sin(_Theta);
            NewX = (_u * a + (_x * (Math.Pow(_v, 2) + Math.Pow(_w, 2) - _u * (_v * _y + _w * _z)) * d + c * (-_w * _y + _v * _z) * e)) / b;
            NewY = (_v * a + (_y * (Math.Pow(_u, 2) + Math.Pow(_w, 2) - _v * (_u * _x + _w * _z)) * d + c * (_w * _x - _u * _z) * e)) / b;
            NewZ = (_w * a + (_z * (Math.Pow(_u, 2) + Math.Pow(_v, 2) - _w * (_u * _x + _v * _y)) * d + c * (-_v * _x + _u * _y) * e)) / b;
            return NewZ;
        }
        void DrawShape(Graphics GraphicsObject)
        {
            newZ[0] = RotateObject(Theta, u, v, w, x[0], y[0], z[0], ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Theta, u, v, w, x[1], y[1], z[1], ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Theta, u, v, w, x[2], y[2], z[2], ref newX[2], ref newY[2]);
            Point[0] = new PointF((float)newX[0], (float)newY[0]);
            Point[1] = new PointF((float)newX[1], (float)newY[1]);
            Point[2] = new PointF((float)newX[2], (float)newY[2]);
            PointF[] CurvePoints = { Point[0], Point[1], Point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush MyBrush = new SolidBrush(Color.Blue);
            GraphicsObject.Clear(Color.White);
            GraphicsObject.DrawPolygon(MyPen, CurvePoints);
            GraphicsObject.FillPolygon(MyBrush, CurvePoints);
            PointF MyPoint1 = new PointF(0, 0);
            PointF MyPoint2 = new PointF((int)u, (int)v);
            GraphicsObject.DrawLine(MyPen, MyPoint1, MyPoint2);
        }
    }
}
