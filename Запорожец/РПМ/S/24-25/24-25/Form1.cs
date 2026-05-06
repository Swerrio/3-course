using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_25
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[100];
        int simpleSearchSteps = 0;
        int binarySearchSteps = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // быстрая сортировка
        private void QuickSort(ref int[] Array, int Left, int Right)
        {
            int i = Left;
            int j = Right;
            int x = Array[(Left + Right) / 2];
            do
            {
                while (Array[i] < x) ++i;
                while (Array[j] > x) --j;
                if (i <= j)
                {
                    int t = Array[i];
                    Array[i] = Array[j];
                    Array[j] = t;
                    i++; j--;
                }
            } while (i <= j);

            if (Left < j) QuickSort(ref Array, Left, j);
            if (i < Right) QuickSort(ref Array, i, Right);
        }

        // обыный поиск
        private int SimpleSearch(int[] Array, int Value)
        {
            simpleSearchSteps = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                simpleSearchSteps++;
                if (Array[i] == Value) return i;
            }
            return -1;
        }

        // дихотомический поиск
        private int BinarySearch(int[] Array, int Value, int Left, int Right)
        {
            binarySearchSteps++;
            int x = (Left + Right) / 2;
            if (Array[x] == Value) return x;
            if ((x == Left) || (x == Right)) return -1;

            if (Array[x] < Value)
                return BinarySearch(Array, Value, x, Right);
            else
                return BinarySearch(Array, Value, Left, x);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxSearch.Text, out int target)) return;

            Random rnd = new Random();
            for (int i = 0; i < 100; i++) numbers[i] = rnd.Next(1, 1000);

            // поиск до сортировки
            SimpleSearch(numbers, target);

            // сортировка
            QuickSort(ref numbers, 0, numbers.Length - 1);

            // дихотомический поиск после сортировки
            binarySearchSteps = 0;
            BinarySearch(numbers, target, 0, numbers.Length - 1);

            listBoxArray.Items.Clear();
            foreach (int n in numbers) listBoxArray.Items.Add(n);

            labelStats.Text = $"Простой поиск: {simpleSearchSteps} итераций\n" +
                             $"Дихотомия: {binarySearchSteps} итераций";
        }
    }
}