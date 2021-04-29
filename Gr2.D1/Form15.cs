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
    public partial class Form15 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch, Yaw, Roll;
        public Form15()
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
            Fill_Surface();
        }

        public class Vertex
        {
            public int x;
            public int y;
            public int z;
            public Vertex(int _x, int _y, int _z)
            {
                x = _x;
                y = _y;
                z = _z;
            }
        }

        public class Surface
        {
            public Vertex x1;
            public Vertex x2;
            public Vertex x3;
            public Vertex x4;

            public Surface(Vertex _x1, Vertex _x2, Vertex _x3, Vertex _x4)
            {
                x1 = _x1;
                x2 = _x2;
                x3 = _x3;
                x4 = _x4;
            }
        }

        ArrayList Surface_List = new ArrayList();
        void Fill_Surface()
        {
            ArrayList SurfList = new ArrayList();
            Surface_List.Add(new Surface(new Vertex(0, 0, 0), new Vertex(100, 0, 0), new Vertex(100, 0, 100), new Vertex(0, 0, 100)));
            Surface_List.Add(new Surface(new Vertex(0, 0, 100), new Vertex(0, 100, 100), new Vertex(100, 100, 100), new Vertex(100, 0, 100)));
            Surface_List.Add(new Surface(new Vertex(0, 0, 100), new Vertex(0, 100, 100), new Vertex(0, 100, 0), new Vertex(0, 0, 0)));
            Surface_List.Add(new Surface(new Vertex(0, 0, 0), new Vertex(0, 100, 0), new Vertex(100, 100, 0), new Vertex(100, 0, 0)));
            Surface_List.Add(new Surface(new Vertex(100, 0, 0), new Vertex(100, 0, 100), new Vertex(100, 100, 100), new Vertex(100, 100, 0)));
            Surface_List.Add(new Surface(new Vertex(0, 100, 100), new Vertex(0, 100, 0), new Vertex(100, 100, 0), new Vertex(100, 100, 100)));
        }
        Vertex RotateVertex(double _Pitch, double _Yaw, double _Roll, Vertex MyVertex)
        {
            int _x, _y, _z;
            int NewX, NewY, NewZ;
            _x = MyVertex.x;
            _y = MyVertex.y;
            _z = MyVertex.z;
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
            NewX = (int)(m[0, 0] * _x + m[1, 0] * _y + m[2, 0] * _z) + 50;
            NewY = (int)(m[0, 1] * _x + m[1, 1] * _y + m[2, 1] * _z);
            NewZ = (int)(m[0, 2] * _x + m[1, 2] * _y + m[2, 2] * _z);
            Vertex NewVertex = new Vertex(NewX, NewY, NewZ);
            return NewVertex;
        }

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            Pitch = Factor * HScrollBarPitch.Value;
            DrawShape(G);
        }

        private void HScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            Roll = Factor * HScrollBarRoll.Value;
            DrawShape(G);
        }

        private void HScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            Yaw = Factor * HScrollBarYaw.Value;
            DrawShape(G);
        }

        Surface RotateSurface(double _Pitch, double _Yaw, double _Roll, Surface MySurface)
        {
            Vertex x1, x2, x3, x4;
            x1 = MySurface.x1;
            x2 = MySurface.x2;
            x3 = MySurface.x3;
            x4 = MySurface.x4;
            Vertex NewX1, NewX2, NewX3, NewX4;
            NewX1 = RotateVertex(_Pitch, _Yaw, _Roll, x1);
            NewX2 = RotateVertex(_Pitch, _Yaw, _Roll, x2);
            NewX3 = RotateVertex(_Pitch, _Yaw, _Roll, x3);
            NewX4 = RotateVertex(_Pitch, _Yaw, _Roll, x4);
            Surface NewSurface = new Surface(NewX1, NewX2, NewX3, NewX4);
            return NewSurface;
        }

        void DrawShape(Graphics GraphicsObject)
        {
            int Surface_Count;
            Surface_Count = Surface_List.Count;
            int i;
            SolidBrush[] MyBrush = {new SolidBrush(Color.Blue), new SolidBrush(Color.Red),
                new SolidBrush(Color.Black), new SolidBrush(Color.Purple),
                new SolidBrush(Color.Orchid), new SolidBrush(Color.Green)};
            Pen[] MyPen = {new Pen(Color.Blue, 1), new Pen(Color.Red, 1), new Pen(Color.Black, 1), new Pen(Color.Purple, 1),
                new Pen(Color.Orchid, 1), new Pen(Color.Green, 1) };
            GraphicsObject.Clear(Color.White);
            for (i = 0; i < Surface_Count - 1; i++)
            {
                Surface _x, newx;
                _x = (Surface)Surface_List[i];
                newx = RotateSurface(Pitch, Yaw, Roll, _x);
                PointF[] CurvePoints = {new PointF(newx.x1.x, newx.x1.y), new PointF(newx.x2.x, newx.x2.y), new PointF(newx.x3.x, newx.x3.y),
                    new PointF(newx.x4.x, newx.x4.y)};
                FillMode NewFillMode = FillMode.Winding;
                G.DrawPolygon(MyPen[i], CurvePoints);
            }
            int XStart, YStart;
            XStart = pictureBox1.Width / 2;
            YStart = pictureBox1.Height / 2;
            Matrix MyMatrix = new Matrix();
            MyMatrix.Translate(XStart, YStart);
            GraphicsObject.Transform = MyMatrix;
        }
    }
}
