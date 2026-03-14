using weatherApp.Backend.Models;
using System.Text.Json;
using System.Drawing.Drawing2D;

namespace weatherApp.Backend.Services;

public sealed class GeocodingService
{

    /*
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _geoBaseUrl;

    public GeocodingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY") ?? string.Empty;
        _geoBaseUrl = Environment.GetEnvironmentVariable("OPENWEATHER_GEO_URL") ?? string.Empty;
    }


*/


    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _geoBaseUrl;

    public GeocodingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY") ?? string.Empty;
        _geoBaseUrl = Environment.GetEnvironmentVariable("OPENWEATHER_BASE_URL") ?? string.Empty;
    }
    public async Task<CityCoordinates?> GetCoordinatesByCityAsync(string city, CancellationToken cancellationToken = default)
    {

        string baseUrl = "";

        if (string.IsNullOrWhiteSpace(city) ||
            string.IsNullOrWhiteSpace(_apiKey) ||
            string.IsNullOrWhiteSpace(_geoBaseUrl))
        {
            return null;
        }

        baseUrl = $"{_geoBaseUrl}/geo/1.0/direct?q={Uri.EscapeDataString(city)}&limit=1&appid={_apiKey}";

        var response = await _httpClient.GetAsync(baseUrl, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var jsonStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var document = await JsonDocument.ParseAsync(jsonStream, cancellationToken: cancellationToken);

        if (document.RootElement.ValueKind != JsonValueKind.Array || document.RootElement.GetArrayLength() == 0)
        {
            return null;
        }

        var firstItem = document.RootElement[0];

        ///make a variable get the lat and lon from the json using getDouble method

        var lat = firstItem.GetProperty("lat").GetDouble();
        var lon = firstItem.GetProperty("lon").GetDouble();
        var name = firstItem.GetProperty("name").GetString() ?? city;
        var country = firstItem.GetProperty("country").GetString() ?? string.Empty;

        return new CityCoordinates
        {
            Name = name,
            Country = country,
            Latitude = lat,
            Longitude = lon
        };
    }
}
