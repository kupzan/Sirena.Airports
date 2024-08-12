namespace Sirena.Airports.Api.AirportService;

/// <summary>
/// Интерфейс службы с информацией об аэропортах
/// </summary>
public interface IAirportService
{
    public Task<GetAirportResponse> GetAirport(GetAirportRequest request);
}