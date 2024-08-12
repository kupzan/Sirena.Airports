namespace Sirena.Airports.Api.Views
{
    /// <summary>
    /// DTO для ответа на запрос о расстоянии между точками
    /// </summary>
    public class GetDistanceView
    {
        public string IataFrom { get; set; }
        public string NameFrom { get; set; }

        public string IataTo { get; set; }
        public string NameTo { get; set; }

        public double Distance { get; set; }
        public string DistanceUnit { get; set; }
    }
}
