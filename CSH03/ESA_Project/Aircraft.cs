using System;
using static System.Math;
using System.Threading;
using System.IO;



namespace ESA_Project
{
    public delegate void TransponderDel(string kennung, Position pos); //Delegate TransponderDel 2 Parameter
    public delegate void FliegerRegisterDel();//Delegate no Parameter

    interface ITransponder
    {
        void Transpond(string kennung, Position pos);
    }
    enum Airbus : short { A300, A310, A318, A319, A320, A321, A330, A340, A380, Boeing_717, Boeing_737, Boeing_747, Boeing_777, Boeing_BBJ }

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
            Console.WriteLine($"x:{x}, y:{y}, h:{h}, deltaX:{deltaX}, deltaY:{deltaY}, deltaH:{deltaH}");
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
        protected Position pos;
        protected string kennung;

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
        protected Position zielPos;
        protected int streckeProTakt;//Geschwindigkeit
        protected int flughöhe;

        protected int steighöheProTakt;
        protected int sinkhöheProTakt;
        
        public static bool protokollieren = true;

        protected bool steigt = false;
        protected bool sinkt = false;

        public Flugzeug(string kennung, Position startPos)
        {
            this.kennung = kennung;
            this.pos = startPos;
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
        double a, b, alpha, a1, b1;
        bool gelandet = false;
        
        public Starrflügelflugzeug(string kennung, Position startPos) : base(kennung, startPos)
        {
            //Aircraft.transponder += new TransponderDel(Transpond);
            Aircraft.transponder += Transpond;//MG
        }
        public void Transpond(string kennung, Position pos)
        {
            double abstand = Math.Sqrt(Math.Pow(this.pos.x - pos.x, 2) + Math.Pow(this.pos.y - pos.y, 2));

            if (kennung.Equals(this.kennung))
            {
                Console.WriteLine("{0} an Position x = {1}, y = {2}, h = {3}", kennung, pos.x, pos.y, pos.h);
            }
            else
            {
                Console.Write("\t{0} ist {1} m von {2} entfernt.\n", this.kennung, (int)abstand, kennung);

                if (Math.Abs(this.pos.h - pos.h) < 100 && abstand < 500)
                {
                    Console.WriteLine("\tWARNUNG: {0} hat nur {1} m Höhenabstand!", kennung, Math.Abs(this.pos.h - pos.h));
                }
            }
        }

        private bool SinkenEinleiten()
        {
            double strecke = Math.Sqrt(Math.Pow(streckeProTakt, 2) - Math.Pow(sinkhöheProTakt, 2));
            int sinkstrecke = (int)(strecke * (pos.h - zielPos.h) / sinkhöheProTakt);
            int zieldistanz = Zieldistanz();

            if (sinkstrecke >= zieldistanz)
            {
                // optionale Konsolenausgabe zur Kontrolle
                //Console.WriteLine("{0} Sinkstrecke {1} >= Zieldistanz {2}", kennung, sinkstrecke, zieldistanz);
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
            pos.PositionÄndern((int)a1, (int)b1, steighöheProTakt);
        }

        private int Zieldistanz()
        {
            return (int)Math.Sqrt(Math.Pow(zielPos.x - pos.x, 2) + Math.Pow(zielPos.y - pos.y, 2));
        }
        public void Protokolldatei()
        {
            try
            {
                int day = DateTime.Now.Day;
                //int month = DateTime.Now.Month;
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;
                int second = DateTime.Now.Second;

             
                //<kennung>_<Tag>-<Stunde>-<Minute>-<Sekunde>.bin
                //string fileName = $"{kennung}_{day}_{month}_{hour}_{minute}_{second}.bin";

                //Aufgabe3.b
                //Innerhalb der Klasse Starrflugelflug wird der Dateipfad gesetzt,
                //da sie mit den Methoden des Flugzeugobjekts leicht aufgerufen werden kann.

                
                string fileName = $"{kennung}_{day}_{hour}_{minute}_{second}.bin";

                string pfad = @"C:\CSH-Lehrgang\VS-Projekte\" + fileName;

                Console.WriteLine($"filename: {fileName}, pfad: {pfad}");

                //Aufgabe3.a
                //Die entsprechende Methode entspricht der Rolle der Klasse Starrflugelflug,
                //und da sie nicht von anderen Klassen genutzt wird, ist es ratsam,
                //sich innerhalb der Klasse Starrfluegelflug zu befinden.

                //BinaryWriter writer = new BinaryWriter(File.Open(pfad, FileMode.Create));// Output error
                StreamWriter writer = new StreamWriter(File.Open(pfad, FileMode.Create));

                string header = $"Flug \"{kennung}\" (Typ \"Starrflügelflugzeug\") startet an Position \"{pos.x}-{pos.y}-{pos.h}\" mit Zielposition \"{zielPos.x}-{zielPos.y}-{zielPos.h}\".";

                writer.Write(header);
                //writer.Write(Environment.NewLine);
            
                                while (!gelandet)
                                {

                                    writer.Write(pos.x.ToString());
                                    writer.Write("-");
                                    writer.Write(pos.y.ToString());
                                    writer.Write("-");
                                    writer.Write(pos.h.ToString());
                                    writer.Write(Environment.NewLine); // 개행 문자 추가

                                    Steuern();
                                }

                //Aufgabe3.d
                //Nach der Landung endet die Schleife, in der die Aufzeichnung geschrieben wird,
                //und der Writer muss geschlossen werden, nachdem die Daten geschrieben wurden.
                
                writer.Close();

                Console.WriteLine($" Positionen des Flugzeugs {kennung} wurden protokolliert.");
            }
            catch (IOException e)
            {
                Console.WriteLine($" Protokollierung für Flugzeug {kennung} deaktiviert.");
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
                Aircraft.transponder(kennung, pos);

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
                Aircraft.fliegerRegister -= this.Steuern;
                Aircraft.transponder -= this.Transpond;

                Console.WriteLine("\n{0} gelandet ( Zieldistanz={1}, Höhendistanz ={2} )", kennung, Zieldistanz(), pos.h - zielPos.h);
            }
        }

        class Düsenflugzeug : Starrflügelflugzeug
        {
            public Airbus typ;

            private int sitzplätze;

            public Düsenflugzeug(string kennung, Position startPos) : base(kennung, startPos)
            {
                Console.WriteLine("Starte initialized.");

                bool initialized = this.Starte();

                if (initialized)
                {
                    Aircraft.transponder += this.Transpond;
                    Aircraft.fliegerRegister += this.Steuern;
                }
            }

            public void Starte(Position zielPos, int streckeProTakt, int flughöhe, int steighöheProTakt, int sinkhöheProTakt)
            {
                this.zielPos = zielPos;
                this.streckeProTakt = streckeProTakt;
                this.flughöhe = flughöhe;
                this.steighöheProTakt = steighöheProTakt;
                this.sinkhöheProTakt = sinkhöheProTakt;
                this.steigt = true;
            }

            public bool Starte()
            {
                string pfad = ".\\" + kennung + ".init";
                StreamReader reader;

                try
                {
                    reader = new StreamReader(File.Open(pfad, FileMode.Open));
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("{0} Fehler beim Mangel auf die Datei " + pfad, e.GetType().Name);
                    return false;
                }
                catch (IOException e)
                {
                    Console.WriteLine("{0} Fehler beim Zugriff auf die Datei " + pfad, e.GetType().Name);
                    return false;
                }

                int[] data = new int[9];

                for (int i = 0; i < 9; i++)
                {
                    string str = reader.ReadLine();
                    str = str.Substring(str.IndexOf('=') + 1);
                    data[i] = Int32.Parse(str);
                }
                reader.Close();

                this.zielPos.x = data[0];
                this.zielPos.y = data[1];
                this.zielPos.h = data[2];
                streckeProTakt = data[3];
                flughöhe = data[4];
                steighöheProTakt = data[5];
                sinkhöheProTakt = data[6];

                //"typ" aus data[7] initialisieren
                Array typen = Enum.GetValues(typeof(Airbus));
                this.typ = (Airbus)typen.GetValue(data[7]);
                sitzplätze = data[8];

                Console.WriteLine(" Flug {0} vom Typ {1} mit {2} Plätzen initialisiert.", kennung, typ, sitzplätze);
                steigt = true;
                try
                {
                    if (protokollieren)
                    {
                        Protokolldatei();
                    }
                }
                catch(IOException e)
                {
                    Console.WriteLine($" Fehler beim Protokollieren für Flugzeug {kennung}");
                }
                
                Console.WriteLine();
                return true;
            }
        }

        class Aircraft
        {
            public static TransponderDel transponder;
            public static FliegerRegisterDel fliegerRegister;
            public void ProgrammTakten()
            {
                Düsenflugzeug flieger1 = new Düsenflugzeug("LH 500", new Position(3500, 1500, 180));
                //Düsenflugzeug flieger2 = new Düsenflugzeug("LH 3000", new Position(3000, 2000, 100));//Einfach

                while (fliegerRegister != null)
                {
                    fliegerRegister();
                    Console.WriteLine();
                    Thread.Sleep(1000);// 1 Sekunde
                }
            }

            static void Main(string[] args)
            {
                Aircraft testProject = new Aircraft();
                testProject.ProgrammTakten();
                Console.ReadLine();
            }
        }
    }
}
