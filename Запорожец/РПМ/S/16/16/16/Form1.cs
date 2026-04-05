using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtXmin.Text = "1";
            txtXmax.Text = "4";
            txtStep.Text = "0,1";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // Константы
            double y = 0.869 * Math.Pow(10, -2);
            double z = 0.13 * Math.Pow(10, 3);

            // Параметры графика из текстовых полей
            double xMin = double.Parse(txtXmin.Text);
            double xMax = double.Parse(txtXmax.Text);
            double step = double.Parse(txtStep.Text);

            int count = (int)Math.Ceiling((xMax - xMin) / step) + 1;
            double[] xValues = new double[count];
            double[] hValues = new double[count];

            // Цикл расчета
            for (int i = 0; i < count; i++)
            {
                double x = xMin + step * i;
                xValues[i] = x;

                // Считаем формулу по частям
                double absYX = Math.Abs(y - x);

                double numerator = Math.Pow(x, y + 1) + Math.Exp(y - 1);
                double denominator = 1 + x * Math.Abs(y - Math.Tan(z));

                double part1 = (numerator / denominator) * (1 + absYX);
                double part2 = Math.Pow(absYX, 2) / 2.0;
                double part3 = Math.Pow(absYX, 3) / 3.0;

                hValues[i] = part1 + part2 - part3;
            }

            // Настройка осей и вывод
            chart1.ChartAreas[0].AxisX.Minimum = xMin;
            chart1.ChartAreas[0].AxisX.Maximum = xMax;

            chart1.Series[0].Points.DataBindXY(xValues, hValues);
        }
    }
}
