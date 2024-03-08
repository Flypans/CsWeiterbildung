using System;

namespace _01Aufgabe3
{
    class Program
    {
        enum Airbus
        {
            A300 = 200, A310, A318 = 100, A319, A320, A321, A330 = 300, A340, A380 = 400
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Airbus.A321 : " + (int)Airbus.A321);

            foreach (Airbus enumValue in Enum.GetValues(typeof(Airbus)))
            {
                Console.WriteLine(enumValue + " = " + (int)enumValue);
            }
        }
    }
}
