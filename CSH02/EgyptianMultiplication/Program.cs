using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianMultiplication
{
    class Uebungen
    {
        public int Multiplizieren(int kaufpreise, int muenzen, int hoelzchen)
        {
            if (hoelzchen == 1)// End conditions
            {
                Console.WriteLine($" End :{hoelzchen} Price:{kaufpreise += muenzen}");
                return kaufpreise += muenzen;
            }
            
            else if (hoelzchen % 2 == 0) //gerade
            {
                Console.WriteLine($" {hoelzchen} Gerad, muenzen :{muenzen} , hoelzchen {hoelzchen}");
                return Multiplizieren(kaufpreise, muenzen << 1, hoelzchen >> 1); //recursive function
            }
            else //ungerad
            {
                kaufpreise = kaufpreise + muenzen;

                Console.WriteLine($" {hoelzchen} Ungerad, muenzen :{muenzen} , hoelzchen {hoelzchen}, kaufpreise{kaufpreise}");
                return Multiplizieren(kaufpreise, muenzen << 1, hoelzchen >> 1);//recursive function
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Uebungen ue = new Uebungen();

            int kaufpreis = 0;
            int muenzen = 7;
            int hoelzchen = 53;

            kaufpreis = ue.Multiplizieren(kaufpreis, muenzen, hoelzchen);

            Console.WriteLine($"{muenzen} x {hoelzchen} = { kaufpreis}, Kontrolle: {muenzen * hoelzchen}");

        }
    }
}
