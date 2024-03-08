using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion4Enum
{

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
        public  void Steigen()
        {
            int standard = 100;
            pos.Positionändern(0, 0, standard);
            Console.WriteLine(kennung + " steigt " + standard + " Meter, neue Höhe = " + pos.h);
        }
        public override  void Steigen(int meter) //Overloading
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
            //this.Transpond(kennung, pos);//Process is terminated due to StackOverflowException.
            Console.WriteLine("Flieger funkt Kennung \"" + kennung + "\" und Position " + pos.x + "/" + pos.y + "/" + pos.h);
        }
        public override void Transpond(Position pos, string kennung)
        {
            //Console.WriteLine("Flieger funkt Kennung \"" + kennung + "\" und Position " + pos.x + "/" + pos.y + "/" + pos.h);
       
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
            //this.typ = typ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
/*
            Position pos1 = new Position(105020, 30800, 110);
            Luftfahrzeug flieger1 = new Flugzeug("LH 4080", pos1);
            flieger1.Steigen(300);
            flieger1.Sinken(100);
            Console.WriteLine(" Position x = " + pos1.x + ", y = " + pos1.y + ", h = " + pos1.h);

            Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("BA 1892", new Position(100, 300, 600));
            flieger2.Steigen(900);
            flieger2.Sinken(200);

            Luftfahrzeug flieger3 = new Flugzeug("LH 4080", new Position(105020, 30800, 110));
            flieger3.Steigen(100);
            flieger3.Sinken(50);

            Düsenflugzeug flieger4 = new Düsenflugzeug("LH 3000", new Position(1000, 2000, 150));
            flieger4.Steigen(500);
            flieger4.Sinken(100);

            flieger4.typ = Düsenflugzeugtyp.Boeing_747;
            Console.WriteLine(flieger4.typ);
*/
            Starrflügelflugzeug flieger = new Starrflügelflugzeug("LH 3000", new Position(100, 500, 20));
            //flieger.Transpond("LH 3000", new Position(100, 500, 20));//메서드를 호출할 때 인자의 순서를 바꾸어 무한 재귀 호출
            flieger.Transpond("LH 3000", new Position(100, 500, 20));

            flieger.Steigen(500);
            flieger.Sinken(100);

        }
    }
}
