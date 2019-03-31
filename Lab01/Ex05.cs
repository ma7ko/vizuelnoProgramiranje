using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    enum strength : byte
    {
        easy = 1,
        normal = 6,
        hard = 10
    }

    class Program
    {
        static void Main(string[] args)
        {
            string vnes;
            string[] nizaLozinki;
            char[] separator = { ' ' };
            Console.WriteLine("Vnesete povekje lozinki vo eden red odvoeni so prazno mesto, obiduvajki se da pogodite");
            Console.WriteLine("3 lozinki koi kje bidat kompjuterski generirani");
            vnes = Console.ReadLine();
            nizaLozinki = vnes.Split(separator);
            Program p = new Program();
            string lesnaGenerirana = p.CreatePassword(strength.easy);
            string srednaGenerirana = p.CreatePassword(strength.normal);
            string teshkaGenerirana = p.CreatePassword(strength.hard);
            foreach(string lozinka in nizaLozinki)
            {
                if (lozinka.Equals(lesnaGenerirana))
                    Console.WriteLine("Ja pogodivte {0}", lesnaGenerirana);
                else
                    Console.WriteLine("Ne ja pogodivte {0}, vie vnesovte {1}", lesnaGenerirana, lozinka);
                if (lozinka.Equals(srednaGenerirana))
                    Console.WriteLine("Ja pogodivte {0}", srednaGenerirana);
                else
                    Console.WriteLine("Ne ja pogodivte {0}, vie vnesovte {1}", srednaGenerirana, lozinka);
                if (lozinka.Equals(teshkaGenerirana))
                    Console.WriteLine("Ja pogodivte {0}", teshkaGenerirana);
                else
                    Console.WriteLine("Ne ja pogodivte {0}, vie vnesovte {1}", teshkaGenerirana, lozinka);
            }
            Console.ReadKey();
        }

        public string CreatePassword(strength s)
        {
            Console.WriteLine("{0}", s);
            Random rnd = new Random();
            const string prva = "abcdefghijklmnopqrstuvwxyz";
            const string vtora = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            const string treta = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+{}|:<>?[]\\;',./\"";
            StringBuilder res = new StringBuilder();
            int length = 0;
            if (s.Equals(strength.easy))
            {
                length = rnd.Next(1, 6);
                while (0 < length--)
                {
                    res.Append(prva[rnd.Next(prva.Length)]);
                }
                return res.ToString();
            }
            else if (s.Equals(strength.normal))
            {
                length = rnd.Next(6, 10);
                while (0 < length--)
                {
                    res.Append(vtora[rnd.Next(vtora.Length)]);
                }
                return res.ToString();
            }
            else if (s.Equals(strength.hard))
            {
                length = rnd.Next(10, 13);
                while (0 < length--)
                {
                    res.Append(treta[rnd.Next(treta.Length)]);
                }
                return res.ToString();
            }
            else
                return "Nevaliden vlez";
            }
    }
}
