namespace Sirena.Airports;

/// <summary>
/// Значение в единице измерения
/// </summary>
public class UnitValue
{
    public UnitValue(double value, UnitEnumeration unit)
    {
        Value = value;
        Unit = unit;
    }
    public double Value { get; private set; }
    public UnitEnumeration Unit { get; private set; }
}