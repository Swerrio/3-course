using System;
using System.Windows.Forms;

namespace _22_23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Метод разделения строк
        private void SplitStringByPoint(string source, out string before, out string after)
        {
            int index = source.IndexOf('.');

            if (index != -1)
            {
                // Вырезаем часть до точки
                before = source.Substring(0, index);
                // Вырезаем часть после точки
                after = source.Substring(index + 1);
            }
            else
            {
                before = source;
                after = "Точка не найдена";
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                MessageBox.Show("Введите строку с точкой");
                return;
            }

            string head, tail;

            SplitStringByPoint(textBoxInput.Text, out head, out tail);

            listBoxResults.Items.Add($"Ввод: {textBoxInput.Text}");
            listBoxResults.Items.Add($"  До точки: {head}");
            listBoxResults.Items.Add($"  После точки: {tail}");

            textBoxInput.Clear();
            textBoxInput.Focus();
        }
    }
}