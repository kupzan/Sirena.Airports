namespace Sirena.Airports.Api.AirportService;

/// <summary>
/// ��������� ������ � ����������� �� ����������
/// </summary>
public interface IAirportService
{
    public Task<GetAirportResponse> GetAirport(GetAirportRequest request);
}