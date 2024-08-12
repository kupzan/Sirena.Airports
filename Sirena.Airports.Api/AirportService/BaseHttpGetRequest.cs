namespace Sirena.Airports.Api.AirportService;

public abstract class BaseHttpGetRequest : IBaseHttpRequest
{
    public abstract string Uri { get; }
    public HttpMethod HttpMethod => HttpMethod.Get;
    public virtual HttpContent? ToHttpContent() => null;
}