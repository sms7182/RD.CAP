using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace RD.Core.CAP.ExampleEvent
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args).ConfigureServices((host,services)=> {
                  
                  services.AddScoped<IExampleService, ExampleService>();
                  
                  services.AddEventHandler<ExampleEventHandler>("CAPDB", "mongodb://localhost:27017", "localhost", "guest", "guest"); });
    }
   

    
}
