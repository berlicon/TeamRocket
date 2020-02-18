using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Python.Runtime;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class MainController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        [HttpGet("testGet/{x}/{y}")]
        public string TestGet(int x, int y)
        {
            return (x + y).ToString();
        }

        [HttpPost("testPost/{x}/{y}")]
        public string TestPost([FromRoute] int x, [FromRoute] int y, [FromBody] Elem elem)
        {
            //return $"{x + y}";
            return ($"{x + y} - {elem.Id} - {elem.Name} - {elem.Active} - {(elem.List != null ? elem.List.Length : 0)}");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //FileUtil.SaveTimeToFile();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("TestNDarray")]
        public string TestNDarray([FromBody] float[] input)
        {
            return ModelUtil.TestNDarray(input);
        }

        [HttpPost("predict")]
        public string Predict([FromBody] float[] input)
        {
            return ModelUtil.Predict(input);
        }

        [HttpPost("init")]
        public void Init()
        {
            ModelUtil.Init();
        }
    }
}
