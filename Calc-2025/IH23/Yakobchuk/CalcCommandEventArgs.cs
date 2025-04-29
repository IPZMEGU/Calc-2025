using System;

namespace Calc_2023.IH23.Yakobchuk
{
    public class CalcCommandEventArgs : EventArgs
    {
        public string Text
        {
            get { return _text; }
            private set { _text = value; }
        }

        private string _text;

        public CalcCommandEventArgs(string text)
        {
            Text = text;
        }
    }
}
