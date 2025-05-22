using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_Vasulushun
{
    
    public partial class CalcVasulushun : Form
    {
        bool resTablo = true;
        string prevoperation = "";

        public CalcVasulushun()
        {
            InitializeComponent();
        }

        void plusTablo(string symbol)
        {
            if (resTablo)
                textTablo.Text = "";
            if (textTablo.Text == "0")
                textTablo.Text = "";
            textTablo.Text += symbol.ToString();
            resTablo = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plusTablo(((Button)sender).Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (resTablo)
                textTablo.Text = "  0";
            resTablo = false;
            if (textTablo.Text.IndexOf(',') < 0)
                textTablo.Text += ",";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (resTablo)
                textTablo.Text = "0";
            else
                textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            if (textTablo.Text == "")
                textTablo.Text = "0";
            resTablo = false;
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
                MessageBox.Show("Помилка! Операцію виконати неможливо.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablo = 0;
                textTablo.Text = "0";
            }
            switch (prevoperation)
            {
                case "+/-":
                    tablo = -tablo;
                    break;
                case "√x":
                    if (tablo < 0)
                        MessageBox.Show("Помилка! Неможливо добути корінь з від'ємного числа.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        tablo = Math.Sqrt(tablo);
                    break;
                case "x²":
                    tablo = tablo * tablo;
                    break;
                case "1/x":
                    if (tablo == 0)
                        MessageBox.Show("Помилка! Ділення на нуль неможливе.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        tablo = 1 / tablo;
                    break;
                case "%":
                    tablo *= 0.01;
                    break;
            }
            textTablo.Text = tablo.ToString();
            resTablo = true;
        }

        private void button17_Click(object sender, EventArgs e)
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
            resTablo = true;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            runOperationMemory(((Button)sender).Text);
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
                MessageBox.Show("Помилка! Операцію виконати неможливо.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablo = 0;
                textTablo.Text = "0";
            }

            try
            {
                buffer = Convert.ToDouble("0" + textBuffer.Text);
            }
            catch
            {
                MessageBox.Show("Помилка! Неправильно введене значення.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buffer = 0;
                textBuffer.Text = "0";
            }

            if (prevoperation == "")
            {
                buffer = tablo;
                textBuffer.Text = buffer.ToString();
                resTablo = true;
                return;
            }
            switch (prevoperation)
            {
                case "+":
                    buffer += tablo;
                    break;
                case "-":
                    buffer -= tablo;
                    break;
                case "×":
                    buffer *= tablo;
                    break;
                case "÷":
                    if (tablo == 0)
                        MessageBox.Show("Помилка! Ділення на нуль неможливе.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        buffer /= tablo;
                    break;
            }
            tablo = buffer;
            textTablo.Text = tablo.ToString();
            textBuffer.Text = buffer.ToString();
            prevoperation = "";
            resTablo = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (prevoperation == "")
            {
                
                try
                {
                    textBuffer.Text = textTablo.Text;
                }
                catch
                {
                    MessageBox.Show("Помилка! Неправильно введене значення.", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBuffer.Text = "0";
                }
                prevoperation = (((Button)sender).Text);
                resTablo = true; 
            }
            else
            {
                
                runOperationBuffer();
                prevoperation = ""; 
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textTablo.Text = "0";
            textBuffer.Text = textMemory.Text = "";
            resTablo = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textTablo.Text = "0";
            resTablo = false;
        }

        private void CalcVasulushun_Load(object sender, EventArgs e)
        {

        }
}

    }

