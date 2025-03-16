using System;
using System.Windows.Forms;
using Calc_2023;
using Calculator_by_Vodyanitski;

namespace Calculator_by_Vodyanitski
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormStart());
        }
    }
}
