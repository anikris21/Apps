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

            InventoryItems invItems = new InventoryItems(inventories);

            Console.WriteLine($"Enumerated Inventory  - ");
            foreach (Inventory item in invItems)
            {
                Console.WriteLine($" {item.Name}, {item.Price}");
            }

            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
        }
    } 


}