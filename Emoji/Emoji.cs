namespace LibraryEmoji
{
    public class Emoji
    {
        string name;
        /// <summary>
        /// Название эмодзи
        /// </summary>
        public string Name { get; set; }

        string tag;
        /// <summary>
        /// Тег эмодзи
        /// </summary>
        public string Tag { get; private set; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Emoji()
        {
            Name = "No name";
            Tag = "No name";
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="emojiNname"></param>
        /// <param name="emojiTag"></param>
        public Emoji(string emojiNname, string emojiTag)
        {
            name = emojiNname;
            Tag = emojiTag;
        }

    }
}
