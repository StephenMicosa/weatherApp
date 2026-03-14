using weatherApp.Backend.Models;

namespace weatherApp.Backend.Services;

public sealed class WeatherFacadeService
{
    private readonly GeocodingService _geocodingService;
    private readonly WeatherService _weatherService;

    public WeatherFacadeService(GeocodingService geocodingService, WeatherService weatherService)
    {
        _geocodingService = geocodingService;
        _weatherService = weatherService;
    }

    public async Task<CurrentWeather?> GetCurrentByCityAsync(string city, CancellationToken cancellationToken = default)
    {
        var coordinates = await _geocodingService.GetCoordinatesByCityAsync(city, cancellationToken);
        if (coordinates is null)
        {
            return null;
        }

        return await _weatherService.GetCurrentWeatherAsync(coordinates.Latitude, coordinates.Longitude, cancellationToken);
    }

    public async Task<IReadOnlyList<ForecastItem>> GetForecastByCityAsync(string city, CancellationToken cancellationToken = default)
    {
        var coordinates = await _geocodingService.GetCoordinatesByCityAsync(city, cancellationToken);
        if (coordinates is null)
        {
            return [];
        }

        return await _weatherService.GetForecastAsync(coordinates.Latitude, coordinates.Longitude, cancellationToken);
    }
}
