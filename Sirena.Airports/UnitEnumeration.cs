namespace Sirena.Airports;

/// <summary>
/// Единицы измерения. При добавлении новой единицы, необходимо добавить соответствующие функции преобразования в конвертер
/// <see cref="UnitConverter"/>
/// </summary>
public class UnitEnumeration : Enumeration
{
    public static UnitEnumeration Kilometer = new UnitEnumeration(1, "Километр");
    public static UnitEnumeration Miles = new UnitEnumeration(2, "Мили");
    public static UnitEnumeration Meter = new UnitEnumeration(3, "Mетр");

    public UnitEnumeration(int id, string name) : base(id, name)
    {
    }
}