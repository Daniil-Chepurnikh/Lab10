using LibraryEmoji;
using MyDCInputOutputConsole;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Output.Message(">>>>>>>>>>>>>>>>>>ЧАСТЬ 1<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n", ConsoleColor.Cyan);
            Output.Separator();

            Emoji[] emojis = new Emoji[52];

            for (int p = 0; p < emojis.Length; p++)
            {
                Random rn = new();

                emojis[p] = rn.Next(4) switch
                {
                    0 => new Emoji(rn),
                    1 => new AnimalEmoji(rn),
                    2 => new FaceEmoji(rn),
                    _ => new SmilingEmoji(rn) // как дефолт в обычном свитч
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

            Output.Separator();
            Output.Message(">>>>>>>>>>>>>>>>>>ЧАСТЬ 2<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n", ConsoleColor.Cyan);

            // просто захотел вернуть кортеж
            (double average, bool isHappy) = CalculateAverageSmileStrength(emojis);



            // TODO: написать запросы нормальные
            // GoodPractise: В запрос ты передаёшь 1 большой кусок входных данных и он уже сам его полностью обрабатывает
            // а не самому каждый элемент просматривать и проверят 
        }

        /// <summary>
        /// Возвращает среднюю силу улыбки и оценку счастливости набора эмодзи
        /// </summary>
        /// <param name="emos">Набор эмодзи</param>
        /// <returns>Среднее, метка счастливости(true, если счастлив)</returns>
        public static (double average, bool isHappy) CalculateAverageSmileStrength(Emoji[] emos)
        {
            double averageSmileStrength = 0.0;
            uint smileCount = 0;
            foreach (Emoji emo in emos)
            {
                if (emo is SmilingEmoji smile)
                {
                    averageSmileStrength += smile.Strength;
                    smileCount++;
                }
            }
            averageSmileStrength /= smileCount;

            return (averageSmileStrength, averageSmileStrength > 5);
        }

    }
}
