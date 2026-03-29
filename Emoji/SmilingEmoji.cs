using MyDCInputOutputConsole;
using System;
using System.Linq.Expressions;

namespace LibraryEmoji
{
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

        string? _smileReason;
        /// <summary>
        /// Причина улыбки
        /// </summary>
        public string? SmileReason
        {
            get => _smileReason;
            set
            {
                if (IsCorrectString(value))
                    _smileReason = value;
            }
        }

        /// <summary>
        /// Возвращает объект базового класса
        /// </summary>
        public FaceEmoji GetBase
        {
            get => new FaceEmoji(Name, Tag, IdNumber, Expression, Strength);
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public SmilingEmoji() :base() => SmileReason = "Просто улыбается";

        /// <summary>
        /// Инициализация с клавиатуры
        /// </summary>
        /// <param name="num">Название эмодзи</param>
        public SmilingEmoji(IdNumber id)
        {
            Init();
            IdNumber = id;
        }

        /// <summary>
        /// Конструктор со случайнми значениями
        /// </summary>
        /// <param name="rnd">Просто маркер того, что нужны случайные значения</param>
        public SmilingEmoji(Random rnd) => RandomInit();

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название жмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="expression">Выражение лица эмодзи</param>
        /// <param name="smileReason">Причина улыбки эмодзи</param>
        /// <param name="strength">Сила эмодзи</param>
        /// <param name="num">Номер эмодзи</param>
        public SmilingEmoji(string name, string tag, string expression, string smileReason, ushort strength, IdNumber id)
            : base(name, tag, id, expression,  strength)
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
        override public bool Equals(object? obj) => obj is SmilingEmoji smile && SimpleEquals(smile);

        /// <summary>
        /// Дополняет проверкой на равенство причин улыбки
        /// </summary>
        /// <param name="other">Сравниваемый эмодзи</param>
        /// <returns>true, если равны</returns>
        override public bool SimpleEquals(Emoji other) => base.SimpleEquals(other) && SmileReason == ((SmilingEmoji)other).SmileReason;
        #endregion

        /// <summary>
        /// Получает хеш-код
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        override public int GetHashCode() => HashCode.Combine(base.GetHashCode(), SmileReason);

        /// <summary>
        /// Инициализирует атрибуты
        /// </summary>
        override protected void Init()
        {
            base.Init();
            Output.Message("Введите причину улыбки эмодзи", ConsoleColor.White);
            SmileReason = Input.Data();
        }

        /// <summary>
        /// Инициализирует атрибуты случайными значениями
        /// </summary>
        override public void RandomInit()
        {
            base.RandomInit();
            SmileReason = smileReasons[IRandomInit.random.Next(0, smileReasons.Length)];
        }

        #region Show 
        /// <summary>
        /// Передаёт строку данных покемона
        /// </summary>
        /// <returns>Строка с данными</returns>
        new public string Show() => ToString();

        /// <summary>
        /// Передаёт инфорацию об эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        override public string VirtualShow() => ToString();
        #endregion

        /// <summary>
        /// Возвращает общие данные всех классов(название и тег)
        /// </summary>
        /// <returns>Строка с данными</returns>
        override public string ToString() => base.ToString() + $" Причина улыбки: {SmileReason}.";

        /// <summary>
        /// Создайт клон улыбающейся эмодзи
        /// </summary>
        /// <returns>ссылка на кло</returns>
        override public object Clone()
        {
            SmilingEmoji smile = (SmilingEmoji)base.Clone();
            smile.SmileReason = this.SmileReason;

            return smile;
        }

        /// <summary>
        /// Создаёт поверхностную копию эмодзи
        /// </summary>
        /// <returns>Ссылка на копию</returns>
        new public SmilingEmoji ShallowCopy() => (SmilingEmoji)MemberwiseClone();
    }
}
