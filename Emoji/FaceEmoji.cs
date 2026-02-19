using System;
using System.Globalization;
using System.Reflection.PortableExecutable;

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
        
        string expression;
        /// <summary>
        /// Лицо эмодзи
        /// </summary>
        public string Expression
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

        // TODO: доопределить VirtualShow

        // TODO: написать Equals

    }
}
