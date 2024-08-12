namespace Sirena.Airports;

/// <summary>
/// Реализация калькулятора расстояния между 2мя координатами на основе формулы
/// </summary>
public class CustomDistanceCalculator : IDistanceCalculator
{
    private UnitValue _radiusEarth = new UnitValue(6371, UnitEnumeration.Kilometer);

    public double GetDistance(Location from, Location to, UnitEnumeration? unit = null)
    {
        var cosd = Math.Sin(ToRadian(from.Latitude)) * Math.Sin(ToRadian(to.Latitude)) + 
                   Math.Cos(ToRadian(from.Latitude)) * Math.Cos(ToRadian(to.Latitude)) * Math.Cos(ToRadian(to.Longitude - from.Longitude));
        var converter = new UnitConverter();
        var radius = converter.Convert(_radiusEarth.Unit, unit ?? UnitEnumeration.Miles, _radiusEarth.Value);
        var distance = radius * Math.Acos(cosd);
        return distance;
    }

    protected double ToRadian(double angle) => angle * (Math.PI / 180);
}