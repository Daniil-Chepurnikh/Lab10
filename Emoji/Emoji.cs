using MyDCInputOutputConsole;
using System.Data;
using System.Text.RegularExpressions;

namespace LibraryEmoji
{
    public class Emoji
    {
        protected const string ERROR_STRING = "Строка не удовлетворяет требованиям. Не вводите цифры и специальные символы";
        
        protected static readonly Random random = new();
        
        /// <summary>
        /// возможные названия для случайного выбора
        /// </summary>
        static readonly string[] names =
        [
            "радость", "злость", "печаль", "гнев", "страх",
            "ненависть", "любовь", "спокойствие"
        ];
        
        string? _name;
        /// <summary>
        /// Название эмодзи
        /// </summary>
        public string? Name 
        {
            get => _name; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не должно быть пустым или нулевым, состоять из пробелов");

                if (!IsCorrectString(value))
                    throw new ArgumentException(ERROR_STRING);

                _name = value;
            }
        }

        /// <summary>
        /// Проверяет строку на МОИ требования
        /// </summary>
        /// <param name="checkString">проверяемая строка</param>
        /// <returns>true если подходит</returns>
        protected static bool IsCorrectString(string checkString)
        {
            string[] words = checkString.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //hasSpecialChar &&= words.Length > 2;  Спросить чё за жесть

            return !Regex.IsMatch(checkString, @"\d") && words.Length <= 2;
        }

        /// <summary>
        /// возможные теги для случайного выбора
        /// </summary>
        static readonly string[] tags =
        [
            "улыбка", "слёзы", "мат", "поцелуй", "салют",
            "цветок", "деньги"
        ];

        string? _tag;
        /// <summary>
        /// Тег эмодзи
        /// </summary>
        public string? Tag 
        { 
            get => _tag;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Тег эмодзи не может быть пустым, состоять только из пробелов или нулевым");

                if (!IsCorrectString(value))
                    throw new ArgumentException(ERROR_STRING);

                _tag = value;
            }
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Emoji()
        {
            Name = "Без названия";
            Tag = "Без тега";
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="emojiNname"></param>
        /// <param name="emojiTag"></param>
        public Emoji(string emojiName, string emojiTag)
        {
            Name = emojiName;
            Tag = emojiTag;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="source">Копируемый эмодзи</param>
        public Emoji(Emoji source)
        {
            ArgumentNullException.ThrowIfNull(source, "Невозможно скопировать эмодзи по null");
            
            Name = source.Name;
            Tag = source.Tag;
        }
        #endregion

        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        public override bool Equals(object? obj)
        {
            return obj is Emoji emoji &&
                   Name == emoji.Name &&
                   Tag == emoji.Tag;
        }

        /// <summary>
        /// Показывает данные эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public virtual string VirtualShow() => $"Вид: {nameof(Emoji)}. " + ToString();

        /// <summary>
        /// Получает хеш-код
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        public override int GetHashCode() => Name.GetHashCode() + Tag.GetHashCode();

        /// <summary>
        /// Инициализирует атрибуты случайными значениями
        /// </summary>
        protected virtual void RandomInit()
        {
            Name = names[random.Next(0, names.Length)];
            Tag = tags[random.Next(0, tags.Length)];
        } // спросить куда и как это пристроить

        /// <summary>
        /// Инициализирует атрибуты
        /// </summary>
        protected virtual void Init()
        {
            Output.Message("Введите название эмодзи: ", ConsoleColor.White);
            Name = Input.Data();

            Output.Message("Введите тег эмодзи: ", ConsoleColor.White);
            Tag = Input.Data();
        }

        /// <summary>
        /// Возвращает общие данные всех классов(название и тег)
        /// </summary>
        /// <returns>Строка с данными</returns>
        public override string ToString() => $"Название: {Name}, тег: {Tag}\n"; // спросить куда и как это пристроить
    }
}
