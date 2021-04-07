using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Cinema.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builtConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("C:\\Users\\Maksim.Ruksha\\source\\repos\\Cinema-intern\\logs.txt")
                //.WriteTo.File(builtConfig["Logging:FilePath"])
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                return WebHost.CreateDefaultBuilder(args)
                    .ConfigureServices((context, services) =>
                    {
                        services.AddMvc();
                    })
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.AddConfiguration(builtConfig);
                    })
                    .ConfigureLogging(logging =>
                    {
                        logging.AddSerilog();
                    })
                    .UseStartup<Startup>();
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
        //TODO: cleanup this
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("C:\\Users\\Maksim.Ruksha\\source\\repos\\Cinema-intern\\logs.txt")
                //.WriteTo.File(builtConfig["Logging:FilePath"])
                .WriteTo.Console()
                .CreateLogger();

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.ClearProviders();
                    logging.AddSerilog();
                    /*logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();*/

                });
        }
    }
}
