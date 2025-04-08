using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcKutsevychc
{
    public partial class FormCalc : Form
    {
        bool resultTablo = false;
        string prevOperation = "";

        public FormCalc()
        {
            InitializeComponent();
        }
        void plusTablo(string plus)
        {
            if (resultTablo)
            { textTablo.Text = "0";
                resultTablo = false;
            }
            if (textTablo.Text == "0")
                textTablo.Text = "";
            textTablo.Text += plus;
        }

        private void runOperationTablo(string operation)
        {
            double tablo;
            try
            { tablo = Convert.ToDouble(textTablo.Text); }
            catch
            {
                tablo = 0;
                textTablo.Text = "0";
            }

            switch (operation)
            {
                case "sqrt":
                    if (tablo < 0)
                        MessageBox.Show("Операція неможлива: корінь з від'ємного числа", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else tablo = Math.Sqrt(tablo);
                    break;
                case "%":
                    tablo *= 0.01;
                    break;
                case "1/x":
                    if (tablo == 0)
                        MessageBox.Show("Операція неможлива: ділення на нуль", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else tablo = 1 / tablo;
                    break;
                case "+/-":
                    tablo =-tablo;
                    break;
                case "sqr":
                    tablo = tablo * tablo;
                    break;
                case "sin":
                    tablo = Math.Sin(tablo);
                    break;
                case "cos":
                    tablo = Math.Cos(tablo);
                    break;
                case "tg":
                    tablo = Math.Tan(tablo);
                    break;
            }
            textTablo.Text = tablo.ToString();
            resultTablo = true;
        }

        void runOperationBuffer()
        {
            
            double tablo, buffer;
            try
            { tablo = Convert.ToDouble(textTablo.Text == "" ? "0" : textTablo.Text); }
            catch
            { MessageBox.Show("Табло містить не корректне число", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablo = 0;
                textTablo.Text = "0"; }

            try
            { buffer = Convert.ToDouble(textBuffer.Text == "" ? "0" : textBuffer.Text); }
            catch
            {
                MessageBox.Show("Буфер містить не корректне число", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buffer = 0;
                textTablo.Text = "0";
            }
            if (prevOperation == "")
             buffer=tablo;
            switch (prevOperation)
            {
                case "+":
                    buffer += tablo;
                    break;
                case "-":
                    buffer -= tablo;
                    break;
                case "/":
                    if (tablo == 0)
                        MessageBox.Show("Операція неможлива: ділення на нуль", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else buffer /= tablo;
                    break;
                case "*":
                    buffer *= tablo;
                    break;
            }
            tablo = buffer;
            textTablo.Text = tablo.ToString();
            textBuffer.Text = buffer.ToString();
            prevOperation = "";
            resultTablo = true;
        }
    

            void plusTablo(char symbol)
            {
                if (resultTablo)
                    textTablo.Text = "";
                if (textTablo.Text == "0")
                    textTablo.Text = "";
                textTablo.Text += symbol.ToString();
                resultTablo = false;
            }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void buttonKoma_Click(object sender, EventArgs e)
            {
                if (resultTablo)
                    textTablo.Text = "0";
                bool available = false;
                int i, len;
                len = textTablo.Text.Length;
                for (i = 0; i < len; i++)
                    if (textTablo.Text[i].ToString() == ",")
                    {
                        available = true;
                        break;
                    }
                if (!available)
                    textTablo.Text += ",";
                resultTablo = false;

            }

            private void button29_Click(object sender, EventArgs e)
            {
                if (resultTablo)
                    textTablo.Text = "0";
                else
                    textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
                if (textTablo.Text == "")
                    textTablo.Text = "0";
                resultTablo = false;
            }

            private void button20_Click(object sender, EventArgs e)
            {
                
            }

            private void button13_Click(object sender, EventArgs e)
            {
                
            }

            private void button14_Click(object sender, EventArgs e)
            {
                
            }

            private void button15_Click(object sender, EventArgs e)
            {
                
            }

            private void button21_Click(object sender, EventArgs e)
            {
                runOperationTablo("sin");
            }

            private void button22_Click(object sender, EventArgs e)
            {
                runOperationTablo("cos");
            }

            private void button23_Click(object sender, EventArgs e)
            {
                runOperationTablo("tg");
            }

            private void button4_Click(object sender, EventArgs e)
            {

            }

            private void button30_Click(object sender, EventArgs e)
            {
                textTablo.Text = "0";
            }

            private void button19_Click_1(object sender, EventArgs e)
            {
                runOperationBuffer();
                prevOperation="/";
            }

            private void button15_Click_1(object sender, EventArgs e)
            {

            }

            private void button24_Click(object sender, EventArgs e)
            {
                runOperationBuffer();
            }

            private void button2_Click_1(object sender, EventArgs e)
            {
                plusTablo(((Button)sender).Text);
            }

        private void FormCalc_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            runOperationBuffer();
            prevOperation = "/";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            runOperationBuffer();
            prevOperation = "+";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            runOperationBuffer();
            prevOperation = "-";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            runOperationBuffer();
            prevOperation = "*";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            runOperationBuffer();
            prevOperation = "-";
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            runOperationTablo("sqr");
            
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            runOperationTablo("sqrt");
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            runOperationTablo("1/x");
        }

        private void button15_Click_2(object sender, EventArgs e)
        {
            runOperationTablo("%");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runOperationTablo("+/-");
        }
    }
}
