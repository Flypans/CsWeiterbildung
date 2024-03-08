using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion4Typen
{
    //enum Airbus { A300, A310, A318, A319, A320, A321, A330, A340, A350, A380 }
    //enum Airbus : short { A300, A310, A318, A319, A320, A321, A330, A340, A350, A380 }
    //public Airbus type;

    class Referenztype
    {
        //Heap
        public int value;
        public Referenztype(int value)
        {
            this.value = value;
        }
    }
    class Program
    {
        //Heap
        static void ReferenztypeTesten()
        {
            Referenztype a = new Referenztype(12345);
            Referenztype b = a;

            Console.WriteLine("------------------Heap-------");
            Console.WriteLine("a = " + a.value);
            Console.WriteLine("b = " + b.value);

            a.value = 0;
            Console.WriteLine("b nach Änderung von a = " + b.value);
            Console.WriteLine(" a = 0 nach Änderung von a = " + a.value);
        }
        //Stack
        static void WerttypeTesten()
        {
            int a = 12345;
            int b = a;
            Console.WriteLine("------------------Stack-------");
            Console.WriteLine(" a = " + a);
            Console.WriteLine(" b = " + b);

            a = 0;

            Console.WriteLine(" b nach Änderung von a = " + b);
            Console.WriteLine(" a = 0 nach Änderung von a = " + a);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Heap or Stack");
            Program.WerttypeTesten();
            Program.ReferenztypeTesten();
        }
    }
 
}
