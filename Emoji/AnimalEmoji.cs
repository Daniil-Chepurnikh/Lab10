using MyDCInputOutput;

namespace LibraryEmoji;

/// <summary>
/// Класс животных эмодзи
/// </summary>
public class AnimalEmoji : Emoji
{
    /// <summary>
    /// возможные части тела животного для случайного выбора
    /// </summary>
    public static readonly string[] animalParts =
    [
        "голова", "лапа", "хвост", "глаз", "ухо",
        "нос", "зубы", "шея", "коготь", "рога"
    ];

    private string? _animalPart;
    /// <summary>
    /// Часть тела животного в эмодзи
    /// </summary>
    public string? AnimalPart
    {
        get => _animalPart;
        set
        {
            if (IsCorrectString(value))
            {
                _animalPart = value;
            }
        }
    }

    /// <summary>
    /// Возвращает объект базового класса
    /// </summary>
    public Emoji GetBase => new(Name, Tag, IdNumber);

    #region Конструкторы
    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public AnimalEmoji() : base()
    {
        AnimalPart = "Часть тела";
    }

    /// <summary>
    /// Инициализация с клавиатуры
    /// </summary>
    /// <param name="id">Номер эмодзи</param>
    public AnimalEmoji(IdNumber id)
    {
        Init();
        IdNumber = id;
    }

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="name">Название эмодзи</param>
    /// <param name="tag">Тег эмодзи</param>
    /// <param name="animalPart">Часть животного в эмодзи</param>
    /// <param name="id">Номер эмодзи</param>
    public AnimalEmoji(string name, string tag, IdNumber id, string animalPart) : base(name, tag, id)
    {
        AnimalPart = animalPart;
    }

    /// <summary>
    /// Конструктор со случайными значениями
    /// </summary>
    /// <param name="rnd">Просто в виде маркера того, что нужны случайные значения</param>
    public AnimalEmoji(Random rnd)
    {
        RandomInit();
    }
    #endregion

    #region Всё для Equals
    /// <summary>
    /// Сранивает объекты
    /// </summary>
    /// <param name="obj">Сравниваемый объект</param>
    /// <returns>true если равны</returns>
    public override bool Equals(object? obj)
    {
        return obj is AnimalEmoji an && SimpleEquals(an);
    }

    /// <summary>
    /// Дополняет проверкой на равенство части животного
    /// </summary>
    /// <param name="other">Сравниваемый эмодзи</param>
    /// <returns>true, если равны</returns>
    protected override bool SimpleEquals(Emoji other)
    {
        return base.SimpleEquals(other) && AnimalPart == ((AnimalEmoji)other).AnimalPart;
    }
    #endregion

    #region Show
    /// <summary>
    /// Передаёт информацию об эмодзи
    /// </summary>
    /// <returns>Строка с информацией</returns>
    public override string VirtualShow()
    {
        return ToString();
    }

    /// <summary>
    /// Показывает данные эмодзи
    /// </summary>
    /// <returns>Строка с информацией</returns>
    public new string Show()
    {
        return ToString();
    }
    #endregion

    /// <summary>
    /// Возвращает общие данные всех классов
    /// </summary>
    /// <returns>Строка с данными</returns>
    public override string ToString()
    {
        return base.ToString() + $" Часть тела: {AnimalPart}.";
    }

    /// <summary>
    /// Инициализирует атрибуты
    /// </summary>
    protected override void Init()
    {
        base.Init();
        Output.Message("Введите часть тела животного в эмодзи: ", ConsoleColor.White);
        AnimalPart = Input.Data();
    }

    /// <summary>
    /// Получает хеш-код объекта
    /// </summary>
    /// <returns>Значение хеш-кода</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), AnimalPart);
    }

    /// <summary>
    /// Инициализирует атрибуты случайными значениями
    /// </summary>
    public override void RandomInit()
    {
        base.RandomInit();
        AnimalPart = animalParts[IRandomInit.random.Next(animalParts.Length)];
    }

    /// <summary>
    /// Клонирует животное эмодзи
    /// </summary>
    /// <returns></returns>
    public override object Clone()
    {
        AnimalEmoji an = (AnimalEmoji)base.Clone();
        an.AnimalPart = this.AnimalPart;

        return an;
    }

    /// <summary>
    /// Создаёт поверхностную копию эмодзи
    /// </summary>
    /// <returns>Ссылка на копию</returns>
    public new AnimalEmoji ShallowCopy()
    {
        return (AnimalEmoji)MemberwiseClone();
    }

    /// <summary>
    /// Оператор равенства
    /// </summary>
    /// <param name="a">Первый сравниваемый эмодзи</param>
    /// <param name="b">Второй сравниваемый эмодзи</param>
    /// <returns>true если равны, иначе false</returns>
    public static bool operator ==(AnimalEmoji a, AnimalEmoji b)
    {
        return a.Equals(b);
    }

    /// <summary>
    /// Оператор неравенства
    /// </summary>
    /// <param name="a">Первый сравниваемый эмодзи</param>
    /// <param name="b">Второй сравниваемый эмодзи</param>
    /// <returns>true если не равны, иначе false</returns>
    public static bool operator !=(AnimalEmoji a, AnimalEmoji b)
    {
        return !a.Equals(b);
    }
}
