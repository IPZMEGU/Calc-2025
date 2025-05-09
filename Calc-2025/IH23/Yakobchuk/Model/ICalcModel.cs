namespace Calc_2023.IH23.Yakobchuk.Model
{
    interface ICalcModel
    {
        string DisplayText { get; }
        string DisplayMemory { get; }
        string DisplyExpression { get; }

        void AppendDigitOrDecimal(string digit);
        void SetOperation(OperatorType operation);
        void ApplyUnaryOperation(OperatorType operation);
        void ToggleSign();
        void ApplyFactorial();
        void OpenParenthesis();
        void CloseParenthesis();
        void CalculateResult();
        void ClearAll();
        void ClearEntry();
        void Backspace();
        // пам'ять:
        void MemorySave();
        void MemoryRecall();
        void MemoryAdd();
        void MemorySubtract();
        void MemoryClear();
    }
}
