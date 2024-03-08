using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion3
{
    class Luftfahrzeug
    {
        //protected string kennung = "Unidentified Flying Object(UFO)";
        protected string kennung;

        public Luftfahrzeug()
        {

        }

        public Luftfahrzeug(string kennung)
        {
            this.kennung = kennung;
        }

        public void Steigen(int meter)
        {
            Console.WriteLine(kennung + " steigt " + meter + " Meter");
        }

        public void Sinken(int meter)
        {
            Console.WriteLine(kennung + " sinkt " + meter + " Meter");
        }
    }

    class Flugzeug: Luftfahrzeug
    {

        //1M
        //public Flugzeug()
        //{
        //    kennung = " keine Kennung";
        //}

        //2M
        //public Flugzeug() : base() { }

        //3M
        //public Flugzeug() : base("keine Kennung") { }

        //4M
        public Flugzeug(string kennung) : base(kennung)
        {
            //this.kennung = "UFO";
            kennung = "UFO";
        }

    }

    class Starrflügelflugzeug  : Flugzeug
    {
        public Starrflügelflugzeug(string kennung) : base(kennung)
        {

        }
    }

    class Düsenflugzeug : Flugzeug
    {
        public Düsenflugzeug(string kennung) : base(kennung)
        {

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Luftfahrzeug flieger = new Luftfahrzeug("LH 4080");//Constructor method  생성자 메소드 

            flieger.Steigen(100);
            flieger.Sinken(50);

            Flugzeug flieger2 = new Flugzeug("keine Kennung");
            flieger2.Steigen(600);
            flieger2.Sinken(300);

/*
            Starrflügelflugzeug flieger3 = new Starrflügelflugzeug("UFO");
            flieger2.Steigen(900);
            flieger2.Sinken(400);


            Düsenflugzeug flieger4 = new Düsenflugzeug("UFO");
            flieger2.Steigen(1200);
            flieger2.Sinken(700);
*/
        }
    }
}
