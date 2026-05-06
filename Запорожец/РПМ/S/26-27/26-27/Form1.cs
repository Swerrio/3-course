using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26_27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Blue, 2);

            int count = (int)numCount.Value;
            int initialSize = 20;
            int step = 20;
            DrawRecursiveSquare(g, myPen, count, initialSize, step);
        }

        // Рекурсивный метод
        private void DrawRecursiveSquare(Graphics g, Pen pen, int n, int size, int step)
        {
            if (n <= 0) return;

            // Находим центр экрана
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Вычисляем верхний левый угол квадрата, чтобы он был центрирован
            int x = centerX - size / 2;
            int y = centerY - size / 2;

            // Рисуем квадрат
            g.DrawRectangle(pen, x, y, size, size);

            // уменьшаем счетчик n и увеличиваем размер
            DrawRecursiveSquare(g, pen, n - 1, size + step, step);
        }
    }
}