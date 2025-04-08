using System;
using System.Windows.Forms;

namespace CalcDzhura // Змінено простір імен на CalcDzhura
{
    public partial class FormCalcDzhura : Form
    {
        private double memoryValue = 0;
        private double previousValue = 0;
        private string currentOperation = "";
        private bool isNewInput = true;

        public FormCalcDzhura()
        {
            InitializeComponent();
            displayBox.Text = "0";
            memoryBox.Text = "0";
            buttonMC.Enabled = false;
            buttonMR.Enabled = false;
        }

        private void AppendNumber(string number)
        {
            if (isNewInput || displayBox.Text == "0")
                displayBox.Text = number;
            else
                displayBox.Text += number;

            isNewInput = false;
        }

        private void ExecuteOperation(string operation)
        {
            double currentNumber = Convert.ToDouble(displayBox.Text);

            switch (operation)
            {
                case "%":
                    currentNumber *= 0.01;
                    break;
                case "√": // Змінено на символ кореня відповідно до дизайнера
                    if (currentNumber < 0)
                    {
                        MessageBox.Show("Неможливо обчислити квадратний корінь з від’ємного числа!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    currentNumber = Math.Sqrt(currentNumber);
                    break;
                case "x²":
                    currentNumber *= currentNumber;
                    break;
                case "1/x":
                    if (currentNumber == 0)
                    {
                        MessageBox.Show("Ділення на нуль неможливе!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    currentNumber = 1 / currentNumber;
                    break;
                case "+/-":
                    currentNumber *= -1;
                    break;
            }

            displayBox.Text = currentNumber.ToString();
            isNewInput = true;
        }

        private void PerformMemoryOperation(string operation)
        {
            double currentNumber = Convert.ToDouble(displayBox.Text);

            switch (operation)
            {
                case "MS":
                    memoryValue = currentNumber;
                    break;
                case "M+":
                    memoryValue += currentNumber;
                    break;
                case "M-":
                    memoryValue -= currentNumber;
                    break;
                case "MR":
                    displayBox.Text = memoryValue.ToString();
                    isNewInput = true;
                    break;
                case "MC":
                    memoryValue = 0;
                    break;
            }

            buttonMC.Enabled = memoryValue != 0;
            buttonMR.Enabled = memoryValue != 0;
            memoryBox.Text = memoryValue.ToString();
        }

        private void PerformArithmeticOperation(string operation)
        {
            double currentNumber = Convert.ToDouble(displayBox.Text);

            if (currentOperation == "")
            {
                previousValue = currentNumber;
            }
            else
            {
                switch (currentOperation)
                {
                    case "+":
                        previousValue += currentNumber;
                        break;
                    case "-":
                        previousValue -= currentNumber;
                        break;
                    case "*":
                        previousValue *= currentNumber;
                        break;
                    case "/":
                        if (currentNumber == 0)
                        {
                            MessageBox.Show("Ділення на нуль неможливе!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        previousValue /= currentNumber;
                        break;
                }
            }

            if (operation == "=")
            {
                displayBox.Text = previousValue.ToString();
                currentOperation = "";
            }
            else
            {
                currentOperation = operation;
                isNewInput = true;
            }
        }

        private void button1_Click(object sender, EventArgs e) => AppendNumber("1");
        private void button2_Click(object sender, EventArgs e) => AppendNumber("2");
        private void button3_Click(object sender, EventArgs e) => AppendNumber("3");
        private void button4_Click(object sender, EventArgs e) => AppendNumber("4");
        private void button5_Click(object sender, EventArgs e) => AppendNumber("5");
        private void button6_Click(object sender, EventArgs e) => AppendNumber("6");
        private void button7_Click(object sender, EventArgs e) => AppendNumber("7");
        private void button8_Click(object sender, EventArgs e) => AppendNumber("8");
        private void button9_Click(object sender, EventArgs e) => AppendNumber("9");
        private void button0_Click(object sender, EventArgs e) => AppendNumber("0");

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (displayBox.Text.Length > 1)
                displayBox.Text = displayBox.Text.Substring(0, displayBox.Text.Length - 1);
            else
                displayBox.Text = "0";
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!displayBox.Text.Contains(","))
                displayBox.Text += ",";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            displayBox.Text = "0";
            previousValue = 0;
            currentOperation = "";
            isNewInput = true; 
        }

        private void buttonAdd_Click(object sender, EventArgs e) => PerformArithmeticOperation("+");
        private void buttonSub_Click(object sender, EventArgs e) => PerformArithmeticOperation("-");
        private void buttonMul_Click(object sender, EventArgs e) => PerformArithmeticOperation("*");
        private void buttonDiv_Click(object sender, EventArgs e) => PerformArithmeticOperation("/");
        private void buttonEq_Click(object sender, EventArgs e) => PerformArithmeticOperation("=");

        private void buttonPercent_Click(object sender, EventArgs e) => ExecuteOperation("%");
        private void buttonSqrt_Click(object sender, EventArgs e) => ExecuteOperation("√"); 
        private void buttonSquare_Click(object sender, EventArgs e) => ExecuteOperation("x²");
        private void buttonInv_Click(object sender, EventArgs e) => ExecuteOperation("1/x");
        private void buttonNegate_Click(object sender, EventArgs e) => ExecuteOperation("+/-");

        private void buttonMC_Click(object sender, EventArgs e) => PerformMemoryOperation("MC");
        private void buttonMR_Click(object sender, EventArgs e) => PerformMemoryOperation("MR");
        private void buttonMS_Click(object sender, EventArgs e) => PerformMemoryOperation("MS");
        private void buttonMPlus_Click(object sender, EventArgs e) => PerformMemoryOperation("M+");
        private void buttonMMinus_Click(object sender, EventArgs e) => PerformMemoryOperation("M-");

        private void displayBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void memoryBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}