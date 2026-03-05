using lab_10_v5_ClassLibrary;
using System;

namespace LibraryEmoji
{
    public class Pokemon : IRandomInit
    {
        #region Диапазон значений
        public const short MIN_ATK = 17;
        public const short MAX_ATK = 414;

        public const short MIN_DEF = 32;
        public const short MAX_DEF = 396;

        public const short MIN_STAM = 1;
        public const short MAX_STAM = 496;
        #endregion

        public static int Count { get; private set; }

        int attack;
        int defense;
        int stamina;

        /// <summary>
        /// Aтака 
        /// </summary>
        public int Attack
        {
            get => attack;
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN_ATK, "По условию атака");

                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX_ATK, "По условию атака");

                attack = value;
            }
        }

        /// <summary>
        /// Защита
        /// </summary>
        public int Defense
        {
            get => defense;
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN_DEF, "По условию защита");

                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX_DEF, "По условию защита");

                defense = value;
            }
        }

        /// <summary>
        /// Выносливость
        /// </summary>
        public int Stamina
        {
            get => stamina;
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, MIN_STAM, "По условию выносливость");

                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MAX_STAM, "По условию выносливость");

                stamina = value;
            }
        }

        #region Конструкторы
        /// <summary>
        /// По умолчанию
        /// </summary>
        public Pokemon()
        {
            Attack = MIN_ATK;
            Defense = MIN_DEF;
            Stamina = MIN_STAM;

            Count++;
        }

        /// <summary>
        /// Инициализация желаемыми значениями
        /// </summary>
        /// <param name="atk">Атака</param>
        /// <param name="def">Защита</param>
        /// <param name="stam">Выносливость</param>
        public Pokemon(int attack, int defense, int stamina)
        {
            Attack = attack;
            Defense = defense;
            Stamina = stamina;

            Count++;
        }

        /// <summary>
        /// Глубокое копирование
        /// </summary>
        /// <param name="p">Копируемый экземпляр</param>
        public Pokemon(Pokemon source)
        {
            ArgumentNullException.ThrowIfNull(source, "Невозможно скопировать по null");

            Attack = source.attack;
            Defense = source.defense;
            Stamina = source.stamina;

            Count++;
        }

        /// <summary>
        /// Конструктором с инициализатором
        /// </summary>
        /// <param name="atk">Атака покемона</param>
        public Pokemon(int atk) : this()
        {
            Attack = atk;
        }

        /// <summary>
        /// Рандомный конструктор
        /// </summary>
        /// <param name="rnd">Просто метка рандома</param>
        public Pokemon(Random rnd)
        {
            RandomInit();

            Count++;
        }
        #endregion

        /// <summary>
        /// Печатает все характеристики покемона
        /// </summary>
        /// <param name="p">Конкретный покемон</param>
        override public string ToString() => $"Атака: {Attack,3}, защита: {Defense,3}, выносливость: {Stamina,3}\n";

        #region Увеличение параметров
        /// <summary>
        /// Увеличивает параметры покемона, если возможно, на переданные значения
        /// </summary>
        /// <param name="p">Изменяемый покемон</param>
        /// <param name="increaseAttack">Атака</param>
        /// <param name="increaseDefense">Защита</param>
        /// <param name="increaseStamina">Выносливость</param>
        /// <returns>Изменённый покемон</returns>
        public static Pokemon IncreaseStats(Pokemon p, int increaseAttack, int increaseDefense, int increaseStamina)
        {
            p.IncreaseStats(increaseAttack, increaseDefense, increaseStamina);
            return p;
        }

        /// <summary>
        /// Увеличивает параметры покемона на переданные значения
        /// </summary>
        /// <param name="increaseAttack">Атака</param>
        /// <param name="increaseDefense">Защита</param>
        /// <param name="increaseStamina">Выносливость</param>
        /// <returns>Изменённый покемон</returns>
        public void IncreaseStats(int increaseAttack, int increaseDefense, int increaseStamina)
        {
            IncreaseAttack(increaseAttack);
            IncreaseDefense(increaseDefense);
            IncreaseStamina(increaseStamina);
        }

        /// <summary>
        /// Увеличивает атаку покемона
        /// </summary>
        /// <param name="increaseAttack">Увеличение</param>
        void IncreaseAttack(int increaseAttack) => Attack += increaseAttack;

        /// <summary>
        /// Увеличивает зашиту покемона
        /// </summary>
        /// <param name="increaseDefense">Увеличение</param>
        void IncreaseDefense(int increaseDefense) => Defense += increaseDefense;

        /// <summary>
        /// Увеличивает выносливость покемона, если возможно
        /// </summary>
        /// <param name="increaseStamina">Увеличение</param>
        void IncreaseStamina(int increaseStamina) => Stamina += increaseStamina;
        #endregion

        #region Переопределённые операции
        /// <summary>
        /// Считает и возвращает мощность покемона
        /// </summary>
        /// <param name="p">Покемон</param>
        /// <returns>Мощность(округляя до 0,01)</returns>
        public static double operator ~(Pokemon p) => p.CalculatePower();

        /// <summary>
        /// Считает мощность покемона
        /// </summary>
        /// <returns>Число с округлением до сотых</returns>
        double CalculatePower() => Math.Round(Math.Sqrt(Defense) * Math.Sqrt(Stamina) / 10 * Attack, 2);

        /// <summary>
        /// Уменьшает выносливость покемона на 1
        /// </summary>
        /// <param name="p">Покемон, выносливость которого надо уменьшить</param>
        /// <returns>Изменённый покемон</returns>
        public static Pokemon operator --(Pokemon p)
        {
            Pokemon pokemon = new(p);
            pokemon.DecrementStamina();
            return pokemon;
        }

        /// <summary>
        /// Уменьшает выноливость на 1
        /// </summary>
        void DecrementStamina() => Stamina--;

        /// <summary>
        /// Считает сумму характеристик покемона 
        /// </summary>
        /// <param name="p">Покемон</param>
        public static explicit operator int(Pokemon p) => p.Sum(); // explicit - явное привидение

        /// <summary>
        /// Считает сумму характеристик покемона 
        /// </summary>
        /// <returns>Сумма характеристик</returns>
        int Sum() => Attack + Defense + Stamina;

        /// <summary>
        /// Считает среднее характеристик покемона 
        /// </summary>
        /// <param name="p">Покемон</param>
        public static implicit operator double(Pokemon p) => p.Average(); // implicit - неявное привидение

        /// <summary>
        /// Считает среднее характеристик покемона 
        /// </summary>
        /// <returns></returns>
        double Average() => Math.Round(Sum() / 3.0, 2);

        /// <summary>
        /// Увеличивает выносливость покемона на определённое число
        /// </summary>
        /// <param name="p">Покемон для увеличения</param>
        /// <param name="stam">Увеличение</param>
        /// <returns>Изменённый покемон</returns>
        public static Pokemon operator >>(Pokemon p, int increaseStamina)
        {
            Pokemon pokemon = new(p);
            pokemon.IncreaseStamina(increaseStamina);
            return pokemon;
        }

        /// <summary>
        /// Увеличивает атаку покемона на заданное число
        /// </summary>
        /// <param name="p">Покемон</param>
        /// <param name="increaseAttack">Увеличение</param>
        /// <returns>Покемон с изменённой атакой атакой</returns>
        public static Pokemon operator <(Pokemon p, int increaseAttack)
        {
            Pokemon pokemon = new(p);
            pokemon.IncreaseAttack(increaseAttack);
            return pokemon;
        }

        /// <summary>
        /// Увеличивает атаку покемона на заданное число
        /// </summary>
        /// <param name="increaseAttack">Увеличение</param>
        /// <param name="p">Покемон</param>
        /// <returns>Покемон с изменённой атакой атакой</returns>
        public static Pokemon operator <(int increaseAttack, Pokemon p) => p < increaseAttack;

        /// <summary>
        /// Увеличивает защиту покемона на заданное число
        /// </summary>
        /// <param name="p">Покемон3</param>
        /// <param name="increaseDefense">Увеличение защиты</param>
        /// <returns>Покемон с изменённой защитой</returns>
        public static Pokemon operator >(Pokemon p, int increaseDefense)
        {
            Pokemon pokemon = new(p);
            pokemon.IncreaseDefense(increaseDefense);
            return pokemon;
        }

        /// <summary>
        /// Увеличивает защиту покемона на заданное число
        /// </summary>
        /// <param name="increaseDefense">Увеличение защиты</param>
        /// <param name="p">Покемон3</param>
        /// <returns>Покемон с изменённой защитой</returns>
        public static Pokemon operator >(int increaseDefense, Pokemon p) => p > increaseDefense;
        #endregion

        /// <summary>
        /// Сравнивает на равенство
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true если объекты равны</returns>
        override public bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj, "Невозможно сравнить значение по null");

            return obj is Pokemon pokemon
                    && pokemon.Attack == Attack
                    && pokemon.Defense == Defense
                    && pokemon.Stamina == Stamina;
        }

        public void RandomInit(Random random)
        {
            throw new NotImplementedException();
        }

        public void RandomInit()
        {
            Random rn = new Random();
            
            Attack = rn.Next(100, 200);
            Defense = rn.Next(100, 200);
            Stamina = rn.Next(100, 200);
        }

        // TODO: сделать GetHashCode при необходимости

    }
}
