using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sirena.Airports.Api.AirportService;
using Sirena.Airports.Api.Views;

namespace Sirena.Airports.Api;

public static class SirenaApi
{
    public static IEndpointRouteBuilder MapSirenaApi(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/", () => "yo, i'm sirena api");
        routeBuilder.MapGet("/distance", GetDistance);
        return routeBuilder;
    }

    public static async Task<Results<Ok<GetDistanceView>, NotFound>> GetDistance([FromQuery] string iataFrom, [FromQuery] string iataTo,
        [FromServices] IAirportService airportService, [FromServices]IDistanceCalculator distanceCalculator)
    {
        var airportFrom = await airportService.GetAirport(new GetAirportRequest(iataFrom));
        var airportTo = await airportService.GetAirport(new GetAirportRequest(iataTo));
        var from = new Location()
        {
            Latitude = airportFrom.Location.Latitude,
            Longitude = airportFrom.Location.Longitude
        };
        var to = new Location()
        {
            Latitude = airportFrom.Location.Latitude,
            Longitude = airportTo.Location.Longitude
        };
        var unit = UnitEnumeration.Miles;
        var distance = distanceCalculator.GetDistance(from, to, unit);

        return TypedResults.Ok(new GetDistanceView
        {
            IataFrom = airportFrom.Iata,
            NameFrom = airportFrom.Name,
            IataTo = airportTo.Iata,
            NameTo = airportTo.Name,
            Distance = distance,
            DistanceUnit = unit.Name
        });
    }
}

