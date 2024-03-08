using System;

//Schreiben Sie eine Methode zur Berechnung der Fakultät einer Zahl,
//in der die Berechnung mithilfe einer for-Schleife durchgeführt wird.
//Die Zahl soll als Parameter an die Methode übergeben,
//die berechnete Fakultät von der Methode zurückgegeben werden.

namespace Aufgabe3
{
    class Program
    {
        static long Fakultät(int zahl)
        {
            long result = 1;
            //(5! = 1 X 2 X 3 X 4 X 5)
            for (int i = 1; i <= zahl; i++)
            {
                result = result * i;
            }
            return result;
        }
        static void Main(string[] args)
        {
            int inputNumber = 0;

            while(true)
            {
                Console.WriteLine("=====Zero to End =====");
                Console.Write("Please Enter a Number: ");

                inputNumber = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("=> Input Number : !" + inputNumber);

                if (inputNumber == 0)
                {
                    Console.WriteLine("Thank you");
                    break;
                }
                    
                else
                {
                    long fakultät = Fakultät(inputNumber);
                    Console.WriteLine("=> " + inputNumber + "!" + " ist = " + fakultät);
                }
            }
        }
    }
}
