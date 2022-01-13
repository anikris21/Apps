using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp
{
    public interface IMathClass
    {
        int Add(int x, int y);

        int Subtract(int x, int y);

        int Multiply(int x, int y);

        int Divide(int x, int y);
    }

    public class MathClass :IMathClass
    {
        public int Divide(int x, int y)
        {
            if (y == 0)
            {
                throw new InvalidOperationException();
            }
            return x / y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int Subtract(int x, int y)
        {
            return (x - y);
        }

        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
