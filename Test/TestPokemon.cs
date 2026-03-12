using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestPokemon
{
    #region Boundary Value Testing
    [TestMethod]
    public void TestCreatePokemonWithMinParameters()
    {
        Pokemon pokemon = new(Pokemon.MIN_ATK, Pokemon.MIN_DEF, Pokemon.MIN_STAM);

        Assert.AreEqual(Pokemon.MIN_ATK, pokemon.Attack);
        Assert.AreEqual(Pokemon.MIN_DEF, pokemon.Defense);
        Assert.AreEqual(Pokemon.MIN_STAM, pokemon.Stamina);
    }

    [TestMethod]
    public void TestCreatePokemonWithMinAttack1()
    {
        bool isPassed = false;
        try
        {
            Pokemon pokemon = new(Pokemon.MIN_ATK - 1);
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestCreatePokemonWithMinAttack2()
    {
        Pokemon pokemon = new(Pokemon.MIN_ATK + 1);

        Assert.AreEqual(Pokemon.MIN_ATK + 1, pokemon.Attack);
    }

    [TestMethod]
    public void TestCreatePokemonWithMinDefense1()
    {
        bool isPassed = false;
        try
        {
            Pokemon pokemon = new(299, Pokemon.MIN_DEF - 1, 111);
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestCreatePokemonWithMinDefense2()
    {
        Pokemon pokemon = new(299, Pokemon.MIN_DEF + 1, 111);

        Assert.AreEqual(Pokemon.MIN_DEF + 1, pokemon.Defense);
    }

    [TestMethod]
    public void TestCreatePokemonWithMinStamina1()
    {
        bool isPassed = false;
        try
        {
            Pokemon pokemon = new(299, 299, Pokemon.MIN_STAM - 1);
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestCreatePokemonWithMinStamina2()
    {
        Pokemon pokemon = new(299, 299, Pokemon.MIN_STAM + 1);

        Assert.AreEqual(Pokemon.MIN_STAM + 1, pokemon.Stamina);
    }

    [TestMethod]
    public void TestCreatePokemonWithMaxParameters()
    {
        Pokemon pokemon = new(Pokemon.MAX_ATK, Pokemon.MAX_DEF, Pokemon.MAX_STAM);

        Assert.AreEqual(Pokemon.MAX_ATK, pokemon.Attack);
        Assert.AreEqual(Pokemon.MAX_DEF, pokemon.Defense);
        Assert.AreEqual(Pokemon.MAX_STAM, pokemon.Stamina);
    }

    [TestMethod]
    public void TestCreatePokemonWithMaxStamina1()
    {
        Pokemon pokemon = new(299, 299, Pokemon.MAX_STAM - 1);

        Assert.AreEqual(Pokemon.MAX_STAM - 1, pokemon.Stamina);
    }

    [TestMethod]
    public void TestCreatePokemonWithMaxStamina2()
    {
        bool isPassed = false;
        try
        {
            Pokemon pokemon = new(299, 299, Pokemon.MAX_STAM + 1);
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestCreatePokemonWithMaxDefense1()
    {
        Pokemon pokemon = new(299, Pokemon.MAX_DEF - 1, 299);

        Assert.AreEqual(Pokemon.MAX_DEF - 1, pokemon.Defense);
    }

    [TestMethod]
    public void TestCreatePokemonWithMaxDefense2()
    {
        bool isPassed = false;
        try
        {
            Pokemon pokemon = new(299, Pokemon.MAX_DEF + 1, 299);
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestCreatePokemonWithMaxAttack1()
    {
        Pokemon pokemon = new(Pokemon.MAX_ATK - 1, 111, 299);

        Assert.AreEqual(Pokemon.MAX_ATK - 1, pokemon.Attack);
    }

    [TestMethod]
    public void TestCreatePokemonWithMaxAttack2()
    {
        bool isPassed = false;
        try
        {
            Pokemon pokemon = new(Pokemon.MAX_ATK + 1, 111, 299);
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }
    #endregion

    #region Тестирование конструкторов
    [TestMethod]
    public void TestCreatePokemonWithAttackOnly()
    {
        Pokemon pokemon = new(299);

        Assert.AreEqual(299, pokemon.Attack);
        Assert.AreEqual(Pokemon.MIN_DEF, pokemon.Defense);
        Assert.AreEqual(Pokemon.MIN_STAM, pokemon.Stamina);
    }

    [TestMethod]
    public void TestCreatePokemonWithoutParameters()
    {
        Pokemon pokemon = new();

        Assert.AreEqual(Pokemon.MIN_ATK, pokemon.Attack);
        Assert.AreEqual(Pokemon.MIN_DEF, pokemon.Defense);
        Assert.AreEqual(Pokemon.MIN_STAM, pokemon.Stamina);
    }

    [TestMethod]
    public void TestCreatePokemonWithMidParameters()
    {
        Pokemon pokemon = new(222, 333, 444);

        Assert.AreEqual(222, pokemon.Attack);
        Assert.AreEqual(333, pokemon.Defense);
        Assert.AreEqual(444, pokemon.Stamina);
    }

    [TestMethod]
    public void TestCopyPokemon()
    {
        Pokemon pokemon = new(Pokemon.MIN_ATK, Pokemon.MIN_DEF, Pokemon.MIN_STAM);
        Pokemon copy = new(pokemon);

        Assert.AreEqual(copy.Attack, pokemon.Attack);
        Assert.AreEqual(copy.Defense, pokemon.Defense);
        Assert.AreEqual(copy.Stamina, pokemon.Stamina);

        copy.IncreaseStats(111, 111, 111);

        Assert.AreNotEqual(pokemon.Attack, copy.Attack);
        Assert.AreNotEqual(pokemon.Defense, copy.Defense);
        Assert.AreNotEqual(pokemon.Stamina, copy.Stamina);
    }
    #endregion

    [TestMethod]
    public void TestIncreaseParametrs1()
    {
        Pokemon p = new(111, 111, 111);

        p.IncreaseStats(111, 222, 333);

        Assert.AreEqual(222, p.Attack);
        Assert.AreEqual(333, p.Defense);
        Assert.AreEqual(444, p.Stamina);
    }

    [TestMethod]
    public void TestIncreaseParametrs2()
    {
        Pokemon p = new(111, 111, 111);

        p.IncreaseStats(-52, -66, -110);

        Assert.AreEqual(59, p.Attack);
        Assert.AreEqual(45, p.Defense);
        Assert.AreEqual(1, p.Stamina);
    }

    [TestMethod]
    public void TestIncreaseParametrs3()
    {
        Pokemon p = new(111, 111, 111);

        bool isPassed = false;
        try
        {
            p.IncreaseStats(1111, -66, -110);
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestIncreaseParametrs4()
    {
        Pokemon p = new(111, 111, 111);

        bool isPassed = false;
        try
        {
            p.IncreaseStats(-1111, -66, -110);
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    #region Тестирование переопределённых операций
    [TestMethod]
    public void TestCalculatePower1()
    {
        Pokemon p = new(100, 273, 111);
        double power = ~p;

        Assert.AreEqual(1740.78, power);
    }

    [TestMethod]
    public void TestCalculatePower2()
    {
        Pokemon p = new(100, 111, 111);
        double power = ~p;

        Assert.AreEqual(1110.0, power);
    }

    [TestMethod]
    public void TestSum()
    {
        Pokemon p = new(100, 273, 111);
        int sum = (int)p;

        Assert.AreEqual(484, sum);
    }

    [TestMethod]
    public void TestAverage()
    {
        Pokemon p = new(100, 273, 111);
        double average = p;

        Assert.AreEqual(161.33, average);
    }

    [TestMethod]
    public void TestIncreaseDefense1()
    {
        Pokemon p = new(100, 273, 111);
        p = p > 100;

        Assert.AreEqual(373, p.Defense);
    }

    [TestMethod]
    public void TestIncreaseDefense2()
    {
        Pokemon p = new(100, 273, 111);
        p = 100 > p;

        Assert.AreEqual(373, p.Defense);
    }

    [TestMethod]
    public void TestIncreaseDefense3()
    {
        bool isPassed = false;
        Pokemon p = new(100, 273, 111);

        try
        {
            p = 1000 > p;
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }
        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestIncreaseAttack1()
    {
        Pokemon p = new(100, 273, 111);
        p = p < 100;

        Assert.AreEqual(200, p.Attack);
    }

    [TestMethod]
    public void TestIncreaseAttack2()
    {
        Pokemon p = new(100, 273, 111);
        p = 100 < p;

        Assert.AreEqual(200, p.Attack);
    }

    [TestMethod]
    public void TestIncreaseAttack3()
    {
        bool isPassed = false;
        Pokemon p = new(100, 273, 111);

        try
        {
            p = 1000 < p;
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }
        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestIncreaseStamina1()
    {
        Pokemon p = new(100, 273, 111);
        p >>= 100;

        Assert.AreEqual(211, p.Stamina);
    }

    [TestMethod]
    public void TestIncreaseStamina2()
    {
        Pokemon p = new(100, 273, 111);
        bool isPassed = false;
        try
        {
            p >>= 1000;
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }
        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestDecrementStamina1()
    {
        Pokemon p = new(100, 273, 111);
        p--;

        Assert.AreEqual(110, p.Stamina);
    }

    [TestMethod]
    public void TestDecrementStamina2()
    {
        Pokemon p = new(100, 273, 1);
        bool isPassed = false;
        try
        {
            p--;
        }
        catch (ArgumentOutOfRangeException)
        {
            isPassed = true;
        }
        Assert.IsTrue(isPassed);
    }
    #endregion

    [TestMethod]
    public void TestEquals1()
    {
        Pokemon p = new(111, 222, 333);
        Pokemon pokemon = new(111, 111, 111);

        var result = pokemon.Equals(p);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestEquals2()
    {
        Pokemon p = new(111, 111, 111);
        Pokemon pokemon = new(111, 111, 111);

        var result = pokemon.Equals(p);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestEquals3()
    {
        Pokemon p = new(111, 222, 333);
        bool isPassed = false;
        try
        {
            var result = p.Equals(null);
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestEquals4()
    {
        Pokemon p = new(111, 222, 333);
        object ooops = 1;

        var result = p.Equals(ooops);

        Assert.IsFalse(result);
    }
}
