using MyDCInputOutputConsole;
using System;

namespace LibraryEmoji
{
    public class AnimalEmoji :Emoji
    {
        // TODO: придумать массивчик возможных частей тел


        string? animalPart;
        /// <summary>
        /// Часть тела животного в эмодзи
        /// </summary>
        public string? AnimalPart 
        { 
            get => animalPart; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Часть тела животного не может быть пустой, состоять только из пробелов или нулевой");

                animalPart = value;
            }
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public AnimalEmoji() :base() => AnimalPart = "Неопределённая часть тела";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="animalPart">Часть тела животного в эмодзи</param>
        public AnimalEmoji(string name, string tag, string animalPart) :base(name, tag) => AnimalPart = animalPart;

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="source">Копируемый эмодзи</param>
        public AnimalEmoji(AnimalEmoji source) :base(source) => AnimalPart = source.AnimalPart;
        #endregion

        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        public override bool Equals(object? obj)
        {
            return obj is AnimalEmoji animal 
                   && animal.AnimalPart == AnimalPart
                   && base.Equals(obj);
        }

        /// <summary>
        /// Передаёт информацию об эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public override string VirtualShow() => $"Вид: {nameof(AnimalEmoji)}. Часть тела: {AnimalPart}. {base.ToString()}";

        /// <summary>
        /// Инициализирует атрибуты
        /// </summary>
        protected override void Init()
        {
            base.Init();

            Output.Message("Введите часть тела животного в эмодзи", ConsoleColor.White);
            AnimalPart = Input.Data();  
        }

        /// <summary>
        /// Получает хеш-код объекта
        /// </summary>
        /// <returns>Значение хеш-кода</returns>
        public override int GetHashCode() => base.GetHashCode() + AnimalPart.GetHashCode();
    }
}
