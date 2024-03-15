using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02WHA4
{
    class Uebung
    {
        public void SwitchZaehler(uint n)
        {
            string ausgabe = "Wir zählen: ";

            switch (n > 5 ? 5 : n)//조건 연산자?
            {
                case 1: ausgabe += "eins, ";
                    break;
                case 2: ausgabe += "zwei, ";
                    break;
                case 3: ausgabe += "drei, ";
                    break;
                case 4: ausgabe += "vier, ";
                    break;
                case 5: ausgabe += "fünf, ";
                    break;
                case 6: ausgabe += "ganz viele ";
                    break;

                default: ausgabe = "kann nicht zaehlen";
                    break;
            }

            Console.WriteLine(ausgabe);
        }
        public void Fahrstuhl(uint stockwerk)
        {
            stockwerk %= 4;

            if (stockwerk == 0)
                Console.WriteLine($" {stockwerk}. : Erdgeschoss erreicht");
            else if (stockwerk == 1)
                Console.WriteLine($" {stockwerk}. : Obergeschoss  erreicht");
            else if (stockwerk == 2)
                Console.WriteLine($" {stockwerk}. : Obergeschoss  erreicht");
            else if (stockwerk == 3)
                Console.WriteLine($" {stockwerk}. : Dachgeschoss  erreicht");
            else
                Console.WriteLine($" {stockwerk}. : Error ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Uebung ue = new Uebung();

            ue.Fahrstuhl(5);
            ue.SwitchZaehler(3);
        }
    }
}
