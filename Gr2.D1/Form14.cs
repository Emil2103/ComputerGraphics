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
    public partial class Form14 : Form
    {
        Graphics G;
        double Factor = Math.PI / 180;
        public Form14()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();
            FillCube();
            int Minimum = 0, Maximum = 369;
            HScrollBarPitch.Minimum = Minimum;
            HScrollBarPitch.Maximum = Maximum;
            HScrollBarYaw.Minimum = Minimum;
            HScrollBarYaw.Maximum = Maximum;
            HScrollBarRoll.Minimum = Minimum;
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
        double Pitch;
        double Yaw;
        double Roll;
        public class Vertex
        {
            public double x, y, z;

            public Vertex(double _x, double _y, double _z)
            {
                x = _x;
                y = _y;
                z = _z;
            }
        }
        public class Side
        {
            Vertex a;
            Vertex b;
            Vertex c;
            Vertex d;
            public Side(Vertex _a, Vertex _b, Vertex _c, Vertex _d)
            {
                a = _a;
                b = _b;
                c = _c;
                d = _d;
            }
        }
        Vertex[] VertexList = new Vertex[8];
        ArrayList SideList = new ArrayList();

        void FillCube()
        {
            VertexList[0] = new Vertex(0, 0, 0);
            VertexList[1] = (new Vertex(100, 0, 0));
            VertexList[2] = (new Vertex(100, 0, 100));
            VertexList[3] = (new Vertex(0, 0, 100));
            VertexList[4] = (new Vertex(0, 100, 0));
            VertexList[5] = (new Vertex(100, 100, 0));
            VertexList[6] = (new Vertex(100, 100, 100));
            VertexList[7] = (new Vertex(0, 100, 100));
            SideList.Add(new Side((Vertex)VertexList[0], (Vertex)VertexList[1], (Vertex)VertexList[2], (Vertex)VertexList[3]));
            SideList.Add(new Side((Vertex)VertexList[4], (Vertex)VertexList[5], (Vertex)VertexList[6], (Vertex)VertexList[7]));
            SideList.Add(new Side((Vertex)VertexList[6], (Vertex)VertexList[5], (Vertex)VertexList[1], (Vertex)VertexList[2]));
            SideList.Add(new Side((Vertex)VertexList[7], (Vertex)VertexList[4], (Vertex)VertexList[0], (Vertex)VertexList[3]));
            SideList.Add(new Side((Vertex)VertexList[0], (Vertex)VertexList[4], (Vertex)VertexList[5], (Vertex)VertexList[1]));
            SideList.Add(new Side((Vertex)VertexList[7], (Vertex)VertexList[6], (Vertex)VertexList[2], (Vertex)VertexList[3]));


        }
        double RotateObject(double _Pitch, double _Yaw, double _Roll, double _x, double _y, double _z, ref double _NewX, ref double _NewY)
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
            double _NewZ;
            _NewX = m[0, 0] * _x + m[1, 0] * _y + m[2, 0] * _z;
            _NewY = m[0, 1] * _x + m[1, 1] * _y + m[2, 1] * _z;
            _NewZ = m[0, 2] * _x + m[1, 2] * _y + m[2, 2] * _z;
            return _NewZ;
        }

        void DrawShape(Graphics GraphicsObject)
        {

            int ArraySize = 8;
            double[] NewX = new double[ArraySize];
            double[] NewY = new double[ArraySize];
            double[] NewZ = new double[ArraySize];
            int i;
            Pen MyPen = new Pen(Color.Red, 2);
            SolidBrush MyBrush = new SolidBrush(Color.Blue);
            GraphicsObject.Clear(Color.White);
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            G.Transform = myMatrix;
            for (int j = 0; j < ArraySize; j++)
            {
                NewZ[j] = RotateObject(Pitch, Yaw, Roll, VertexList[j].x, VertexList[j].y, VertexList[j].z, ref NewX[j], ref NewY[j]);
                Rectangle MyBox = new Rectangle((int)NewX[j], (int)NewY[j], 10, 10);
                GraphicsObject.DrawEllipse(MyPen, MyBox);
                GraphicsObject.FillEllipse(MyBrush, MyBox);
            }
        }
    }
}
