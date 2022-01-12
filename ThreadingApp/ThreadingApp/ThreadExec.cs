using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingApp
{
    internal class ThreadExec
    {
        public void thread()
        {
            Console.WriteLine($"\n-----------Thread start --------------");
            Console.WriteLine($"managed thread id - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"exiting thread");
        }
    }
}
