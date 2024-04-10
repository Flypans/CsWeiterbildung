using System;
using static System.Math;
using System.Threading;
using System.IO;
using System.Text;

namespace BinToCmd
{
    class Program
    {
        public void ESA4Out(string pfad)
        {
            StreamReader reader = new StreamReader(File.Open(pfad, FileMode.Open));

            //while (reader.BaseStream.Position != reader.BaseStream.Length)
            try
            {
                string airRoute = reader.ReadToEnd();
                Console.WriteLine(airRoute);
            }
            catch (IOException e)
            {
                Console.WriteLine("{0} Fehler beim Zugriff auf die Datei " + pfad);
            }
            reader.Close();
        }
        static void Main(string[] args)
        {
            Program test = new Program();
            string pfad = @"C:\CSH-Lehrgang\VS-Projekte\LH 500.bin";
            test.ESA4Out(pfad);
        }
    }
}

