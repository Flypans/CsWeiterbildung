using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion4Enum
{
    //enum Airbus : short { A300, A310, A318, A319, A320, A321, A330, A340, A350, A380 }
    public enum Düsenflugzeugtyp : short {A300, A310, A318, A319, A320, A321, A330, A340, A350, A380, Boeing_717, Boeing_737, Boeing_747, Boeing_767, Boeing_777, Boeing_BBJ }
    //class Position
    struct Position
    {
        public int x, y, h;

        //public Position(int x, int y, int h)
        //{
        // 구조체는 초기화 필요. 
        //}
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

    class Luftfahrzeug
    {
        protected string kennung;
        protected Position pos;

        public Luftfahrzeug()
        {

        }

        public Luftfahrzeug(string kennung, Position pos)
        {
            this.kennung = kennung;
            this.pos = pos;
        }

        public void Steigen(int meter)
        {
            pos.Positionändern(0, 0, meter);//초기화
            Console.WriteLine(kennung + " steigt " + meter + " Meter, neue Höhe = " + pos.h);


        }

        public void Sinken(int meter)
        {
            pos.Positionändern(0, 0, -meter);//초기화
            Console.WriteLine(kennung + " sinkt " + meter + " Meter, neue Höhe = " + pos.h);
        }
    }

    class Flugzeug : Luftfahrzeug
    {
        public Flugzeug(string kennung, Position pos) : base(kennung, pos)
        {
            this.kennung = kennung;
        }

    }

    class Starrflügelflugzeug : Flugzeug
    {
        public Starrflügelflugzeug(string kennung, Position pos) : base(kennung, pos)
        {

        }
    }

    class Düsenflugzeug : Starrflügelflugzeug
    {
        public Düsenflugzeugtyp typ;
        public Düsenflugzeug(string kennung, Position pos) : base(kennung, pos)
        {
            //this.typ = typ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1M
            Position pos1;
            pos1.x = 105020;
            pos1.y = 30800;
            pos1.h = 110;

            Luftfahrzeug flieger1 = new Luftfahrzeug("LH 4080", pos1);//Constructor method  생성자 메소드 

            flieger1.Steigen(300);
            flieger1.Sinken(100);

            Console.WriteLine(" Position x = " + pos1.x + ", y = " + pos1.y + ", h = " + pos1.h);

            //2M
/*
            Position pos2 = new Position(5020, 800, 500);
            Düsenflugzeug flieger2 = new Düsenflugzeug("NA 334", pos2);

            flieger2.Steigen(600);
            flieger2.Sinken(300);

            Console.WriteLine(" Position x =  " + pos2.x + ", y = " + pos2.y + ", h = " + pos2.h);
*/
            //3M
            Starrflügelflugzeug flieger3 = new Starrflügelflugzeug("BA 1892", new Position(100, 300, 600));

            flieger3.Steigen(900);
            flieger3.Sinken(200);

            //4M
            Luftfahrzeug flieger4 = new Luftfahrzeug("LH 4080", new Position(105020, 30800, 110));

            flieger4.Steigen(100);
            flieger4.Sinken(50);

            // Enum for Airbus
 /*      
                        Düsenflugzeug flieger = new Düsenflugzeug("LH 4080", new Position(1000, 2000, 150));
                        flieger.typ = Airbus.A320;
                        Console.WriteLine(flieger.typ);
                        flieger.Steigen(100);
                        flieger.Sinken(50);

                        Console.WriteLine("Typ eines enum-Elements: " + Airbus.A320.GetType());
                        Console.WriteLine("Wer eines enum-Elements: " + Airbus.A380);
                        Console.WriteLine("index eines enum-Elements: " + (int)Airbus.A320);

                        flieger.typ = (Airbus)8;
                        Console.WriteLine("(Airbus)8 = " + flieger.typ);
 */
            Düsenflugzeug fliger = new Düsenflugzeug("LH 3000", new Position(1000, 2000, 150));
            fliger.typ = Düsenflugzeugtyp.Boeing_747;

            //Düsenflugzeug fliger = new Düsenflugzeug("LH 3000", new Position(1000, 2000, 150),Airbus.A320);
            Console.WriteLine(fliger.typ);
        }
    }
}
