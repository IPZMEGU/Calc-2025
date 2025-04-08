using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator_by_Vodyanitski;

namespace Calculator_by_Vodyanitski
{
    public partial class formVodyanitski : Form
    {
        public formVodyanitski()
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
                textResult.Text = num2;
            }
            else
            {
                num1 += txt;
                textResult.Text = num1;
            }
        }

        private void SetNum(string txt)
        {
            if (isNum2)
            {
                num2 = txt;
                textResult.Text = num2;
            }
            else
            {
                num1 = txt;
                textResult.Text = num1;
            }
        }
       
        private void SetResult(string operation)
        {
            string result = null;

            switch (operation)
            {
                case "+": { result = MainMathFunctions.Add(num1, num2); break; }
                case "-": { result = MainMathFunctions.Sub(num1, num2); break; }
                case "*": { result = MainMathFunctions.Mul(num1, num2); break; }
                case "/": { result = MainMathFunctions.Dev(num1, num2); break; }
                case "%": { result = MainMathFunctions.Proc(num1, num2); break; }
                case "√": { result = MainMathFunctions.Sqr(num1); isNum2 = false; break; }
                case "x²": { result = MainMathFunctions.Pow(num1); isNum2 = false; break; }
                case "1/x": { result = MainMathFunctions.OneDev(num1); isNum2 = false; break; }
                default:break;
            }
            OutputResult(result, operation);
            if (isNum2) { if(result != null) num1 = result; } else { num1 = null;}
            isPoint = false;
        }

        private void OutputResult(string result, string operation)
        {
            switch (operation)
            {
                case "√": { if (num1 != null) textHistory.Text = "√" + num1 + " = "; break; }
                case "x²": { if (num1 != null) textHistory.Text =  num1 + "² = "; break; }
                case "1/x": { if (num1 != null) textHistory.Text = "1/" + num1 + " = "; break; }
                default:
                    {
                        if(num2 != null)
                        {
                            textHistory.Text = num1 + " " + operation + " " + num2 + " = ";
                        }
                        else
                            if(num1 != null)
                            {
                                textHistory.Text = num1 + " " + operation + " ";
                                break;
                            }


                    }
                    break;

            }

            num2 = null;
            if(result != null)
            {
                textResult.Text = result;
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
                if (textResult.Text.Length > 0)
                    if (textResult.Text[0] == '-')
                    {
                        textResult.Text = textResult.Text.Substring(1, textResult.Text.Length - 1);
                    }
                    else
                    {
                        textResult.Text = "-" + textResult.Text;
                    }
                SetNum(textResult.Text);
                return;
            }
            AddNum(txt);
        }

        private void buttonOperationClick(object obj, EventArgs e)
        {
            if (num1 == null)
            {
                if (textResult.Text.Length > 0)
                    num1 = textResult.Text;
                else
                    return;
            }

            isNum2 = true;
            currentOperation = ((Button)obj).Text;
            SetResult(currentOperation);
        }
        private void buttonClear(object obj, EventArgs e)
        {
            textResult.Text = "";
            textHistory.Text = "";
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
            if(textResult.Text.Length<=0)
            {
                return;
            }
            textResult.Text = textResult.Text.Substring(0,textResult.Text.Length - 1);
            SetNum(textResult.Text);
        }

        private void buttonResetMemory(object obj, EventArgs e)
        {
            memoryNum = "";
            num1 = null;
            num2 = null;
        }

        private void buttonSaveResultInMemory(object obj, EventArgs e)
        {
            memoryNum = textResult.Text;
        }

        private void buttonShowMemoryNumber(object obj, EventArgs e)
        {          
            textResult.Text = "";
            textHistory.Text = "";
            textResult.Text = memoryNum;          
        }


        private void buttonAddInMemory(object obj, EventArgs e)
        {        
            if (Double.TryParse(textResult.Text, out double a) && Double.TryParse(memoryNum, out double b))
            {              
                double sum = a + b;
                memoryNum = sum.ToString();               
            }          
        }
        
        private void buttonSubInMemory(object  obj, EventArgs e)
        {
            
            if (Double.TryParse(textResult.Text, out double a) && Double.TryParse(memoryNum, out double b))
            {
                double sum = b - a;
                memoryNum = sum.ToString();                
            }
            
        }

        private bool isClickMouse = false;
        private Point startPosition;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isClickMouse = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isClickMouse = true;
            startPosition = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClickMouse)
            {
                Point currentPosition = PointToScreen(e.Location);
                Location = new Point(currentPosition.X - startPosition.X, currentPosition.Y - startPosition.Y);
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //throw new System.NotImplementedException();
            
        }
    }
}
