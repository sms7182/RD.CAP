using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RD.Core.CAP.ExampleEvent
{
    public class ExampleEventHandler:BaseEventHandler<SecondSampleEvent>
    {
        readonly ICapPublisher _capPublisher;
        readonly IExampleService _exampleService;
        public ExampleEventHandler(ICapPublisher capPublisher,IExampleService exampleService)
        {
            _capPublisher = capPublisher;
            _exampleService = exampleService;
        }
        [CapSubscribe(nameof(SecondSampleEvent))]
        public async Task Handle(SecondSampleEvent secondSampleEvent)
        {
            
        }
    }

    
    public interface IExampleService
    {

    }
    public class ExampleService:IExampleService
    {

    }
}
