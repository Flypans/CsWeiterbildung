using System;


//Der Code definiert abstrakte Methoden Flaeche und Umfang in der Super Class Figur,
//und diese werden dann in den Subclass Rechteck und Quadrat entsprechend überschrieben.
//Durch das Verwenden des override Schlüsselworts wird in den Subclass die Methode aus der Super Class überschrieben.

//Fläche des Rechtecks: breite* hoehe
//Umfang des Rechtecks: 2 * (breite + hoehe)
//Fläche des Quadrats: breite* breite
//Umfang des Quadrats: 4 * breite

namespace CS01Aufgabe5
{
    public abstract class Figur
    {
        public abstract int Flaeche(int breite, int hoehe);
        public abstract int Umfang(int breite, int hoehe);
    }

    public class Rechteck : Figur
    {
        public override int Flaeche(int breite, int hoehe)
        {
            return breite * hoehe;
        }

        public override int Umfang(int breite, int hoehe)
        {
            return 2 * (breite + hoehe);
        }

    }
    public class Quadrat : Figur
    {
        public override int Flaeche(int breite, int hoehe)
        {
            return breite + breite;
        }

        public override int Umfang(int breite, int hoehe)
        {
            return 4 * breite;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Rechteck rechteckValue = new Rechteck();
            Console.WriteLine("Fläche des Rechtecks : " + rechteckValue.Flaeche(3, 6));
            Console.WriteLine("Umfang des Rechtecks : " + rechteckValue.Umfang(4, 8));

            Quadrat quadratValue = new Quadrat();
            Console.WriteLine("Fläche des Quadrat : " + quadratValue.Flaeche(4, 4));
            Console.WriteLine("Umfang des Quadrat : " + quadratValue.Umfang(8, 8));

        }
    }
}
