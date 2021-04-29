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
    public partial class Form5 : Form
    {
        Graphics G;
        double Factor;
        double Pitch;
        double Yaw;
        double Roll;
        public Form5()
        {
            InitializeComponent();
            Factor = Math.PI / 180;
            Pitch = Factor * hScrollBarPitch.Value;
            Yaw = Factor * hScrollBarYaw.Value;
            Roll = Factor * hScrollBarRoll.Value;
            G = pictureBox1.CreateGraphics();
            G.TranslateTransform(0, 0);
        }

        void DrawShape(Graphics GraphicObject, int rad, int dx)
        {
            int x0, y0, z0, R, m;
            x0 = 5;
            y0 = 5;
            z0 = 5;
            R = rad;
            m = 2;
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
                    NewZ1 = RotateObject(Pitch, Yaw, Roll, j, y1, i, ref NewX1, ref NewY1);
                    NewZ2 = RotateObject(Pitch, Yaw, Roll, j, y2, i, ref NewX2, ref NewY2);
                    Rectangle MyBox1 = new Rectangle((int)NewX1 + dx, (int)NewY1, m, m);
                    Rectangle MyBox2 = new Rectangle((int)NewX2 + dx, (int)NewY2, m, m);
                    GraphicObject.DrawEllipse(MyPen1, MyBox1);
                    GraphicObject.DrawEllipse(MyPen2, MyBox2);
                }
            }
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(/*pictureBox1.Width / 2*/dx, pictureBox1.Height / 2, MatrixOrder.Append);
            G.Transform = myMatrix;
        }
        double RotateObject(double Pitch, double Yaw, double Roll, double x, double y, double z, ref double NewX, ref double NewY)
        {
            double[,] m = new double[3, 3];
            m[0, 0] = Cos(Yaw) * Cos(Roll);
            m[0, 1] = -Cos(Yaw) * Sin(Roll);
            m[0, 2] = -Sin(Yaw);
            m[1, 0] = Sin(Pitch) * Sin(Yaw) * Cos(Roll) + Sin(Roll) * Cos(Pitch);
            m[1, 1] = -Sin(Pitch) * Sin(Yaw) * Sin(Roll) + Cos(Roll) * Cos(Pitch);
            m[1, 2] = Cos(Yaw);
            m[2, 0] = -Cos(Pitch) * Sin(Yaw) * Cos(Roll) + Sin(Pitch) * Sin(Roll);
            m[2, 1] = Cos(Pitch) * Sin(Yaw) * Sin(Roll) + Sin(Pitch) * Cos(Roll);
            m[2, 2] = Cos(Yaw) * Cos(Pitch);
            double NewZ;
            NewX = (int)(m[0, 0] * x + m[1, 0] * y + m[2, 0] * z);
            NewY = (int)(m[0, 1] * x + m[1, 1] * y + m[2, 1] * z);
            NewZ = (int)(m[0, 2] * x + m[1, 2] * y + m[2, 2] * z);
            return NewZ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawShape(G, 20, 0);
            G.Clear(Color.White);
            DrawShape(G, 20, 20);
            DrawShape(G, 30, 20 + 30);
            DrawShape(G, 40, 20 + 30 + 40);
            DrawShape(G, 50, 20 + 30 + 40 + 50);
            DrawShape(G, 60, 20 + 30 + 40 + 50 + 60);
            DrawShape(G, 70, 20 + 30 + 40 + 50 + 60 + 70);
        }
    }
}
