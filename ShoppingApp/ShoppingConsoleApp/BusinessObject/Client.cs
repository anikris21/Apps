// ShppingConsoleApp.
namespace ShoppingConsoleApp.BusinessObject
{
    public class Client
    {
        public int Id { get; private init; }

        public string Name { get; private init; }

        public List<string> ShoppingCart { get; private init; }

        public Client(int id, string name)
        {
            ShoppingCart = new List<string>();
            Id = id;
            Name = name;
        }

        public void AddToCart(string item)
        {
            ShoppingCart.Add(item);
        }



    }
}