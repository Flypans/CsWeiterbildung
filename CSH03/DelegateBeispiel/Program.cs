using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBeispiel
{
    delegate void Nachrict (string sender);

    class Program
    {
        public void GutenTag( string sender)
        {
            Console.WriteLine(sender + " sagt guten Tag.");
        }
        public void AufWiedersehen(string sender)
        {
            Console.WriteLine(sender + " sagt auf Wiedersehen.");
        }
        public void AufWiederhoeren (string sender)
        {
            Console.WriteLine(sender + " sagt auf Wiederhören.");
        }
        public void DelegateAnwenden()
        {
            Nachrict info = new Nachrict(GutenTag); // Delegate 선언
            
            //info();
            //info(1234);
            //info("Ihr", "Administrator");

            info += new Nachrict(AufWiedersehen); // Delegate에 Methode 추가 +=
            info -= new Nachrict(AufWiederhoeren); // Delegate에 Methode 빼기 -= ,특정한 메서드 구독(subscription)을 취소하는 데 사용

            info("Ihr Administrator");
        }

       
        public static void Main(string[] args)
        {
            Program test = new Program();
            test.DelegateAnwenden();
        }
    }
}
