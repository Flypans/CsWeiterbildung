using System;
using static System.Math;
using System.Text;//MG
using System.Threading;
using System.IO;

//#error version
namespace CSH03_Lektion5
{
    public delegate void TransponderDel(string kennung, Position pos); //Delegate TransponderDel 2 Parameter
    public delegate void FliegerRegisterDel();//Delegate no Parameter

    interface ITransponder
    {
        void Transpond(string kennung, Position pos);
    }

    //enum Airbus { A300 = 280, A310 = 240, A318 = 260, A319 = 250, A320 = 290, A321 = 320, A330 = 350, A340 = 310, A350 = 253, A380 = 550 };
    enum Airbus { A300, A310, A318, A319, A320, A321, A330, A340, A350, A380 };

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
            //Console.WriteLine($"~~~ deltaX: {deltaX}, deltaY: {deltaY}, deltaH: {deltaH}, x: {x}, y: {y}, h: {h}");
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
        //public void Starte(Position zielPos, int streckeProTakt, int flughöhe, int steighöheProTakt, int sinkhöheProTakt)
        public bool Starte(Position zielPos, int streckeProTakt, int flughöhe, int steighöheProTakt, int sinkhöheProTakt)
        {
            this.zielPos = zielPos;
            this.streckeProTakt = streckeProTakt;
            this.flughöhe = flughöhe;
            this.steighöheProTakt = steighöheProTakt;
            this.sinkhöheProTakt = sinkhöheProTakt;
            this.steigt = true;

            string pfad = ".\\" + kennung + ".init";

            //StreamReader reader = new StreamReader(File.Open(pfad, FileMode.Open));
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(File.Open(pfad, FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine("Fehler beim Zugriff auf die Datei \"{0}\"", pfad);
                return false;
            }

            int[] data = new int[9];

            for (int i = 0; i < 9; i++)
            {
                string str = reader.ReadLine();
                //str = str.Substring(str.IndexOf('='));
                str = str.Substring(str.IndexOf('=') + 1);
                Console.WriteLine(str);
                data[i] = Int32.Parse(str);
                //Console.WriteLine(reader.ReadLine());
            }
            //Console.WriteLine();
            reader.Close();
            this.zielPos.x = data[0];
            this.zielPos.y = data[1];
            this.zielPos.h = data[2];
            streckeProTakt = data[3];
            flughöhe = data[4];
            steighöheProTakt = data[5];
            sinkhöheProTakt = data[6];
            // TODO : "Typ" aus data[7];
            //initialisieren sitzplätze = data[8];
            //sitzplätze = data[8];

            steigt = true;
            return true;

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
            if (kennung.Equals(this.kennung))
            {
                //Console.WriteLine(this.kennung + " erkennt Eingang eigenes Signal.");
                Console.WriteLine("{0} an Position x = {1}, y = {2}, h = {3}", kennung, pos.x, pos.y, pos.h);
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
            //private int sitzplätze;
            protected int sitzplätze;

            //initialisiert Ziel und Geschwindigkeit.
            public bool Starte(Position zielPos, int streckeProTakt, int flughöhe, int steighöheProTakt, int sinkhöheProTakt)
            {
                this.zielPos = zielPos;
                this.streckeProTakt = streckeProTakt;
                this.flughöhe = flughöhe;
                this.steighöheProTakt = steighöheProTakt;
                this.sinkhöheProTakt = sinkhöheProTakt;
                this.steigt = true;

                string pfad = ".\\" + kennung + ".init";
                //StreamReader reader = new StreamReader(File.Open(pfad, FileMode.Open));

                StreamReader reader = null;

                try
                {
                    reader = new StreamReader(File.Open(pfad, FileMode.Open));
                }
                catch (IOException e)
                {
                    Console.WriteLine("Fehler beim Zugriff auf die Datei \"{0}\"", pfad);
                    return false;
                }

                int[] data = new int[9];

                for (int i = 0; i < 9; i++)
                {
                    string str = reader.ReadLine();
                    str = str.Substring(str.IndexOf('='));
                    //str = str.Substring(str.IndexOf('=') + 1);
                    Console.WriteLine(str);
                    data[i] = Int32.Parse(str);
                    //Console.WriteLine(reader.ReadLine());
                }
                //Console.WriteLine();
                reader.Close();
                this.zielPos.x = data[0];
                this.zielPos.y = data[1];
                this.zielPos.h = data[2];
                streckeProTakt = data[3];
                flughöhe = data[4];
                steighöheProTakt = data[5];
                sinkhöheProTakt = data[6];
                // TODO : "Typ" aus data[7];
                //initialisieren sitzplätze = data[8];
                Array typen = Enum.GetValues(typeof(Airbus));
                this.typ = (Airbus)typen.GetValue(data[7]);
                sitzplätze = data[8];
                Console.WriteLine("Flug {0} vom Typ {1} mit {2} Plaetzen initialisiert.", kennung, typ, sitzplätze);
                steigt = true;
                return true;

            }

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
            /*
                        public Düsenflugzeug(string kennung, Position pos, Airbus typ) : base(kennung, pos)
                        {
                            this.typ = typ;
                            // typ 열거형 값에 따라 sitzplätze를 초기화합니다
                            //this.sitzplätze = sitzplätze;
                            this.sitzplätze = (int)typ;

                            Console.WriteLine("Der Flieger vom Typ{00} hat {1} Plätze", this.GetType(), sitzplätze);
                        }
            */
            public Düsenflugzeug(string kennung, Position pos) : base(kennung, pos)
            {
                /*
                                bool initialized = this.Starte();

                                if (initialized)
                                {
                                    Program.transponder += this.Transpond;
                                    Program.fliegerRegister += this.Steuern;
                                }
                */
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
                Starrflügelflugzeug flieger1 = new Starrflügelflugzeug("LH 500", new Position(3500, 1500, 180));
                Program.fliegerRegister += flieger1.Steuern;
                flieger1.Starte(new Position(1000, 500, 200), 200, 300, 20, 10);

                Starrflügelflugzeug flieger2 = new Starrflügelflugzeug("LH 3000", new Position(3000, 2000, 100));
                Program.fliegerRegister += flieger2.Steuern;
                flieger2.Starte(new Position(1000, 500, 200), 260, 350, 25, 15);
                /*
                                Düsenflugzeug flieger3 = new Düsenflugzeug("LH 500", new Position(3500, 1500, 180), Airbus.A300);
                                Düsenflugzeug flieger4 = new Düsenflugzeug("LH 3000", new Position(3000, 2000, 100), Airbus.A310);
                */

                Düsenflugzeug flieger3 = new Düsenflugzeug("LH 500", new Position(3500, 1500, 180));
                Düsenflugzeug flieger4 = new Düsenflugzeug("LH 3000", new Position(3000, 2000, 100));

                /*
                                Düsenflugzeug flieger3 = new Düsenflugzeug("LH 500", new Position(3500, 1500, 180));
                                flieger3.Starte(new Position(1000, 500, 200), 200, 300, 20, 10);

                                Düsenflugzeug flieger4 = new Düsenflugzeug("LH 3000", new Position(3000, 2000, 100));
                                flieger4.Starte(new Position(1000, 500, 200), 260, 350, 25, 15);
                */
                //System.NullReferenceException: in der while-Schleife der Program-Methode
                //ProgrammTakten beim Aufruf des Delegates fliegerRegister
                //while (true)z
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


