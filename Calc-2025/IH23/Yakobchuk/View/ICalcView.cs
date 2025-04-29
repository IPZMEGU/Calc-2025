using System;

namespace Calc_2023.IH23.Yakobchuk.View
{
    public interface ICalcView
    {
        event EventHandler<CalcCommandEventArgs> CalcCommand;
        void UpdateDisplay(string displayText, string memoryActive, string displyExpression);
    }
}
