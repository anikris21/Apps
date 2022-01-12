namespace UnitTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("------------ UnitTest App -----------");

            MathClass mathClass = new MathClass();

            Console.WriteLine($"Add 3, 4 {mathClass.Add(3, 4)}");
            Console.WriteLine($"Subtract 4, 6 {mathClass.Subtract(6, 4)}");
            Console.WriteLine($"Multiply 4, 6 {mathClass.Multiply(4, 6)}");
            Console.WriteLine($"Divide   6, 4 {mathClass.Divide(6, 4)}");

            Console.WriteLine("-------------------------------------");
            Console.ReadKey();
        }
    }
}