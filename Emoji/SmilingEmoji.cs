using lab_10_v5_ClassLibrary;
using MyDCInputOutputConsole;
using System;
using System.Linq.Expressions;

namespace LibraryEmoji
{
    public class SmilingEmoji :Emoji, IRandomInit
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
        public override string VirtualShow() => ToString();

        /// <summary>
        /// Сравнивает объекты
        /// </summary>
        /// <param name="obj">Сравнивемый объект</param>
        /// <returns>true если равны</returns>
        public override bool Equals(object? obj)
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
        public void RandomInit()
        {
            base.RandomInit();
            SmileReason = smileReasons[random.Next(0, smileReasons.Length)];
        }

        /// <summary>
        /// Возвращает общие данные всех классов(название и тег)
        /// </summary>
        /// <returns>Строка с данными</returns>
        public override string ToString() => $"Вид: {nameof(SmilingEmoji)}. Причина улыбки: {SmileReason}. Название: {Name}, тег: {Tag}."; // спросить куда и как это пристроить

        public new string Show() => ToString();
    }
}
