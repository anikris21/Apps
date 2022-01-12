using EnumeratorApp;

namespace App
{
    public class EnumeratorApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"--------- EnumeratorApp -------------");
            Inventory[] inventories = new Inventory[]
            {
                new Inventory("PC", 1000),
                new Inventory("Laptop", 1000),
                new Inventory("Mobile", 1000)
            };

            Console.WriteLine($"Enumerated Inventory  - ");
            foreach (Inventory item in inventories)
            {
                Console.WriteLine($" {item.Name}, {item.Price}");
            }

            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }
    } 


}