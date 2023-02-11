// See https://aka.ms/new-console-template for more information
using System;


namespace Program {
    public class Program {
        public static void Main() {



            AppDomain current = AppDomain.CurrentDomain; 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Handleex);
            Console.WriteLine("Hello "); 

            Console.WriteLine("Num : ");
            var n1 = Console.ReadLine();
            Console.WriteLine("num : ");
            var n11 = Console.ReadLine();
            Console.WriteLine("Op : ");
            int r = Console.Read();

            try {

             calc(Convert.ToInt16(n1) ,  Convert.ToInt16(n11), r);
            } catch {
                Console.Write("catch ");
                throw;
            }

            Console.WriteLine("executing num : ");


        }

        public static int calc(int n1, int n11, int op) {
            switch(op) {
                case '+': return n1 + n11;

                default: throw new OutOfMemoryException();
            }
            

        }

        public static void Handleex(object s, UnhandledExceptionEventArgs eventArgs) {
            Console.WriteLine($" {eventArgs.ExceptionObject}");
        }


    }
}
