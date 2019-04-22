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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDodadiNovProdukt_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //newForm.Show();
            if(newForm.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                listBoxProdukti.Items.Add(Form2.produkt);
            }
        }

        private void listBoxProdukti_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produkt selektiranProd = listBoxProdukti.SelectedItem as Produkt;
            if(selektiranProd!=null)
            {
                textBoxImeF1.Text = selektiranProd.getIme();
                textBoxKategorijaF1.Text = selektiranProd.getKategorija();
                textBoxCenaF1.Text = selektiranProd.getCena().ToString();
            }
        }

        private void buttonIsprazniListaProdukti_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Дали сакате да ја испразните листата со продукти?","Испразни ја листата", MessageBoxButtons.YesNo) == DialogResult.Yes)
                listBoxProdukti.Items.Clear();
        }

        private void buttonIzbrishiProdukt_Click(object sender, EventArgs e)
        {
            if(listBoxProdukti.SelectedIndex!=-1)
            {
                listBoxProdukti.Items.RemoveAt(listBoxProdukti.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Немате селектирано продукт");
            }
        }

        private void buttonIzbrishiOdKoshnichka_Click(object sender, EventArgs e)
        {
            if(listBoxKoshnichka.SelectedIndex!=-1)
            {
                listBoxKoshnichka.Items.RemoveAt(listBoxKoshnichka.SelectedIndex);
                vkupnocena();
            }
            else
            {
                MessageBox.Show("Немате селектирано продукт");
            }
        }

        private void buttonDodadiVoKoshnichka_Click(object sender, EventArgs e)
        {
            if (listBoxProdukti.SelectedIndex != -1)
            {
                listBoxKoshnichka.Items.Add(listBoxProdukti.SelectedItem);
                vkupnocena();
            }
            else
            {
                MessageBox.Show("Немате селектирано продукт");
            }
        }
        public void vkupnocena()
        {
            int suma = 0;
            foreach(Produkt p in listBoxKoshnichka.Items)
            {
                suma += p.getCena();
            }
            vkupnaCena.Text = suma.ToString();

        }
    }
}
