namespace lab_10_v5_ClassLibrary;

public class IdNumber
{
    private int _number;
    /// <summary>
    /// Номер
    /// </summary>
    public int Number
    {
        get => _number;
        set
        {
            if (value < 0)
                throw new ArgumentException("Номер не может быть меньше нуля");
            _number = value;
        }
    }

    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public IdNumber() => _number = 0; 
        
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    public IdNumber(int number) => Number = number;

    /// <summary>
    /// Сравнивает два номера
    /// </summary>
    /// <param name="obj">Потенциальный номер</param>
    /// <returns>true если равны</returns>
    public override bool Equals(object? obj) => obj is IdNumber num && Number == num.Number;
        
    /// <summary>
    /// Получает хеш-код объекта
    /// </summary>
    /// <returns>Значение хеш-кода</returns>
    public override int GetHashCode() => Number.GetHashCode();

    /// <summary>
    /// Переопределён
    /// </summary>
    /// <returns>Соответствующая строка</returns>
    public override string ToString() => $"Номер: {_number}";
}