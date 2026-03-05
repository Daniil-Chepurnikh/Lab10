using lab_10_v5_ClassLibrary;
using MyDCInputOutputConsole;
using System;

namespace LibraryEmoji
{
    /// <summary>
    /// Класс животных эмодзи
    /// </summary>
    public class AnimalEmoji : Emoji
    {
        /// <summary>
        /// возможные части тела животного для случайного выбора
        /// </summary>
        static readonly string[] animalParts =
        [
            "голова", "лапа", "хвост", "глаз", "ухо",
            "нос", "зубы", "шея", "коготь"
        ];

        string? _animalPart;
        /// <summary>
        /// Часть тела животного в эмодзи
        /// </summary>
        public string? AnimalPart 
        { 
            get => _animalPart; 
            set
            {
                 if (IsCorrectString(value))
                    _animalPart = value;
            }
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public AnimalEmoji() :base() => AnimalPart = "Часть тела";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="animalPart">Часть тела животного в эмодзи</param>
        public AnimalEmoji(int num)
        {
            Init();
            _number = new(num);
        }

        /// <summary>
        /// Конструктор со случайными значениями
        /// </summary>
        /// <param name="rnd">Просто в виде маркера того, что нужны случайные значения</param>
        public AnimalEmoji(Random rnd) => RandomInit();
        #endregion

        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        override public bool Equals(object? obj) => obj is AnimalEmoji an && SimpleEquals(an);

        /// <summary>
        /// Дополняет проверкой на равенство части животного
        /// </summary>
        /// <param name="other">Сравниваемый эмодзи</param>
        /// <returns>true, если равны</returns>
        override protected bool SimpleEquals(Emoji other) => base.SimpleEquals(other) && AnimalPart == ((AnimalEmoji)other).AnimalPart;   
        
        /// <summary>
        /// Передаёт информацию об эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        override public string VirtualShow() => ToString();

        /// <summary>
        /// Показывает данные эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        new public string Show() => ToString();

        /// <summary>
        /// Возвращает общие данные всех классов
        /// </summary>
        /// <returns>Строка с данными</returns>
        override public string ToString() => base.ToString() + $"Часть тела: {AnimalPart}.";

        /// <summary>
        /// Инициализирует атрибуты
        /// </summary>
        override protected void Init()
        {
            base.Init();
            Output.Message("Введите часть тела животного в эмодзи: ", ConsoleColor.White);
            AnimalPart = Input.Data();  
        }

        /// <summary>
        /// Получает хеш-код объекта
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        override public int GetHashCode() => base.GetHashCode() + AnimalPart.GetHashCode();

        /// <summary>
        /// Инициализирует атрибуты случайными значениями
        /// </summary>
        override public void RandomInit()
        {
            base.RandomInit();
            AnimalPart = animalParts[random.Next(0, animalParts.Length)];
        }

        /// <summary>
        /// Без комментариев
        /// </summary>
        /// <returns>Без комментариев</returns>
        // TODO: переделать по комментариям
        public static string SayRrroarrr(Emoji[] emos) => "~Rrroarrr~\n";


    }
}
