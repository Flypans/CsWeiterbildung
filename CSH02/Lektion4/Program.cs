using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion4
{
    class Uebungen
    {
        public void ForEach(string[] values)
        {
            foreach(string Value in values)
            {
                Console.WriteLine(Value);
            }
        }

        public void ForStattForEach(string[] values)
        {
            for(int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($" {i} = {values[i]}");
            }
        }

        public int FakultaetDoWhile(int number)
        {
            int ergebnis = 1;
            int zaehler = 1;

            do
            {
                ergebnis *= zaehler++;

            } while (zaehler <= number);

            return ergebnis;
        }
        public int FakultaetWhile(int number)
        {
            int ergebnis = 1;
            int zaehler = 1;

            /*
                        while(zaehler <= number)
                        {
                            ergebnis = ergebnis * zaehler;
                            zaehler = zaehler + 1;
                        }
            */
            while (zaehler <= number)
            {
                ergebnis *= zaehler++;
            }
            return ergebnis;
        }
        public enum DayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
        public void ToDayInWeek(DayOfWeek toDay)
        {
            switch (toDay)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Today is on Monday");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("Today is on Tuesday");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("Today is on Wednesday");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Today is on Thursday");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Today is on Friday");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Today is on Saturday");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("Today is on Sunday");
                    break;
                default:
                    Console.WriteLine("Unknown");
                    break;
            }
        }
        public void Fahrstuhl(uint stockwerk)
        {
            switch (stockwerk)
            {
                case 0:
                    Console.WriteLine("ERDEGESCHOSS ERREICHT");
                    break;
                case 1:
                    Console.WriteLine("1. OBERGESCHOSS ERREICHT");
                    break;
                case 2:
                    Console.WriteLine("2. OBERGESCHOSS ERREICHT");
                    break;
                case 3:
                    Console.WriteLine("DACHGESCHOSS ERREICHT");
                    break;
                default:
                    Console.WriteLine($"{stockwerk} Invalid floor number entered.");
                    break;
            }
        }

        public void AlternativeAuswahl(bool CSHinteressiert, bool VBinteressiert)
        {
            Console.WriteLine($" CSHinteressiert : {CSHinteressiert} , VBinteressiert : {VBinteressiert}");
            if (CSHinteressiert)
            {
                Console.WriteLine("Ich buche einen C#-Lehrgang.");
            }
            else if (VBinteressiert)
            {
                Console.WriteLine("Ich buche einen VB.NET-Lehrgang.");
            }
            else
            {
                Console.WriteLine("Ich orientiere mich im Studienführer.");
            }
        }

        public void EinfacheAuswahl(int alter, string name)
        {
            Console.WriteLine($" alter :  {alter} , name : {name}");

            const int VOLLJAEHRIG = 18;

            if (alter >= VOLLJAEHRIG)
            {
                Console.WriteLine($"{name} ist volljährig.");
            }
            else
            {
                Console.WriteLine($"{name} ist NICHT volljährig.");
            }
        }

        public int Sequenz(int a, int b, int c, int d, int e)
        {
            int Result, r1, r2, r3 = 0;

            r1 = b * c;
            Console.WriteLine("{0} = {1} * {2}", r1, b, c);

            r2 = a + r1;
            Console.WriteLine("{0} = {1} + {2}", r2, a, r1);

            r3 = d - e;
            Console.WriteLine("{0} = {1} - {2}", r3, d, e);

            r1 = r2 * r3;
            Console.WriteLine("{0} = {1} * {2}", r1, r2, r3);

            Result = r1;
            Console.WriteLine("Kontrolle: {0}", (a + b * c) * (d - e));

            return Result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uebungen ue = new Uebungen();
            Console.WriteLine($"Sequnz : {ue.Sequenz(10, 3, 5, 19, 2)}");

            ue.EinfacheAuswahl(19, "Gudrun");

            ue.AlternativeAuswahl(true, false);
            ue.Fahrstuhl(7);

            Uebungen.DayOfWeek toDay = Uebungen.DayOfWeek.Friday;// emum
            ue.ToDayInWeek(toDay);

            Console.WriteLine($" 5! = {ue.FakultaetWhile(5)}");

            Console.WriteLine($" 8! = {ue.FakultaetDoWhile(8)}");

            string[] values = { "eins", "zwei", "drei", "vier" };
            ue.ForEach(values);
            ue.ForStattForEach(values);


        }
    }
}
