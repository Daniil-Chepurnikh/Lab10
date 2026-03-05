using LibraryEmoji;
using MyDCInputOutputConsole;
using System;

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

            int smileReasonLength = 0;
            
            foreach (Emoji emoji in emojis)
            {
                if (typeof(SmilingEmoji) == emoji.GetType())
                    smileReasonLength = Math.Max(smileReasonLength, SmilingEmoji.GetSmileReasonLength((SmilingEmoji)emoji));

                if (emoji is AnimalEmoji animal)
                    Output.Message(AnimalEmoji.SayRrroarrr(), ConsoleColor.Yellow);

                FaceEmoji? face = emoji as FaceEmoji;
                try
                {
                    Output.Message(FaceEmoji.Wink(face), ConsoleColor.Yellow);
                }
                catch (ArgumentNullException)
                {
                    Output.Message("Не получилсь подмигнуть\n", ConsoleColor.Blue);
                }
            }
            

        }
    }
}
