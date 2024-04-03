using System;
using System.IO;

#pragma warning disable CS0168

namespace BinaryBeispiele
{
    class Program
    {
        public void BinaryRead(string path)
        {
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));

            /*
                        //Hard coding i < 3
                        for( int i = 0; i < 3; i++)
                        {
                            Console.Write("{0}", reader.ReadInt32());
                        }
            */
            bool goOn = true;

            while (goOn)
            {
                try
                {
                    Console.Write("{0} ", reader.ReadInt32()); //System.IO.EndOfStreamException
                }
                //catch(EndOfStreamException) // 예외 오브젝트 사용하지 않음
                catch (EndOfStreamException e)
                {
                    goOn = false;
                }
                catch (ObjectDisposedException e)
                {
                    goOn = false;
                }
                catch (IOException e)
                {
                    goOn = false;
                }
            }

            reader.Close();

            Console.WriteLine();
        }

        public void StreamRead(string paht)
        {
            StreamReader reader = new StreamReader(File.Open(paht, FileMode.Open));
            Console.WriteLine(reader.ReadLine());

            reader.Close();
        }

        public void BinaryWrite(string path, int[] content)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));

            for (int i = 0; i < content.Length; i++)
            {
                writer.Write(content[i]);
                //Console.Write(content[i]);
            }

            writer.Close();
        }
        static void Main(string[] args)
        {
            Program test = new Program();
            string path = @"C:\CSH-Lehrgang\VS-Projekte\CSH03\Musterdatei.bin";

            int[] pos = { 1400, 3250, 280 };

            test.BinaryWrite(path, pos);
            //test.StreamRead(path);
            test.BinaryRead(path);
        }
    }
}
