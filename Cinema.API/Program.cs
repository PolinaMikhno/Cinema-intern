using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Cinema.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string logsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                              "\\logs.txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logsPath)
                .WriteTo.Console()
                .CreateLogger();
            
            try
            {
                Log.Information("Starting up...");
                return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .UseSerilog(Log.Logger);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host builder error");

                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
