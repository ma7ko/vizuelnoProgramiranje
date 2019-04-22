using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public static Produkt produkt;
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonDodadiF2_Click(object sender, EventArgs e)
        {
            string ime = textBoxImeF2.Text.ToString();
            string kategorija = textBoxKategorijaF2.Text.ToString();
            int cena;
            int.TryParse(textBoxCenaF2.Text, out cena);
            produkt = new Produkt(ime, kategorija, cena);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonOtkazhiF2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
