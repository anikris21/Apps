// ShppingConsoleApp.
namespace ShoppingConsoleApp.BusinessObject
{
    public class Client
    {
        public int Id { get; private init; }

        public string Name { get; private init; }

        public List<string> ShoppingCart { get; private init; }
        public IClientRepository _repository { get; set; }

        public Client(int id, string name, IClientRepository clientRepository)
        {
            ShoppingCart = new List<string>();
            Id = id;
            Name = name;
            _repository = clientRepository;
        }

        public void AddToCart(string item)
        {
            ShoppingCart.Add(item);
        }

        public void SaveCart()
        {
            _repository.PersistCart();
        }



    }
}