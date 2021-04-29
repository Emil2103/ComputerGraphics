using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static System.Math;


namespace Gr2.D1
{
    public partial class Form8 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        const int Vertex_number = 3;
        double Pitch, Yaw, Roll;
        public Form8()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            HScrollBarPitch.Minimum = 1;
            HScrollBarPitch.Maximum = 369;
            HScrollBarYaw.Minimum = 1;
            HScrollBarYaw.Maximum = 369;
            HScrollBarRoll.Minimum = 1;
            HScrollBarRoll.Maximum = 369;
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

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            Pitch = HScrollBarPitch.Value;
            DrawShape(G);
        }

        private void HScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            Yaw = HScrollBarYaw.Value;
            DrawShape(G);
        }

        private void HScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            Roll = HScrollBarRoll.Value;
            DrawShape(G);
        }

        double RotateObject(double _Pitch, double _Yaw, double _Roll, double _x, double _y, double _z, ref double NewX, ref double NewY)
        {
            double[,] m = new double[3, 3];
            m[0, 0] = Cos(Factor * _Yaw) * Cos(Factor * _Roll);
            m[0, 1] = -Cos(Factor * _Yaw) * Sin(Factor * _Roll);
            m[0, 2] = -Sin(Factor * _Yaw);

            m[1, 0] = Sin(Factor * _Pitch) * Sin(Factor * _Yaw) * Cos(Factor * _Roll) + Sin(Factor * _Roll) * Cos(Factor * _Pitch);
            m[1, 1] = -Sin(Factor * _Pitch) * Sin(Factor * _Yaw) * Sin(Factor * _Roll) + Cos(Factor * _Roll) * Cos(Factor * _Pitch);
            m[1, 2] = Cos(Factor * _Yaw);

            m[2, 0] = -Cos(Factor * _Pitch) * Sin(Factor * _Yaw) * Cos(Factor * _Roll) + Sin(Factor * _Pitch) * Sin(Factor * _Roll);
            m[2, 1] = Cos(Factor * _Pitch) * Sin(Factor * _Yaw) * Sin(Factor * _Roll) + Sin(Factor * _Pitch) * Cos(Factor * _Roll);
            m[2, 2] = Cos(Factor * _Yaw) * Cos(Factor * _Pitch);
            double NewZ;
            NewX = m[0, 0] * _x + m[1, 0] * _y + m[2, 0] * _z;
            NewY = m[0, 1] * _x + m[1, 1] * _y + m[2, 1] * _z;
            NewZ = m[0, 2] * _x + m[1, 2] * _y + m[2, 2] * _z;
            return NewZ;
        }

        void DrawShape(Graphics GraphicsObject)
        {
            newZ[0] = RotateObject(Pitch, Yaw, Roll, x[0], y[0], z[0], ref newX[0], ref newY[0]);
            newZ[1] = RotateObject(Pitch, Yaw, Roll, x[1], y[1], z[1], ref newX[1], ref newY[1]);
            newZ[2] = RotateObject(Pitch, Yaw, Roll, x[2], y[2], z[2], ref newX[2], ref newY[2]);

            Point[0] = new PointF((float)newX[0], (float)newY[0]);
            Point[1] = new PointF((float)newX[1], (float)newY[1]);
            Point[2] = new PointF((float)newX[2], (float)newY[2]);
            PointF[] CurvePoints = { Point[0], Point[1], Point[2] };
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush Mybrush = new SolidBrush(Color.Blue);
            GraphicsObject.Clear(Color.White);
            GraphicsObject.DrawPolygon(MyPen, CurvePoints);
            GraphicsObject.FillPolygon(Mybrush, CurvePoints);
        }
    }
}
