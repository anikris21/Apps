
using GcDemo;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<List<Longer[]>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/start", (List<Longer[]> bin) =>
{
    Console.WriteLine("/start");
    var forecast =  Enumerable.Range(0, 10000).Select(index =>
        new Longer(){
            Number = Random.Shared.NextInt64(),
            Description = Random.Shared.NextInt64().ToString()
        }) 
        .ToArray<Longer>();
    bin.Add(forecast);
    return "Ok";
})
.WithName("start")
.WithOpenApi();

app.MapGet("/promote", (List<Longer[]> bin) =>
{
    List<string> lines = new List<string>();
    Console.WriteLine("/promote");
    Console.WriteLine($"Generation collection : 0");
    lines.Add($"Generation collection : bin [{GC.GetGeneration(bin)}] bin[0] [{GC.GetGeneration(bin[0])}]");
    Console.WriteLine($"Generation collection : bin [{GC.GetGeneration(bin)}] bin[0] [{GC.GetGeneration(bin[0])}]");
    
    GC.Collect(0);

    lines.Add($"Generation collection : bin [{GC.GetGeneration(bin)}] bin[0] [{GC.GetGeneration(bin[0])}]");
    Console.WriteLine($"Generation collection : bin [{GC.GetGeneration(bin)}] bin[0] [{GC.GetGeneration(bin[0])}]");
    bin.RemoveAt(0);
    return lines;
})
.WithName("promote")
.WithOpenApi();

app.MapGet("/sweep", (List<Longer[]> bin) =>
{
    List<string> lines = new List<string>();
    Console.WriteLine("/sweep");
    Console.WriteLine($"Generation collection : 1");
    lines.Add($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    Console.WriteLine($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    
    GC.Collect(1);

    lines.Add($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    Console.WriteLine($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    
    return lines;
})
.WithName("sweep")
.WithOpenApi();

app.MapGet("/test", (List<Longer[]> bin) =>
{
    List<string> lines = new List<string>();
    Console.WriteLine("/sweep");
    Console.WriteLine($"Generation collection : 1");
    lines.Add($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    Console.WriteLine($"Generation collection : bin [{GC.GetGeneration(bin)}] ");
    
    GC.Collect(1);

    lines.Add($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    Console.WriteLine($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    bin.RemoveAt(0);
    return lines;
})
.WithName("test")
.WithOpenApi();

app.MapGet("/compact", (List<Longer[]> bin) =>
{
    List<string> lines = new List<string>();
    Console.WriteLine("/compact");
    Console.WriteLine($"Generation collection : 1");
    lines.Add($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    Console.WriteLine($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    
    GC.Collect(1, GCCollectionMode.Default, true, compacting:true);

    lines.Add($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    Console.WriteLine($"Generation collection : bin [{GC.GetGeneration(bin)}]");
    
    return lines;
})
.WithName("compact")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
