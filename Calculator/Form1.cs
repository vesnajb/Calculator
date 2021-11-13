using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Calculator
{
    public partial class Form1 : Form
    {
        //upotreba na globalizacija
        NumberFormatInfo nfi = new CultureInfo("en-US").NumberFormat;

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

            //Enable/Disable na tockata, za da ne moze da se pisuvaat broevi so poveke od 1 tocka
            if (b.Text == ".")
                b.Enabled = false;

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
                        vrednost += Decimal.Parse(txt_result.Text, nfi);
                        break;
                    case "-":
                        vrednost -= Decimal.Parse(txt_result.Text, nfi);
                        break;
                    case "*":
                        vrednost *= Decimal.Parse(txt_result.Text, nfi);
                        break;
                    case "/":
                        vrednost /= Decimal.Parse(txt_result.Text, nfi);
                        break;
                    default:
                        break;
                }
            }
            else
                vrednost = Decimal.Parse(txt_result.Text, nfi);

            operacija = b.Text;
            lbl_izraz.Text = vrednost.ToString(nfi) + " " + operacija;
            operacija_klik = true;
            button11.Enabled = true; //enable na tockata

        }

        private void ednakvo_Click(object sender, EventArgs e)
        {
            lbl_izraz.Text = "";
            switch (operacija)
            {
                case "+":
                    txt_result.Text = (vrednost + Decimal.Parse(txt_result.Text, nfi)).ToString(nfi);
                    break;
                case "-":
                    txt_result.Text = (vrednost - Decimal.Parse(txt_result.Text, nfi)).ToString(nfi);
                    break;
                case "*":
                    txt_result.Text = (vrednost * Decimal.Parse(txt_result.Text, nfi)).ToString(nfi);
                    break;
                case "/":
                    txt_result.Text = (vrednost / Decimal.Parse(txt_result.Text, nfi)).ToString(nfi);
                    break;
                default:
                    break;
            }
            vrednost = 0;
            brOperacii = 0;
            operacija_klik = true;
            button11.Enabled = true; //enable na tockata
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            txt_result.Text = "";
            button11.Enabled = true; //enable na tockata
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            txt_result.Text = "";
            vrednost = 0;
            lbl_izraz.Text = "";
            button11.Enabled = true; //enable na tockata
        }
    }
}
