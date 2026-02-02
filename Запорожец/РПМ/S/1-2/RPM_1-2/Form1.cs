using System;
using System.Drawing;
using System.Windows.Forms;

namespace RPM_1_2
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RearrangeButtonsExcept(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RearrangeButtonsExcept(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RearrangeButtonsExcept(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RearrangeButtonsExcept(sender);
        }

        private void RearrangeButtonsExcept(object clickedButton)
        {
            Button[] buttons = { button1, button2, button3, button4 };

            foreach (var btn in buttons)
            {
                if (btn != clickedButton)
                {
                    int maxWidth = this.ClientSize.Width - 50;
                    int maxHeight = this.ClientSize.Height - 30;

                    int width = rand.Next(50, 150);
                    int height = rand.Next(30, 80);

                    int x = rand.Next(0, Math.Max(1, maxWidth - width));
                    int y = rand.Next(0, Math.Max(1, maxHeight - height));

                    btn.Location = new Point(x, y);
                    btn.Size = new Size(width, height);
                }
            }
        }
    }
}