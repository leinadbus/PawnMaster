using Microsoft.AspNetCore.Mvc;
using PawnMaster.API.Services;
using PawnMaster.API.ViewModels;

namespace PawnMaster.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _service = weatherForecastService;
        }

        [HttpGet("loquequiera",Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Bkla");
            return _service.GetForecasts();
           
        }


    }
}