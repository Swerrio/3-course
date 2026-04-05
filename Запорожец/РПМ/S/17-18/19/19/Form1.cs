using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19
{
    public partial class Form1 : Form
    {
        // Угол
        private double angleEarth = 0;
        private double angleMoon = 0;

        // Радиусы орбит
        private const int sunOrbitRadius = 150;
        private const int earthOrbitRadius = 40;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Важно для плавной анимации
            this.BackColor = Color.Black; // Космос
            this.Paint += new PaintEventHandler(Form1_Paint);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ClientSize.Width / 2;
            int cy = ClientSize.Height / 2;

            // Рисуем Солнце
            g.FillEllipse(Brushes.Yellow, cx - 30, cy - 30, 60, 60);

            // Рассчитываем координаты Земли
            int earthX = cx + (int)(sunOrbitRadius * Math.Cos(angleEarth));
            int earthY = cy + (int)(sunOrbitRadius * Math.Sin(angleEarth));

            // Рисуем орбиту Земли (пунктиром)
            Pen orbitPen = new Pen(Color.DimGray, 1);
            orbitPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawEllipse(orbitPen, cx - sunOrbitRadius, cy - sunOrbitRadius, sunOrbitRadius * 2, sunOrbitRadius * 2);

            // Рисуем Землю
            g.FillEllipse(Brushes.DeepSkyBlue, earthX - 12, earthY - 12, 24, 24);

            // Рассчитываем координаты Луны (относительно Земли!)
            int moonX = earthX + (int)(earthOrbitRadius * Math.Cos(angleMoon));
            int moonY = earthY + (int)(earthOrbitRadius * Math.Sin(angleMoon));

            // Рисуем Луну
            g.FillEllipse(Brushes.LightGray, moonX - 5, moonY - 5, 10, 10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Увеличиваем углы
            angleEarth += 0.02;
            angleMoon += 0.08;

            // Перерисовываем форму
            Invalidate();
        }
    }
}
