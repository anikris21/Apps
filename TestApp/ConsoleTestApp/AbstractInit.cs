using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    internal abstract class AbstractInit
    {
        public abstract void Init();

        public abstract void Print();
        
    }

    internal class ConcreteInit:AbstractInit
    {
        public override void Init()
        {
            Console.WriteLine($"Init ...");
        }

        public override void Print()
        {
            Console.WriteLine($"------------- Abstract obj = concrete obj()  Print Method ---------------");
        }
    }
}
