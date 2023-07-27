using ShoppingConsoleApp.BusinessObject;
using DataAccess;

//var repository = new ClientRepository();

var repository = new ClientRepository("connection string");
Client client = repository.GetClientFromId(1);
client.SaveCart();

void DisplayClient(Client client)
{
    Console.WriteLine( "******" + client.Name + "******");
    foreach(var item in client.ShoppingCart)
    {
        Console.WriteLine(item);
    }

}