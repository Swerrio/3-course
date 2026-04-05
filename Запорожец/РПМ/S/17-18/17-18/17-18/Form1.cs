using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17_18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.SkyBlue);

            // солнце
            SolidBrush sunBrush = new SolidBrush(Color.Yellow);
            g.FillEllipse(sunBrush, 50, 50, 80, 80);

            // Лучи солнца
            Pen rayPen = new Pen(Color.Orange, 3);
            rayPen.DashStyle = DashStyle.Dash;
            g.DrawLine(rayPen, 90, 40, 90, 10);

            rayPen.DashStyle = DashStyle.DashDot;
            g.DrawLine(rayPen, 140, 90, 180, 90);

            // Трава
            SolidBrush grassBrush = new SolidBrush(Color.ForestGreen);
            g.FillRectangle(grassBrush, 0, 300, this.Width, this.Height - 300);

            // Дом
            SolidBrush houseBrush = new SolidBrush(Color.BurlyWood);
            g.FillRectangle(houseBrush, 200, 200, 150, 150);
            g.DrawRectangle(Pens.Black, 200, 200, 150, 150);

            // Крыша
            Point[] roofPoints = {
                new Point(200, 200),
                new Point(350, 200),
                new Point(275, 120)
            };
            g.FillPolygon(Brushes.Brown, roofPoints);
            g.DrawPolygon(Pens.Black, roofPoints);

            // Забор
            Pen fencePen = new Pen(Color.SaddleBrown, 4);
            for (int x = 10; x < 180; x += 20)
            {
                g.DrawLine(fencePen, x, 320, x, 280);
            }
            g.DrawLine(fencePen, 5, 300, 185, 300);

            // Облако
            g.FillEllipse(Brushes.White, 400, 60, 100, 50);
            g.FillEllipse(Brushes.White, 430, 40, 80, 60);
        }
    }
}
