namespace Sirena.Airports;

/// <summary>
/// Интерфейс для вычисления расстояния между 2мя координатами
/// </summary>
public interface IDistanceCalculator
{
    /// <summary>
    /// Расчет расстояния между двумя точками в единицах измерения
    /// </summary>
    /// <param name="from">Точка от</param>
    /// <param name="to">Точка до</param>
    /// <param name="unit">Единица измерения. (По умолчанию - мили)</param>
    /// <returns>Значение расстояния в заданой единице измерения</returns>
    public double GetDistance(Location from, Location to, UnitEnumeration? unit = null);
}