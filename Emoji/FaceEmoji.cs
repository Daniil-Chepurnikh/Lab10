using MyDCInputOutputConsole;
using System;

namespace LibraryEmoji
{
    internal class FaceEmoji :Emoji
    {
        static readonly string[] expressions =
        [
            ":(", ":)", "^|0_0|^", "(0 + 0(", 
            "://", ";(", "?:", ":-(", ":-)", "(~` _ ~`(",
            "- _ -", "'_'"
        ];
        
        string? expression;
        /// <summary>
        /// Лицо эмодзи
        /// </summary>
        public string? Expression
        {
            get => expression;
            set
            {
                if (!CheckExpression(expression))
                    throw new ArgumentException("Введённый набор символов не является допустимой комбинацией");
                expression = value;
            }
        }

        /// <summary>
        /// Проверяет введённый набор символов на совпадение с допустимым лицом
        /// </summary>
        /// <param name="newFace">Проверяемый набор символов</param>
        /// <returns>true если символы совпали</returns>
        bool CheckExpression(string newExpression)
        {
            var isCorrectFace = false;

            foreach (string p in expressions)
            {
                if (p == newExpression)
                {
                    isCorrectFace = true;
                    break;
                }
            }
            return isCorrectFace;
        }

        ushort strength;
        /// <summary>
        /// Сила эмодзи
        /// </summary>
        public ushort Strength
        {
            get => strength;
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0, "Сила лицевой эмодзи не может быть меньше 0");

                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 10, "Сила лицевой эмодзи не может быть больше 10");

                strength = value;
            }
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public FaceEmoji() :base() => Expression = "Нет выражения лица";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="expression">Выражение лица эмодзи</param>
        public FaceEmoji(string name, string tag, string expression) :base(name, tag) => Expression = expression;

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="source">Копируемый эмодзи</param>
        public FaceEmoji(FaceEmoji source) : base(source) => Expression = source.Expression;
        #endregion

        /// <summary>
        /// Передаёт информацию об эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public override string VirtualShow() => $"Выражение: {Expression}. Сила: {Strength}. {base.ToString()}";

        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        public override bool Equals(object? obj)
        {
            return obj is FaceEmoji face
                   && face.Strength == Strength
                   && face.Expression == Expression
                   && base.Equals(obj);
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

        // TODO: доопределить RandomInit
    }
}
