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
    public partial class Form22 : Form
    {

        public Form22()
        {
            InitializeComponent();
        }
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch = 0;
        double Yaw = 0;
        double Roll = 0;
        public double RotateObject(double Pitch, double Yaw, double Roll, double x, double y, double z, ref double NewX, ref double NewY)
        {
            double[,] m = new double[4, 4];
            m[1, 1] = Math.Cos(Yaw) * Math.Cos(Roll);
            m[1, 2] = -Math.Cos(Yaw) * Math.Sin(Roll);
            m[1, 3] = -Math.Sin(Yaw);
            m[2, 1] = Math.Sin(Pitch) * Math.Sin(Yaw) * Math.Cos(Roll) + Math.Sin(Roll) * Math.Cos(Pitch);
            m[2, 2] = -Math.Sin(Pitch) * Math.Sin(Yaw) * Math.Sin(Roll) + Math.Cos(Roll) * Math.Cos(Pitch);
            m[2, 3] = Math.Cos(Yaw);
            m[3, 1] = -Math.Cos(Pitch) * Math.Sin(Yaw) * Math.Cos(Roll) + Math.Sin(Pitch) * Math.Sin(Roll);
            m[3, 2] = Math.Cos(Pitch) * Math.Sin(Yaw) * Math.Sin(Roll) + Math.Sin(Pitch) * Math.Cos(Roll);
            m[3, 3] = Math.Cos(Yaw) * Math.Cos(Pitch);
            double NewZ;
            NewX = m[1, 1] * x + m[2, 1] * y + m[3, 1] * z;
            NewY = m[1, 2] * x + m[2, 2] * y + m[3, 2] * z;
            NewZ = m[1, 3] * x + m[2, 3] * y + m[3, 3] * z;
            return NewZ;
        }
        public class Vertex_Coordinate
        {
            public int x;
            public int y;
            public int z;
            public Vertex_Coordinate(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        ArrayList MyList = new ArrayList();
        ArrayList NewList = new ArrayList();
        double a, b, c, H, d, x0, y0, z0, R, L;

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

        private void HScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            Pitch = Factor * HScrollBarPitch.Value;
            DrawShape(G);
        }

        int m;

        private void Form22_Load(object sender, EventArgs e)
        {
            G = pictureBox1.CreateGraphics();
            x0 = 0;
            y0 = 0;
            z0 = 0;
            R = 100;
            m = 5;
            L = 200;
            a = 50;
            b = 100;
            c = 150;
            H = 300;
            d = 150;
            Fill_Cone();
        }
        void Fill_Cone()
        {
            int i, j;
            double ZMin, ZMax;
            ZMin = z0;
            ZMax = z0 + H;
            for (i = (int)ZMin; i <= ZMax; i += m)
            {
                double XMin, XMax;
                double SmallR;
                SmallR = (R / H) * (H + z0 - i);
                XMin = x0 - SmallR;
                XMax = x0 + SmallR;

                for (j = (int)XMin; j <= XMax; j += m)
                {
                    int YMin;
                    int YMax;
                    int x;
                    int z;
                    x = j;
                    z = i;
                    YMin = (int)(y0 - Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x - x0), 2)));
                    YMax = (int)(y0 + Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((x - x0), 2)));
                    MyList.Add(new Vertex_Coordinate(j, YMin, i));
                    MyList.Add(new Vertex_Coordinate(j, YMax, i));
                }
            }
        }
        int RotateAboutAlphaBeta(double alpha, double beta, int x0, int y0, int z0, ref int x, ref int y)
        {
            int z;
            double factor;
            factor = Math.PI / 180;
            x = (int)(Math.Cos(alpha) * x0 + Math.Sin(alpha) * Math.Sin(-beta) * y0 + Math.Sin(alpha) * Math.Cos(-beta) * z0);
            y = (int)(Math.Cos(-beta) * y0 - Math.Sin(-beta) * z0);
            z = (int)(-Math.Sin(alpha) * x0 + Math.Cos(alpha) * Math.Sin(-beta) * y0 + Math.Cos(alpha) * Math.Cos(-beta) * z0);
            return z;
        }
        void DrawShape(Graphics GraphicObject)
        {
            double x1, y1, z1, x2, y2, z2;
            double newx0, newy0, newz0, newx1, newy1, newz1, newx2, newy2, newz2;
            newx0 = 0;
            newy0 = 0;
            newz0 = 0;
            newx1 = 0;
            newy1 = 0;
            newz1 = 0;
            newx2 = 0;
            newy2 = 0;
            newz2 = 0;
            x1 = x0;
            y1 = y0;
            z1 = z0 + H;
            double factor;
            factor = Math.PI / 180;
            double alpha;
            double beta;
            alpha = Math.PI / 4;
            beta = Math.PI / 4;
            x2 = (int)(H * Math.Sin(alpha) * Math.Cos(beta));
            y2 = (int)(H * Math.Sin(beta));
            z2 = (int)(H * Math.Cos(alpha) * Math.Cos(beta));
            newz0 = RotateObject(Pitch, Yaw, Roll, x0, y0, z0, ref newx0, ref newy0);
            newz1 = RotateObject(Pitch, Yaw, Roll, x1, y1, z1, ref newx1, ref newy1);
            newz2 = RotateObject(Pitch, Yaw, Roll, x2, y2, z2, ref newx2, ref newy2);
            Pen MyPen1 = new Pen(Color.Blue, 1);
            Pen MyPen2 = new Pen(Color.Red, 1);
            Point Point0 = new Point((int)newx0, (int)newy0);
            Point Point1 = new Point((int)newx1, (int)newy1);
            Point Point2 = new Point((int)newx2, (int)newy2);
            G.Clear(Color.White);
            G.DrawLine(MyPen1, Point0, Point1);
            G.DrawLine(MyPen2, Point0, Point2);
            int ListCount;
            ListCount = MyList.Count - 1;
            int i;
            Pen MyPen = new Pen(Color.Green, 1);
            Pen MyPen3 = new Pen(Color.Brown, 1);
            for (i = 0; i <= ListCount; i++)
            {
                int x;
                int y;
                int z;
                double newx = 0;
                double newy = 0;
                double newz = 0;
                x = ((Vertex_Coordinate)MyList[i]).x;
                y = ((Vertex_Coordinate)MyList[i]).y;
                z = ((Vertex_Coordinate)MyList[i]).z;
                int myx = 0;
                int myy = 0;
                int myz = 0;
                double newmyx = 0;
                double newmyy = 0;
                double newmyz = 0;
                myz = RotateAboutAlphaBeta(alpha, beta, x, y, z, ref myx, ref myy);
                newmyz = RotateObject(Pitch, Yaw, Roll, myx, myy, myz, ref newmyx, ref newmyy);
                newz = RotateObject(Pitch, Yaw, Roll, x, y, z, ref newx, ref newy);
                Rectangle MyBox1 = new Rectangle((int)newx, (int)newy, 1, 1);
                Rectangle MyBox2 = new Rectangle((int)newmyx, (int)newmyy, 1, 1);
                G.DrawEllipse(MyPen, MyBox1);
                G.DrawEllipse(MyPen3, MyBox2);
            }
            int xstart;
            int ystart;
            xstart = pictureBox1.Width / 2;
            ystart = pictureBox1.Height / 2;
            Matrix MyMatrix = new Matrix();
            MyMatrix.Translate(xstart, ystart);
            G.Transform = MyMatrix;
        }



    }
    
}
