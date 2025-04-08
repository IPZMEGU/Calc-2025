using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorGD;
using LROOP7;
using Calc_Motrynets;
using CalcFomin;
using calc_Katerynych;
using Calculator;
using Calc_Maksymchuk;
using Calculator_by_Vodyanitski;
using CalcKutsevychc;
using Calc_Makhniuk;
using Calc_VladyslavM;
using CalcKostiuk;

namespace Calc_2023
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcSH calcForm = new CalcSH();
            calcForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GomonDForm gomonDForm = new GomonDForm();
            gomonDForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalcFK2 Romanuk = new CalcFK2();
            Romanuk.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalcMotrynets calc_Motrynets = new CalcMotrynets();
            calc_Motrynets.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Calc_Fomin c = new Calc_Fomin();
            c.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CalcHlinskih h = new CalcHlinskih();
            h.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CalcDikal n = new CalcDikal();
            n.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Calc_Katerynych katerynych = new Calc_Katerynych();
            katerynych.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CalcMaksymchuk p = new CalcMaksymchuk();
            p.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            formVodyanitski v = new formVodyanitski();
            v.ShowDialog();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            FormCalc v = new FormCalc();
            v.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CalcMakhniuk v = new CalcMakhniuk();
            v.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CalcVladyslav calcVM = new CalcVladyslav();
            calcVM.ShowDialog();


        }

        private void button14_Click(object sender, EventArgs e)
        {
            Calc_Kostiuk KostDenis = new Calc_Kostiuk();
            KostDenis.ShowDialog();
        }
    }
}
