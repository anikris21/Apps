using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Parsers;
using Microsoft.Diagnostics.Tracing.Session;

namespace ETWClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            if (!(TraceEventSession.IsElevated() ?? false)) 
            { 
                Console.WriteLine("Run as admin"); return; 
            
            }

            TraceEventSession session = new TraceEventSession("TraceApp");
            session.EnableProvider("TraceAppEventSource", TraceEventLevel.Verbose);


            var parser = session.Source.Dynamic;
            parser.All += e => {
                for (int i = 0; i < e.PayloadNames.Length; i++) { Console.Write($"e.PayloadValue(i) "); }

                Console.WriteLine();
            };

            session.Source.Process();

        }
    }
}