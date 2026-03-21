using MyDCInputOutputConsole;
using System;

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

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public SmilingEmoji() :base() => SmileReason = "Просто улыбается";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="smileReason">Причина улыбки</param>
        public SmilingEmoji(int num)
        {
            Init();
            _number = new(num);
        }

        /// <summary>
        /// Конструктор со случайнми значениями
        /// </summary>
        /// <param name="rnd">Просто в виде маркера того, что нужны случайниые значения</param>
        public SmilingEmoji(Random rnd) => RandomInit();
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
            SmileReason = smileReasons[random.Next(0, smileReasons.Length)];
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

        override public object Clone()
        {
            SmilingEmoji smile = (SmilingEmoji)base.Clone();
            smile.Strength = Strength;
            smile.Expression = Expression;

            return smile;
        }
    }
}
