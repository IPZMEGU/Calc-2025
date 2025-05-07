using System;
using System.Collections.Generic;

namespace Calc_2023.IH23.Yakobchuk.Model
{
    class CalcModel : ICalcModel
    {
        private string _currentInput = "0";         // те, що користувач зараз вводить
        private double _result;                     // поточний результат
        private bool _waitingForNewInput;           // чи чекати новий ввід

        private string _expression = string.Empty;  // змінна для зберігання виразу

        private double _memory;                     // пам'ять (MS, MR, M+ і т.д.)

        public string DisplayText
        {
            get { return _currentInput; }
        }

        public string DisplayMemory
        {
            get { return _memory.ToString(); }
        }

        public string DisplyExpression
        {
            get { return _expression; }
        }

        /// <summary>
        /// Метод для додавання цифр або крапки
        /// </summary>
        /// <param name="digit"></param>
        public void AppendDigitOrDecimal(string digit)
        {
            if (_waitingForNewInput)
            {
                _currentInput = "0";
                _waitingForNewInput = false;
            }

            if (digit == ".")
            {
                if (!_currentInput.Contains("."))
                    _currentInput += ".";
            }
            else
            {
                if (_currentInput == "0")
                    _currentInput = digit;
                else
                    _currentInput += digit;
            }
        }

        /// <summary>
        /// Метод для встановлення бінарної операції (+, -, *, /, ^)
        /// </summary>
        /// <param name="operation"></param>
        public void SetOperation(OperatorType operation)
        {
            if (!_waitingForNewInput)
                _expression += _currentInput;
            else if (!string.IsNullOrWhiteSpace(_expression)
                     && IsOperator(_expression[_expression.Length - 1].ToString()))
            {
                _expression = _expression.Substring(0, _expression.Length - 1);
            }

            switch (operation)
            {
                case OperatorType.Add:
                    _expression += "+";
                    break;
                case OperatorType.Subtract:
                    _expression += "-";
                    break;
                case OperatorType.Multiply:
                    _expression += "*";
                    break;
                case OperatorType.Divide:
                    _expression += "/";
                    break;
                case OperatorType.Power:
                    _expression += "^";
                    break;
            }

            _waitingForNewInput = true;
        }

        /// <summary>
        /// Метод для унарних операцій (sqrt, 1/x, x!)
        /// </summary>
        /// <param name="operation"></param>
        public void ApplyUnaryOperation(OperatorType operation)
        {
            double input = double.Parse(_currentInput);

            switch (operation)
            {
                case OperatorType.SquareRoot:
                    input = Math.Sqrt(input);
                    break;
                case OperatorType.Reciprocal:
                    input = 1.0 / input;
                    break;
                case OperatorType.Square:
                    input = input * input;
                    break;
                case OperatorType.Percent:
                    input = _result * input / 100.0;
                    break;
            }

            _currentInput = input.ToString();
            _waitingForNewInput = false;
        }

        /// <summary>
        /// Унарний плюс/мінус (+/-)
        /// </summary>
        public void ToggleSign()
        {
            if (_currentInput.StartsWith("-"))
                _currentInput = _currentInput.Substring(1);
            else if (_currentInput != "0")
                _currentInput = "-" + _currentInput;
        }

        /// <summary>
        /// Факторіал x!
        /// </summary>
        public void ApplyFactorial()
        {
            double input = double.Parse(_currentInput);

            if (input < 0 || input != Math.Floor(input))
            {
                _currentInput = "Error";
                return;
            }

            double result = 1;
            for (int i = 1; i <= (int)input; i++)
            {
                result *= i;
            }

            _currentInput = result.ToString();
            _waitingForNewInput = false;
        }

        #region Обробка дужок

        public void OpenParenthesis()
        {
            _expression += "(";
        }

        public void CloseParenthesis()
        {
            _expression += _currentInput + ")";
            _waitingForNewInput = true;
        }

        #endregion Обробка дужок

        /// <summary>
        /// Метод для обчислення при натисканні "="
        /// </summary>
        public void CalculateResult()
        {
            _expression += _currentInput;

            try
            {
                _result = EvaluateExpression(_expression);
                _currentInput = _result.ToString();
            }
            catch (DivideByZeroException)
            {
                _currentInput = "Division by zero!";
            }
            catch (Exception)
            {
                _currentInput = "Error";
            }

            _expression = "";
            _waitingForNewInput = false;
        }


        #region Очищення і Backspace

        public void ClearAll()
        {
            _currentInput = "0";
            _result = 0;
            _waitingForNewInput = false;
            _expression = string.Empty;
        }

        public void ClearEntry()
        {
            _currentInput = "0";
        }

        public void Backspace()
        {
            if (_waitingForNewInput)
                return;

            _currentInput = _currentInput.Length > 1
                ? _currentInput.Substring(0, _currentInput.Length - 1)
                : "0";
        }

        #endregion Очищення і Backspace

        #region Операції пам'яті

        public void MemorySave()
        {
            _memory = double.Parse(_currentInput);
        }

        public void MemoryRecall()
        {
            _currentInput = _memory.ToString();
            _waitingForNewInput = true;
        }

        public void MemoryAdd()
        {
            _memory += double.Parse(_currentInput);
        }

        public void MemorySubtract()
        {
            _memory -= double.Parse(_currentInput);
        }

        public void MemoryClear()
        {
            _memory = 0;
        }

        #endregion Операції пам'яті

        #region Обчислення значення виразу

        /// <summary>
        /// Пріоритет операцій
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        private static int GetPriority(string op)
        {
            if (op == "+" || op == "-")
                return 1;
            if (op == "*" || op == "/")
                return 2;
            if (op == "^")
                return 3;
            return 0;
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
        }

        /// <summary>
        /// Перетворення виразу у постфікс
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static IEnumerable<string> ToPostfix(string expression)
        {
            List<string> output = new List<string>();
            Stack<string> operators = new Stack<string>();

            int i = 0;
            while (i < expression.Length)
            {
                if (char.IsDigit(expression[i]) || expression[i] == '.')
                {
                    string number = "";

                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        number += expression[i];
                        i++;
                    }

                    output.Add(number);
                    continue;
                }

                if (expression[i] == '(')
                {
                    operators.Push("(");
                }
                else if (expression[i] == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                        output.Add(operators.Pop());
                    if (operators.Count > 0)
                        operators.Pop(); // викидаємо "("
                }
                else if (IsOperator(expression[i].ToString()))
                {
                    string op = expression[i].ToString();

                    // Унарний мінус:
                    if (op == "-" && (i == 0 || expression[i - 1] == '(' || IsOperator(expression[i - 1].ToString())))
                    {
                        // Це унарний мінус: приписуємо до числа
                        i++;
                        string number = "-";

                        // Додаємо всі цифри числа
                        while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                        {
                            number += expression[i];
                            i++;
                        }

                        output.Add(number);
                        continue;
                    }

                    while (operators.Count > 0 && GetPriority(operators.Peek()) >= GetPriority(op))
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(op);
                }

                i++;
            }

            while (operators.Count > 0)
            {
                output.Add(operators.Pop());
            }

            return output;
        }

        /// <summary>
        /// Обчислення постфіксного виразу
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        private static double EvaluatePostfix(IEnumerable<string> postfix)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string token in postfix)
            {
                if (IsOperator(token))
                {
                    double right = stack.Pop();
                    double left = stack.Pop();
                    double result = 0;

                    switch (token)
                    {
                        case "+":
                            result = left + right;
                            break;
                        case "-":
                            result = left - right;
                            break;
                        case "*":
                            result = left * right;
                            break;
                        case "/":
                            if (right == 0)
                                throw new DivideByZeroException();
                            result = left / right;
                            break;
                        case "^":
                            result = Math.Pow(left, right);
                            break;
                    }

                    stack.Push(result);
                }
                else
                {
                    stack.Push(double.Parse(token));
                }
            }

            return stack.Pop();
        }

        private static double EvaluateExpression(string expression)
        {
            IEnumerable<string> postfix = ToPostfix(expression);
            return EvaluatePostfix(postfix);
        }

        #endregion Обчислення значення виразу
    }
}
