using MyDCInputOutput;

namespace LibraryEmoji;

/// <summary>
/// Класс улыбающихся эмодзи
/// </summary>
public class SmilingEmoji : FaceEmoji
{
    /// <summary>
    /// возможные причины улыбок для случайного выбора
    /// </summary>
    public static readonly string[] smileReasons =
    [
        "хорошая погода", "победа команды", "хорошее настроение",
        "вкусная еда", "весёлое видео", "выходные", "любимая музыка",
        "сарказм", "поражение противника", "встреча родственников",
        "переполнение эмоциями"
    ];

    private string? _smileReason;
    /// <summary>
    /// Причина улыбки
    /// </summary>
    public string? SmileReason
    {
        get => _smileReason;
        set
        {
            if (IsCorrectString(value))
            {
                _smileReason = value;
            }
        }
    }

    /// <summary>
    /// Возвращает объект базового класса
    /// </summary>
    public new FaceEmoji GetBase => new(Name, Tag, IdNumber, Expression, Strength);

    #region Конструкторы
    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public SmilingEmoji() : base()
    {
        SmileReason = "Просто улыбается";
    }

    /// <summary>
    /// Инициализация с клавиатуры
    /// </summary>
    /// <param name="id">Название эмодзи</param>
    public SmilingEmoji(IdNumber id)
    {
        Init();
        IdNumber = id;
    }

    /// <summary>
    /// Конструктор со случайнми значениями
    /// </summary>
    /// <param name="rnd">Просто маркер того, что нужны случайные значения</param>
    public SmilingEmoji(Random rnd)
    {
        RandomInit();
    }

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="name">Название жмодзи</param>
    /// <param name="tag">Тег эмодзи</param>
    /// <param name="expression">Выражение лица эмодзи</param>
    /// <param name="smileReason">Причина улыбки эмодзи</param>
    /// <param name="strength">Сила эмодзи</param>
    /// <param name="id">Номер эмодзи</param>
    public SmilingEmoji(string name, string tag, string expression, string smileReason, ushort strength, IdNumber id)
        : base(name, tag, id, expression, strength)
    {
        SmileReason = smileReason;
    }
    #endregion

    #region Всё для Equals
    /// <summary>
    /// Сравнивает объекты
    /// </summary>
    /// <param name="obj">Сравнивемый объект</param>
    /// <returns>true если равны</returns>
    public override bool Equals(object? obj)
    {
        return obj is SmilingEmoji smile && SimpleEquals(smile);
    }

    /// <summary>
    /// Дополняет проверкой на равенство причин улыбки
    /// </summary>
    /// <param name="other">Сравниваемый эмодзи</param>
    /// <returns>true, если равны</returns>
    protected override bool SimpleEquals(Emoji other)
    {
        return base.SimpleEquals(other) && SmileReason == ((SmilingEmoji)other).SmileReason;
    }
    #endregion

    /// <summary>
    /// Получает хеш-код
    /// </summary>
    /// <returns>Значение хеш-кода</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), SmileReason);
    }

    /// <summary>
    /// Инициализирует атрибуты
    /// </summary>
    protected override void Init()
    {
        base.Init();
        Output.Message("Введите причину улыбки эмодзи", ConsoleColor.White);
        SmileReason = Input.Data();
    }

    /// <summary>
    /// Инициализирует атрибуты случайными значениями
    /// </summary>
    public override void RandomInit()
    {
        base.RandomInit();
        SmileReason = smileReasons[IRandomInit.random.Next(smileReasons.Length)];
    }

    #region Show 
    /// <summary>
    /// Передаёт строку данных покемона
    /// </summary>
    /// <returns>Строка с данными</returns>
    public new string Show()
    {
        return ToString();
    }

    /// <summary>
    /// Передаёт инфорацию об эмодзи
    /// </summary>
    /// <returns>Строка с информацией</returns>
    public override string VirtualShow()
    {
        return ToString();
    }
    #endregion

    /// <summary>
    /// Возвращает общие данные всех классов(название и тег)
    /// </summary>
    /// <returns>Строка с данными</returns>
    public override string ToString()
    {
        return base.ToString() + $" Причина улыбки: {SmileReason}.";
    }

    /// <summary>
    /// Создайт клон улыбающейся эмодзи
    /// </summary>
    /// <returns>ссылка на кло</returns>
    public override object Clone()
    {
        SmilingEmoji smile = (SmilingEmoji)base.Clone();
        smile.SmileReason = this.SmileReason;

        return smile;
    }

    /// <summary>
    /// Создаёт поверхностную копию эмодзи
    /// </summary>
    /// <returns>Ссылка на копию</returns>
    public new SmilingEmoji ShallowCopy()
    {
        return (SmilingEmoji)MemberwiseClone();
    }

    /// <summary>
    /// Оператор равенства
    /// </summary>
    /// <param name="a">Первый сравниваемый эмодзи</param>
    /// <param name="b">Второй сравниваемый эмодзи</param>
    /// <returns>true если равны, иначе false</returns>
    public static bool operator ==(SmilingEmoji a, SmilingEmoji b)
    {
        return a.Equals(b);
    }

    /// <summary>
    /// Оператор неравенства
    /// </summary>
    /// <param name="a">Первый сравниваемый эмодзи</param>
    /// <param name="b">Второй сравниваемый эмодзи</param>
    /// <returns>true если не равны, иначе false</returns>
    public static bool operator !=(SmilingEmoji a, SmilingEmoji b)
    {
        return !a.Equals(b);
    }
}
