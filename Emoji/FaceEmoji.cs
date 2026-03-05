using lab_10_v5_ClassLibrary;
using MyDCInputOutputConsole;
using System;

namespace LibraryEmoji
{
    public class FaceEmoji :Emoji, IRandomInit
    {
        static readonly string[] expressions =
        [
            ":(", ":)", "^|0_0|^", "(0 + 0(", 
            "://", ";(", "?:", ":-(", ":-)", "(~` _ ~`(",
            "- _ -", "'_'"
        ];
        
        string? _expression;
        /// <summary>
        /// Лицо эмодзи
        /// </summary>
        public string? Expression
        {
            get => _expression;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ERROR_NULL_WHITESPACE_STRING);
                _expression = value;
            }
        }

        ushort _strength;
        /// <summary>
        /// Сила эмодзи
        /// </summary>
        public ushort Strength
        {
            get => _strength;
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0, "Сила лицевой эмодзи не может быть меньше 0");
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 10, "Сила лицевой эмодзи не может быть больше 10");

                _strength = value;
            }
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public FaceEmoji() :base()
        {
             Expression = "Нет выражения";
             Strength = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="expression">Выражение лица эмодзи</param>
        public FaceEmoji(int num)
        {
            Init();
            _number = new(num);
        }

        /// <summary>
        /// Конструктор со случайнми значениями
        /// </summary>
        /// <param name="rnd">Просто в виде маркера того, что нужны случайниые значения</param>
        public FaceEmoji(Random rnd) => RandomInit();
        #endregion

        /// <summary>
        /// Передаёт информацию об эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public override string VirtualShow() => ToString();

        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        public override bool Equals(object? obj)
        {
            return obj is FaceEmoji face &&
                   face.Strength == Strength &&
                   face.Expression == Expression &&
                   face.Name == Name &&
                   face.Tag == Tag &&
                   face._number.Equals(_number);
        }

        /// <summary>
        /// Инициализирует атрибуты
        /// </summary>
        protected override void Init()
        {
            base.Init();
            Output.Message("Введите выражение лица эмодзи", ConsoleColor.White);
            Expression = Input.Data();

            Strength = (ushort)Input.IntNumber("Введите силу эмодзи", "Вы не ввели целое число в разрешённом диапазоне");
        }

        /// <summary>
        /// Получает хеш-код
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        public override int GetHashCode() => base.GetHashCode() + Strength.GetHashCode() +
                                             Expression.GetHashCode();

        /// <summary>
        /// Инициализирует атрибуты случайными значениями
        /// </summary>
        public void RandomInit()
        {
            base.RandomInit();
            Expression = expressions[random.Next(0, expressions.Length)];
        }

        /// <summary>
        /// Возвращает общие данные всех классов(название и тег)
        /// </summary>
        /// <returns>Строка с данными</returns>
        public override string ToString() => $"Вид: {nameof(FaceEmoji)}. Выражение: {Expression}. Сила: {Strength}. Название: {Name}, тег: {Tag}"; // спросить куда и как это пристроить

        /// <summary>
        /// Возвращает данные объекта
        /// </summary>
        /// <returns></returns>
        public new string Show() => ToString();
    }
}
