using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        int brOperacii = 0;
        Decimal vrednost = 0;
        String operacija = "";
        bool operacija_klik = false;
        public Form1()
        {
            InitializeComponent();
        }

        //this is for all btns with character number
        private void button_Click(object sender, EventArgs e)
        {
            if (operacija_klik || txt_result.Text == "0")
                txt_result.Clear();

            Button b = (Button)sender;
            txt_result.Text += b.Text;

            operacija_klik = false;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            brOperacii++;

            if (brOperacii > 1)
            {
                switch (operacija)
                {
                    case "+":
                        vrednost += Decimal.Parse(txt_result.Text);
                        break;
                    case "-":
                        vrednost -= Decimal.Parse(txt_result.Text);
                        break;
                    case "*":
                        vrednost *= Decimal.Parse(txt_result.Text);
                        break;
                    case "/":
                        vrednost /= Decimal.Parse(txt_result.Text);
                        break;
                    default:
                        break;
                }
            }
            else
                vrednost = Decimal.Parse(txt_result.Text);

            operacija = b.Text;
            lbl_izraz.Text = vrednost + " " + operacija;
            operacija_klik = true;

        }

        private void ednakvo_Click(object sender, EventArgs e)
        {
            lbl_izraz.Text = "";
            switch (operacija)
            {
                case "+":
                    txt_result.Text = (vrednost + Decimal.Parse(txt_result.Text)).ToString();
                    break;
                case "-":
                    txt_result.Text = (vrednost - Decimal.Parse(txt_result.Text)).ToString();
                    break;
                case "*":
                    txt_result.Text = (vrednost * Decimal.Parse(txt_result.Text)).ToString();
                    break;
                case "/":
                    txt_result.Text = (vrednost / Decimal.Parse(txt_result.Text)).ToString();
                    break;
                default:
                    break;
            }
            vrednost = 0;
            brOperacii = 0;
            operacija_klik = true;
        }
    }
}
