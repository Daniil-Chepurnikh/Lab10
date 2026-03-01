using LibraryEmoji;
using MyDCInputOutputConsole;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Emoji emoji_1 = new("Рок жив", "Рок вечен");
            Emoji emoji_2 = new(emoji_1);
            emoji_1.Tag = "Рок навсегда";

            AnimalEmoji an = new();
            Output.Message(an.VirtualShow(), ConsoleColor.White);
             // TODO: доплнить демонстрационную программу
        }
    }
}
