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
    public partial class Form10 : Form
    {
        Graphics G;
        const int Vertex_Number = 3;
        double[] x = new double[Vertex_Number];
        double[] y = new double[Vertex_Number];
        double[] z = new double[Vertex_Number];
        double[] newX = new double[Vertex_Number];
        double[] newY = new double[Vertex_Number];
        double[] newZ = new double[Vertex_Number];
        PointF[] Point = new PointF[Vertex_Number];
        double Factor = Math.PI / 180;
        double Pitch, Yaw, Roll, Theta, XOffset, YOffset, ZOffset;
        public Form10()
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
            HScrollBarXOffset.Minimum = Minimum;
            HScrollBarXOffset.Maximum = pictureBox1.Width;
            HScrollBarYOffset.Minimum = Minimum;
            HScrollBarYOffset.Maximum = pictureBox1.Width;
            HScrollBarZOffset.Minimum = Minimum;
            HScrollBarZOffset.Maximum = pictureBox1.Width;

            x[0] = 200;
            y[0] = 100;
            x[1] = 300;
            y[1] = 300;
            x[2] = 400;
            y[2] = 100;
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

        private void HScrollBarXOffset_Scroll(object sender, ScrollEventArgs e)
        {
            XOffset = HScrollBarXOffset.Value;
            DrawShape(G);
        }

        private void HScrollBarYOffset_Scroll(object sender, ScrollEventArgs e)
        {
            YOffset = HScrollBarYOffset.Value;
            DrawShape(G);
        }

        private void HScrollBarZOffset_Scroll(object sender, ScrollEventArgs e)
        {
            ZOffset = HScrollBarZOffset.Value;
            DrawShape(G);
        }

        private void HScrollBarTheta_Scroll(object sender, ScrollEventArgs e)
        {
            Theta = Factor * HScrollBarTheta.Value;
            DrawShape(G);
        }
        double RotateObject(double _Theta, double _Pitch, double _Yaw, double _Roll, double _x, double _y, double _z,
            double x0, double y0, double z0, ref double NewX, ref double NewY)
        {
            double temp = 1.0 - Math.Cos(_Theta);
            double NewZ;
            NewX = x0 + (_x - x0) * (_Pitch * temp * _Pitch + Math.Cos(_Theta)) + (_y - y0) * (_Yaw * temp * _Pitch - Math.Sin(_Theta) * _Roll) + (_z - z0) *
                (_Roll * temp * _Pitch + Math.Sin(_Theta) * _Yaw);
            NewY = y0 + (_x - x0) * (_Pitch * temp * _Yaw + Math.Sin(_Theta) * _Roll) + (_y - y0) * (_Yaw * temp * _Yaw + Math.Cos(_Theta)) + (_z - z0) *
                (_Roll * temp * _Yaw - Math.Sin(_Theta) * _Pitch);
            NewZ = z0 + (_x - x0) * (_Pitch * temp * _Roll - Math.Sin(_Theta) * _Yaw) + (_y - y0) * (_Yaw * temp * _Roll + Math.Sin(_Theta) * _Pitch) + (_z - z0) *
                (_Roll * temp * _Roll + Math.Cos(_Theta));
            return NewZ;
        }
        void DrawShape(Graphics GraphicsObject)
        {
            newZ[0] = RotateObject(Theta, Pitch, Yaw, Roll, x[0], y[0], z[0], XOffset, YOffset, ZOffset, ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Theta, Pitch, Yaw, Roll, x[1], y[1], z[1], XOffset, YOffset, ZOffset, ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Theta, Pitch, Yaw, Roll, x[2], y[2], z[2], XOffset, YOffset, ZOffset, ref newX[2], ref newY[2]);
            Point[0] = new PointF((float)newX[0], (float)newY[0]);
            Point[1] = new PointF((float)newX[1], (float)newY[1]);
            Point[2] = new PointF((float)newX[2], (float)newY[2]);
            Rectangle MyRectangle = new Rectangle((int)XOffset, (int)YOffset, 5, 5);
            Pen BlackPen = new Pen(Color.Black, 2);
            PointF[] CurvePoints = { Point[0], Point[1], Point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush MyBrush = new SolidBrush(Color.Blue);
            GraphicsObject.Clear(Color.White);
            GraphicsObject.DrawEllipse(BlackPen, MyRectangle);
            double L = 5 * pictureBox1.Width;
            PointF MyPoint1 = new PointF(0, 0);
            PointF MyPoint2 = new PointF((float)(L * Math.Cos(Pitch)), (float)(L * Math.Cos(Yaw)));
            GraphicsObject.DrawLine(MyPen, MyPoint1, MyPoint2);
            GraphicsObject.DrawPolygon(MyPen, CurvePoints);
            GraphicsObject.FillPolygon(MyBrush, CurvePoints);
        }
    }
}
