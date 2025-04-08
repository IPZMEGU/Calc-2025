using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcKostiuk
{
    public partial class Calc_Kostiuk : Form
    {
        bool resultTablo = true;
        string operation = "";

        void plusTablo(char symbol)
        {
            if (resultTablo)
                textTablo.Text = "";
            if (textTablo.Text == "0")
                textTablo.Text = "";
            textTablo.Text += symbol.ToString();
            resultTablo = false;
        }

        public Calc_Kostiuk()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            plusTablo('7');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            plusTablo('8');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            plusTablo('9');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            plusTablo('4');
        }

        private void button10_Click(object sender, EventArgs e)
        {
            plusTablo('5');
        }

        private void button11_Click(object sender, EventArgs e)
        {
            plusTablo('6');
        }
        private void button12_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "M+";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            plusTablo('1');
        }

        private void button14_Click(object sender, EventArgs e)
        {
            plusTablo('2');
        }

        private void button15_Click(object sender, EventArgs e)
        {
            plusTablo('3');
        }
        private void button17_Click(object sender, EventArgs e)
        {
            plusTablo('0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "C";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MR";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MC";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "M-";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            runOperationTablo("+/-");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "/";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "*";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "+";
        }
        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "-";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            runOperationTablo("1/x");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            runOperationTablo("%");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            runOperationTablo("X!");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            runOperationTablo("^2");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "=";
            runOperationMemory();
        }

        private void buttonKoma_Click(object sender, EventArgs e)
        {
            if (resultTablo)
                textTablo.Text = "0";
            bool available = false;
            int i, len;
            len = textTablo.Text.Length;
            for (i = 0; i < len; i++)
                if (textTablo.Text[i] == ',')
                {
                    available = true;
                    break;
                }
            if (!available)
                textTablo.Text += ",";
            resultTablo = false;
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (resultTablo)
                textTablo.Text = "0";
            else
                textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            if (textTablo.Text == "")
                textTablo.Text = "0";
            resultTablo = false;
        }

        private void runOperationTablo(string opr)
        {
            double tablo;
            if (opr == "")
                return;
            try
            {
                tablo = Convert.ToDouble(textTablo.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Операцію виконати неможливо", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTablo.Text = "0";
                return;
            }
            switch (opr)
            {
                case "Sqrt":
                    if (tablo < 0)
                    {
                        MessageBox.Show("Операція неможлива : Корінь з від'ємного числа", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tablo = Math.Sqrt(tablo);
                    break;

                case "%":
                    tablo *= 0.01;
                    break;

                case "1/x":
                    if (tablo == 0)
                    {
                        MessageBox.Show("Операція неможлива: ділення на 0", "Увага!", MessageBoxButtons.OK);
                        return;
                    }
                    tablo = 1 / tablo;
                    break;

                case "+/-":
                    tablo *= -1;
                    break;
                case "^2":
                    tablo = Math.Pow(tablo, 2);
                    break;

                case "X!":
                    tablo = Factorial((int)tablo);
                    break;
            }
            textTablo.Text = tablo.ToString();
            resultTablo = true;
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            runOperationTablo("Sqrt");
        }

        private void runOperationMemory()
        {
            double tablo, memory;
            if (operation == "")
                return;
            try
            {
                tablo = Convert.ToDouble(textTablo.Text);
                memory = Convert.ToDouble(textMemory.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Операцію виконати неможливо", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTablo.Text = textMemory.Text = "0";
                return;
            }
            switch (operation)
            {
                case "+":
                    tablo += memory;
                    memory = tablo;
                    break;
                case "-":
                    tablo = memory - tablo;
                    memory = tablo;
                    break;
                case "*":
                    tablo *= memory;
                    memory = tablo;
                    break;
                case "/":
                    if (tablo == 0)
                    {
                        MessageBox.Show("Операція неможлива, ділення на 0", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tablo = memory / tablo;
                    memory = tablo;
                    break;
                case "=":
                    tablo = memory;
                    break;
                case "M+":
                    memory += tablo;
                    break;
                case "M-":
                    memory -= tablo;
                    break;
                case "MC":
                    memory = 0;
                    break;
                case "MR":
                    tablo = memory;
                    break;
                case "MT":
                    memory = tablo;
                    break;
                case "C":
                    tablo = 0;
                    memory = 0;
                    break;

            }
            operation = "";
            textTablo.Text = tablo.ToString();
            textMemory.Text = memory.ToString();
            resultTablo = true;
        }
        private double Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}