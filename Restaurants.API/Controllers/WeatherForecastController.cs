using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurants.API.Model;
using Restaurants.API.Services;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecast ;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecast = weatherForecastService;
        }

        [HttpPost("generate")]
        public IActionResult PostGenerate([FromQuery] int count, [FromBody] TemperatureAdjust request)
        {
            if (count < 0 || request.min > request.max)
                return BadRequest("count must be greather than 0 and min temperature must be less than max temp");
            var res = this._weatherForecast.Get(count, request.min, request.max);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = this._weatherForecast.Get();
            return StatusCode(400, res);
        }



        [HttpGet]
        [Route("{take}/example")]
        public IEnumerable<WeatherForecast> Get2([FromQuery] int max, [FromRoute] int take)
        {
            return this._weatherForecast.Get();
        }


        [HttpPost]
        public string Hello([FromBody] string Name)
        {
            return $"Hello {Name}";
        }




    }
}
