using LibraryEmoji;
using MyDCInputOutputConsole;
using System;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Output.Message(">>>>>>>>>>>>>>>>>>ЧАСТЬ 2<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n", ConsoleColor.Cyan);

            Emoji[] emojis = new Emoji[15]; // основной
            Emoji[] emojis2 = { new Emoji() }; // чтобы показать как работает один из запросов

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

            if (CalculateAverageSmileStrength(emojis) > 5)
                Output.Message("Эмодзи счастливы\n", ConsoleColor.Blue);
            else if (CalculateAverageSmileStrength(emojis) > 0)
                Output.Message("Эмодзи печальны\n", ConsoleColor.DarkRed);
            else
                Output.Message("Нет ни одной улыбающейся эмоции\n", ConsoleColor.White);

            Output.Separator();
            
            if (CalculateAverageSmileStrength(emojis2) > 5)
                Output.Message("Эмодзи счастливы\n", ConsoleColor.Blue);
            else if (CalculateAverageSmileStrength(emojis2) > 0)
                Output.Message("Эмодзи печальны\n", ConsoleColor.DarkRed);
            else
                Output.Message("Нет ни одной улыбающейся эмоции\n", ConsoleColor.White);

            Output.Message($"Количество трёхбуквенных частей тела животных: {CountAnimalParts(emojis)}\n", ConsoleColor.Blue);

            Output.Message("Самое длинное выражение: " + MaxExpressionLength(emojis) + "\n", ConsoleColor.White);

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

            Output.Message(".......................Поиск по IComparable.........................\n", ConsoleColor.White);

            int indexComparable = Array.BinarySearch(emojis, new Emoji(new IdNumber(9999)));
            if (indexComparable < 0)
                Output.Message("Элемент не найден\n", ConsoleColor.Blue);
            else
            {
                Output.Message(emojis[indexComparable] +"\n", ConsoleColor.White);
                Output.Message($" Номер элемента: {indexComparable + 1}\n", ConsoleColor.White);
            }

            Emoji[] emojisComaparer = new Emoji[15];

            for (int p = 0; p < emojisComaparer.Length; p++)
            {
                Random rn = new();

                emojisComaparer[p] = rn.Next(4) switch
                {
                    0 => new Emoji(rn),
                    1 => new AnimalEmoji(rn),
                    2 => new FaceEmoji(rn),
                    _ => new SmilingEmoji(rn)
                };
            }

            Output.Message(".....................Поиск по ICompare.....................\n", ConsoleColor.White);

            Array.Sort(emojisComaparer, new EmojiComparer());
            for (int q = 0; q < emojisComaparer.Length; q++)
            {
                ConsoleColor color = (q % 3) switch
                {
                    0 => ConsoleColor.Cyan,
                    1 => ConsoleColor.Magenta,
                    _ => ConsoleColor.Green
                };

                Output.Message(emojisComaparer[q] + "\n", color);
            }

            int indexCompare = Array.BinarySearch(emojisComaparer, new Emoji(new IdNumber(1)), new EmojiComparer());
            if (indexCompare < 0)
                Output.Message("Элемент не найден\n", ConsoleColor.Blue);
            else
            {
                Output.Message(emojisComaparer[indexCompare] + "\n", ConsoleColor.White);
                Output.Message($"Номер элемента: {indexCompare + 1}\n", ConsoleColor.White);
            }

            Output.Message(".....................Клонирование.......................\n", ConsoleColor.White);
            Output.Separator();

            SmilingEmoji face = new SmilingEmoji { Name = "qqq", Tag = "fwfff", SmileReason = "Нафиг унывать", Expression = ":)))", Strength = 1 };
            Output.Message($"Эмодзи исходник: {face} \n", ConsoleColor.Cyan);

            SmilingEmoji emo = (SmilingEmoji)face.Clone();

            Output.Message($"Эмодзи исходник после создания клона: {face} \n", ConsoleColor.Cyan);
            Output.Message($"Клон сейчас: {emo} \n", ConsoleColor.Red);

            emo.SmileReason = "www";
            emo.Strength = 9;
            emo.Expression = "*_*";
            emo.Name = "qwerty";
            emo.Tag = "zxcvb";

            Output.Message($"Эмодзи исходник после изменений в клоне: {face} \n", ConsoleColor.Cyan);
            Output.Message($"Клон после изменений: {emo} \n", ConsoleColor.Red);

            Output.Message(".....................Поверхностное копирование.......................\n", ConsoleColor.White);
            Output.Separator();

            SmilingEmoji smile = new SmilingEmoji{ Expression = "qqqq", Name = "pppp", SmileReason = "hhhh", Strength= 1,
                                                   Tag = "oooo", IdNumber = new(190) };

            SmilingEmoji smileCopy = smile.ShallowCopy();

            Output.Message($"Эмодзи исходник: {smile} \n", ConsoleColor.Cyan);
            Output.Message($"Копия: {smileCopy} \n", ConsoleColor.Red);

            smile.Name = "русский рок";
            smile.Expression = "рок жив";
            smile.Strength = 9;
            smile.Tag = "Манчестер Красный";
            smile.IdNumber.Number = new();
            smile.SmileReason = "ssss";

            Output.Separator();
            Output.Message($"..............................Провели изменения в копии..................................\n", ConsoleColor.Yellow);
            Output.Separator();

            Output.Message($"Копия: {smileCopy} \n", ConsoleColor.Red);
            Output.Message($"Эмодзи исходник: {smile} \n", ConsoleColor.Cyan);

            Output.Separator();
            Output.Message($"..............................Массив из эмодзи и покемонов..................................\n", ConsoleColor.Yellow);

            object[] emojis_pokemons = new object[20];

            for (int p = 0; p < emojis_pokemons.Length; p++)
            {
                Random rn = new();

                emojis_pokemons[p] = rn.Next(4) switch
                {
                    0 => new Emoji(rn),
                    1 => new AnimalEmoji(rn),
                    2 => new FaceEmoji(rn),
                    _ => new SmilingEmoji(rn),
                };
            }

            uint emNum, smileNum, anNum, faceNum;
            emNum = smileNum = anNum = faceNum = 0;
            
            for (int p = 0; p < emojis_pokemons.Length; p++)
            {
                Output.Message($"{emojis_pokemons[p]}\n", ConsoleColor.White);

                if (typeof(Emoji) == emojis_pokemons[p].GetType())
                    emNum++;
                else if (typeof(AnimalEmoji) == emojis_pokemons[p].GetType())
                    anNum++;
                else if (typeof(FaceEmoji) == emojis_pokemons[p].GetType())
                    faceNum++;
                else
                    smileNum++;

            }
            Output.Separator();

            Output.Message($"Эмодзи: {emNum}\n", ConsoleColor.Magenta);
            Output.Message($"Лиц: {faceNum} \n", ConsoleColor.Magenta);
            Output.Message($"Животных: {anNum} \n", ConsoleColor.Magenta);
            Output.Message($"Улыбок: {smileNum} \n", ConsoleColor.Magenta);
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
            if (smileCount != 0)
                averageSmileStrength /= smileCount;

            return averageSmileStrength;
        }
        
        /// <summary>
        /// Считает сколько трёхбуквенных частей тела животных встречено
        /// </summary>
        /// <param name="emos">Набор эмодзи</param>
        /// <returns>Целое число трёхбуквенных частей тела</returns>
        public static uint CountAnimalParts(Emoji[] emos)
        {
            uint num = 0;
            foreach (Emoji emo in emos)
            {
                if (emo.GetType() == typeof(AnimalEmoji))
                {
                    AnimalEmoji an = (AnimalEmoji)emo;

                    if (an.AnimalPart.Length == 3)
                        num++;
                }
            }
            return num;
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
                try
                {
                    FaceEmoji face = emo as FaceEmoji;
                    if (str.Length < face.Expression.Length)
                        str = face.Expression;
                }
                catch {}
            }
            return str;
        }
    }
}
