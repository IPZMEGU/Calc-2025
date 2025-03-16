using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_Makhniuk
{
    public partial class CalcMakhniuk : Form
    {
        public string D;
        public string N1;
        public bool n2;
        private string previousValue;
        public List<double> Numbers { get; } = new List<double>();
        public List<string> Operations { get; } = new List<string>();

        public CalcMakhniuk()

        {
            n2 = false;
            InitializeComponent();
            textBoxMemory.Text = "";
            previousValue = "0";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            double dn, res;

            dn = Convert.ToDouble(textBox1.Text);
            res = -dn;
            textBox1.Text = res.ToString();
            UpdateTextBoxMemory("-" + dn.ToString() + " " + res.ToString());
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;

            if (n2)
            {
                n2 = false;
                textBoxMemory.Text = N1 + D;
                textBox1.Text = "0";
            }

            if (textBox1.Text == "0" || n2)
            {
                textBox1.Text = B.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text + B.Text;
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBoxMemory.Text = "";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            double currentNumber = Convert.ToDouble(textBox1.Text);

            if (n2)
            {
                n2 = false;
                textBoxMemory.Text = textBox1.Text + D;
                N1 = textBox1.Text;
                textBox1.Text = "0";
            }

            Numbers.Add(currentNumber);
            Operations.Add(B.Text);

            UpdateTextBoxMemory(currentNumber + " " + B.Text);

            textBox1.Text = "0";
        }
        private void button24_Click(object sender, EventArgs e)
        {
            double currentNumber = Convert.ToDouble(textBox1.Text);
            Numbers.Add(currentNumber);

            double result = Numbers[0];
            for (int i = 0; i < Operations.Count; i++)
            {
                switch (Operations[i])
                {
                    case "+":
                        result += Numbers[i + 1];
                        break;
                    case "-":
                        result -= Numbers[i + 1];
                        break;
                    case "X":
                        result *= Numbers[i + 1];
                        break;
                    case "/":
                        if (Numbers[i + 1] != 0)
                            result /= Numbers[i + 1];
                        else
                            result = 0;
                        break;
                }
            }

            textBoxMemory.Text = "";
            UpdateTextBoxMemory(result.ToString());
            textBox1.Text = result.ToString();
            Numbers.Clear();
            Operations.Clear();
        }

        private void UpdateTextBoxMemory(string text)
        {
            if (!string.IsNullOrWhiteSpace(textBoxMemory.Text))
            {
                textBoxMemory.Text += " " + text;
            }
            else
            {
                textBoxMemory.Text = text;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double dn, res;

            dn = Convert.ToDouble(textBox1.Text);
            res = Math.Sqrt(dn);
            textBoxMemory.Text = "";
            UpdateTextBoxMemory("√" + dn + " = " + res.ToString());
            textBox1.Text = res.ToString();
            previousValue = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double dn, res;

            dn = Convert.ToDouble(textBox1.Text);
            res = Math.Pow(dn, 2);
            previousValue = textBox1.Text;
            textBoxMemory.Text = "";
            UpdateTextBoxMemory(dn + "² = " + res.ToString());
            textBox1.Text = res.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double dn, res;

            dn = Convert.ToDouble(textBox1.Text);
            if (dn != 0)
                res = 1 / dn;
            else
                res = 0;
            textBoxMemory.Text = "";
            UpdateTextBoxMemory("1/" + dn + " = " + res.ToString());
            textBox1.Text = res.ToString();
            previousValue = res.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
                textBox1.Text = textBox1.Text + ",";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            else
                textBox1.Text = "0";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
    }
}