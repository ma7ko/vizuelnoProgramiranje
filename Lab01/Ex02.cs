using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double N,menu;
            Random random = new Random();
            double midval = 0, max = 0, min = 1000;
            Console.WriteLine("Enter how many numbers you will use:");
            N = Convert.ToDouble(Console.ReadLine());
            double[] niza = new double[Convert.ToInt32(N)];
            Console.WriteLine("If you want to enter them by yourself press 1, otherwise press 2");
            menu = Convert.ToDouble(Console.ReadLine());
            if(menu==1) {
                for(int i=0;i<N;i++) {
                    niza[i] = Convert.ToDouble(Console.ReadLine());
                }
            }
            else {
                for(int i=0;i<N;i++) {
                    niza[i] = random.Next(1, 1000);
                    Console.Write("{0} ", niza[i]);
                }
            }
            Console.WriteLine(" ");
            foreach(double d in niza) {
                if (d > max)
                    max = d;
                if (d < min)
                    min = d;
                midval = midval + d;
            }
            Console.WriteLine("The middle value of the sequence of numbers is {0}", midval/N);
            Console.WriteLine("The maximum in the sequence is {0}", max);
            Console.WriteLine("The minimum in the sequence is {0}", min);
            Console.ReadKey();
        }
    }
}
