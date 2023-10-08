using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordApp
{
    record TestRef
    {
        public int Prop { get; set; }
        public TestRef(int v)
        {
            Prop = v;
        }
        public void Print()
        {
            Console.WriteLine("*Test1 c");
        }

        public void Print1()
        {
            Console.WriteLine("Test1 virtual  c");
        }
    }
}
