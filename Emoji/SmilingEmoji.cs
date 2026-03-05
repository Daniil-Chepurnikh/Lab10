using MyDCInputOutputConsole;
using System;

namespace LibraryEmoji
{
    /// <summary>
    /// Класс улыбающихся эмодзи
    /// </summary>
    public class SmilingEmoji : Emoji
    {
        /// <summary>
        /// возможные причины улыбок для случайного выбора
        /// </summary>
        static readonly string[] smileReasons =
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

        /// <summary>
        /// Передаёт инфорацию об эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        override public string VirtualShow() => ToString();

        /// <summary>
        /// Сравнивает объекты
        /// </summary>
        /// <param name="obj">Сравнивемый объект</param>
        /// <returns>true если равны</returns>
        override public bool Equals(object? obj)
        {
            return obj is SmilingEmoji smile
                   && smile.SmileReason == SmileReason &&
                   smile.Name == Name &&
                   smile.Tag == Tag &&
                   smile._number.Equals(_number);
        }

        /// <summary>
        /// Получает хеш-код
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        override public int GetHashCode() => base.GetHashCode() + SmileReason.GetHashCode();

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

        /// <summary>
        /// Возвращает общие данные всех классов(название и тег)
        /// </summary>
        /// <returns>Строка с данными</returns>
        override public string ToString() => $"Вид: {nameof(SmilingEmoji)}. Причина улыбки: {SmileReason}. Название: {Name}, тег: {Tag}."; // спросить куда и как это пристроить

        /// <summary>
        /// Передаёт строку данных покемона
        /// </summary>
        /// <returns>Строка с данными</returns>
        new public string Show() => ToString();

        /// <summary>
        /// Возвращает длину причины улыбки, если возможно
        /// </summary>
        /// <param name="emoji">Эмодзи, длину причны улыбки которого мы хотим узнать</param>
        /// <returns>Длина причины улыбки</returns>
        /// <exception cref="ArgumentNullException">При передаче аргумента null</exception>
        public static int GetSmileReasonLength(SmilingEmoji? emoji)
        {
            return emoji is not null ? emoji.SmileReason.Length : throw new ArgumentNullException();
        }
    }
}
