namespace weatherApp.Backend.Models;

public sealed class ForecastItem
{
    public DateTime ForecastAt { get; init; }
    public decimal TemperatureCelsius { get; init; }
    public int HumidityPercent { get; init; }
    public string Condition { get; init; } = string.Empty;
    public string IconCode { get; init; } = string.Empty;
}
