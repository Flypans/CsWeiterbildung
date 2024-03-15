using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02WHA3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("12345 & 8: {0}", 12345 & 8);
            // Ausgabe: 8

            Console.WriteLine("12345 & 512: {0}", 12345 & 512);
            // Ausgabe: 0

            Console.WriteLine("12345 & 8192: {0}", 12345 & 8192);
            // Ausgabe: 8192

            Console.WriteLine("Int32.MaxValue =    :  {0}",Int32.MaxValue);
            Console.WriteLine("Int32.MaxValue << 1 :  {0}", Int32.MaxValue << 1);
        }
    }
}
