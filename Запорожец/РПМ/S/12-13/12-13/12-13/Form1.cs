using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_13
{
    public partial class Form1 : Form
    {
        int[] Mas;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mas = new int[30]; // Инициализируем на 30 элементов
            listBox1.Items.Clear();
            Random rand = new Random();

            int sum = 0;
            int count = 0;

            for (int i = 0; i < 30; i++)
            {
                Mas[i] = rand.Next(1, 100);
                listBox1.Items.Add($"Mas[{i}] = {Mas[i]}");

                // делится на 5 и НЕ делится на 7
                if (Mas[i] % 5 == 0 && Mas[i] % 7 != 0)
                {
                    sum += Mas[i];
                    count++;
                }
            }
            label1.Text = $"1: Кол-во = {count}, Сумма = {sum}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mas = new int[50]; // Инициализируем на 50 элементов
            listBox1.Items.Clear();
            Random rand = new Random();

            // Генерируем массив
            for (int i = 0; i < 50; i++)
            {
                Mas[i] = rand.Next(1, 50);
                listBox1.Items.Add($"Mas[{i}] = {Mas[i]}");
            }

            // Находим максимальный элемент
            int maxVal = Mas[0];
            for (int i = 1; i < 50; i++)
            {
                if (Mas[i] > maxVal) maxVal = Mas[i];
            }

            // Считаем, сколько раз встречается этот максимум
            int countMax = 0;
            for (int i = 0; i < 50; i++)
            {
                if (Mas[i] == maxVal) countMax++;
            }

            label2.Text = $"2: Максимум ({maxVal}) встретился {countMax} раз";
        }
    }
}
