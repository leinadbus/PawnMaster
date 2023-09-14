using PawnMaster.API.ViewModels;

namespace PawnMaster.API.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetForecasts();
    }
}
