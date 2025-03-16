using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_VladyslavM
{
    public partial class CalcVladyslav : Form
    {
        bool resultTablo = true;
        string operationPrev = "";
        public CalcVladyslav()
        {
            InitializeComponent();
        }

        void PlusTablo(string symbol)
        {
            if (resultTablo)
                textTablo.Text = "";
            if (textTablo.Text == "0")
                textTablo.Text = "";
            textTablo.Text += symbol.ToString();
            resultTablo = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            PlusTablo(((Button)sender).Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (resultTablo)
                textTablo.Text = "0";
            resultTablo = false;
            if (textTablo.Text.IndexOf(',') < 0)
                textTablo.Text += ",";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (resultTablo)
                textTablo.Text = "0";
            else
                textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            if (textTablo.Text == "")
                textTablo.Text = "0";
            resultTablo = false;
        }

        void runOperationTablo(string operation)
        {
            double tablo;
            try
            {
                tablo = Convert.ToDouble(textTablo.Text);
            }
            catch
            {
                MessageBox.Show("Помилка! Операцію виконати неможливо", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablo = 0;
                textTablo.Text = "0";
            }
            switch (operation)
            {
                case "+/-":
                    tablo = -tablo;
                    break;
                case "√x":
                    if (tablo < 0)
                        MessageBox.Show("Помилка! Неможливо добути корінь з від'ємного числа", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        tablo = Math.Sqrt(tablo);
                    break;
                case "x²":
                    tablo = tablo*tablo;
                    break;
                case "1/x":
                    if (tablo == 0)
                        MessageBox.Show("Помилка! Ділити на нуль неможна", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        tablo = 1/tablo;
                    break;
                case "%":
                    tablo *= 0.01;
                    break;
            }
            textTablo.Text = tablo.ToString();
            resultTablo = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runOperationTablo(((Button)sender).Text);
        }

        void runOperationMemory(string operation)
        {
            double tablo, memory;
            try
            {
                memory = Convert.ToDouble("0" + textMemory.Text);
                tablo = Convert.ToDouble("0" + textTablo.Text);
            }
            catch
            {
                MessageBox.Show("Помилка! Операцію виконати неможливо.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablo = 0;
                memory = 0;
                textTablo.Text = textMemory.Text = "0";
            }

            if (operation == "")
                return;

            switch (operation)
            {
                case "MC":
                    memory = 0;
                    break;
                case "MR":
                    tablo = memory;
                    break;
                case "M+":
                    memory += tablo;
                    break;
                case "M-":
                    memory -= tablo;
                    break;
                case "MS":
                    memory = tablo;
                    break;
            }
            textTablo.Text = tablo.ToString();
            textMemory.Text = memory.ToString();
            resultTablo = true;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            runOperationMemory(((Button)sender).Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textTablo.Text = "0";
            resultTablo = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textTablo.Text = "0";
            textBuffer.Text = textMemory.Text = "";
            resultTablo = false;
        }

        void runOperationBuffer()
        {
            double tablo, buffer;
            try
            {
                tablo = Convert.ToDouble("0" + textTablo.Text);
            }
            catch
            {
                MessageBox.Show("Операцію виконати неможливо", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablo = 0;
                textTablo.Text = "0";
            }

            try
            {
                buffer = Convert.ToDouble("0" + textBuffer.Text);
            }
            catch
            {
                MessageBox.Show("Неправильно введене значення", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buffer = 0;
                textBuffer.Text = "0";
            }

            if (operationPrev == "")
            {
                buffer = tablo;
                textBuffer.Text = buffer.ToString();
                resultTablo = true;
                return;
            }
            switch (operationPrev)
            {
                case "+":
                    buffer += tablo;
                    break;
                case "-":
                    buffer -= tablo;
                    break;
                case "*":
                    buffer *= tablo;
                    break;
                case "/":
                    if (tablo == 0)
                        MessageBox.Show("Ділити на нуль неможна", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        buffer /= tablo;
                    break;
            }
            tablo = buffer;
            textTablo.Text = tablo.ToString();
            textBuffer.Text = buffer.ToString();
            operationPrev = "";
            resultTablo = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            runOperationBuffer();
            operationPrev = (((Button)sender).Text);
        }       
    }
}
