using System;
using System.Threading;

//#error version
namespace _03WHA2_3
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
        }

        public void HöheÄndern(int deltaH)//Aufruf in Sinken/Steigen
        {
            h = h + deltaH;
        }
    }

    abstract class Luftfahrzeug
    {
        protected string kennung;
        protected Position pos;

        public string Kennung
        {
            set { kennung = value; }
            get { return kennung; }
        }

        public abstract void Steigen(int meter);
        public abstract void Sinken(int meter);
    }

    class Flugzeug : Luftfahrzeug
    {
        public Flugzeug(string kennung, Position pos)
        {
            this.kennung = kennung;
            this.pos = pos;
        }

        public override void Steigen(int meter)
        {
            pos.HöheÄndern(meter);
            Console.WriteLine(kennung + "steigt " + meter + "Meter, Höhe =" + pos.h);
        }

        public override void Sinken(int meter)
        {
            pos.HöheÄndern(-meter);
            Console.WriteLine(kennung + "sinkt " + meter + "Meter, Höhe =" + pos.h);
        }
    }

    class Starrflügelflugzeug : Flugzeug, ITransponder
    {

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
                Console.WriteLine(this.kennung + " erkennt Eingang eigenes Signal.");
            }
            // Die Höhendifferenzen, kleiner 100 && größer 0,  
            else if (this.pos.h - pos.h < 100 && this.pos.h - pos.h > 0)
            {
                Console.WriteLine(" Warnung !: {0} fliegt nur {1} Meter höher als {2}", this.kennung, this.pos.h - pos.h, kennung);
            }
            else if (pos.h - this.pos.h < 100 && pos.h - this.pos.h > 0)
            {
                Console.WriteLine(" Warnung !: {0} fliegt nur {1} Meter tiefer als {2}", this.kennung, pos.h - this.pos.h, kennung);
            }
            else
            {
                Console.WriteLine(this.kennung + " empfängt Position von {0}: x = {1}, y = {2}, Höhe = {3}", this.kennung, pos.x, pos.y, pos.h);
            }
        }

        public void Steuern()
        {
            Program.transponder(kennung, pos);
        }
    }

    class Düsenflugzeug : Starrflügelflugzeug
    {
        public Airbus typ;
        private int sitzplätze;
        private int fluggäste;

        public int Fluggäste
        {
            set
            {
                if (sitzplätze < (fluggäste + value))
                {
                    Console.WriteLine("Keine Buchung: Die " + "Fluggastzahl würde mit der Zubuchung " +
                        "von {0} Plätzen die verfügbaren Plätze " + "von {1} um {2} übersteigen!",
                        value, sitzplätze, value + fluggäste - sitzplätze);
                }
                else
                {
                    fluggäste += value;
                }
            }
            get { return fluggäste; }
        }

        public Düsenflugzeug(string kennung, Position pos, Airbus typ) : base(kennung, pos)
        {
            this.typ = typ;
            sitzplätze = (int)typ;

            Console.WriteLine("Der Flieger vom Typ{00} hat {1} Plätze", this.GetType(), sitzplätze);
        }

        public void Buchen(int plätze)
        {
            Fluggäste = plätze;//Property
        }
    }

    class Program
    {
        //transponder 정적 델리게이트를 정의
        public static TransponderDel transponder;

        //FliegerRegisterDel 정적 델리게이트를 정의
        public static FliegerRegisterDel fliegerRegister;

        public void TransponderTest() // Code 1.6
        {
            Starrflügelflugzeug flieger1 = new Starrflügelflugzeug("LH 3000", new Position(3000, 2000, 100));
            flieger1.Steuern();
            Console.WriteLine();

            Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 500", new Position(3500, 1500, 180));
            flieger1.Steuern();
            flieger2.Steuern();
            Console.WriteLine();


            Starrflügelflugzeug flieger3 = new Starrflügelflugzeug("LH444", new Position(17300, 23400, 780));
            flieger1.Steuern();
            flieger2.Steuern();
            flieger3.Steuern();
            Console.WriteLine();
            transponder -= flieger2.Transpond; // aus Delegate entfernen

            flieger1.Steuern();
            flieger3.Steuern();
            Console.WriteLine();
        }

        public void ProgrammTakten()
        {
            Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 500", new Position(3500, 1500, 180));
            Program.fliegerRegister = Program.fliegerRegister + flieger2.Steuern;

            Starrflügelflugzeug flieger1 = new Starrflügelflugzeug("LH 3000", new Position(3000, 2000, 100));
            Program.fliegerRegister = Program.fliegerRegister + flieger1.Steuern;

            while (true)
            {
                Console.WriteLine();
                Thread.Sleep(1000);// 1 Sekunde
            }
        }

        static void Main(string[] args)
        {
            Program test = new Program();
            test.TransponderTest();
            test.ProgrammTakten();
            Console.ReadLine();
        }
    }
}
