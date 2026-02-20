using System;

namespace LibraryEmoji
{
    internal class SmilingEmoji :Emoji
    {
        string smileReason;
        /// <summary>
        /// Причина улыбки
        /// </summary>
        public string SmileReason
        {
            get => smileReason;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Причина улыбки не может быть пустой, состоять только из пробелов или нулевой");
                
                //TODO: придумать ограничения и их проверку

            }
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public SmilingEmoji() :base() => SmileReason = "Улыбается без причины, просто счастлив в жизни";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название эмодзи</param>
        /// <param name="tag">Тег эмодзи</param>
        /// <param name="smileReason">Причина улыбки</param>
        public SmilingEmoji(string name, string tag, string smileReason) : base(name, tag) => SmileReason = smileReason;

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="source">Копируемый эмодзи</param>
        public SmilingEmoji(SmilingEmoji source) : base(source) => SmileReason = source.SmileReason;
        #endregion

    }
}
