using lab_10_v5_ClassLibrary;
using MyDCInputOutputConsole;
using System.Text.RegularExpressions;

namespace LibraryEmoji
{
    public class Emoji
    {
        protected const string ERROR_DIGIT_LONG_STRING = "Строка не удовлетворяет требованиям. Не вводите цифры и специальные символы";
        protected const string ERROR_NULL_WHITESPACE_STRING = "Строка не может быть нулевой или пустой, не может состоять только из пробелов";

        protected static readonly Random random = new();
        
        /// <summary>
        /// возможные названия для случайного выбора
        /// </summary>
        static readonly string[] names =
        [
            "радость", "злость", "печаль", "гнев", "страх",
            "ненависть", "любовь", "спокойствие"
        ];

        IdNumber _number;
        
        
        string? _name;
        /// <summary>
        /// Название эмодзи
        /// </summary>
        public string? Name 
        {
            get => _name; 
            set
            {
                if (IsCorrectString(value))
                    _name = value;
            }
        }

        /// <summary>
        /// Проверяет строку на удовлетворение требованиям
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns>true если строка подходит</returns>
        /// <exception cref="ArgumentNullException">Если строка null, пустая или стостоит только из пробелов</exception>
        /// <exception cref="ArgumentException">Если в строке есть числа или она состоит более чем из 2 элементов</exception>
        protected static bool IsCorrectString(string checkString)
        {
            if (string.IsNullOrWhiteSpace(checkString))
                throw new ArgumentNullException(ERROR_NULL_WHITESPACE_STRING);

            string[] words = checkString.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //hasSpecialChar &&= words.Length > 2;  спросить чё за жесть

            if (Regex.IsMatch(checkString, @"\d") || words.Length > 2)
                throw new ArgumentException(ERROR_DIGIT_LONG_STRING);

            return true;
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
                if (IsCorrectString(value))
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
            _number = new IdNumber();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="emojiNname"></param>
        /// <param name="emojiTag"></param>
        public Emoji(string emojiName, string emojiTag, int num)
        {
            Name = emojiName;
            Tag = emojiTag;
            _number = new IdNumber(num);
        }
        #endregion

        
        // TODO: переписать все икуалсы
        
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
