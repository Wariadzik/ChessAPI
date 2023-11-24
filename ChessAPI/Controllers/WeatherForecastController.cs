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

        [HttpGet("extra")]
        public IEnumerable<WeatherForecast> GetWeatherExtra([FromQuery]int resultCount, [FromQuery] int minT, [FromQuery] int maxT)
        {
            var result = _service.GetExtra(resultCount, minT, maxT);
            return result;
        }

        [HttpPost("/generate")]
        public ActionResult<IEnumerable<WeatherForecast>> GenerateWeather([FromQuery] int resultCount, [FromBody] TempReq tempReq)
        {
            if (resultCount <= 0 || tempReq.Max<tempReq.Min)
            {
                return BadRequest();
            }
            var result = _service.GetExtra(resultCount, tempReq.Min, tempReq.Max);
            return Ok(result);
        }
    }
}
