namespace UnitTest;
using Program;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.That(() => Program.calc(10, 1, '/'), Throws.TypeOf<OutOfMemoryException>() );
        Assert.Pass();
    }
}