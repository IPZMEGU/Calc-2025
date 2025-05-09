using System;
using System.Windows.Forms;

namespace Calc_2023.IH23.Yakobchuk.View
{
    public partial class CalcView : Form, ICalcView
    {
        public CalcView()
        {
            InitializeComponent();

            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Click += Button_Click;
                    ctrl.Tag = ctrl.Text;
                }
            }
        }

        void CalcView_KeyDown(object sender, KeyEventArgs e)
        {
            string key = "";

            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                key = ((char) e.KeyCode).ToString(); // Цифри 0-9
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                key = ((char) (e.KeyCode - Keys.NumPad0 + '0')).ToString(); // Цифри з NumPad
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus && e.Shift)
            {
                key = "+";
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                key = "-";
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                key = "*";
            }
            else if (e.KeyCode == Keys.Divide)
            {
                key = "/";
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemplus && !e.Shift)
            {
                key = "=";
            }
            else if (e.KeyCode == Keys.Back)
            {
                key = "Backspace";
            }
            else if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                key = ".";
            }
            else if (e.KeyCode == Keys.Escape)
            {
                key = "C";
            }

            if (!string.IsNullOrEmpty(key))
            {
                CalcCommand?.Invoke(this, new CalcCommandEventArgs(key));
                e.Handled = true;
            }
        }

        private static T GetSafeTag<T>(Button btn)
        {
            return (T)Convert.ChangeType(btn.Tag ?? btn.Text, typeof(T));
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string tag = GetSafeTag<string>((Button) sender);

            CalcCommand?.Invoke(this, new CalcCommandEventArgs(tag));

            lblMemory.Focus();
        }

        public event EventHandler<CalcCommandEventArgs> CalcCommand;

        public void UpdateDisplay(string displayText, string displayMemory, string displyExpression)
        {
            txtResult.Text = displayText;
            txtMemory.Text = displayMemory;
            txtExpression.Text = displyExpression;
        }
    }
}