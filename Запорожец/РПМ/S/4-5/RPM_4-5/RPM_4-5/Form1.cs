using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPM_4_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                // 1. Получение данных
                double x = Convert.ToDouble(textBox1.Text);
                double y = Convert.ToDouble(textBox2.Text);
                double z = Convert.ToDouble(textBox3.Text);
                double fx = 0;

                // Выбор функции f(x)
                if (radioButton1.Checked) fx = Math.Sinh(x); // sh(x)
                else if (radioButton2.Checked) fx = Math.Pow(x, 2); // x^2
                else if (radioButton3.Checked) fx = Math.Exp(x); // e^x

                // Нахождение min(f(x), y)
                double min_val;
                if (fx < y) min_val = fx;
                else min_val = y;

                // Нахождение max(min_val, z)
                double r;
                if (min_val > z) r = min_val;
                else r = z;

                // Вывод результатов
                textBox4.Clear();
                textBox4.AppendText("Результаты" + Environment.NewLine);
                textBox4.AppendText($"При X={x}, Y={y}, Z={z}" + Environment.NewLine);
                textBox4.AppendText($"f(x) = {fx:F5}" + Environment.NewLine);
                textBox4.AppendText($"Результат r = {r:F5}");
            }
        }
    }
