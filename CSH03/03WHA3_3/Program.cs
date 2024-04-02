using System;
using static System.Math;
using System.Threading;

//#error version
namespace _03WHA3_3
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
    }

    class Flugzeug : Luftfahrzeug
    {
        protected Position zielPos;
        protected int streckeProTakt;//Geschwindigkeit

        protected int flughöhe;

        protected int steighöheProTakt;
        protected int sinkhöheProTakt;

        protected bool steigt = false;
        protected bool sinkt = false;


        //initialisiert Ziel und Geschwindigkeit.
        public void Starte(Position zielPos, int streckeProTakt, int flughöhe, int steighöheProTakt, int sinkhöheProTakt)
        {
            this.zielPos = zielPos;
            this.streckeProTakt = streckeProTakt;

            this.flughöhe = flughöhe;
            this.steighöheProTakt = steighöheProTakt;
            this.sinkhöheProTakt = sinkhöheProTakt;
            this.steigt = true;
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

        private bool SinkenEinleiten()
        {
            double strecke = Math.Sqrt(Math.Pow(streckeProTakt, 2) - Math.Pow(sinkhöheProTakt, 2));

            int sinkstrecke = (int)strecke * (pos.h - zielPos.h) / sinkhöheProTakt;

            int zieldistanz = Zieldistanz();

            if (sinkstrecke >= zieldistanz)
            {
                // optionale Konsolenausgabe zur Kontrolle
                Console.WriteLine("{0} Sinkstrecke {1} >= Zieldistanz {2}", kennung, sinkstrecke, zieldistanz);
                return true;
            }
            else
                return false;
        }

        // modifizierte Übernahme der bisherigen Berechnung aus "Steuern":
        // Beim Sinkflug ist ein negativer Wert für den zweiten Parameter anzugeben
        private void PositionBerechnen(double strecke, int steighöheProTakt)
        {
            a = zielPos.x - pos.x;
            b = zielPos.y - pos.y;

            alpha = Math.Atan2(b, a);

            a1 = Math.Cos(alpha) * strecke;
            b1 = Math.Sin(alpha) * strecke;

            //startPos.PositionÄndern((int)a1, (int)b1, steighöheProTakt);
            pos.PositionÄndern((int)a1, (int)b1, steighöheProTakt);
        }

        private int Zieldistanz()
        {
            return (int)Math.Sqrt(Math.Pow(zielPos.x - pos.x, 2) + Math.Pow(zielPos.y - pos.y, 2));
        }


        public Starrflügelflugzeug(string kennung, Position pos) : base(kennung, pos)
        {
            //Transpond 메서드를 TransponderDel 델리게이트에 등록합니다.
            //이렇게 함으로써 해당 비행기가 위치를 전송할 때마다 TransponderDel 델리게이트를 통해 메시지를 보낼 수 있습니다
            Program.transponder += new TransponderDel(Transpond);
        }

        public void Transpond(string kennung, Position pos)
        {
            double abstand = Math.Sqrt(Math.Pow(this.pos.x - pos.x, 2) + Math.Pow(this.pos.y - pos.y, 2));

            if (kennung.Equals(this.kennung))
            {
                DateTime timestamp = DateTime.Now;
                Console.Write("{0}:{1}", timestamp.Minute, timestamp.Second);
                //Console.WriteLine("{0} an Position x = {1}, y = {2}, h = {3}", kennung, pos.x, pos.y, pos.h);
                Console.Write("\t {0}-Position: {1}-{2}-{3} ", this.kennung, pos.x, pos.y, pos.h);
                Console.Write("Zieldistanz: {0} m \n", Zieldistanz());
            }
            else
            {
                Console.Write("\t {0} ist {1} m von {2} entfernt.\n", this.kennung, (int)abstand, kennung);

                if (Math.Abs(this.pos.h) < 100 && abstand < 500)
                {
                    Console.WriteLine("\t WARNUNG: {0} hat nur {1} m Höhenabstand!", kennung, Math.Abs(this.pos.h - pos.h));
                }
            }
        }

        public void Steuern()
        {
            if (steigt)
            {
                if (this.SinkenEinleiten())
                {
                    steigt = false;
                    sinkt = true;
                }
                else if (pos.h > flughöhe)
                {
                    steigt = false;
                }
            }
            else if (sinkt)
            {
                if (pos.h <= zielPos.h + sinkhöheProTakt)
                {
                    gelandet = true;
                }
            }
            else
            {
                if (this.SinkenEinleiten())// Horizontalflug
                {
                    sinkt = true;
                }
            }


            if (!gelandet)
            {
                // Zunächst die aktuelle Position ausgeben:
                Program.transponder(kennung, pos);

                // "strecke" (am Boden) berechnen:
                if (steigt)
                {
                    double strecke = Math.Sqrt(Math.Pow(streckeProTakt, 2) - Math.Pow(steighöheProTakt, 2));
                    this.PositionBerechnen(strecke, steighöheProTakt);
                }
                else if (sinkt)
                {
                    double strecke = Math.Sqrt(Math.Pow(streckeProTakt, 2) - Math.Pow(sinkhöheProTakt, 2));
                    this.PositionBerechnen(strecke, -sinkhöheProTakt);
                }
                else
                {
                    // im Horizontalflug ist "strecke" gleich "streckeProTakt"
                    this.PositionBerechnen(streckeProTakt, 0);
                }
            }
            else
            {
                // Flieger deregistrieren, Transponder abschalten, Abschlussmeldung
                Program.fliegerRegister -= this.Steuern;
                Program.transponder -= this.Transpond;

                Console.WriteLine("\n{0} gelandet ( Zieldistanz={1}, Höhendistanz ={2} )", kennung, Zieldistanz(), pos.h - zielPos.h);
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
            public void ProgrammTakten()
            {
                Starrflügelflugzeug flieger1 = new Starrflügelflugzeug("LH  500", new Position(3500, 1500, 180));
                Program.fliegerRegister += flieger1.Steuern;
                flieger1.Starte(new Position(1000, 500, 200), 200, 300, 20, 10);

                Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 3000", new Position(3000, 2000, 100));
                Program.fliegerRegister += flieger2.Steuern;
                flieger2.Starte(new Position(1000, 500, 200), 260, 350, 25, 15);


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
                Console.ReadLine();
            }
        }
    }
}
