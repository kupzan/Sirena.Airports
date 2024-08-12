using Newtonsoft.Json;

namespace Sirena.Airports.Api.AirportService;

public class GetAirportResponse
{
    [JsonProperty("iata")]
    public string Iata { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("city")]
    public string City { get; set; }
    [JsonProperty("city_iata")]
    public string CityIata { get; set; }
    [JsonProperty("icao")]
    public string Icao { get; set; }
    [JsonProperty("country")]
    public string Country { get; set; }
    [JsonProperty("country_iata")]
    public string CountryIata { get; set; }
    [JsonProperty("rating")]
    public int Rating { get; set; }
    [JsonProperty("hubs")]
    public int Hubs { get; set; }
    [JsonProperty("timezone_region_name")]
    public string TimezoneRegionName { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("location")]
    public GetAirportLocationResponse Location { get; set; }
}

public class GetAirportLocationResponse
{
    [JsonProperty("lon")]
    public double Longitude { get; set; }
    [JsonProperty("lat")]
    public double Latitude { get; set; }
}

public class ErrorResponse
{
    public string ErrorMessage { get; set; }
}