using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _03WHA2_1
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime now = DateTime.Now;
            Console.WriteLine($"{now.Hour}:{now.Minute}:{now.Second}");

            while (true)
            {
                Console.Write("\r\a{0}", DateTime.Now);
            }

        }
    }
}
