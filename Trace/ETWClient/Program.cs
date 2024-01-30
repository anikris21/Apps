
using Microsoft.Diagnostics.Tracing;
//using Microsoft.Diagnostics.Parsers;
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
            if (!(TraceEventSession.IsElevated() ?? false))
            {
                Console.WriteLine("Run as admin");
                //return;

            }

            TraceEventSession session = new TraceEventSession("TraceApp");
            session.EnableProvider("TraceAppEventSource", TraceEventLevel.Verbose);


            var parser = session.Source.Dynamic;
            parser.All += e => {
                for (int i = 0; i < e.PayloadNames.Length; i++)
                {
                    Console.Write($"{e.PayloadValue(i)} ");

                }

                Console.WriteLine();
            };

            session.Source.Process();


        }
    }
}
