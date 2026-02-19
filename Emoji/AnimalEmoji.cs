using System;
using System.Runtime.InteropServices.JavaScript;

namespace LibraryEmoji
{
    internal class AnimalEmoji :Emoji
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
        public AnimalEmoji(AnimalEmoji source) :base(source)
        {
            if (source is not AnimalEmoji)
                throw new ArgumentException("Несоответствие типов");

            AnimalPart = source.AnimalPart;
        }

        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        public override bool Equals(object? obj)
        {
            return  obj is AnimalEmoji animal 
                    && base.Equals(obj) 
                    && animal.AnimalPart == animal.AnimalPart;
        }


    }
}
