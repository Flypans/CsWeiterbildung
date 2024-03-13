using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02WHA2_1
{
    /*
    decimal 값을 binary로 변환하는 방법은 Convert.ToString() 메서드를 사용하여 가능합니다.
    그러나 Convert.ToString() 메서드는 decimal 값을 바이너리로 직접 변환하지 않습니다.
    대신, 먼저 decimal 값을 int나 long으로 변환한 다음 이를 이진수로 변환합니다.
    이 코드는 decimal 값을 int로 변환한 후 이를 이진수로 변환하여 출력합니다.
    그러나 이진수로 변환할 때 정확성을 보장할 수 없을 수 있으므로 주의해야 합니다.
*/

/*
            decimal number = 12345;
            // decimal 값을 int로 변환 후 binary로 변환
            int intValue = Decimal.ToInt32(number);
            string binaryValue = Convert.ToString(intValue, 2); //binary
            Console.WriteLine("Decimal 값 {0}의 Binary 표현: {1}", number, binaryValue);
*/
    class ReferenceTest
    {
        public void ArrayHandling()
        {
            int[,] intArray2D = new int[2, 3] { { 4, 16, 36 }, { 9, 25, 49} };
            Console.WriteLine("1. Dimension: {0}", intArray2D.GetLength(0));
            Console.WriteLine("2. Dimension: {0}", intArray2D.GetLength(1));
        }
    }
    class SingleWerteTest
    {
        public void SingleWerte()
        {
            Console.WriteLine("Single.NegativeInfinity : {0}", Single.NegativeInfinity);
            Console.WriteLine("Single.MinValue : {0}", Single.MinValue);
            Console.WriteLine("Single.NaN : {0}", Single.NaN);
            Console.WriteLine("Single.Epsilon : {0}", Single.Epsilon);
            Console.WriteLine("Single.MaxValue : {0}", Single.MaxValue);
            Console.WriteLine("Single.PositiveInfinity : {0}", Single.PositiveInfinity);
        }

        public void EinfacheTypenMethoden()
        {
            double a = 1234567890;
            Console.WriteLine("a.Tostring : {0}", a.ToString());

            double Da = 1234500000;
            double Db = 0.00000012345;
            double Dc = 1.2345E9;
            double Dd = 1.2345E-7;

            Console.WriteLine(Da);
            Console.WriteLine(Db);
            Console.WriteLine(Dc);
            Console.WriteLine(Dd);

            //Wie lässt sich mit C#-Mitteln prüfen, ob a und c sowie b und d gleich sind?
            Console.WriteLine("Da and Dc = {0}", Da.Equals(Dc));
            Console.WriteLine("Db and Dd = {0}", Db.Equals(Dd));

            //Wie lassen sich die vier double-Werte explizit in Zeichenketten umwandeln?
            Console.WriteLine("ToString({0}", Da.ToString()+")");
            Console.WriteLine("ToString({0}", Db.ToString()+")");
            Console.WriteLine("ToString({0}", Dc.ToString()+")");
            Console.WriteLine("ToString({0}", Dd.ToString()+")");

            //Auch die Object - Methode GetHashCode() kann auf die Werte der einfachen Typen angewandt werden
            Console.WriteLine("Hashcode: {0}", Da.GetHashCode());
            Console.WriteLine("Hashcode: {0}", Db.GetHashCode());
            Console.WriteLine("Hashcode: {0}", Dc.GetHashCode());
            Console.WriteLine("Hashcode: {0}", Dd.GetHashCode());
        }

        public void WelcheZahlKleiner()
        {
            decimal value1 = 1E-28M;
            decimal value2 = -1E28M;
            Console.WriteLine(value1);
            Console.WriteLine(value2);

            Console.WriteLine(" 1E-28M AND -1E28M = {0}", value1.Equals(value2));
            
            bool isFirstValueSmaller = value1 < value2;
            Console.WriteLine(isFirstValueSmaller);
            Console.WriteLine(isFirstValueSmaller ? "value1 ist kleiner." : "value2 it kleiner.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SingleWerteTest singlevalue = new SingleWerteTest();
            singlevalue.SingleWerte();
            singlevalue.EinfacheTypenMethoden();
            singlevalue.WelcheZahlKleiner();

            ReferenceTest ReferenceArray = new ReferenceTest();
            ReferenceArray.ArrayHandling();
        }
    }
}
