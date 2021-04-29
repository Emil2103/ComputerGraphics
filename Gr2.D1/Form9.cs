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
    public partial class Form9 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        const int Vertex_number = 3;
        double[] x = new double[Vertex_number];
        double[] y = new double[Vertex_number];
        double[] z = new double[Vertex_number];
        double[] newX = new double[Vertex_number];
        double[] newY = new double[Vertex_number];
        double[] newZ = new double[Vertex_number];
        PointF[] Point = new PointF[Vertex_number];
        double Pitch, Yaw, Roll, Theta;

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            Pitch = Factor * (HScrollBarPitch.Value);
            DrawShape(G);
        }

        private void HScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            Yaw = Factor * (HScrollBarYaw.Value);
            DrawShape(G);
        }

        private void HScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            Roll = Factor * (HScrollBarRoll.Value);
            DrawShape(G);
        }

        private void HScrollBarTheta_Scroll(object sender, ScrollEventArgs e)
        {
            Theta = Factor * (HScrollBarTheta.Value);
            DrawShape(G);
        }

        public Form9()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            HScrollBarPitch.Minimum = 1;
            HScrollBarPitch.Maximum = 369;
            HScrollBarYaw.Minimum = 1;
            HScrollBarYaw.Maximum = 369;
            HScrollBarRoll.Minimum = 1;
            HScrollBarRoll.Maximum = 369;
            HScrollBarTheta.Minimum = 1;
            HScrollBarTheta.Maximum = 369;
            x[0] = 200;
            y[0] = 100;
            x[1] = 300;
            y[1] = 300;
            x[2] = 400;
            y[2] = 100;
        }
        double RotateObject(double _Pitch, double _Yaw, double _Roll, double _a, double _x, double _y, double _z, ref double newx, ref double newy)
        {
            Double Temp = 1.0 - Math.Cos(_a);
            double newz;
            newx = _x * (_Pitch * Temp * _Pitch + Math.Cos(_a)) + _y * (_Yaw * Temp * _Pitch - Math.Sin(_a) * _Roll) +
                _z * (_Roll * Temp * _Pitch + Math.Sin(_a) * _Yaw);
            newy = _x * (_Pitch * Temp * _Yaw + Math.Sin(_a) * _Roll) + _y * (_Yaw * Temp * _Yaw + Math.Cos(_a)) +
                _z * (_Roll * Temp * _Yaw - Math.Sin(_a) * _Pitch);
            newz = _x * (_Pitch * Temp * _Roll - Math.Sin(_a) * _Yaw) + _y * (_Yaw * Temp * _Roll + Math.Sin(_a) * _Pitch) +
                _z * (_Roll * Temp * _Roll + Math.Cos(_a));
            return newz;
        }

        void DrawShape(Graphics GraphicsObject)
        {
            newZ[0] = RotateObject(Pitch, Yaw, Roll, Theta, x[0], y[0], z[0], ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Pitch, Yaw, Roll, Theta, x[1], y[1], z[1], ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Pitch, Yaw, Roll, Theta, x[2], y[2], z[2], ref newX[2], ref newY[2]);
            Point[0] = new PointF((float)newX[0], (float)newY[0]);
            Point[1] = new PointF((float)newX[1], (float)newY[1]);
            Point[2] = new PointF((float)newX[2], (float)newY[2]);
            PointF MyPoint = new PointF(0, 0);
            double L;
            L = 5 * pictureBox1.Width;
            double MyX, MyY;
            MyX = L * Math.Cos(Pitch);
            MyY = L * Math.Cos(Yaw);
            PointF MyPoint2 = new PointF((float)MyX, (float)MyY);
            Pen BlackPen = new Pen(Color.Black, 2);
            PointF[] CurvePoints = { Point[0], Point[1], Point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush MyBrush = new SolidBrush(Color.Blue);
            G.Clear(Color.White);
            GraphicsObject.DrawPolygon(MyPen, CurvePoints);
            GraphicsObject.FillPolygon(MyBrush, CurvePoints);
            GraphicsObject.DrawLine(BlackPen, MyPoint, MyPoint2);
        }
    }
}
