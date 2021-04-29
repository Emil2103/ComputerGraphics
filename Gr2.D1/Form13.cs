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
    public partial class Form13 : Form
    {
        Graphics G;
        const int Vertex_number = 3;
        public Form13()
        {
            InitializeComponent();
            G = MyPictureBox.CreateGraphics();
            int Minimum = 1, Maximum = 369;
            HScrollBarTheta.Minimum = Minimum;
            HScrollBarTheta.Maximum = Maximum;
            HScrollBarPitch.Minimum = Minimum;
            HScrollBarPitch.Maximum = MyPictureBox.Width;
            HScrollBarYaw.Minimum = Minimum;
            HScrollBarYaw.Maximum = MyPictureBox.Width;
            HScrollBarRoll.Minimum = Minimum;
            HScrollBarRoll.Maximum = MyPictureBox.Width;
            HScrollBarA.Minimum = Minimum;
            HScrollBarA.Maximum = MyPictureBox.Width;
            HScrollBarB.Minimum = Minimum;
            HScrollBarB.Maximum = MyPictureBox.Width;
            HScrollBarC.Minimum = Minimum;
            HScrollBarC.Maximum = MyPictureBox.Width;

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
        double Theta, A, B, C, u, v, w;

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

        private void HScrollBarA_Scroll(object sender, ScrollEventArgs e)
        {
            A = HScrollBarA.Value;
            DrawShape(G);

        }

        private void HScrollBarB_Scroll(object sender, ScrollEventArgs e)
        {
            B = HScrollBarB.Value;
            DrawShape(G);
        }

        private void HScrollBarC_Scroll(object sender, ScrollEventArgs e)
        {
            C = HScrollBarC.Value;
            DrawShape(G);
        }

        private void HScrollBarTheta_Scroll(object sender, ScrollEventArgs e)
        {
            Theta = Factor * HScrollBarTheta.Value;
            DrawShape(G);
        }
        double RotateObject(double _Theta, double _A, double _B, double _C, double _u, double _v, double _w,
           double _x, double _y, double _z, ref double NewX, ref double NewY)
        {
            double NewZ;
            double L = Math.Pow(_u, 2) + Math.Pow(_v, 2) + Math.Pow(_w, 2);
            double sqrL = Math.Sqrt(L);
            double Lu = Math.Pow(_v, 2) + Math.Pow(_w, 2);
            double Lv = Math.Pow(_u, 2) + Math.Pow(_w, 2);
            double Lw = Math.Pow(_u, 2) + Math.Pow(_v, 2);
            NewX = (_A * Lu + _u * (-_B * _v - _C * _w + _u * _x + _v * _y + _w * _z) + ((_x - _A) * Lu + _u * (_B * _v + _C * _w - _v * _y - _w * _z)
                + Lu * _x) * Math.Cos(_Theta) + sqrL * (-_C * _v + _B * _w - _w * _y + _v * _z) * Math.Sin(_Theta)) / L;
            NewY = (_B * Lv + _v * (-_A * _u - _C * _w + _u * _x + _v * _y + _w * _z) + ((_y - _B) * Lv + _v * (_A * _u + _C * _w - _u * _x - _w * _z)
                + Lv * _y) * Math.Cos(_Theta) + sqrL * (-_C * _u - _A * _w + _w * _x - _u * _z) * Math.Sin(_Theta)) / L;
            NewZ = (_C * Lw + _w * (-_A * _u - _B * _v + _u * _x + _v * _y + _w * _z) + ((_z - _C) * Lw + _w * (_A * _u + _B * _v - _u * _x - _v * _y)
                + Lw * _z) * Math.Cos(_Theta) + sqrL * (-_B * _u + _A * _v - _v * _x + _u * _y) * Math.Sin(_Theta)) / L;
            return NewZ;
        }

        void DrawShape(Graphics GraphicsObject)
        {
            newZ[0] = RotateObject(Theta, A, B, C, u, v, w, x[0], y[0], z[0], ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Theta, A, B, C, u, v, w, x[1], y[1], z[1], ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Theta, A, B, C, u, v, w, x[2], y[2], z[2], ref newX[2], ref newY[2]);
            Point[0] = new PointF((float)newX[0], (float)newY[0]);
            Point[1] = new PointF((float)newX[1], (float)newY[1]);
            Point[2] = new PointF((float)newX[2], (float)newY[2]);
            PointF[] CurvePoints = { Point[0], Point[1], Point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush MyBrush = new SolidBrush(Color.Blue);
            GraphicsObject.Clear(Color.White);
            GraphicsObject.DrawPolygon(MyPen, CurvePoints);
            GraphicsObject.FillPolygon(MyBrush, CurvePoints);
            PointF MyPoint1 = new PointF((float)A, (float)B);
            PointF MyPoint2 = new PointF((float)u, (float)v);
            Pen BlackPen = new Pen(Color.Black, 2);
            GraphicsObject.DrawLine(BlackPen, MyPoint1, MyPoint2);
        }
    }
}
