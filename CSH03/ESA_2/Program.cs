using System;
using System.IO;

namespace ESA_2
{
    class Program
    {
        static void ESA2In(byte[] array, string pfad)
        {
            try
            {
                StreamWriter writer = new StreamWriter(File.Open(pfad, FileMode.Create));
                
                foreach(byte index in array)
                {
                    writer.Write((char)index);// byte to char casting
                }
                
                Console.WriteLine(" Erfolgreiches Schreiben auf die Datei. ");
                writer.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(" Fehler beim Zugriff auf die Datei. ");
            }
        }

        static void ESA2Out(string pfad)
        {
            try
            {
                StreamReader reader = new StreamReader(File.Open(pfad, FileMode.Open));

                int count = 0;
                int index = 0;

                while((index = reader.Read()) != -1 )
                {
                    Console.Write($"[{(char)index}]");// byte to char casting
                    count++;
                    if (count % 11 == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" Fehler beim Schreiben auf die Datei. ");
            }
        }
        static void Main(string[] args)
        {
            byte[] array = {
            32, 32, 67, 67, 32, 32, 32, 35, 32, 35, 32,
            32, 67, 32, 32, 67, 32, 32, 35, 32, 35, 32,
            67, 32, 32, 32, 32, 32, 35, 35, 35, 35, 35,
            67, 32, 32, 32, 32, 32, 32, 35, 32, 35, 32,
            67, 32, 32, 32, 32, 32, 35, 35, 35, 35, 35,
            32, 67, 32, 32, 67, 32, 32, 35, 32, 35, 32,
            32, 32, 67, 67, 32, 32, 32, 35, 32, 35, 32
        };

            string pfad = @"C:\CSH-Lehrgang\VS-Projekte\CSH03\ESA_2\bin\Release\ESA_2.txt";

            ESA2In(array, pfad);
            ESA2Out(pfad);
        }
    }
}
