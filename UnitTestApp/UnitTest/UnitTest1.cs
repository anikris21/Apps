using Xunit;
using UnitTestApp;
using System;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest1()
        {
            // Setup
            MathClass m = new MathClass();
            
            // Exercise

            // Asset/verify
            Assert.Equal(m.Add(3, 4), 3+4);

            // Teardown
        }

        [Fact]
        public void AddSubtractTest()
        {
            // Setpup
            MathClass m = new MathClass();

            // Exercise

            // Assert/verify
            Assert.Throws<InvalidOperationException>(() => m.Divide(10, 0));
            
            // Teardown
        }
    }
}