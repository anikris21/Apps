using RelApp.DbContexts;
using RelApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RelAppDbContext>((options) => { 
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

// RelAppDbContext dbContext Task<Results<NotFound, Ok<Employee>>> FirstOrDefaultAsync return
app.MapGet("/employee/{empId:int}", async Task<Results<NotFound, Ok<Employee>>> (int empId, RelAppDbContext dbContext) => {
    var res = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == empId);
    if (res == null) { return TypedResults.NotFound(); }
    return TypedResults.Ok(res);

});

app.MapGet("/department/{depId:int}", async Task<Results<NotFound, Ok<Department>>> (int depId, RelAppDbContext dbContext) =>
{
    var res = await dbContext.Department.FirstOrDefaultAsync(d => d.Id == depId);
    if (res == null) { return TypedResults.NotFound(); }
    return TypedResults.Ok(res);
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
