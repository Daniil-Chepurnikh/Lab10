using LibraryEmoji;
using MyDCInputOutputConsole;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {           
            Emoji[] emojis = new Emoji[35];

            for (int p = 0; p < emojis.Length; p++)
            {
                Random rn = new();

                emojis[p] = rn.Next(4) switch
                {
                    0 => new Emoji(rn),
                    1 => new AnimalEmoji(rn),
                    2 => new FaceEmoji(rn),
                    _ => new SmilingEmoji(rn)
                };
            }

            for (int p = 0; p < emojis.Length; p++)
            {
                Random rn = new();

                switch (rn.Next(2))
                {
                    case 0:
                        Output.Message(emojis[p].Show() + '\n', ConsoleColor.Cyan);
                        break; 
                    case 1:
                        Output.Message(emojis[p].VirtualShow() + '\n', ConsoleColor.Magenta);
                        break;
                }
            }



        }
    }
}
