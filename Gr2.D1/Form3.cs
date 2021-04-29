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
    public partial class Form3 : Form
    {
        Graphics G;
        double Factor;
        double Pitch;
        double Yaw;
        double Roll;
        public Form3()
        {
            InitializeComponent();
            Factor = Math.PI / 180;
            Pitch = Factor * hScrollBarPitch.Value;
            Yaw = Factor * hScrollBarYaw.Value;
            Roll = Factor * hScrollBarRoll.Value;
            G = pictureBox1.CreateGraphics();
            G.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
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
            NewX = (int)(m[0, 0] * _x + m[1, 0] * _y + m[2, 0] * _z);
            NewY = (int)(m[0, 1] * _x + m[1, 1] * _y + m[2, 1] * _z);
            NewZ = (int)(m[0, 2] * _x + m[1, 2] * _y + m[2, 2] * _z);
            return NewZ;
        }

        void DrawShape(Graphics GraphicObject)
        {
            GraphicObject.Clear(Color.White);
            int R, r;
            double X, Y, Newx = 0, Newy = 0, Z;

            R = 60;
            r = 20;
            for (int i = 0; i < 360; i += 7)
            {
                for (int j = -180; j < 180; j += 7)
                {
                    X = (R + r * Cos(j)) * Cos(i);
                    Y = r * Sin(j);
                    Z = (R + r * Cos(j)) * Sin(i);
                    Z = RotateObject(Pitch, Yaw, Roll, X, Y, Z, ref Newx, ref Newy);
                    G.DrawEllipse(Pens.Red, (float)Newx - 1, (float)Newy - 1, 2, 2);
                }
            }
        }
       
        private void hScrollBarPitch_Scroll(object sender, ScrollEventArgs e)
        {
            Pitch = hScrollBarPitch.Value * Factor;
            DrawShape(G);
        }

        private void hScrollBarYaw_Scroll(object sender, ScrollEventArgs e)
        {
            Yaw = hScrollBarYaw.Value * Factor;
            DrawShape(G);
        }

        private void hScrollBarRoll_Scroll(object sender, ScrollEventArgs e)
        {
            Roll = hScrollBarRoll.Value * Factor;
            DrawShape(G);
        }
    }
}

