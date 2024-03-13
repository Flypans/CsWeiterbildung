using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion3
{
    class Operatoren
    {
        public void LogicalOps()
        {
            //kreditwürdig = volljährig & (verdienst > 2000 | bürge)
            bool volljährig = true;
            double verdienst = 1900;
            bool Bürge = true;
            bool kreditwürdig = volljährig & (verdienst > 2000 | Bürge);

            Console.WriteLine("kreditwürdig: {0}", kreditwürdig);
        }
        public void Vergleiche()
        {
            double x = 2.39;
            double y = 2.37;
            bool b = x >= y;      // Wert von b ist true;

            Console.WriteLine(" x : {0}, y : {1}, b : {2}", x, y, b);

            int var1 = -1234;
            int var2 = 1234;
            int var3 = 1234;

            Console.WriteLine("var1 < var2 == var3 >= var2: {0}", var1 < var2 == var3 >= var2);

            string s1 = "string";
            string s2 = s1;

            Console.WriteLine("s1 == s2: {0}", s1 == s2);
        }
        public void RundeKlammern()
        {
            //Auf welche Ganzzahl wird der Ausdruck 5 + 11 · 12 – 14 / 7 ausgewertet ?
            int ausgewertet = (5 + (11 * 12)) - (14 / 7);
            Console.WriteLine(ausgewertet);
        }
        public void UnaereOperatoren()
        {
        }
        public void TernaererOperator()
        {
            int var1 = +1234;
            int var2 = -1234;

            string auswertung = (var1 == var2) ? "gleich" : "ungleich";
            Console.WriteLine("{0} == {1} ? {2}", var1, var2, auswertung);
        }
        public void Module()
        {
            int intVar1 = 1234;
            int intVar2 = 13;
            double doubleVar1 = 22.33;
            double doubleVar2 = 6.6;

            Console.WriteLine("intVar1 % intVar2 = {0}", intVar1 % intVar2);
            Console.WriteLine("doubleVar1 % doubleVar2 = {0}", doubleVar1 % doubleVar2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Operatoren ops = new Operatoren();
            ops.TernaererOperator();
            ops.RundeKlammern();
            ops.Module();
            ops.Vergleiche();
            ops.LogicalOps();
        }
    }
}
