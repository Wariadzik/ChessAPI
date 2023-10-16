using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeather()
        {
            var result = _service.Get();
            return result;
        }

        [HttpGet("data/{name}")]
        public string Get2([FromQuery]int favoriteNumber, [FromRoute]string name)
        {
            if (favoriteNumber == 0) return "You are a little zero!";

            return $"Hello {name}";
        }
    }
}
