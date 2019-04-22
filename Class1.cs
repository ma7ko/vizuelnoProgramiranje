using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Produkt
    {
        string ime;
        string kategorija;
        int cena;
        public Produkt(string ime, string kategorija, int cena)
        {
            this.ime = ime;
            this.kategorija = kategorija;
            this.cena = cena;
        }
        public string getIme()
        {
            return ime;
        }
        public string getKategorija()
        {
            return kategorija;
        }
        public int getCena()
        {
            return cena;
        }
        public override string ToString()
        {
            return string.Format("{0}", ime);
        }
    }
}
