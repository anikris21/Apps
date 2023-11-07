using System.Diagnostics;
namespace EventLogApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddLogging(logbuilder => {
                logbuilder.AddConsole(options => { options.TimestampFormat = "[HH:mm:ss]"; });
                logbuilder.AddEventLog(options => { options.LogName = "Application1";
                    options.SourceName = "TraceAppSource";

                });
            });

            var app = builder.Build();

            if (!EventLog.SourceExists("TraceAppSource")) { EventLog.CreateEventSource("TraceAppSource", "Application1"); }



            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}