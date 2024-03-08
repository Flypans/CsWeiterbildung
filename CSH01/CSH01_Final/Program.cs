using System;

namespace CSH01_Final
{
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
            Starrflügelflugzeug flieger = new Starrflügelflugzeug("LH 3000", new Position(100, 500, 20));

            flieger.Transpond("LH 3000", new Position(100, 500, 20));

            flieger.Steigen(500);
            flieger.Sinken(100);

        }
    }
}
