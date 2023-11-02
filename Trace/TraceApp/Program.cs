using System.Diagnostics;

namespace TraceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();

            Trace.WriteLine("Entering main");


            Console.WriteLine("Hello, World!");


            Trace.WriteLine("Exiting main");
            Trace.Unindent();
        }
    }
}