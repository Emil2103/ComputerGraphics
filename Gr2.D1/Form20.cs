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
    public partial class Form20 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        double Pitch, Yaw, Roll;
        public Form20()
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
        void DrawShape(Graphics GraphicObject)
        {
            int x0, y0, z0, R, m;
            x0 = 5;
            y0 = 5;
            z0 = 5;
            R = 50;
            m = 5;
            GraphicObject.Clear(Color.White);
            int ZMin, Zmax;
            ZMin = z0 - R;
            Zmax = z0 + R;
            int i, j;
            SolidBrush MyBrush1 = new SolidBrush(Color.Blue);
            SolidBrush MyBrush2 = new SolidBrush(Color.Red);
            //Pen MyPen1 = new Pen(Color.Blue, 1);
            //Pen MyPen2 = new Pen(Color.Red, 1);
            for (i = ZMin; i < Zmax; i += m)
            {
                int XMin, XMax;
                XMin = (int)(x0 - Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2)));
                XMax = (int)(x0 + Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2)));
                double SmallR;
                SmallR = Math.Sqrt(Math.Pow(R, 2) - Math.Pow((i - z0), 2));
                for (j = XMin; j < XMax; j += m)
                {
                    double y1, y2;
                    y1 = y0 + Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((j - x0), 2));
                    y2 = y0 - Math.Sqrt(Math.Pow(SmallR, 2) - Math.Pow((j - x0), 2));
                    double NewX1 = 0, NewY1 = 0, NewZ1;
                    double NewX2 = 0, NewY2 = 0, NewZ2;
                    NewZ1 = RotateObject(Pitch, Yaw, Roll, j, y1, i, ref NewX1, ref NewY1);
                    NewZ2 = RotateObject(Pitch, Yaw, Roll, j, y2, i, ref NewX2, ref NewY2);
                    RectangleF MyBox1 = new RectangleF((float)NewX1, (float)NewY1, 10, 10);
                    RectangleF MyBox2 = new RectangleF((float)NewX2, (float)NewY2, 10, 10);
                    GraphicObject.FillEllipse(MyBrush1, MyBox1);
                    GraphicObject.FillEllipse(MyBrush2, MyBox2);
                    //GraphicObject.DrawEllipse(MyPen1, MyBox1);
                    //GraphicObject.DrawEllipse(MyPen2, MyBox2);
                }
            }
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            G.Transform = myMatrix;
        }
    }
}
