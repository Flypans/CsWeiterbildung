using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion2
{
    class Luftfahrzeug
    {
        protected string kennung;
        public Luftfahrzeug(string kennung)
        {
            this.kennung = kennung;
        }

        //ToString() Override
        public override string ToString()
        {
            //return base.ToString();
            return kennung;
        }

    }
    class Referenztyp
    {
        public int value;

        public Referenztyp(int value)
        {
            this.value = value;
        }
    }

    class Uebungen
    {
        public void ChartypTesten()
        {
            char[] zeichen = { 'Z', 'e', 'i', 'c', 'h', 'e', 'n', 'k', 'e', 't', 't', 'e' };
            string str = new String(zeichen);
            Console.WriteLine("Der String: " + str);

        }
        public void StringtypTesten()
        {

            string a = "12345";

            string b = a;

            Console.WriteLine("=>a{0} b{1}0", a, b);

            a = "0";
            Console.WriteLine("=>a{0} b{1}0", a, b);
            Console.WriteLine("=============================");
        }
        public void ReferenztypTesten()
        {
            Referenztyp a = new Referenztyp(12345);
            Referenztyp b = a;
            Console.WriteLine("=============================");
            Console.WriteLine("a = {0}, b = {1}", a.value, b.value);
            
            a.value = 0;

            Console.WriteLine("a = {0}, b = {1}", a.value, b.value);

            Console.WriteLine("=============================");
        }

        public void ArrayHandling()
        {
            int[] intArray = new int[5] { 0, 1, 4, 9, 16 };

            int[,] intArray2D = new int[2, 3] { { 4, 16, 36 }, { 9, 25, 49 } };

            string[] stringArray = new string[3] { "ene", "mene", "muh" };

            Luftfahrzeug[] fliegerArray = new Luftfahrzeug[3]{
                new Luftfahrzeug("LH 3000"),
                new Luftfahrzeug("LH 550"),
                new Luftfahrzeug("LH 405")
            };
            Console.WriteLine(fliegerArray[2]);

            int[] quadratzahlen = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("quadratzahlen[{0}] : {1}", i, quadratzahlen[i]);
            }
            Console.WriteLine("=============================");

            quadratzahlen[0] = 2 * 2;
            quadratzahlen[1] = 3 * 3;
            quadratzahlen[2] = 4 * 4;
            quadratzahlen[3] = 5 * 5;
            quadratzahlen[4] = 6 * 6;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("quadratzahlen[{0}] : {1}", i, quadratzahlen[i]);
            }
            Console.WriteLine("=============================");
            Console.WriteLine("fliegerArray end : {0}", fliegerArray[fliegerArray.Length - 1]);

            int[,] matirx2D = new int[3, 4];

            Console.WriteLine("1 matrix : {0}", matirx2D.GetLength(0));
            Console.WriteLine("2 matrix : {0}", matirx2D.GetLength(1));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
                        char zeichenSmall = 'a';
                        Console.WriteLine(zeichenSmall);
                        Console.WriteLine((int)zeichenSmall);

                        char zeichenBig = 'A';
                        Console.WriteLine(zeichenBig);
                        Console.WriteLine((int)zeichenBig);

                        char[] csharp = new char[] { '\u0043', '\u0023' };
                        Console.WriteLine(csharp);

                        //char charA = 0x0041;// Fehler
                        char charA = (char)0x0041;// Type Casting
                        Console.WriteLine(charA);

                        int intB = 90;
                        char charb = (char)intB;
                        Console.WriteLine(charb);
            */
            Uebungen ue = new Uebungen();
            ue.ArrayHandling();
            ue.ReferenztypTesten();
            ue.StringtypTesten();
            ue.ChartypTesten();
        }
    }
}
