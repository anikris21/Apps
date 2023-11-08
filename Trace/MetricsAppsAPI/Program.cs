using MetricsAppsAPI.Model;
using MetricsAppsAPI.Services;
using App.Metrics.Formatters.Prometheus;
using App.Metrics.AspNetCore.Tracking;

namespace MetricsAppsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<CustomerService>();

            builder.Services.AddMetrics();
            builder.Services.AddMetricsTrackingMiddleware();

            // metrics end points 
            builder.Services.AddMetricsEndpoints();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseMetricsAllMiddleware();

            app.UseMetricsAllEndpoints();

            //app.UseMetricsWebTracking();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}