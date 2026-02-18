using System;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace LibraryEmoji
{
    internal class FaceEmoji : Emoji
    {
        static readonly string[] faces =
        [
            ":(", ":)", "^|0_0|^", "(0 + 0(", 
            "://", ";(", "?:", ":-(", ":-)", "(~` _ ~`(",
            "- _ -", "'_'"
        ];

        string face;
        /// <summary>
        /// Лицо эмодзи
        /// </summary>
        public string Face
        {
            get => face;
            set
            {
                
            }
        }
        
        private ushort strength;
        /// <summary>
        /// Сила эмодзи
        /// </summary>
        public ushort Strength
        {
            get => strength;
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0, "Сила лицевой эмодзи не может быть меньше 0");

                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 10, "Сила лицевой эмодзи не может быть больше 10");

                strength = value;
            }
        }
    }
}
