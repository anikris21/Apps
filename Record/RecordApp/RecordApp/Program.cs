namespace RecordApp
{
    using System;

    record struct Test
    {
        public int Prop { get; set; }
        public Test(int v)
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
    class Test1
    {
        public int Prop { get; set; } = 10;
        public void Print()
        {
            Console.WriteLine("*Test1 c");
        }

        public virtual void Print1()
        {
            Console.WriteLine("Test1 virtual  c");
        }

        public void Deconstruct(out string str, out int val) { str = "hello"; val = Prop; }
    }

    public class HelloWorld
    {
         static void Upd(Test t1, TestRef rt) { t1.Prop = 100;
            rt.Prop = 100;
        }
        public static void Main(string[] args)
        {
            Test1 t = new Test1();
            Console.WriteLine($"Hash {t.GetHashCode()}");
            t.Prop = 11;
            Console.WriteLine($"Hash {t.GetHashCode()}");
            var (str, v) = t;
            Console.WriteLine($"Test obj {str} {v}");

            Test t1 = new Test(10);
            Test t_1 = t1;
            Console.WriteLine(ReferenceEquals(t1, t_1));
            //Upd(t1);
            Console.WriteLine(t1);

            Console.WriteLine("****** Records : ");
            TestRef rt = new TestRef(10);
            TestRef rt_1 = rt;
            Console.WriteLine(ReferenceEquals(rt, rt_1));
            Upd(t1, rt_1);
            Console.WriteLine(rt_1);

            Console.WriteLine("****** Records end : ");



            Test t11 = new Test(10);
            Console.WriteLine(t1 == t11);
            Console.WriteLine($"struct Hash {t1.GetHashCode()}");
            t1.Prop = 11;
            Console.WriteLine($"struct Hash {t1.GetHashCode()}");

            Console.WriteLine("Hello Mono World");
        }
    }
}