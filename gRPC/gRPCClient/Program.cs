using Grpc.Net.Client;
using gRPCService;

namespace Program;
class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Hello, World!");
        var request = new HelloRequest {Name = "Sunil"};
        var channel = GrpcChannel.ForAddress("https://localhost:7226");
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(request);
        // .Message
        Console.WriteLine(reply.Message);
        

    }
}