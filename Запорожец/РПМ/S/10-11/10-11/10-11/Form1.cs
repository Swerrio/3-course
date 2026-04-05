using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в ListBox
            if (listBox1.SelectedIndex == -1)
            {
                label1.Text = "Выберите строку из списка!";
                return;
            }

            // Получаем выбранную строку
            string input = listBox1.SelectedItem.ToString();

            // Разбиваем строку на массив слов
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder resultBuilder = new StringBuilder();

            foreach (string word in words)
            {
                // Получаем длину слова
                resultBuilder.Append(word.Length.ToString() + " ");
            }

            label1.Text = "Длины слов: " + resultBuilder.ToString().Trim();
        }
    }
}
