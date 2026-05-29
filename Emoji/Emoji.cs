using MyDCInputOutput;
using System.Text.RegularExpressions;

namespace LibraryEmoji
{
    /// <summary>
    /// Базовый класс библиотеки
    /// </summary>
    public class Emoji : IRandomInit, IComparable, ICloneable
    {
        /// <summary>
        /// Ошибка длины строки и наличия цифр
        /// </summary>
        protected const string ERROR_DIGIT_LONG_STRING = "Строка не удовлетворяет требованиям. Не вводите цифры";
        
        /// <summary>
        /// Ошибка нулевой или пустой/пробельной строки
        /// </summary>
        protected const string ERROR_NULL_WHITESPACE_STRING = "Строка не может быть нулевой или пустой, не может состоять только из пробелов";

        /// <summary>
        /// Номер эмодзи
        /// </summary>
        public IdNumber IdNumber { get; set; }

        /// <summary>
        /// возможные названия для случайного выбора
        /// </summary>
        public static readonly string[] names =
        [
            "радость", "злость", "печаль", "гнев", "страх",
            "ненависть", "любовь", "спокойствие", "тревога",
            "отчаяние", "депрессия", "страсть", "умиротворение",
            "отвращение", "скорбь", "пошлость", "разврат"
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
            "цветок", "деньги", "огонь", "птичка", "алкоголь",
            "солнце", "луна", "звёздочка", "дождь", "молния",
            "шарик", "азарт", "смерть"
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
        /// <param name="str">Проверяемая строка</param>
        /// <returns>true если строка подходит</returns>
        /// <exception cref="ArgumentNullException">Если строка null, пустая или стостоит только из пробелов</exception>
        /// <exception cref="ArgumentException">Если в строке есть числа или она состоит более чем из 2 элементов</exception>
        protected static bool IsCorrectString(string? str)
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
            IdNumber = new();
        }

        /// <summary>
        /// Конструктор инициализации из консоли
        /// </summary>
        /// <param name="id">Номер эмодзи</param>
        public Emoji(IdNumber id)
        {
            Init();
            IdNumber = id;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="id">Номер эмодзи</param>
        public Emoji(string name, string tag, IdNumber id)
        {
            Name = name;
            Tag = tag;
            IdNumber = id;
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
            return ReferenceEquals(obj, this) ||
                   (obj is Emoji other &&
                   SimpleEquals(other));
        }

        /// <summary>
        /// Проверяет равенство названия, тега и номера
        /// </summary>
        /// <param name="other">Сравниваемый эмодзи</param>
        /// <returns>true, равны</returns>
        virtual protected bool SimpleEquals(Emoji other)
        {
            return Name == other.Name &&
                   Tag == other.Tag &&
                   IdNumber.Equals(other.IdNumber);
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
        override public string ToString() => $"Вид: {GetType().Name}. Название: {Name}, тег: {Tag}. {IdNumber}";
        /* Сначала решил попробоавать просто геттайп, но печатало с библиотекой
         * это не мой Name а object*/

        /// <summary>
        /// Получает хеш-код
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        override public int GetHashCode() => HashCode.Combine(Name, Tag, IdNumber);

        /// <summary>
        /// Инициализирует атрибуты случайными значениями
        /// </summary>
        virtual public void RandomInit()
        {
            Name = names[IRandomInit.random.Next(names.Length)];
            Tag = tags[IRandomInit.random.Next(tags.Length)];
            IdNumber = new(IRandomInit.random.Next(111));
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

        /// <summary>
        /// Реализация интерфейса IClonable
        /// </summary>
        /// <returns>Ссылка на новый объект</returns>
        virtual public object Clone()
        {
            Emoji emo = (Emoji)MemberwiseClone();

            emo.IdNumber = new IdNumber(IdNumber.Number);

            return emo;
        }

        /// <summary>
        /// Создаёт поверхностную копию эмодзи
        /// </summary>
        /// <returns>Ссылка на копию</returns>
        public Emoji ShallowCopy() => (Emoji)MemberwiseClone();

        /// <summary>
        /// Оператор равенства
        /// </summary>
        /// <param name="a">Первый сравниваемый эмодзи</param>
        /// <param name="b">Второй сравниваемый эмодзи</param>
        /// <returns>true если равны, иначе false</returns>
        public static bool operator ==(Emoji a, Emoji b)
        {
            if (ReferenceEquals(a, b)) return true;   // оба null или один и тот же объект
            if (a is null || b is null) return false;  // один null, второй нет
            return a.Equals(b);
        }

        /// <summary>
        /// Оператор неравенства
        /// </summary>
        /// <param name="a">Первый сравниваемый эмодзи</param>
        /// <param name="b">Второй сравниваемый эмодзи</param>
        /// <returns>true если не равны, иначе false</returns>
        public static bool operator !=(Emoji a, Emoji b) => !(a == b);

        /// <summary>
        /// Оператор меньше
        /// </summary>
        /// <param name="a">Первый сравниваемый эмодзи</param>
        /// <param name="b">Второй сравниваемый эмодзи</param>
        /// <returns>true если первый меньше второго, иначе false</returns>
        public static bool operator <(Emoji a, Emoji b)
        {
            if (ReferenceEquals(a, b)) return false; // два null или один объект
            if (a is null) return true;   // null меньше любого не-null
            if (b is null) return false;  // любой не-null не меньше null
            return a.CompareTo(b) < 0;
        }

        /// <summary>
        /// Оператор больше
        /// </summary>
        /// <param name="a">Первый сравниваемый эмодзи</param>
        /// <param name="b">Второй сравниваемый эмодзи</param>
        /// <returns>true если первый больше второго, иначе false</returns>
        public static bool operator >(Emoji a, Emoji b)
        {
            if (ReferenceEquals(a, b)) return false;
            if (a is null) return false;
            if (b is null) return true;
            return a.CompareTo(b) > 0;
        }
    }
}
