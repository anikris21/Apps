using Models;
using Models.Tests.Data;

try
{
    foreach (var worker in Workers.TestData)
    {
        Console.WriteLine(worker);
    }
}
catch (Exception e)
{
    Console.WriteLine($"Err : {e.Message}");
}
