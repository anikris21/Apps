using System.Threading;
using ThreadingApp;

public class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("Hello, World!");
        Console.WriteLine("--------------------------");

        ThreadExec threadExec = new ThreadExec();
        Thread thread = new Thread(threadExec.thread);
        thread.Start();

        Console.ReadKey();
    }

}