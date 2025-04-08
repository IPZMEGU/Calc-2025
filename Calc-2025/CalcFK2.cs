using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LROOP7
{
    public partial class CalcFK2 : Form
    {
        bool resultTablo = false;
        string prevOperation = "";
        public CalcFK2()
        {
            InitializeComponent();
        }

        void plusTablo(string plus)
        {   if (resultTablo)
            { textTablo.Text = "0";
              resultTablo = false;
            }
            if (textTablo.Text == "0")
                textTablo.Text = "";
            textTablo.Text += plus;

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
                tablo = 0;
                textTablo.Text = "0";
            }
            switch (operation)
            {
                case "+/-":tablo = -tablo;
                    break;
                case "Sqrt":
                    if (tablo < 0)
                        MessageBox.Show("Добути корінь з від'ємного числа неможливо");
                    else
                        tablo = Math.Sqrt(tablo);
                    break;
                case "x^2":
                    tablo = tablo*tablo;
                    break;
                case "1/x":
                    if (tablo == 0)
                        MessageBox.Show("На нуль ділити не можна");
                    else
                        tablo = 1/tablo;
                    break;
            }
            textTablo.Text = tablo.ToString();
            resultTablo = true;
        }

        void runOperationMemory(string operation)
        {
            double tablo, memory;
            try
            {
                tablo = Convert.ToDouble(textTablo.Text);
            }
            catch
            {
                tablo = 0;
                textTablo.Text = "0";
            }
            try
            {
                memory = Convert.ToDouble(textMemory.Text);
            }
            catch
            {
                memory = 0;
                textMemory.Text = "0";
            }
            switch (operation)
            {
                case "MC":
                    memory = 0;
                    break;
                case "MR":
                    tablo = memory;
                    if (tablo < 0)
                        MessageBox.Show("Добути корінь з від'ємного числа неможливо");
                    else
                        tablo = Math.Sqrt(tablo);
                    break;
                case "M+":
                    memory+=tablo;
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

        void runOperationBuffer()
        {  
            double tablo, buffer;
            try
            {
                tablo = Convert.ToDouble(textTablo.Text);
            }
            catch
            {
                tablo = 0;
                textTablo.Text = "0";
            }
            try
            {
                buffer = Convert.ToDouble(textBuffer.Text);
            }
            catch
            {
                buffer = 0;
                textBuffer.Text = "0";
            }
            if (prevOperation == "")
            {
                buffer = tablo;
                textBuffer.Text = buffer.ToString();
                resultTablo = true;
                return;
            }
                switch (prevOperation)
            {
                case "+":
                    buffer += tablo; 
                    break;
                case "-":
                    buffer-=tablo;
                    break;
                  
            }
            tablo = buffer;
            textTablo.Text = tablo.ToString();
            textBuffer.Text = buffer.ToString();
            prevOperation = "";
            resultTablo = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            plusTablo("9");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            plusTablo(((Button)sender).Text); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (resultTablo)
            {
                textTablo.Text = "0";
                resultTablo = false;
            }
            if (textTablo.Text.IndexOf(',')<0)
              textTablo.Text += ",";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (resultTablo)
            {
                textTablo.Text = "0";
                resultTablo = false;
                return;
            }
            if (textTablo.Text == "0")
                return;
            textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            if (textTablo.Text == "")
                textTablo.Text = "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            runOperationTablo(((Button)sender).Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textTablo.Text = "0";
            resultTablo = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            runOperationMemory(((Button)sender).Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            runOperationBuffer();
            prevOperation = "+";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            runOperationBuffer();
            prevOperation = "-";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            runOperationBuffer();
        }
    }
}
