using LibraryEmoji;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Emoji emoji_1 = new Emoji("Рок жив", "Рок вечен");
            Emoji emoji_2 = new Emoji(emoji_1);
            emoji_1.Tag = "Рок навсегда";

            Console.WriteLine(emoji_1.Tag);
            Console.WriteLine(emoji_2.Tag);
        }
    }
}
