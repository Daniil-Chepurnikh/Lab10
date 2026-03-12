using LibraryEmoji;
using MyDCInputOutputConsole;
using System;

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

            if (CalculateAverageSmileStrength(emojis) > 5)
                Output.Message("Эмодзи счастливы", ConsoleColor.Blue);
            else
                Output.Message("Эмодзи печальны", ConsoleColor.DarkRed);

            Wink(emojis);
            Output.Separator();

            Output.Message("Самое длинное выражение: " + MaxExpressionLength(emojis), ConsoleColor.White);

            Output.Separator();
            Output.Message(">>>>>>>>>>>>>>>>>>ЧАСТЬ 3<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n", ConsoleColor.Cyan);

            Array.Sort(emojis);
            for (int q = 0; q < emojis.Length; q++)
            {
                ConsoleColor color = (q % 3) switch
                {
                    0 => ConsoleColor.Cyan,
                    1 => ConsoleColor.Magenta,
                    _ => ConsoleColor.Green
                };

                Output.Message(emojis[q] + "\n", color);
            }

            Output.Message("Начался бинарный поиск\n", ConsoleColor.White);

            int index = Array.BinarySearch(emojis, new Emoji(9999));
            if (index < 0)
                Output.Message("Элемент не найден", ConsoleColor.Blue);
            else
            {
                Output.Message(emojis[index], ConsoleColor.White);
                Output.Message($" Номер элемента: {index + 1}", ConsoleColor.White);
            }
        }

        /// <summary>
        /// Возвращает среднюю силу улыбки
        /// </summary>
        /// <param name="emos">Набор эмодзи</param>
        /// <returns>Средняя счастливость</returns>
        public static double CalculateAverageSmileStrength(Emoji[] emos)
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

            return averageSmileStrength;
        }

        /// <summary>
        /// Подмигивает животным глазом
        /// </summary>
        /// <param name="emos">Набор эмодзи</param>
        public static void Wink(Emoji[] emos)
        {
            foreach (Emoji emo in emos)
            {
                if (emo is AnimalEmoji an)
                {
                    Output.Message("Вам подмигнули: (^-0( ", ConsoleColor.Magenta);
                    Output.Message(an + "\n", ConsoleColor.Magenta);
                }
            }
        }

        /// <summary>
        /// Возвращает выражение максимальной длины в массиве
        /// </summary>
        /// <param name="emos">Массив эмодзи</param>
        /// <returns>Выражение</returns>
        public static string MaxExpressionLength(Emoji[] emos)
        {
            string str = string.Empty;
            foreach (Emoji emo in emos)
            {
                FaceEmoji face = emo as FaceEmoji;

                try
                {
                    if (str.Length < face.Expression.Length)
                        str = face.Expression;
                }
                catch {}
            }
            return str;
        }
    }
}
