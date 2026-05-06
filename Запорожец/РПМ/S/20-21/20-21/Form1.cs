using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20_21
{
    public partial class Form1 : Form
    {
        private Point PreviousPoint, point;
        private Bitmap bmp;
        private Pen blackPen;
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blackPen = new Pen(Color.Black, 4);
        }

        // Открыть
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.PNG)|*.bmp;*.jpg;*.gif;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                bmp = new Bitmap(image, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
                g = Graphics.FromImage(pictureBox1.Image);
            }
        }

        // Нажатие мыши
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PreviousPoint.X = e.X;
            PreviousPoint.Y = e.Y;
        }

        // Движение мыши
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && bmp != null)
            {
                point.X = e.X;
                point.Y = e.Y;
                g.DrawLine(blackPen, PreviousPoint, point);
                PreviousPoint.X = point.X;
                PreviousPoint.Y = point.Y;
                pictureBox1.Invalidate();
            }
        }

        // Сохранить
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png";

            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(savedialog.FileName);
            }
        }

        // ЧБ
        private void button3_Click(object sender, EventArgs e)
        {
            if (bmp == null) return;

            // Циклы для перебора всех пикселей на изображении 
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    // Извлекаем значения цветовых каналов
                    Color currentPixel = bmp.GetPixel(i, j);
                    int R = currentPixel.R;
                    int G = currentPixel.G;
                    int B = currentPixel.B;

                    // Высчитываем яркость
                    int Gray = (R + G + B) / 3;

                    Color grayColor = Color.FromArgb(255, Gray, Gray, Gray);

                    // Записываем новый цвет обратно в пиксель
                    bmp.SetPixel(i, j, grayColor);
                }
            }

            // Принудительно перерисовываем форму, чтобы увидеть результат
            pictureBox1.Refresh();
        }

        // Мозаика
        private void button4_Click(object sender, EventArgs e)
        {
            if (bmp == null) return;

            int tileSize = 10;

            for (int x = 0; x < bmp.Width; x += tileSize)
            {
                for (int y = 0; y < bmp.Height; y += tileSize)
                {
                    // Вычисляем координаты центральной точки квадрата
                    int centerX = x + tileSize / 2;
                    int centerY = y + tileSize / 2;

                    // Проверяем, чтобы точка не вышла за границы изображения
                    if (centerX >= bmp.Width) centerX = bmp.Width - 1;
                    if (centerY >= bmp.Height) centerY = bmp.Height - 1;

                    // Получаем цвет средней точки
                    Color middleColor = bmp.GetPixel(centerX, centerY);

                    // Закрашиваем весь фрагмент этим цветом
                    for (int i = x; i < x + tileSize && i < bmp.Width; i++)
                    {
                        for (int j = y; j < y + tileSize && j < bmp.Height; j++)
                        {
                            bmp.SetPixel(i, j, middleColor);
                        }
                    }
                }
            }
            pictureBox1.Refresh();
        }
    }
}