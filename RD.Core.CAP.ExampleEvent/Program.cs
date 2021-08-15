using Microsoft.Extensions.Configuration;
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
              Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, builder) => { builder.AddUserSecrets<CAPInfoUserSecret>(); })
            .ConfigureServices((host,services)=> {
                var secret = (CAPInfoUserSecret)host.Configuration.GetSection(typeof(CAPInfoUserSecret).Name).Get<CAPInfoUserSecret>();
                services.AddScoped<IExampleService, ExampleService>();
                  
                  services.AddEventHandler<ExampleEventHandler>(secret.CAPDBName,secret.CAPDBHost,secret.RabbitMQHost, secret.RabbitUser, secret.RabbitPass); });
    }
   

    
}
