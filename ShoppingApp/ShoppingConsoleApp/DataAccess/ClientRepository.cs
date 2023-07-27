using ShoppingConsoleApp.BusinessObject;

namespace DataAccess
{
    public class ClientRepository : IClientRepository
    {
        // 
        public ClientRepository(string connectionString)
        {
            

        }

        public Client GetClientFromId(int clientId)
        {
            Client client = new Client(1, "Ace Gardner", this);
            client.AddToCart("carnations");
            client.AddToCart("indigo");
            return client;
        }




        public bool PersistCart()
        {
            Console.WriteLine("the cart is being persisted");
            return true;
        }

    }
}