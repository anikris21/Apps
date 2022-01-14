using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateApp
{
    public class EventApp
    {
        public static void StaticPrint(string s)
        {
            Console.WriteLine($" StaticPoint {s}");
        }

        public void InsPrint(string s)
        {
            Console.WriteLine($" InsPoint {s}");
        }
    }
}
