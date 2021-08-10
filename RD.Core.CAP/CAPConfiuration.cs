using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RD.Core.CAP
{
    public static class CAPConfiuration
    {
        public static IServiceCollection AddCAP(this IServiceCollection services)
        {
            services.AddCap(x =>
            {
                x.UseMongoDB(mo => { mo.DatabaseName = "CAPDB"; mo.DatabaseConnection = "mongodb://localhost:27017"; });
                x.UseRabbitMQ("localhost:5672");

               
            });
            return services;
        }
    }
}
