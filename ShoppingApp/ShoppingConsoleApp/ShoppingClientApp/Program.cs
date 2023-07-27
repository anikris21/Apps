using ShoppingConsoleApp.BusinessObject;

Client client = new Client(1, "Ace Gardner");

client.AddToCart("carnations");
client.AddToCart("indigo");

DisplayClient(client);
void DisplayClient(Client client)
{
    Console.WriteLine( "******" + client.Name + "******");
    foreach(var item in client.ShoppingCart)
    {
        Console.WriteLine(item);
    }

}