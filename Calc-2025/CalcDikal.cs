using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc_Katerynych
{
    public partial class CalcDikal : Form
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
        public CalcDikal()
        {
            InitializeComponent();
        }

        private void textTablo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            plusTablo('1');
        }
        private void button2_Click(object sender, EventArgs e)
        {
            plusTablo('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plusTablo('3');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            plusTablo('4');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            plusTablo('5');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            plusTablo('6');
        }

        private void button10_Click(object sender, EventArgs e)
        {
            plusTablo('7');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            plusTablo('8');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            plusTablo('9');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            plusTablo('0');
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            runOperationTablo("%");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            runOperationTablo("1/x");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            runOperationTablo("Sqrt");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (resultTablo)
                textTablo.Text = "0";
            else
                textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            if (textTablo.Text == "")
                textTablo.Text = "0";
            resultTablo = false;
        }

        private void button16_Click(object sender, EventArgs e)
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
        private void runOperationTablo(string opr)
        {
            double tablo;
            if (opr == "")
                return;
            try
            { tablo = Convert.ToDouble(textTablo.Text); }
            catch (System.FormatException)
            {
                MessageBox.Show("Виконання операції неможливе", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTablo.Text = "0";
                return;
            }
            switch (opr)
            {
                case "Sqrt":
                    if (tablo < 0)
                    {
                        MessageBox.Show("Виконання операції неможливе: корінь з від'ємного числа", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Виконання операції неможливе: ділення на нуль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tablo = 1 / tablo;
                    break;
                case "+/-":
                    tablo *= -1;
                    break;
                case "=":
                    if (tablo == 0)
                        return;
                    else
                    tablo = 0;
                    break;

            }
            textTablo.Text = tablo.ToString();
            resultTablo = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            runOperationTablo("+/-");
        }

        private void runOperationMem()
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
                MessageBox.Show("Виконання операції неможливе", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    tablo -= memory;
                    memory = tablo;
                    break;
                case "*":
                    tablo *= memory;
                    memory = tablo;
                    break;
                case "/":
                    if (tablo == 0)
                    {
                        MessageBox.Show("Виконання операції неможливе: ділення на нуль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tablo = memory / tablo;
                    memory = tablo;
                    break;
                case "M+":
                    tablo += memory;
                    break;
                case "M-":
                    tablo -= memory;
                    break;
                case "MC":
                    memory = 0;
                    break;
                case "MR":
                    tablo =  memory;
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

        private void button24_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MT";
            runOperationMem();
            operation = "+";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MT";
            runOperationMem();
            operation = "-";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MT";
            runOperationMem();
            operation = "/";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MT";
            runOperationMem();
            operation = "*";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "C";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MR";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MC";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MT";
            runOperationMem();
            operation = "M+";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MT";
            runOperationMem();
            operation = "M-";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            runOperationMem();
            operation = "MT";
            runOperationTablo("=");
        }
    }
}
