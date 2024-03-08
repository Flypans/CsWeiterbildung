using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;

namespace Lektion2
{
    class Program
    {
        static string ToString( int aValue)
        {
            return "" + aValue;
        }

        static int ToInt(string bValue)
        {
            return int.Parse(bValue);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            string sValue = Program.ToString(12345);

            int iValue = Program.ToInt("67890");

            Console.WriteLine(sValue);

            Console.WriteLine(iValue);
            
            Console.ReadLine();
        }
    }
}
