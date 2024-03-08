using System;

namespace _01Aufgabe4
{
    interface IterFace
    {
        void TuNochWas();
    }

    abstract class A
    {
        public abstract void tuWas();
    }

    class B : A, IterFace
    {
        public override void tuWas()
        {
            Console.WriteLine("tuWas");
        }

        public void TuNochWas()
        {
            Console.WriteLine("tuNochWas");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B bObjekt = new B();
            bObjekt.tuWas();
            bObjekt.TuNochWas();
        }
    }
}
