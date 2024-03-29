using System;
using static System.Math;
using System.Threading;



//#error version
namespace CSH03_Lektion3
{
    public delegate void TransponderDel(string kennung, Position pos); //Delegate TransponderDel 2 Parameter
    public delegate void FliegerRegisterDel();//Delegate no Parameter

    interface ITransponder
    {
        void Transpond(string kennung, Position pos);
    }

    enum Airbus { A300 = 280, A310 = 240, A318 = 260, A319 = 250, A320 = 290, A321 = 320, A330 = 350, A340 = 310, A350 = 253, A380 = 550 };

    public struct Position
    {
        public int x, y, h;

        public Position(int x, int y, int h)
        {
            this.x = x;
            this.y = y;
            this.h = h;
        }

        public void PositionÄndern(int deltaX, int deltaY, int deltaH)
        {
            x = x + deltaX;
            y = y + deltaY;
            h = h + deltaH;
            Console.WriteLine($"~~~ deltaX: {deltaX}, deltaY: {deltaY}, deltaH: {deltaH}, x: {x}, y: {y}, h: {h}");
        }
    }

    abstract class Luftfahrzeug
    {
        protected string kennung;
        public string Kennung
        {
            set { kennung = value; }
            get { return kennung; }
        }
    }

    class Flugzeug : Luftfahrzeug
    {
        protected Position zielPos;
        protected int streckeProTakt;//Geschwindigkeit
        protected Position pos;

        //initialisiert Ziel und Geschwindigkeit.
        public void Starte(Position zielPos, int streckeProTakt, int flughöhe, int steighöheProTakt, int sinkhöheProTakt)
        {
            this.zielPos = zielPos;
            this.streckeProTakt = streckeProTakt;
        }

        public Flugzeug(string kennung, Position pos)
        {
            this.kennung = kennung;
            this.pos = pos;
        }
    }

    class Starrflügelflugzeug : Flugzeug, ITransponder
    {
        double a, b, alpha, a1, b1;
        bool gelandet = false;

        public Starrflügelflugzeug(string kennung, Position pos) : base(kennung, pos)
        {
            //Transpond 메서드를 TransponderDel 델리게이트에 등록합니다.
            //이렇게 함으로써 해당 비행기가 위치를 전송할 때마다 TransponderDel 델리게이트를 통해 메시지를 보낼 수 있습니다
            Program.transponder += new TransponderDel(Transpond);
        }

        public void Transpond(string kennung, Position pos)
        {
            if (kennung.Equals(this.kennung))
            {
                Console.WriteLine("{0} an Position x = {1}, y = {2}", kennung, pos.x, pos.y);
            }
        }

        public void Steuern()
        {
            if (!gelandet)
            {
                Program.transponder(kennung, pos);

                Console.WriteLine($"~~~ a({a}) = zielPos.x ({zielPos.x}) - pos.x ({pos.x})");
                Console.WriteLine($"~~~ b({b}) = zielPos.y ({zielPos.y}) - pos.y ({pos.y})");

                a = zielPos.x - pos.x;
                b = zielPos.y - pos.y;
                alpha = Math.Atan2(b, a);
                //alpha = Math.Atan(b / a); // Division by Zero

                a1 = Math.Cos(alpha) * streckeProTakt;
                b1 = Math.Sin(alpha) * streckeProTakt;
                pos.PositionÄndern((int)a1, (int)b1, 0);

                //Console.WriteLine($"~~~ a: {a}, b: {b}, alpha: {alpha}, a1: {a1}, b1: {b1}");

                if (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) < streckeProTakt)
                {
                    gelandet = true;
                    Console.WriteLine("\n{0} an Position " + "x = {1}, y = {2} gelandet", kennung, pos.x, pos.y);

                    //Removing the method from the fliegerRegister event 
                    //fliegerRegister EVENT에서 Method를 제거하면 EVENT가 발생할 때 Method가 더 이상 호출되지 않습니다.
                    //fliegerRegister EVENT handler list 에서 Steuern() Method를 제거하여
                    //비행기가 착륙한 후 다시 call 되는 것을 효과적으로 방지합니다.
                    //이렇게 하면 비행기가 목적지에 도달한 후에 메서드가 반복적으로 실행되지 않습니다.
                    Program.fliegerRegister -= this.Steuern;
                }
            }
        }
        class Program
        {
            //transponder 정적 델리게이트를 정의
            public static TransponderDel transponder;

            //FliegerRegisterDel 정적 델리게이트를 정의
            public static FliegerRegisterDel fliegerRegister;
            public void ProgrammTakten()
            {
                Starrflügelflugzeug flieger1 = new Starrflügelflugzeug("LH  500", new Position(3500, 1500, 180));
                Program.fliegerRegister += flieger1.Steuern;
                flieger1.Starte(new Position(1000, 500, 200), 200, 300, 20, 10);

                Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 3000", new Position(3000, 2000, 100));
                Program.fliegerRegister += flieger2.Steuern;
                flieger2.Starte(new Position(1000, 500, 200), 260, 350, 25, 15);

                //while (true)
                while (fliegerRegister != null)
                {
                    fliegerRegister();
                    Console.WriteLine();
                    Thread.Sleep(1000);// 1 Sekunde
                }
            }

            static void Main(string[] args)
            {
                Program test = new Program();
                test.ProgrammTakten();
            }
        }
    }
}

