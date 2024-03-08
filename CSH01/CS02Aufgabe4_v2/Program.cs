using System;

//In der Mathematik nennt man einen Algorithmus, dessen allgemeine Gültigkeit noch nicht
//bewiesen wurde, eine „Vermutung“. Eine berühmte Vermutung dieser Art wurde von dem
//amerikanischen Mathematiker Ulam aufgestellt und heißt seitdem Ulamsche Vermutung.
//Sie ist gar nicht kompliziert – umso mehr erstaunt es, dass sie bislang nicht bewiesen
//werden konnte:
//Wenn Sie mit einer Zahl zahl > 0 beginnen und diese Zahl wiederholt halbieren –
//sofern sie gerade ist –, oder aber mit 3 multiplizieren und 1 addieren –
//sofern sie ungerade ist –, dann landen Sie[dies ist bislang nicht allgemein gültig
//bewiesen] irgendwann bei der Zahl 1.
//a)	Planen Sie eine Methode UlamVermutung durch Entwurf eines Struktogramms.
//Die Methode soll zunächst die Zahl, mit der sie aufgerufen wurde,
//ausgeben und sodann in jedem Berechnungsschritt den aktuellen Wert der Variablen zahl
//ausgeben.Die Berechnung endet, wenn zahl den Wert 1 erreicht hat.
//Hinweis: Sie werden eine Schleife benötigen.

namespace C02Aufgabe4_v2
{
    class Program
    {
        static void UlamVermutung(int zahl)
        {
            int result = 0;

            while (result != 1)
            {
                Console.WriteLine("=====Up to One =====");
                Console.Write("Please Enter a Number: ");

                zahl = Convert.ToInt32(Console.ReadLine());

                //Collatz Conjecture
                if (zahl % 2 == 0)
                {
                    zahl = zahl / 2;
                    Console.WriteLine("positive ganze Zahl");
                }

                else
                {
                    zahl = (zahl * 3) + 1;
                }
                result = zahl;

                Console.WriteLine("Result Value : " + result);
            }

        }

        static void Main(string[] args)
        {
            int inputNumber = 0;

            UlamVermutung(inputNumber);
        }
    }
}
