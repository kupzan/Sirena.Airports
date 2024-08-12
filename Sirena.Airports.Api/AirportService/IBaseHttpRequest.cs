namespace Sirena.Airports.Api.AirportService;

public interface IBaseHttpRequest
{
    public string Uri { get; }
    public HttpMethod HttpMethod { get; }
    public HttpContent? ToHttpContent();
}