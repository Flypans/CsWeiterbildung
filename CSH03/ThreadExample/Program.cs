using System;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        public void ProgrammTakten()
        {
            while(true)
            {
                //Console.WriteLine(DateTime.Now);
                Console.Write("\r{0}",DateTime.Now);
                Thread.Sleep(1000);// 1 Sekunde
            }
        }

        static void Main(string[] args)
        {
            Program test = new Program();
            test.ProgrammTakten();
        }
    }
}
