
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Parsers;
using Microsoft.Diagnostics.Tracing.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETWClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            if (!(TraceEventSession.IsElevated() ?? false)) 
            { 
            
            }

            TraceEventSession session = new TraceEventSession("TraceApp");
            session.EnableProvider("TraceAppEventSource", TraceEventLevel.Verbose);


            var parser = session.Source.Dynamic;
            parser.All += e => {

                Console.WriteLine();
            };

            session.Source.Process();


        }
    }
}