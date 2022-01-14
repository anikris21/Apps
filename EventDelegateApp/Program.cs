using EventDelegateApp;

namespace App
{
    public delegate void Print(string message);

    public class EventDelegateApp
    {
        public static void Main()
        {
            Console.WriteLine("-------- EventDelgate App ---------------");

            EventApp ob = new EventApp();
            //ob.InsPrint("Test");

            Print del = ob.InsPrint;
            del += EventApp.StaticPrint;
            del += MainPrint;

            del("Delegate call");
            Console.WriteLine("-----------------------------------------");
            Console.ReadKey();
        }

        public static void MainPrint(string s)
        {
            Console.WriteLine(s);
        }
    }
}