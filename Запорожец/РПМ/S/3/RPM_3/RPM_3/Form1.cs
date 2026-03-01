using System;
using System.Globalization;
using System.Windows.Forms;

namespace RPM_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "2,444";
            textBox2.Text = "0,00869";
            textBox3.Text = "130";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                double x = double.Parse(textBox1.Text);
                double y = double.Parse(textBox2.Text);
                double z = double.Parse(textBox3.Text);

                // Числитель: x^(y+1) + e^(y-1)
                double numerator = Math.Pow(x, y + 1) + Math.Exp(y - 1);

                // Знаменатель: 1 + x * |y - tg(z)|
                double denominator = 1 + Math.Abs(x * (y - Math.Tan(z)));

                // Разность |y - x|
                double diff = Math.Abs(y - x);

                // Сборка формулы
                // (дробь) * (1 + diff) + (diff^2 / 2) - (diff^3 / 3)
                double h = (numerator / denominator) * (1 + diff) + (Math.Pow(diff, 2) / 2.0) - (Math.Pow(diff, 3) / 3.0);
                double result = h - 0.008;
                // Вывод
                textBox4.Clear();
                textBox4.AppendText($"X = {x}" + Environment.NewLine);
                textBox4.AppendText($"Y = {y}" + Environment.NewLine);
                textBox4.AppendText($"Z = {z}" + Environment.NewLine);
                textBox4.AppendText($"Результат h = {result:F5}");
        }
    }
}