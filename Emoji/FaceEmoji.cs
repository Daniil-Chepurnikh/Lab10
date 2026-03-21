using MyDCInputOutputConsole;
using System;

namespace LibraryEmoji
{
    /// <summary>
    /// Класс лицевых эмодзи
    /// </summary>
    public class FaceEmoji : Emoji
    {
        static readonly string[] expressions =
        [
            ":(", ":)", "^|0_0|^", "(0 + 0(", 
            "://", ";(", ";)", "?:", ":-(", ":-)", "(~` _ ~`(",
            "- _ -", "'_'", "|$_$|", "<|0,0|>", @"_/(0 - 0(\_"
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
        /// Инициализация с клавиатуры
        /// </summary>
        /// <param name="num">Номер эмодзи</param>
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

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="expression">Выражение лица эмодзи</param>
        /// <param name="strength">Сила эмодзи</param>
        /// <param name="num">Номер эмодзи</param>
        public FaceEmoji(string name, string tag, string expression, ushort strength, int num) : base(name, tag, num)
        {
            Expression = expression;
            Strength = strength;
        }
        #endregion

        #region Show
        /// <summary>
        /// Передаёт информацию об эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public override string VirtualShow() => ToString();

        /// <summary>
        /// Возвращает данные объекта
        /// </summary>
        /// <returns></returns>
        public new string Show() => ToString();
        #endregion

        /// <summary>
        /// Возвращает общие данные всех классов(название и тег)
        /// </summary>
        /// <returns>Строка с данными</returns>
        public override string ToString() => base.ToString() + $"Выражение: {Expression}. Сила: {Strength}. ";

        #region Всё для Equals
        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        override public bool Equals(object? obj) => obj is FaceEmoji f && SimpleEquals(f);

        /// <summary>
        /// Дополнительно проверяет равенство силы и выражения
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true, если равны</returns>
        override public bool SimpleEquals(Emoji other)
        {
            return base.SimpleEquals(other) &&
                   Strength == ((FaceEmoji)other).Strength &&
                   Expression == ((FaceEmoji)other).Expression;
        }
        #endregion

        /// <summary>
        /// Инициализирует атрибуты
        /// </summary>
        override protected void Init()
        {
            base.Init();
            Output.Message("Введите выражение лица эмодзи", ConsoleColor.White);
            Expression = Input.Data();

            Strength = (ushort)Input.IntNumber("Введите силу эмодзи", "Вы не ввели целое число в разрешённом диапазоне");
        }

        /// <summary>
        /// Инициализирует атрибуты случайными значениями
        /// </summary>
        override public void RandomInit()
        {
            base.RandomInit();
            Expression = expressions[random.Next(0, expressions.Length)];
            Strength = (ushort)random.Next(10);
        }

        /// <summary>
        /// Получает хеш-код
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode, Strength, Expression);

        override public object Clone()
        {
            FaceEmoji face = (FaceEmoji)base.Clone();
            face.Strength = Strength;
            face.Expression = Expression;

            return face;
        }
    }
}
