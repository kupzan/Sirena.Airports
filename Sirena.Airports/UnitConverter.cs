namespace Sirena.Airports;

/// <summary>
/// Конвертер единиц измерения
/// </summary>
public class UnitConverter
{
    private static Dictionary<UnitEnumeration, Dictionary<UnitEnumeration, Func<double, double>>> _convertFuncMap =
        new Dictionary<UnitEnumeration, Dictionary<UnitEnumeration, Func<double, double>>>()
        {
            {
                UnitEnumeration.Kilometer, new Dictionary<UnitEnumeration, Func<double, double>>()
                {
                    { UnitEnumeration.Miles, value => value / 1.609 },
                    { UnitEnumeration.Meter, value => value / 1000 },
                }
            },
            {
                UnitEnumeration.Miles, new Dictionary<UnitEnumeration, Func<double, double>>()
                {
                    { UnitEnumeration.Kilometer, value => value * 1.609 },
                    { UnitEnumeration.Meter, value => value * 1609 },
                }
            },
            {
                UnitEnumeration.Meter, new Dictionary<UnitEnumeration, Func<double, double>>()
                {
                    { UnitEnumeration.Miles, value => value / 1609 },
                    { UnitEnumeration.Kilometer, d => d * 1000 }
                }
            }
        };

    public double Convert(UnitEnumeration unitFrom, UnitEnumeration unitTo, double value) => unitFrom == unitTo ? value : _convertFuncMap[unitFrom][unitTo](value);
}