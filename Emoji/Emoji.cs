using MyDCInputOutputConsole;
using System.Text.RegularExpressions;

namespace LibraryEmoji
{
    /// <summary>
    /// Базовый класс библиотеки
    /// </summary>
    public class Emoji : IRandomInit, IComparable
    {
        protected const string ERROR_DIGIT_LONG_STRING = "Строка не удовлетворяет требованиям. Не вводите цифры";
        protected const string ERROR_NULL_WHITESPACE_STRING = "Строка не может быть нулевой или пустой, не может состоять только из пробелов";

        /// <summary>
        /// Генератор случайных чисел для RandomInit
        /// </summary>
        protected static readonly Random random = new();

        public IdNumber _number;

        /// <summary>
        /// возможные названия для случайного выбора
        /// </summary>
        public static readonly string[] names =
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
                if (IsCorrectString(value))
                    _name = value;
            }
        }

        /// <summary>
        /// возможные теги для случайного выбора
        /// </summary>
        public static readonly string[] tags =
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

        /// <summary>
        /// Проверяет строку на удовлетворение требованиям
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns>true если строка подходит</returns>
        /// <exception cref="ArgumentNullException">Если строка null, пустая или стостоит только из пробелов</exception>
        /// <exception cref="ArgumentException">Если в строке есть числа или она состоит более чем из 2 элементов</exception>
        protected static bool IsCorrectString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(ERROR_NULL_WHITESPACE_STRING);

            string checkString = str.Replace("\t", " ");

            string[] words = checkString.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (Regex.IsMatch(checkString, @"\d") || words.Length > 2)
                throw new ArgumentException(ERROR_DIGIT_LONG_STRING);

            return true;
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Emoji()
        {
            Name = "Без названия";
            Tag = "Без тега";
            _number = new();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="emojiNname"></param>
        /// <param name="emojiTag"></param>
        public Emoji(int num)
        {
            Init();
            _number = new(num);
        }

        /// <summary>
        /// Конструктор со случайнми значениями
        /// </summary>
        /// <param name="rnd">Просто в виде маркера того, что нужны случайниые значения</param>
        public Emoji(Random rnd) => RandomInit();
        #endregion

        #region Всё для Equals
        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        override public bool Equals(object? obj)
        {
            return obj is Emoji other &&
            SimpleEquals(other);
        }

        /// <summary>
        /// Проверяет равенство названия, тега и номера
        /// </summary>
        /// <param name="other">Сравниваемый эмодзи</param>
        /// <returns>true, равны</returns>
        virtual public bool SimpleEquals(Emoji other)
        {
            return Name == other.Name &&
                   Tag == other.Tag &&
                   _number.Equals(other._number);
        }
        #endregion

        #region Show
        /// <summary>
        /// Показывает данные эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        virtual public string VirtualShow() => ToString();

        /// <summary>
        /// Показывает данные эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public string Show() => ToString();
        #endregion

        /// <summary>
        /// Возвращает общие данные всех классов(название и тег)
        /// </summary>
        /// <returns>Строка с данными</returns>
        override public string ToString() => $"Вид: {GetType().Name}. Название: {Name}, тег: {Tag}. ";
        /* Сначала решил попробоавать просто геттайп, но печатало с библиотекой
         * это не мой Name а object*/

        /// <summary>
        /// Получает хеш-код
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        override public int GetHashCode() => HashCode.Combine(Name, Tag, _number);

        /// <summary>
        /// Инициализирует атрибуты случайными значениями
        /// </summary>
        virtual public void RandomInit()
        {
            Name = names[random.Next(0, names.Length)];
            Tag = tags[random.Next(0, tags.Length)];
            _number = new(random.Next(0, 111));
        }

        /// <summary>
        /// Инициализирует атрибуты
        /// </summary>
        virtual protected void Init()
        {
            Output.Message("Введите название эмодзи: ", ConsoleColor.White);
            Name = Input.Data();

            Output.Message("Введите тег эмодзи: ", ConsoleColor.White);
            Tag = Input.Data();
        }

        /// <summary>
        /// Реализация интерфейса IComparable
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>
        /// "-число" если меньше
        /// "+число" если больше
        /// "0" если равны
        /// </returns>
        virtual public int CompareTo(object? obj)
        {
            Emoji other = obj as Emoji;
            ArgumentNullException.ThrowIfNull(other);

            int result = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
            
            if (result != 0)
                return result;
            else
                return string.Compare(Tag, other.Tag, StringComparison.OrdinalIgnoreCase);
        }
    }
}
