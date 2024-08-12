using GeoCoordinatePortable;

namespace Sirena.Airports;

/// <summary>
/// Реализация калькулятора расстояния с использованием библиотеки из для NetCore. (перенос System.Device.Location.GeoCoordinate)
/// </summary>
public class NetDistanceCalculator : IDistanceCalculator
{
    public double GetDistance(Location from, Location to, UnitEnumeration? unit = null)
    {
        var geoFrom = new GeoCoordinate(from.Latitude, from.Longitude);
        var geoTo = new GeoCoordinate(to.Latitude, to.Longitude);
        var converter = new UnitConverter();
        return converter.Convert(UnitEnumeration.Meter, unit ?? UnitEnumeration.Miles, geoFrom.GetDistanceTo(geoTo));
    }
}