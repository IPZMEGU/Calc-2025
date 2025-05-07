using Calc_2023.IH23.Yakobchuk.Model;
using Calc_2023.IH23.Yakobchuk.View;

namespace Calc_2023.IH23.Yakobchuk.Presenter
{
    class CalcPresenter
    {
        private readonly ICalcModel _model;
        private readonly ICalcView _view;

        public CalcPresenter(ICalcModel model, ICalcView view)
        {
            _view = view;
            _model = model;

            _view.CalcCommand += View_CalcCommand;
        }

        void View_CalcCommand(object sender, CalcCommandEventArgs e)
        {
            HandleButton(e.Text);
        }

        private void HandleButton(string text)
        {
            switch (text)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case ".":
                    _model.AppendDigitOrDecimal(text);
                    break;

                case "+":
                    _model.SetOperation(OperatorType.Add);
                    break;
                case "-":
                    _model.SetOperation(OperatorType.Subtract);
                    break;
                case "*":
                    _model.SetOperation(OperatorType.Multiply);
                    break;
                case "/":
                    _model.SetOperation(OperatorType.Divide);
                    break;
                case "x^y":
                    _model.SetOperation(OperatorType.Power);
                    break;
                case "sqrt":
                    _model.ApplyUnaryOperation(OperatorType.SquareRoot);
                    break;
                case "1/x":
                    _model.ApplyUnaryOperation(OperatorType.Reciprocal);
                    break;
                case "x^2":
                    _model.ApplyUnaryOperation(OperatorType.Square);
                    break;
                case "%":
                    _model.ApplyUnaryOperation(OperatorType.Percent);
                    break;
                case "+/-":
                    _model.ToggleSign();
                    break;
                case "x!":
                    _model.ApplyFactorial();
                    break;
                case "(":
                    _model.OpenParenthesis();
                    break;
                case ")":
                    _model.CloseParenthesis();
                    break;
                case "=":
                    _model.CalculateResult();
                    break;
                case "C":
                    _model.ClearAll();
                    break;
                case "CE":
                    _model.ClearEntry();
                    break;
                case "Backspace":
                    _model.Backspace();
                    break;
                case "MS":
                    _model.MemorySave();
                    break;
                case "MR":
                    _model.MemoryRecall();
                    break;
                case "M+":
                    _model.MemoryAdd();
                    break;
                case "M-":
                    _model.MemorySubtract();
                    break;
                case "MC":
                    _model.MemoryClear();
                    break;
            }

            _view.UpdateDisplay(_model.DisplayText, _model.DisplayMemory, _model.DisplyExpression);
        }
    }
}
