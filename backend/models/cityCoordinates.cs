namespace weatherApp.Backend.Models;

public sealed class CityCoordinates
{
    public string Name { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    
}
