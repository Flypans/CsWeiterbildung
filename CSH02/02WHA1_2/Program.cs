using System;

/*
Ausgeben 메서드를 인스턴스 메서드로 정의해야 합니다.
인스턴스 메서드는 클래스의 인스턴스에서 호출되는 메서드입니다.
그러므로 Ausgeben 메서드를 Program 클래스 내부에서 인스턴스 메서드로 변경하고,
Main 메서드에서는 해당 클래스의 인스턴스를 만든 후에 해당 메서드를 호출하면 됩니다.
*/

namespace _02WHA1_2
{
  
    class Program
    {
        public void Ausgeben(int a, int b, string waehrung)
        {
            Console.WriteLine("Für {0} Aktien à {1} {2} haben Sie {3} Euro zu zahlen", a, b, waehrung, a*b);
        }
        static void Main(string[] args)
        {
            Program obj = new Program();

            obj.Ausgeben(110, 5, "Euro");
        }
    }
}
