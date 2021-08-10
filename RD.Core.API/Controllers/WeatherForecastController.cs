using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RD.Core.API.Controllers
{
    
    public class SampleEvent
    {
        public Guid Id { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ICapPublisher _capBus;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ICapPublisher capPublisher)
        {
            _logger = logger;
           _capBus = capPublisher;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("sendWithCAP")]
        public async Task<ActionResult> SendWithCAP(Guid id)
        {
            var sampleEvent = new SampleEvent();
            sampleEvent.Id = id;
            await _capBus.PublishAsync(nameof(SampleEvent), sampleEvent);
            return Ok(sampleEvent);
        }

        //[CapSubscribe(nameof(SampleEvent))]
        //public void CheckReceivedMessage(SampleEvent sampleEvent)
        //{

        //}
    }
}
