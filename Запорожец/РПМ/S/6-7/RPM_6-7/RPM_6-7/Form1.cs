using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPM_6_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                // 1. Считывание исходных данных из TextBox
                double x0 = Convert.ToDouble(textBox1.Text);
                double xk = Convert.ToDouble(textBox2.Text);
                double dx = Convert.ToDouble(textBox3.Text);
                double b = Convert.ToDouble(textBox4.Text);

                textBox5.Clear();
                textBox5.AppendText("Результаты табулирования (Вариант 15):" + Environment.NewLine);

                // 2. Цикл табулирования
                double x = x0;

            // Используем небольшую добавку (dx/2), чтобы избежать проблем с точностью double
            while (x >= (xk + dx / 2))
            {
                    // Формула: y = 10^-3 * |x|^(5/2) + ln|x + b|
                    double y = Math.Pow(10, -3) * Math.Pow(Math.Abs(x), 2.5) + Math.Log(Math.Abs(x + b));

                    // Вывод строки значений
                    textBox5.AppendText($"x = {x:F2}; y = {y:F5}" + Environment.NewLine);

                    // Шаг
                    x += dx;
                }
            }
        }
    }
