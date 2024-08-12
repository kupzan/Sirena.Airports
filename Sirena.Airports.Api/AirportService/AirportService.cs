using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Sirena.Airports.Api.AirportService;

public class HttpAirportService : IAirportService
{
    private HttpClient _httpClient;
    private AirportClientOptions _clientOptions;

    public HttpAirportService(HttpClient httpClient, IOptions<AirportClientOptions> options)
    {
        _httpClient = httpClient;
        _clientOptions = options.Value;
    }
    public Task<GetAirportResponse> GetAirport(GetAirportRequest request) => MakeRequest<GetAirportRequest, GetAirportResponse>(request);

    public async Task<TResponse?> MakeRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IBaseHttpRequest
    {
        var url = $"{_clientOptions.ApiBaseUrl}/{request.Uri}";
        var requestMessage = new HttpRequestMessage(request.HttpMethod, url) { Content = request.ToHttpContent() };
        using var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
        var apiResponse = await JsonDeserializeRespone<TResponse>(response);
        return apiResponse;
    }

    private async Task<T?> JsonDeserializeRespone<T>(HttpResponseMessage response)
    {
        await using var contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        using var streamReader = new StreamReader(contentStream);
        using var jsonTextReader = new JsonTextReader(streamReader);

        var jsonSerializer = JsonSerializer.CreateDefault();
        var content = jsonSerializer.Deserialize<T>(jsonTextReader);
        return content;
    }
}