using System;
using System.IO;

namespace StreamBeispiele
{
    class Program
    {
        public void WriterNutzen(string pfad, string content)
        {
            StreamWriter writer = new StreamWriter(File.Open(pfad, FileMode.Create));
            writer.WriteLine(content);
            writer.Close();
        }
        
        public void ReaderNutzen(string pfad)
        {
            StreamReader reader = new StreamReader(File.Open(pfad, FileMode.Open));
            //Console.WriteLine(reader.ReadLine());
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(0);
            reader.Close();
        }

        static void Main(string[] args)
        {
            Program test = new Program();

            string pfad = @"C:\CSH-Lehrgang\VS-Projekte\CSH03\Streamdatei.txt";
            string content = @"Dieser Text wird Inhalt der Datei. 
Er enthält Zeilenumbrüche und eine Pfadangabe: 
C:\CSH-Lehrgang\VS-Projekte\CSH03\Streamdatei.txt";
            //Console.WriteLine(content);

            test.WriterNutzen(pfad, content);
            test.ReaderNutzen(pfad);
        }
    }
}
