using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int n = 12; // Размер матрицы
            int[,] Y = new int[n, n];
            Random rand = new Random();

            // Настройка таблицы
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            listBox1.Items.Clear();

            // Заполнение матрицы и вывод в таблицу
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y[i, j] = rand.Next(1, 100);
                    dataGridView1.Rows[i].Cells[j].Value = Y[i, j];

                    dataGridView1.Columns[j].Width = 35;
                }
            }

            // Расчет сумм по СТОЛБЦАМ
            // Внешний цикл j номер столбца
            for (int j = 0; j < n; j++)
            {
                int columnSum = 0;
                for (int i = 0; i < n; i++)
                {
                    columnSum += Y[i, j]; // Суммируем элементы в текущем столбце j
                }

                // Выводим результат для каждого столбца
                listBox1.Items.Add($"Столбец {j}: сумма = {columnSum}");
            }
        }
    }
}
