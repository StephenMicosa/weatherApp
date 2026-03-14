namespace weatherApp.Backend.Models;

public sealed class CurrentWeather
{
    public string City { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public decimal TemperatureCelsius { get; init; }
    public int HumidityPercent { get; init; }
    public decimal WindSpeedMetersPerSecond { get; init; }
    public string Condition { get; init; } = string.Empty;
    public string IconCode { get; init; } = string.Empty;
}
