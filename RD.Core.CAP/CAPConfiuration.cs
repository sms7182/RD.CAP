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
         static IServiceCollection AddCAP(this IServiceCollection services)
        {
            services.AddCap(x =>
            {
                x.UseMongoDB(mo => { mo.DatabaseName = "CAPDB"; mo.DatabaseConnection = "mongodb://localhost:27017"; });
                x.UseRabbitMQ(rabbit=> { rabbit.HostName = "localhost";rabbit.Port = 5672;rabbit.UserName = "guest";rabbit.Password = "guest"; });

               
            });
            
            return services;
        }

        public static IServiceCollection AddEventHandler<T>(this IServiceCollection services) where T : ICapSubscribe
        {
            services.AddCAP();
           var types= typeof(T).Assembly.GetTypes();
            foreach(var type in types)
            {
                if (type.BaseType!=null&&type.BaseType.IsGenericType&&typeof(IEvent).IsAssignableFrom(type.BaseType.GenericTypeArguments[0]))
                {
                    services.AddTransient(type);
                }
            }
           
            return services;
        }
    }

   
    public abstract class BaseEventHandler<T>:ICapSubscribe where T :IEvent
    {

    }
    public interface IEvent
    {

    }
    
}
