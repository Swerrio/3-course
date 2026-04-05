using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_9
{
    public partial class Form1 : Form
    {
        // Переменные для отслеживания позиции новых элементов
        int labelY = 10;
        int textBoxY = 10;

        public Form1()
        {
            InitializeComponent();
        }

        // Создает метку и увеличивает все метки по горизонтали
        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем новую метку
            Label newLabel = new Label();
            newLabel.Text = "Метка " + (this.Controls.Count);
            newLabel.Location = new Point(150, labelY);
            newLabel.BackColor = Color.LightBlue;
            newLabel.Parent = this;

            labelY += 30; // Смещение для следующей метки

            // Перебираем все элементы и увеличиваем ширину меток
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    // Используем оператор as для приведения типа
                    Label lbl = c as Label;
                    lbl.Width = lbl.Width * 2;
                }
            }
        }

        // Создает поле ввода и уменьшает все поля по вертикали
        private void button2_Click(object sender, EventArgs e)
        {
            // Создаем новое поле ввода
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Text = "Текст";
            newTextBox.Size = new Size(100, 100);
            newTextBox.Location = new Point(450, textBoxY);
            newTextBox.Parent = this;

            textBoxY += 50;

            // Перебираем все элементы и уменьшаем высоту текстовых полей
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox tb = c as TextBox;
                    tb.Height = tb.Height / 2;
                }
            }
        }
    }
}
