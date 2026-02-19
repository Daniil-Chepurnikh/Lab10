using System;
using System.Runtime.InteropServices.JavaScript;

namespace LibraryEmoji
{
    internal class AnimalEmogi :Emoji
    {
        string animalPart;

        /// <summary>
        /// Часть тела животного в эмодзи
        /// </summary>
        public string AnimalPart 
        { 
            get => animalPart; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Часть тела животного не может быть пустой, состоять только из пробелов или нулевой");
            }
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public AnimalEmogi() :base() => AnimalPart = "Неопределённая часть тела";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="animalPart">Часть тела животного в эмодзи</param>
        public AnimalEmogi(string name, string tag, string animalPart) :base(name, tag) => AnimalPart = animalPart;

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="source">Копируемый эмодзи</param>
        public AnimalEmogi(AnimalEmogi source) :base(source)
        {
            if (source is not AnimalEmogi)
                throw new ArgumentException("Несоответствие типов");

            AnimalPart = source.AnimalPart;
        }
    }
}
