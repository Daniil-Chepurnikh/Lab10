namespace LibraryEmoji
{
    public class Emoji
    {
        string name;
        /// <summary>
        /// Название эмодзи
        /// </summary>
        public string Name 
        {
            get => name; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название эмодзи не может быть пустым, состоять из пробелов или нулевым");

                // TODO: Добавить проверку на не содержательную строку(пробельные символы и знаки препинания без нормальных слов

                name = value;
            }
        }

        string tag;
        /// <summary>
        /// Тег эмодзи
        /// </summary>
        public string Tag 
        { 
            get => tag;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Тег эмодзи не может быть пустым, состоять только из пробелов или нулевым");

                // TODO: Добавить проверку на знаки препинания без нормальных слов

                tag = value;
            }
        }

        // TODO: Добавить проверку на знаки препинания без нормальных слов

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Emoji()
        {
            Name = "Без имени";
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
            ArgumentNullException.ThrowIfNull(source); // TODO: узнать в чём разница между этим вариантом и отвёрткой
            
            Name = source.Name;
            Tag = source.Tag;
        }

        /// <summary>
        /// Сранивает объекты
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если равны</returns>
        public override bool Equals(object? obj)
        {
            return  obj is Emoji emoji 
                    && Name == emoji.Name
                    && Tag == emoji.Tag;
        }

        /// <summary>
        /// Показывает данные эмодзи
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public virtual string VirtualShow() => $"Имя эмодзи: {Name}, тег: {Tag}\n";

        // TODO: Добавить метод рандомной инициализации эмодзи RandomInit

        // TODO: Добавить метод самостоятельной инициализации эмодзи Init
    }
}
