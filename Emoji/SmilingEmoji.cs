using MyDCInputOutputConsole;
using System;
using System.Linq.Expressions;

namespace LibraryEmoji
{
    public class SmilingEmoji :Emoji
    {
        /// <summary>
        /// возможные причины улыбок для случайного выбора
        /// </summary>
        static readonly string[] smileReasons =
        [
            "хорошая погода", "победа команды", "хорошее настроение",
            "вкусная еда", "весёлое видео", "выходные"
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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Причина улыбки не может быть пустой, состоять только из пробелов или нулевой");

                if (!IsCorrectString(value))
                    throw new ArgumentException(ERROR_STRING);

                _smileReason = value;
            }
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public SmilingEmoji() :base() => SmileReason = "Улыбается без причины, просто счастлив в жизни";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="smileReason">Причина улыбки</param>
        public SmilingEmoji(string name, string tag, string smileReason) : base(name, tag) => SmileReason = smileReason;

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="source">Копируемый эмодзи</param>
        public SmilingEmoji(SmilingEmoji source) : base(source) => SmileReason = source.SmileReason;
        #endregion

        /// <summary>
        /// Передаёт инфорацию об эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public override string VirtualShow() => $"Причина улыбки: {SmileReason}. {base.ToString()}";

        /// <summary>
        /// Сравнивает объекты
        /// </summary>
        /// <param name="obj">Сравнивемый объект</param>
        /// <returns>true если равны</returns>
        public override bool Equals(object? obj)
        {
            return obj is SmilingEmoji smile
                   && smile.SmileReason == SmileReason
                   && base.Equals(obj);
        }

        /// <summary>
        /// Получает хеш-код
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        public override int GetHashCode() => base.GetHashCode() + SmileReason.GetHashCode();

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
        protected override void RandomInit()
        {
            RandomInit();
            SmileReason = smileReasons[random.Next(0, smileReasons.Length)];
        }
    }
}
