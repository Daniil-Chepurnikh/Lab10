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

        void RandomInit();
    }
}
