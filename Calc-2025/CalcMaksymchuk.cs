using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calc_Maksymchuk;

namespace Calc_Maksymchuk
{
    public partial class CalcMaksymchuk : Form
    {
        public CalcMaksymchuk()
        {
            InitializeComponent();
        }

        private bool isPoint = false;
        private bool isNum2 = false;

        private string num1 = null;
        private string num2 = null;

        private string currentOperation = "";

        private string memoryNum = null;

        private void AddNum(string txt)
        {
            if (isNum2)
            {
                num2 += txt;
                textTablo.Text = num2;
            }
            else
            {
                num1 += txt;
                textTablo.Text = num1;
            }
        }

        private void SetNum(string txt)
        {
            if (isNum2)
            {
                num2 = txt;
                textTablo.Text = num2;
            }
            else
            {
                num1 = txt;
                textTablo.Text = num1;
            }
        }

        private void SetResult(string operation)
        {
            string result = null;

            switch (operation)
            {
                case "+":
                    {
                        if (isNum2)
                        {
                            if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2))
                            {
                                result = (n1 + n2).ToString();
                            }
                        }
                        break;
                    }
                case "-":
                    {
                        if (isNum2)
                        {
                            if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2))
                            {
                                result = (n1 - n2).ToString();
                            }
                        }
                        break;
                    }
                case "*":
                    {
                        if (isNum2)
                        {
                            if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2))
                            {
                                result = (n1 * n2).ToString();
                            }
                        }
                        break;
                    }
                case "/":
                    {
                        if (isNum2)
                        {
                            if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2) && n2 != 0)
                            {
                                result = (n1 / n2).ToString();
                            }
                        }
                        break;
                    }
                case "%":
                    {
                        if (isNum2)
                        {
                            if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2) && n2 != 0)
                            {
                                result = (n1 % n2).ToString();
                            }
                        }
                        break;
                    }
                case "√":
                    {
                        if (Double.TryParse(num1, out double n1))
                        {
                            result = Math.Sqrt(n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                case "x²":
                    {
                        if (Double.TryParse(num1, out double n1))
                        {
                            result = (n1 * n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                case "1/x":
                    {
                        if (Double.TryParse(num1, out double n1) && n1 != 0)
                        {
                            result = (1 / n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                default: break;
            }

            OutputResult(result, operation);

            if (isNum2)
            {
                if (result != null)
                {
                    num1 = result;
                }
            }
            else
            {
                num1 = null;
            }

            isPoint = false;
        }


        private void OutputResult(string result, string operation)
        {
            switch (operation)
            {
                case "√": { if (num1 != null) textMemory.Text = "√" + num1 + " = "; break; }
                case "x²": { if (num1 != null) textMemory.Text = num1 + "² = "; break; }
                case "1/x": { if (num1 != null) textMemory.Text = "1/" + num1 + " = "; break; }
                default:
                    {
                        if (num2 != null)
                        {
                            textMemory.Text = num1 + " " + operation + " " + num2 + " = ";
                        }
                        else
                            if (num1 != null)
                        {
                            textMemory.Text = num1 + " " + operation + " ";
                            break;
                        }


                    }
                    break;

            }

            num2 = null;
            if (result != null)
            {
                textTablo.Text = result;
            }
        }

        private void buttonNumberClick(object obj, EventArgs e)
        {
            var txt = ((Button)obj).Text;
            {
                if (isPoint && txt == ",") { return; }
                if (txt == ",") { isPoint = true; }
            }

            if (txt == "+/-")
            {
                if (textTablo.Text.Length > 0)
                    if (textTablo.Text[0] == '-')
                    {
                        textTablo.Text = textTablo.Text.Substring(1, textTablo.Text.Length - 1);
                    }
                    else
                    {
                        textTablo.Text = "-" + textTablo.Text;
                    }
                SetNum(textTablo.Text);
                return;
            }
            AddNum(txt);
        }

        private void buttonOperationClick(object obj, EventArgs e)
        {
            if (num1 == null)
            {
                if (textTablo.Text.Length > 0)
                    num1 = textTablo.Text;
                else
                    return;
            }

            isNum2 = true;
            currentOperation = ((Button)obj).Text;
            SetResult(currentOperation);
        }
        private void buttonClear(object obj, EventArgs e)
        {
            textTablo.Text = "";
            textMemory.Text = "";
            isNum2 = false;
            currentOperation = null;
            num1 = null;
            num2 = null;
            isPoint = false;
        }
        private void buttonResultClick(object obj, EventArgs e)
        {
            SetResult(currentOperation);
            isNum2 = false;
            num1 = null;
            num2 = null;
        }
        private void buttonResetNumber(object obj, EventArgs e)
        {
            if (textTablo.Text.Length <= 0)
            {
                return;
            }
            textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            SetNum(textTablo.Text);
        }

        private void buttonResetMemory(object obj, EventArgs e)
        {
            memoryNum = "";
            num1 = null;
            num2 = null;
        }

        private void buttonSaveResultInMemory(object obj, EventArgs e)
        {
            memoryNum = textTablo.Text;
        }

        private void buttonShowMemoryNumber(object obj, EventArgs e)
        {
            textTablo.Text = "";
            textMemory.Text = "";
            textTablo.Text = memoryNum;
        }


        private void buttonAddInMemory(object obj, EventArgs e)
        {
            if (Double.TryParse(textTablo.Text, out double a) && Double.TryParse(memoryNum, out double b))
            {
                double sum = a + b;
                memoryNum = sum.ToString();
            }
        }

        private void buttonSubInMemory(object obj, EventArgs e)
        {

            if (Double.TryParse(textTablo.Text, out double a) && Double.TryParse(memoryNum, out double b))
            {
                double sum = b - a;
                memoryNum = sum.ToString();
            }

        }
        private void buttonE_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                num2 = Math.E.ToString();
                textTablo.Text = num2;
            }
            else
            {
                num1 = Math.E.ToString();
                textTablo.Text = num1;
            }
        }

        private void buttonPi_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                num2 = Math.PI.ToString();
                textTablo.Text = num2;
            }
            else
            {
                num1 = Math.PI.ToString();
                textTablo.Text = num1;
            }
        }

        private double Factorial(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                double result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            }
        }

        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2))
                {
                    num2 = Factorial(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = Factorial(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }

        private void buttonAbs_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2))
                {
                    num2 = Math.Abs(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = Math.Abs(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2) && n2 > 0)
                {
                    num2 = Math.Log10(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1) && n1 > 0)
                {
                    num1 = Math.Log10(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }

        private void buttonLg_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2) && n2 > 0)
                {
                    num2 = Math.Log(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1) && n1 > 0)
                {
                    num1 = Math.Log(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }

        private void buttonTenToThePowerOfX_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2))
                {
                    num2 = Math.Pow(10, n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = Math.Pow(10, n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }

        private void buttonXToThePowerOfY_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2))
                {
                    num2 = Math.Pow(n1, n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = n1.ToString();
                    textTablo.Text = num1;
                }
            }
        }

        private void buttonTwoToThePowerOfN_Click(object sender, EventArgs e)
        {

        }

        private void buttonXSquare_Click(object sender, EventArgs e)
        {

        }

        private void buttonExp_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2))
                {
                    num2 = Math.Exp(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = Math.Exp(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }
        private void buttonMod_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2) && n2 != 0)
                {
                    num2 = (n1 % n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = n1.ToString();
                    textTablo.Text = num1;
                }
            }
        }
        private void buttonCos_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2))
                {
                    num2 = Math.Cos(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = Math.Cos(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }
        private void buttonSin_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2))
                {
                    num2 = Math.Sin(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = Math.Sin(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }
        private void buttonTan_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2))
                {
                    num2 = Math.Tan(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = Math.Tan(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }
        private void buttonCot_Click(object sender, EventArgs e)
        {
            if (isNum2)
            {
                if (Double.TryParse(num2, out double n2))
                {
                    num2 = Math.Cosh(n2).ToString();
                    textTablo.Text = num2;
                }
            }
            else
            {
                if (Double.TryParse(num1, out double n1))
                {
                    num1 = Math.Cosh(n1).ToString();
                    textTablo.Text = num1;
                }
            }
        }
    }
}
