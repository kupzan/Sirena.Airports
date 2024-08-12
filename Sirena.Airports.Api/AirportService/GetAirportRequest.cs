namespace Sirena.Airports.Api.AirportService;

public class GetAirportRequest : IBaseHttpRequest
{
    public GetAirportRequest(string iata)
    {
        Iata = iata;
    }

    public string Iata { get; private set; }

    public string Uri => $"airports/{Iata.ToUpper()}";

    public HttpMethod HttpMethod => HttpMethod.Get;
    public HttpContent? ToHttpContent() => null;
}