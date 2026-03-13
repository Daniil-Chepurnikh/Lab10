using LibraryEmoji;
using System.Collections;

public class EmojiComparer : IComparer
{
    /// <summary>
    /// Реализация интерфейса IComparer
    /// </summary>
    /// <param name="x">Первый объект для сравнения</param>
    /// <param name="y">второй объект для сравнения</param>
    /// <returns>Результат сравнения</returns>
    /// <exception cref="ArgumentNullException">В случае если хотя бы 1 из аргументов null</exception>
    public int Compare(object? x, object? y)
    {
        if (x != null && y != null)
        {
            Emoji em1 = (Emoji)x;
            Emoji em2 = (Emoji)y;

            return string.Compare(em1.Name, em2.Name);
        }
        throw new ArgumentNullException();
    }
}
