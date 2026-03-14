using weatherApp.Backend.Models;

namespace weatherApp.Backend.Services;

public sealed class WeatherService
{
    private readonly string _apiKey;
    private readonly string _weatherUrl;


    public WeatherService()
    {
        _apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY") ?? string.Empty;
        _weatherUrl = Environment.GetEnvironmentVariable("OPENWEATHER_BASE_URL") ?? string.Empty;

    }
    public async Task<CurrentWeather?> GetCurrentWeatherAsync(double latitude, double longitude, CancellationToken cancellationToken = default)
    {

        string baseWeatherUrl = "";

        baseWeatherUrl = $"{baseWeatherUrl}/data/2.5/weather?$lat={latitude}&lon={longitude}&appid={_apiKey}";

        return null;
    }

    public Task<IReadOnlyList<ForecastItem>> GetForecastAsync(double latitude, double longitude, CancellationToken cancellationToken = default)
    {
        // TODO: Implement OpenWeather forecast call.
        IReadOnlyList<ForecastItem> result = [];
        return Task.FromResult(result);
    }
}
