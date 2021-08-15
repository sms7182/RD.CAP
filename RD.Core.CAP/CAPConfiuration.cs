using DotNetCore.CAP;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RD.Core.CAP
{
    public static class CAPConfiuration
    {
        static IServiceCollection AddCAP(this IServiceCollection services,string capDB,string dbConnection,string rabbitHost,string rabbitUser,string rabbitPass)
        {
            services.AddCap(x =>
            {
                x.UseMongoDB(mo => { mo.DatabaseName =capDB; mo.DatabaseConnection = dbConnection; });
                x.UseRabbitMQ(rabbit=> { rabbit.HostName = rabbitHost;rabbit.Port = 5672;rabbit.UserName = rabbitUser;rabbit.Password = rabbitPass; });

               
            });
            
            return services;
        }

        public static IServiceCollection AddEventHandler<T>(this IServiceCollection services,string capDB,string capDBHost,string rabbitHost,string rabbitUser,string rabbitPassword) where T:ICapSubscribe
        {
            services.AddCAP(capDB, capDBHost, rabbitHost, rabbitUser, rabbitPassword);
            var types = typeof(T).Assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.BaseType != null && type.BaseType.IsGenericType && typeof(IEvent).IsAssignableFrom(type.BaseType.GenericTypeArguments[0]))
                {
                    services.AddTransient(type);
                }
            }

            return services;
        }
        
    }

    public interface IEvent
    {

    }
    
}
