using Sirena.Airports.Api.AirportService;

namespace Sirena.Airports.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddHttpClient();
            builder.Services.AddOptions<AirportClientOptions>().BindConfiguration(nameof(AirportClientOptions));
            builder.Services.AddTransient<IAirportService, HttpAirportService>();
            builder.Services.AddTransient<IDistanceCalculator, CustomDistanceCalculator>();

            var app = builder.Build();
            
            app.MapGroup("/v1").MapSirenaApi();
            app.Run();
        }
    }
}
