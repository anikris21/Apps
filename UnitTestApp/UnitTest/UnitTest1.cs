using Xunit;
using UnitTestApp;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest1()
        {
            MathClass m = new MathClass();
            Assert.Equal(m.Add(3, 4), 3+4);
        }
    }
}