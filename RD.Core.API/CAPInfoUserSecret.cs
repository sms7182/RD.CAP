using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RD.Core.API
{
    public class CAPInfoUserSecret
    {
        public string CAPDBName { get; set; }
        public string CAPDBHost { get; set; }
        public string RabbitMQHost { get; set; }
        public string RabbitUser { get; set; }
        public string RabbitPass { get; set; }

    }
}
