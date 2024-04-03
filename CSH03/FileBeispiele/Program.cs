using System;
using static System.Math;
using System.Threading;
using System.IO;
using System.Text;

namespace FileBeispiele
{
    class Program
    {
        public void DateiLesen(string pfad)
        {
            FileStream stream = File.Open(pfad, FileMode.Open);
            byte[] array = new byte[stream.Length];
            int retInt = stream.Read(array, 0, (int)stream.Length);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write((char)array[i]);
            }

            //Ascii
            //Console.WriteLine(string.Join(", ", array));

            //String
            //Console.WriteLine(Encoding.ASCII.GetString(array));

            Console.WriteLine();
            Console.WriteLine("Read-Rückgabewert = {0}", retInt);
            stream.Close();
        }
        public void DateiErstellen(string pfad, byte[] array)
        {
            FileStream stream = File.Open(pfad, FileMode.Create);
            stream.Write(array, 0, array.Length);
            stream.Close();
        }
        static void Main(string[] args)
        {
/*
            string a = "C:\\CSH-Lehrgang\\VS-Projekte\\CSH03\\Musterdatei.txt";
            string b = @"C:\CSH-Lehrgang\VS-Projekte\CSH03\Musterdatei.txt";

            Console.WriteLine("string a Equals string b?" + a.Equals(b));
*/

/*
            File.Open(@"C:\CSH-Lehrgang\VS-Projekte\CSH03\Musterdatei.txt", FileMode.Create);

            //System.IO.IOException: ''C:\CSH-Lehrgang\VS-Projekte\CSH03\Musterdatei.txt' 파일이 이미 있습니다.'
            File.Open(@"C:\CSH-Lehrgang\VS-Projekte\CSH03\Musterdatei.txt", FileMode.CreateNew);
*/
            Program test = new Program();
            string pfad = @"C:\CSH-Lehrgang\VS-Projekte\CSH03\Musterdatei.txt";
            byte[] array = { 68, 97, 116, 101, 105 };
            //byte[] array = Encoding.ASCII.GetBytes("Datei");

            test.DateiErstellen(pfad, array);
            test.DateiLesen(pfad);
        }
    }
}

