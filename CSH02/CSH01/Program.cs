using System;

namespace CSH01
{
    enum Airbus : short { A300, A310, A318, A319, A320, A321, A330, A340, A350, A380 }
    //public enum Düsenflugzeugtyp : short { A300, A310, A318, A319, A320, A321, A330, A340, A350, A380, Boeing_717, Boeing_737, Boeing_747, Boeing_767, Boeing_777, Boeing_BBJ }
    public struct Position
    {
        public int x, y, h;
        public Position(int x, int y, int h)
        {
            this.x = x;
            this.y = y;
            this.h = h;
        }
        public void Positionändern(int deltaX, int deltaY, int deltaH)
        {
            x = x + deltaX;
            y = y + deltaY;
            h = h + deltaH;
        }
    }

    public abstract class Luftfahrzeug
    {
        protected string kennung;
        protected Position pos;

        //Konstruktormethoden Overloading
        public Luftfahrzeug()
        {
        }

        //Konstruktormethoden Overloading
        public Luftfahrzeug(string kennung, Position pos)
        {
            this.kennung = kennung;
            this.pos = pos;
        }

        //overriding
        public abstract void Steigen(int meter);
        public abstract void Sinken(int meter);

        //Interface
        public abstract void Transpond(Position pos, string kennung);
    }

    public interface ITransponder
    {
        void Transpond(string kennung, Position pos);
    }

    public class Flugzeug : Luftfahrzeug
    {
        public Flugzeug(string kennung, Position pos) : base(kennung, pos)
        {
            this.kennung = kennung;
        }
        public void Steigen()
        {
            int standard = 100;
            pos.Positionändern(0, 0, standard);
            Console.WriteLine(kennung + " steigt " + standard + " Meter, neue Höhe = " + pos.h);
        }
        public override void Steigen(int meter) //Overloading
        {
            pos.Positionändern(0, 0, meter);//초기화
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Höhe = " + pos.h);
        }
        public override void Sinken(int meter)
        {
            pos.Positionändern(0, 0, -meter);//초기화
            Console.WriteLine(kennung + " sinkt " + meter + " Meter, neue Höhe = " + pos.h);
        }
        public void Transpond(string kennung, Position pos)
        {
            Console.WriteLine("Flieger funkt Kennung \"" + kennung + "\" und Position " + pos.x + "/" + pos.y + "/" + pos.h);
        }
        public override void Transpond(Position pos, string kennung)
        {
        }

    }
    public class Starrflügelflugzeug : Flugzeug, ITransponder
    {
        public Starrflügelflugzeug(string kennung, Position pos) : base(kennung, pos)
        {
        }
    }

    class Düsenflugzeug : Starrflügelflugzeug
    {
        //public Düsenflugzeugtyp typ;

        public Düsenflugzeug(string kennung, Position pos) : base(kennung, pos)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Flugzeug flieger1 = new Flugzeug("LH 4080", new Position(1000, 2000, 150));

            flieger1.Steigen(100);
            flieger1.Sinken(50);

            Console.WriteLine("Typ eines enum-Elements: " + Airbus.A320.GetType());
            Console.WriteLine("Wer eines enum-Elements: " + Airbus.A380);
            Console.WriteLine("index eines enum-Elements: " + (int)Airbus.A320);
            Console.WriteLine(flieger1.GetType().ToString());
            Console.WriteLine("////////////////////////////////////////////////////////");

            Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 3000", new Position(100, 500, 20));

            flieger2.Transpond("LH 3000", new Position(100, 500, 20));

            flieger2.Steigen(500);
            flieger2.Sinken(100);
            Console.WriteLine(flieger2.GetType().ToString());
            Console.WriteLine("////////////////////////////////////////////////////////");
            //public virtual bool Equals(Object flieger2);
            Object a = new Object();
            Object b = new object();
            bool ergebnis = a.Equals(b);
            Console.WriteLine(ergebnis);
        }
    }
}
