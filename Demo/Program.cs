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

            foreach (Emoji emoji in emojis)
            {
                Random rn = new();

                switch (rn.Next(2))
                {
                    case 0:
                        Output.Message(emoji.Show() + '\n', ConsoleColor.Cyan);
                        break; 
                    case 1:
                        Output.Message(emoji.VirtualShow() + '\n', ConsoleColor.Magenta);
                        break;
                }
            }



        }
    }
}
