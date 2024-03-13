using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion3
{

    class Operatoren
    {
        public void InkrementUndDekrement()
        {
            int var = 1;

            Console.WriteLine("Präfix-Inkrement /-Dekrement");
            Console.WriteLine("var++ = {0}", var++); //1
            Console.WriteLine("var   = {0}", var);//2
            Console.WriteLine("var-- = {0}", var--);//2
            Console.WriteLine("var   = {0}", var);//1

            var = 1;
            Console.WriteLine("Postfix-Inkrement /-Dekrement");
            Console.WriteLine("++var = {0}", ++var);//2
            Console.WriteLine("var   = {0}", var);//2
            Console.WriteLine("--var = {0}", --var);//1
            Console.WriteLine("var   = {0}", var);//1
        }
        public void BinaryAnd(int binaryAnd)
        {
            Console.WriteLine($"Binary And Result : {string.Format("{0,18}", Convert.ToString(binaryAnd, 2))}");
        }

        public void BinaryOr(int binaryOr)
        {
            Console.WriteLine($"Binary OR Result  : {string.Format("{0,18}", Convert.ToString(binaryOr, 2))}");
        }

        public void BinaryXor(int binaryXor)
        {
            Console.WriteLine($"Binary XOR Result : {string.Format("{0,18}", Convert.ToString(binaryXor, 2))}");
        }

        public void ShifOperator()
        {

            int valueA = 1234567;
            int ergebnisLinksShift = valueA << 2;
            int ergebnisRechtsShift = valueA >> 2;

            Console.WriteLine($"1234567 << 2 = {ergebnisLinksShift}");
            Console.WriteLine($"1234567 >> 2 = {ergebnisRechtsShift}");

            int valueB = 9; // 0b00001001;
            int LinksShift = valueB << 2;
            int RechtsShift = valueB >> 2;

            Console.WriteLine($"1234567 << 2 = {LinksShift}");
            Console.WriteLine($"1234567 >> 2 = {RechtsShift}");

            int ValueC = 12345;
            Console.WriteLine($"12345 << 3  {ValueC << 3}");

            int ValueD = 12345;
            Console.WriteLine($"12345 >> 3  {ValueD >> 3}");
        }

        //binaryNumber[length - i - 1] - '0': 문자열로 표현된 2진수에서 각 자릿수를 가져오는 부분입니다.
        //문자열에서 가져온 문자를 정수로 변환하기 위해 ASCII 코드 값에서 문자 '0'의 ASCII 코드 값을 빼줍니다.
        //예를 들어, '0'의 ASCII 코드 값은 48이며, '1'의 ASCII 코드 값은 49입니다.
        //따라서 '1' - '0'은 1이 되고, '0' - '0'은 0이 됩니다.

        //(int)Math.Pow(2, i): 해당 자릿수의 2의 거듭제곱 값을 계산합니다.각 자릿수는 2의 제곱으로 증가하므로,
        //0번째 자릿수부터 2^0(1), 2^1(2), 2^2(4), 2^3(8) 등으로 증가합니다.
        //이렇게 구한 각 자릿수의 10진수 값과 해당 자릿수의 2의 거듭제곱 값을 곱하여 합산하여 전체 2진수를 10진수로 변환합니다.

        //2진수의 가장 오른쪽 자릿수는 최하위 비트(MSB)로, 가장 왼쪽 자릿수는 최상위 비트(LSB)입니다.
        //따라서 문자열에서 가장 오른쪽에 있는 문자가 2진수의 최하위 비트에 해당하고, 가장 왼쪽에 있는 문자가 최상위 비트에 해당합니다.
        //배열의 인덱스는 0부터 시작하므로, binaryNumber[length - 1] 이 가장 오른쪽에 있는 비트를 나타내고,
        //binaryNumber[0] 이 가장 왼쪽에 있는 비트를 나타냅니다.그
        //래서 각 자릿수를 가져올 때 배열을 거꾸로 읽어야 합니다.
        //따라서 binaryNumber[length - i - 1] 에서 -1을 하는 것입니다.

        public int BinaryToDecimal(string binaryNumber)
        {
            int decimalNumber = 0;
            int lenght = binaryNumber.Length;
            int digit;

            Console.WriteLine(binaryNumber + " : Lenght [" + lenght + "]");

            for (int i = 0; i < lenght; i++)
            {
                digit = binaryNumber[lenght - i - 1] - '0';
                decimalNumber = decimalNumber + digit * (int)Math.Pow(2, i);//  거듭제곱 값을 반환 (base, exponent)
                                                                            //Console.WriteLine("[{0}] digit: {1} decimalNumber: {2}",i, digit, decimalNumber);
            }
            return decimalNumber;
        }

        //C#에서 출력 형식을 지정하기 위해 서식 문자열을 사용할 수 있습니다.
        //숫자를 출력할 때 특정 길이로 정렬하려면 {숫자, 너비} 형식의 서식 문자열을 사용할 수 있습니다.
        //여기서 {0,18}은 숫자를 출력할 때 최소 너비를 18로 지정하며, 오른쪽으로 정렬됩니다.
        //숫자가 지정된 너비보다 짧으면 왼쪽에 공백이 채워집니다.
        //Convert.ToString( , 2) 정수를 이진수 문자열로 변환

        public void LogicalOps()
        {
            //kreditwürdig = volljährig & (verdienst > 2000 | bürge)
            bool volljährig = true;
            double verdienst = 1900;
            bool Bürge = true;
            bool kreditwürdig = volljährig & (verdienst > 2000 | Bürge);

            Console.WriteLine("kreditwürdig: {0}", kreditwürdig);
        }
        public void Vergleiche()
        {
            double x = 2.39;
            double y = 2.37;
            bool b = x >= y;      // Wert von b ist true;

            Console.WriteLine(" x : {0}, y : {1}, b : {2}", x, y, b);

            int var1 = -1234;
            int var2 = 1234;
            int var3 = 1234;

            Console.WriteLine("var1 < var2 == var3 >= var2: {0}", var1 < var2 == var3 >= var2);

            string s1 = "string";
            string s2 = s1;

            Console.WriteLine("s1 == s2: {0}", s1 == s2);
        }
        public void RundeKlammern()
        {
            //Auf welche Ganzzahl wird der Ausdruck 5 + 11 · 12 – 14 / 7 ausgewertet ?
            int ausgewertet = (5 + (11 * 12)) - (14 / 7);
            Console.WriteLine(ausgewertet);
        }
        public void UnaereOperatoren()
        {
        }
        public void TernaererOperator()
        {
            int var1 = +1234;
            int var2 = -1234;

            string auswertung = (var1 == var2) ? "gleich" : "ungleich";
            Console.WriteLine("{0} == {1} ? {2}", var1, var2, auswertung);
        }
        public void Module()
        {
            int intVar1 = 1234;
            int intVar2 = 13;
            double doubleVar1 = 22.33;
            double doubleVar2 = 6.6;

            Console.WriteLine("intVar1 % intVar2 = {0}", intVar1 % intVar2);
            Console.WriteLine("doubleVar1 % doubleVar2 = {0}", doubleVar1 % doubleVar2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Operatoren ops = new Operatoren();
            ops.TernaererOperator();
            ops.RundeKlammern();
            ops.Module();
            ops.Vergleiche();
            ops.LogicalOps();

            Console.WriteLine("a = 11000000111001 = {0}", ops.BinaryToDecimal("11000000111001"));
            Console.WriteLine("b = 101101110100000 = {0}", ops.BinaryToDecimal("101101110100000"));

            //숫자 앞에 0b는 이진수를 나타내는 접두사입니다.
            //이것은 C# 7.0부터 도입된 "이진 리터럴" 문법입니다.
            //이진 리터럴을 사용하면 이진수를 직접 코드에 표기할 수 있습니다.
            ops.BinaryAnd(0b11000000111001 & 0b101101110100000);
            ops.BinaryOr(0b11000000111001 | 0b101101110100000);
            ops.BinaryXor(0b11000000111001 ^ 0b101101110100000);

            int number = 1234567;
            bool a = true;
            //$"" 구문은 C# 6.0 이상에서 도입된 문자열 보간(interpolation) 기능
            Console.WriteLine($"Komplement : {!a}");
            Console.WriteLine($"Negation   : {~number}");

            ops.ShifOperator();
            ops.InkrementUndDekrement();

        }
    }
}
