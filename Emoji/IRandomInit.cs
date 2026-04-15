namespace LibraryEmoji
{
    /// <summary>
    /// Интерфейс инициализации случайными значениями
    /// </summary>
    public interface IRandomInit
    {
        /// <summary>
        /// Генератор случайных чисел для RandomInit
        /// </summary>
        static readonly Random random = new();
        
        /// <summary>
        /// Метод инициализации случайными значениями
        /// </summary>
        void RandomInit();
    }
}
