using System;

namespace Lektion1
{
    class Luftfahrzeug
    {
        protected string kennung;
/*
        public virtual string ToString()
        {
            return kennung.string();
        }
*/
        public Luftfahrzeug(string kennung)
        {
            this.kennung = kennung;
        }

        public override string ToString()
        {
            //return base.ToString();
            //return kennung;
            return "Luftfahrzeug mit der Kennung" + kennung;
        }

        public virtual int GetHaschCode()
        {
            return kennung.GetHashCode();
        }
    }

    class Uebungen
    {
        public void Konsolenausgabe(string ort, int jahr, double ausgabe, string waehrung )
        {
/*
            string ort = "Darmstadt";
            int jahr = 2012;
            double ausgabe = 223;
            string waehrung = "Euro";
*/
            Console.WriteLine("Die Einwohner von {0} haben {1} {2} Mio. {3} für Weihnachtsgeschenke ausgegeben", ort, jahr, ausgabe, waehrung);
        }
        public void Objectmethoden()
        {
            Luftfahrzeug flieger1 = new Luftfahrzeug("LH 3000");
            Luftfahrzeug flieger2 = new Luftfahrzeug("LH 4000");
            Luftfahrzeug flieger3 = flieger1;

            Console.WriteLine(flieger1);
            Console.WriteLine(flieger2);
            Console.WriteLine(flieger3);
            Console.WriteLine("-------------------------------");

            Console.WriteLine("flieger1 gleich flieger2 ? {0}",flieger1.Equals(flieger2));
            Console.WriteLine("flieger1 gleich flieger3 ? {0}", flieger1.Equals(flieger3));
            Console.WriteLine("-------------------------------");

            Console.WriteLine(" flieger1 - Hashcode: {0} ", flieger1.GetHaschCode());
            Console.WriteLine(" flieger2 - Hashcode: {0} ", flieger2.GetHaschCode());
            Console.WriteLine(" flieger3 - Hashcode: {0} ", flieger3.GetHaschCode());
            Console.WriteLine("-------------------------------");

            Console.WriteLine("flieger1.ToString: {0}", flieger1.ToString());
            Console.WriteLine("flieger2.ToString: {0}", flieger2.ToString());
            Console.WriteLine("flieger3.ToString: {0}", flieger3.ToString());
            Console.WriteLine("-------------------------------");

            flieger3 = null;
            //Console.WriteLine("flieger3 nach null-Zuweisung: {0}", flieger3);
            Console.WriteLine("flieger3 nach null-Zuweisung: {0}", flieger3.ToString());

            Console.WriteLine("-------------------------------");
        }

        public void ObjectZuweisungen()
        {
            object obj0 = new Object();
            object obj1 = new Luftfahrzeug("LH 200");

            object obj2 = 12;
            object obj3 = "Eine Zeichenkette";
            
            //Object obj4 = new object();// Problem Object
            object obj4 = new object();
           
            //Object obj5 = new object();// Problem Object
            object obj5 = new object();

            Console.WriteLine("obj0 = {0}", obj0.GetType());
            
            Console.WriteLine("obj1 = {0}", obj1.GetType());

            Console.WriteLine("obj2 = {0}", obj2.GetType());
            Console.WriteLine("obj2 = {0}", (int)obj2);

            int zahl = (int)obj2;
            Console.WriteLine("obj2 = {0}", zahl);

            Console.WriteLine("obj3 = {0}", obj3.GetType());
            
            Console.WriteLine("obj4 = {0}", obj4.GetType());
            Console.WriteLine("obj5 = {0}", obj5.GetType());


        }

        class Program
        {
            static void Main(string[] args)
            {
                Uebungen ue = new Uebungen();

                ue.Objectmethoden();
                ue.Konsolenausgabe("Darmstadt", 2012, 223, "Euro");
                ue.Konsolenausgabe("Kleinostheim", 1981, 0.03, "DM");

                ue.ObjectZuweisungen();  
            }
        }
    }
}
