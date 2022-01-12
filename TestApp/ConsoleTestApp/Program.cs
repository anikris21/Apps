namespace ConsoleTestApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-------------- ConsoleTest App ----------------");

            AbstractInit abstractInit = new ConcreteInit();
            abstractInit.Init();
            abstractInit.Print();

            Console.WriteLine("------------------------------------------------");
            Console.ReadKey();
        }
    }
}