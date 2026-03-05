using LibraryEmoji;
using System.Collections;

namespace lab_10_v5_ClassLibrary;

public class EmojiComparer : IComparer
{
    public int Compare(object? x, object? y) // какой смог(захотел)
    {
        if (x != null && y != null)
        {
            Emoji em1 = (Emoji)x;
            Emoji em2 = (Emoji)x;

            if (em1.GetHashCode() > em2.GetHashCode())
                return 1;
            else if (em1.GetHashCode() < em2.GetHashCode())
                return -1;
            else
                return 0;
        }
        throw new ArgumentNullException();
    }
}
