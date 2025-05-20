namespace Restaurants.API.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
        IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature);
    }
}