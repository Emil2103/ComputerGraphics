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
    public partial class Form23 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch, Yaw, Roll;
        int m = 5;
        public Form23()
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
            FillClippedCone();
        }
        double RotateObject(double _Pitch, double _Yaw, double _Roll, double _x, double _y, double _z, ref double NewX, ref double NewY)
        {
            double[,] m = new double[3, 3];
            m[0, 0] = (Cos(_Yaw) * Cos(_Roll));
            m[0, 1] = (-Cos(_Yaw) * Sin(_Roll));
            m[0, 2] = (-Sin(_Yaw));
            m[1, 0] = (Sin(_Pitch) * Sin(_Yaw) * Cos(_Roll) + Sin(_Roll) * Cos(_Pitch));
            m[1, 1] = (-Sin(_Pitch) * Sin(_Yaw) * Sin(_Roll) + Cos(_Roll) * Cos(_Pitch));
            m[1, 2] = Cos(_Yaw);
            m[2, 0] = (-Cos(_Pitch) * Sin(_Yaw) * Cos(_Roll) + Sin(_Pitch) * Sin(_Roll));
            m[2, 1] = (Cos(_Pitch) * Sin(_Yaw) * Sin(_Roll) + Sin(_Pitch) * Cos(_Roll));
            m[2, 2] = (Cos(_Yaw) * Cos(Pitch));

            double NewZ;

            NewX = m[0, 0] * _x + m[1, 0] * _y + m[2, 0] * _z;
            NewY = m[0, 1] * _x + m[1, 1] * _y + m[2, 1] * _z;
            NewZ = m[0, 2] * _x + m[1, 2] * _y + m[2, 2] * _z;

            return NewZ;
        }

        public class Vertex_Coordinate
        {
            public double x;
            public double y;
            public double z;
            public Vertex_Coordinate(double _x, double _y, double _z)
            {
                x = _x;
                y = _y;
                z = _z;
            }
        }
        ArrayList GList = new ArrayList();
        double RotateAboutAlphaBeta(double _alpha, double _beta, double _x0, double _y0, double _z0, ref double _x, ref double _y)
        {
            double _z;
            double factor = Math.PI / 180;
            _x = Cos(_alpha) * _x0 + Sin(_alpha) * Sin(-_beta) * _y0 + Sin(_alpha) * Cos(-_beta) * _z0;
            _y = Cos(-_beta) * _y0 - Sin(-_beta) * _z0;
            _z = -Sin(_alpha) * _x0 + Cos(_alpha) * Sin(-_beta) * _y0 + Cos(_alpha) * Cos(-_beta) * _z0;
            return _z;
        }

        ArrayList GetClippedCone(double _Length, double _RBig, double _RSmall, double _m)
        {
            ArrayList MyList = new ArrayList();
            double i, j;
            double ZMin = 0, ZMax = _Length;
            for (i = ZMin; i < ZMax; i += m)
            {
                double XMax, XMin;
                double SmallR;
                SmallR = (_RBig - i * (_RBig - _RSmall) / _Length);
                XMin = -SmallR;
                XMax = SmallR;
                for (j = XMin; j < XMax; j += m)
                {
                    double YMin, YMax, x, z;
                    x = j;
                    z = i;
                    YMin = -Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x), 2));
                    YMax = Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x), 2));
                    MyList.Add(new Vertex_Coordinate(j, YMin, i));
                    MyList.Add(new Vertex_Coordinate(j, YMax, i));

                }
            }
            return MyList;
        }
        void FillClippedCone()
        {
            int Segments_Count = 3;
            double[] x = new double[4];
            double[] y = new double[4];
            double[] z = new double[4];
            double[] alpha = new double[4];
            double[] beta = new double[4];
            double[] Length = new double[4];
            double[] RBig = new double[4];
            double[] RSmall = new double[4];
            double m = 5;
            RBig[0] = 60;
            RSmall[0] = 50;
            RBig[1] = 50;
            RSmall[1] = 40;
            RBig[2] = 40;
            RSmall[2] = 30;
            double factor = Math.PI / 180;
            alpha[0] = factor * 15;
            beta[0] = factor * 25;
            alpha[1] = factor * 30;
            beta[1] = factor * 45;
            alpha[2] = factor * 15;
            beta[2] = factor * 30;
            Length[0] = 200;
            Length[1] = 150;
            Length[2] = 100;
            x[0] = 0;
            y[0] = 0;
            z[0] = 0;
            int i, j;
            for (i = 1; i <= Segments_Count; i++)
            {
                x[i] = x[(i - 1)] + (Length[(i - 1)] * Cos(beta[(i - 1)]) * Sin(alpha[(i - 1)]));
                y[i] = y[(i - 1)] + (Length[(i - 1)] * Sin(beta[(i - 1)]));
                z[i] = z[(i - 1)] + (Length[(i - 1)] * Cos(beta[(i - 1)]) * Cos(alpha[(i - 1)]));
                ArrayList MyList = new ArrayList();
                MyList = GetClippedCone(Length[(int)(i - 1)], RBig[(int)(i - 1)], RSmall[(int)(i - 1)], m);
                int MyListCount = MyList.Count - 1;
                for (j = 0; j <= MyListCount; j++)
                {
                    double x1, y1, z1, newx = 0, newy = 0, newz;
                    x1 = ((Vertex_Coordinate)MyList[(int)j]).x;
                    y1 = ((Vertex_Coordinate)MyList[(int)j]).y;
                    z1 = ((Vertex_Coordinate)MyList[(int)j]).z;
                    newz = RotateAboutAlphaBeta(alpha[(i - 1)], beta[(i - 1)], x1, y1, z1, ref newx, ref newy);
                    double nx, ny, nz;
                    nx = newx + x[(i - 1)];
                    ny = newy + y[(i - 1)];
                    nz = newz + z[(i - 1)];
                    GList.Add(new Vertex_Coordinate(nx, ny, nz));
                }
            }
        }
        void DrawShape(Graphics GraphicObject)
        {
            G.Clear(Color.White);
            int GlistCount = GList.Count - 1;
            int i;
            Pen MyPen = new Pen(Color.Red, 1);
            for (i = 0; i <= GlistCount; i++)
            {
                double x, y, z, newx = 0, newy = 0, newz;
                x = ((Vertex_Coordinate)GList[i]).x;
                y = ((Vertex_Coordinate)GList[i]).y;
                z = ((Vertex_Coordinate)GList[i]).z;
                newz = RotateObject(Pitch, Yaw, Roll, x, y, z, ref newx, ref newy);
                RectangleF MyBox = new RectangleF((float)newx, (float)newy, 1, 1);
                G.DrawEllipse(MyPen, MyBox);
            }
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2);
            G.Transform = myMatrix;

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
    }
}
