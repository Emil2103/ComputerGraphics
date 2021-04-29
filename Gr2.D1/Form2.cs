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
    public partial class Form2 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch, Yaw, Roll;
        List<Vertex> VertexList = new List<Vertex>();
        List<Surface> Surface_List = new List<Surface>();
        public Form2()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            Pitch = Factor * HScrollBarPitch.Value;
            Yaw = Factor * HScrollBarYaw.Value;
            Roll = Factor * HScrollBarRoll.Value;
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
        
        void Fill_Surface()
        {
            List<Surface> SurfList = new List<Surface>();
            Surface_List.Add(new Surface(new Vertex(0, 0, 0 - 50), new Vertex(100, 0, 0 - 50), new Vertex(100, 0, 100 - 50), new Vertex(0, 0, 100 - 50)));
            Surface_List.Add(new Surface(new Vertex(0, 0, 100 - 50), new Vertex(0, 100, 100 - 50), new Vertex(100, 100, 100 - 50), new Vertex(100, 0, 100 - 50)));
            Surface_List.Add(new Surface(new Vertex(0, 0, 100 - 50), new Vertex(0, 100, 100 - 50), new Vertex(0, 100, 0 - 50), new Vertex(0, 0, 0 - 50)));
            Surface_List.Add(new Surface(new Vertex(0, 0, 0 - 50), new Vertex(0, 100, 0 - 50), new Vertex(100, 100, 0 - 50), new Vertex(100, 0, 0 - 50)));
            Surface_List.Add(new Surface(new Vertex(100, 0, 0 - 50), new Vertex(100, 0, 100 - 50), new Vertex(100, 100, 100 - 50), new Vertex(100, 100, 0 - 50)));
            Surface_List.Add(new Surface(new Vertex(0, 100, 100 - 50), new Vertex(0, 100, 0 - 50), new Vertex(100, 100, 0 - 50), new Vertex(100, 100, 100 - 50)));
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
            NewX = (int)(m[0, 0] * _x + m[1, 0] * _y + m[2, 0] * _z);
            NewY = (int)(m[0, 1] * _x + m[1, 1] * _y + m[2, 1] * _z) ;
            NewZ = (int)(m[0, 2] * _x + m[1, 2] * _y + m[2, 2] * _z);
            Vertex NewVertex = new Vertex(NewX, NewY, NewZ);
            return NewVertex;
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

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            Pitch = Factor * HScrollBarPitch.Value;
            G.Clear(Color.White);
            DrawShape1(G);
            DrawShape(G);

        }

        private void HScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            Yaw = Factor * HScrollBarYaw.Value;
            G.Clear(Color.White);
            DrawShape1(G);
            DrawShape(G);
            
        }

        private void HScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            Roll = Factor * HScrollBarRoll.Value;
            G.Clear(Color.White);
            DrawShape1(G);
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


        void DrawShape(Graphics GraphicsObject)
        {
            int x0 = 0, y0 = 0, z0 = 5;
            int a = 100, b = 100, c = 100;
            int i, j, k, l;
            // Pen MyPen = new Pen(Color.Red);
            // Pen MyPen1 = new Pen(Color.Blue, 1);
            // Pen MyPen2 = new Pen(Color.Red, 1);
            // Pen MyPen3 = new Pen(Color.Green, 1);
            // Pen MyPen4 = new Pen(Color.Black, 1);
            // Pen MyPen5 = new Pen(Color.Yellow, 1);
            // Pen MyPen6 = new Pen(Color.Orchid, 1);
            SolidBrush MyBrush1 = new SolidBrush(Color.FromArgb(250 / 100 * 25, 25, 25, 112));
            SolidBrush MyBrush2 = new SolidBrush(Color.FromArgb(250 / 100 * 25, 255, 0, 0));
            SolidBrush MyBrush3 = new SolidBrush(Color.FromArgb(250 / 100 * 25, 0, 128, 0));
            SolidBrush MyBrush4 = new SolidBrush(Color.FromArgb(250 / 100 * 25, 0, 0, 0));
            SolidBrush MyBrush5 = new SolidBrush(Color.FromArgb(250 / 100 * 25, 255, 255, 0));
            SolidBrush MyBrush6 = new SolidBrush(Color.FromArgb(250 / 100 * 25, 218, 112, 214));

            //GraphicsObject.Clear(Color.White);
            for (i = x0; i < x0 + a; i += 5)
                for (j = y0; j < y0 + b; j += 5)
                {
                    double newx1 = 0, newy1 = 0, newz1;
                    newz1 = RotateObject(Pitch, Yaw, Roll, i, j, z0, ref newx1, ref newy1);
                    Rectangle MyBox = new Rectangle((int)newx1, (int)newy1, 7, 7);
                    GraphicsObject.FillRectangle(MyBrush5, MyBox);
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
                    GraphicsObject.FillRectangle(MyBrush1, MyBox1);
                    GraphicsObject.FillRectangle(MyBrush2, MyBox2);
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
                    GraphicsObject.FillRectangle(MyBrush3, MyBox3);
                    GraphicsObject.FillRectangle(MyBrush4, MyBox4);
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
                    GraphicsObject.FillRectangle(MyBrush6, MyBox);
                    //GraphicsObjet.DrawEllipse(MyPen6, MyBox);
                }
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            G.Transform = myMatrix;
        }

        void DrawShape1(Graphics GraphicObject)
        {
            int x0, y0, z0, R, m;
            x0 = 5;
            y0 = 5;
            z0 = 5;
            R = 50;
            m = 3;

            int ZMin;
            int Zmax;
            ZMin = z0 - R;
            Zmax = z0 + R;
            int i;
            int j;

            Pen MyPen1 = new Pen(Color.Blue, 1);
            Pen MyPen2 = new Pen(Color.Red, 1);
            for (i = ZMin; i <= Zmax; i += m)
            {
                int XMin;
                int XMax;
                XMin = (int)(x0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2)));
                XMax = (int)(x0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2)));
                int SmallR;
                SmallR = (int)(Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2)));
                for (j = XMin; j <= XMax; j += m)
                {
                    double y1;
                    double y2;
                    y1 = y0 + Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((j - x0), 2));
                    y2 = y0 - Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((j - x0), 2));
                    double NewX1 = 50;
                    double NewY1 = 50;
                    double NewZ1;
                    double NewX2 = 50;
                    double NewY2 = 50;
                    double NewZ2;
                    NewZ1 = RotateObject(Pitch, Yaw, Roll, j, y1, i, ref NewX1, ref NewY1) + 43;
                    NewZ2 = RotateObject(Pitch, Yaw, Roll, j, y2, i, ref NewX2, ref NewY2) + 43;
                    Rectangle MyBox1 = new Rectangle((int)NewX1 + 43, (int)NewY1 + 43, m, m);
                    Rectangle MyBox2 = new Rectangle((int)NewX2 + 43, (int)NewY2 + 43, m, m);
                    GraphicObject.DrawEllipse(MyPen1, MyBox1);
                    GraphicObject.DrawEllipse(MyPen2, MyBox2);

                }
            }
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            G.Transform = myMatrix;
        }
    }
}
