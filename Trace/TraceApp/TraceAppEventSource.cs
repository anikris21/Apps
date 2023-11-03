using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;

namespace TraceApp
{
    // EventSource
    [EventSource(Name = "TraceAppEventSource")]
    internal class TraceAppEventSource: EventSource
    {
        public static TraceAppEventSource Log = new TraceAppEventSource();

        [Event(1)]
        public void AppStart(int requestId, string msg) { WriteEvent(1, requestId, msg); }

        [Event(5)] 
        public void AppEnd(int requestId, string msg) { WriteEvent(5, requestId, msg); }

    }
}
