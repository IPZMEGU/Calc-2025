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
    public partial class Calc_Katerynych : Form
    {
        public Calc_Katerynych()
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
                case "log":
                    {
                        if (Double.TryParse(num1, out double n1))
                        {
                            result = Math.Log(n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                case "ln":
                    {
                        if (Double.TryParse(num1, out double n1))
                        {
                            result = Math.Log10(n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                case "|x|":
                    {
                        if (Double.TryParse(num1, out double n1))
                        {
                            result = Math.Abs(n1).ToString();
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
                case "n!":
                    {
                        if (Double.TryParse(num1, out double n1) && n1 != 0)
                        {
                            if (n1 == 0)
                            {
                                result = "1";
                            }
                            else
                            {
                                double res = 1;
                                for (int i = 1; i <= n1; i++)
                                {
                                    res *= i;
                                }
                                result=res.ToString();
                            }
                        }
                        break;
                    }
                case "cos":
                    {
                        if (Double.TryParse(num1, out double n1) && n1 != 0)
                        {
                            result = Math.Cos(n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                case "sin":
                    {
                        if (Double.TryParse(num1, out double n1) && n1 != 0)
                        {
                            result = Math.Sin(n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                case "10^x":
                    {
                        if (Double.TryParse(num1, out double n1) && n1 != 0)
                        {
                            result = Math.Pow(10, n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                case "^":
                    {
                        if (isNum2)
                        {
                            if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2))
                            {
                                result = Math.Pow(n1, n2).ToString();
                            }
                        }
                        break;
                    }
                case "exp":
                    {
                        if (Double.TryParse(num1, out double n1) && n1 != 0)
                        {
                            result = Math.Exp(n1).ToString();
                            isNum2 = false;
                        }
                        break;
                    }
                case "mod":
                    {
                        if (Double.TryParse(num1, out double n1) && Double.TryParse(num2, out double n2))
                        {
                            result = (n1 % n2).ToString();
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
                case "10^x": { if (num1 != null) textMemory.Text = "10^" + num1 + " = "; break; }
                case "log": { if (num1 != null) textMemory.Text = "log(" + num1 + ") = "; break; }
                case "ln": { if (num1 != null) textMemory.Text = "ln(" + num1 + ") = "; break; }
                case "cos": { if (num1 != null) textMemory.Text = "cos(" + num1 + ") = "; break; }
                case "sin": { if (num1 != null) textMemory.Text = "sin(" + num1 + ") = "; break; }
                case "|x|": { if (num1 != null) textMemory.Text = "|" + num1 + "| = "; break; }
                case "n!": { if (num1 != null) textMemory.Text = num1 + "! = "; break; }
                case "exp": { if (num1 != null) textMemory.Text = num1 + " exp = "; break; }

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
                if(textTablo.Text=="" && txt == ",") { return;}
                if (isPoint && txt == ",") { return; }
                if (txt == ",") { isPoint = true; }
            }

            if (txt == "e")
            {
                txt = "2,718";
            }
            if (txt == "π")
            {
                txt = "3,14";
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
            if(currentOperation != "")
            {
                SetResult(currentOperation);
                currentOperation = ((Button)obj).Text;
                SetResult(currentOperation);
            }

            if (num1 == null)
            {
                if (textTablo.Text.Length > 0)
                    num1 = textTablo.Text;
                else
                    return;
            }

            isNum2 = true;
            currentOperation = ((Button)obj).Text;
            if (currentOperation == "x^y")
            {
                currentOperation = "^";
            }
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
            if (textTablo.Text =="")
            {
                textTablo.Text = textMemory.Text;
                textMemory.Text = "0";
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


    }
}
