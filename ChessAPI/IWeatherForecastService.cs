using System.Collections.Generic;

namespace ChessAPI
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
        IEnumerable<WeatherForecast> GetExtra(int resultCount, int minT, int maxT);
    }
}