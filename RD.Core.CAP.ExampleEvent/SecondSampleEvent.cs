using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RD.Core.CAP.ExampleEvent
{
    public class SecondSampleEvent : IEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
   

}
