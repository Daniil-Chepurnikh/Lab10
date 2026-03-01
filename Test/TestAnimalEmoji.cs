using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestAnimalEmoji
{
    [TestMethod]
    public void TestWithoutParameters()
    {
        AnimalEmoji e = new();

        Assert.AreEqual("Без названия", e.Name);
        Assert.AreEqual("Без тега", e.Tag);
        Assert.AreEqual("Неопределённая часть тела", e.AnimalPart);
    }

    [TestMethod]
    public void TestWithParameters()
    {
        AnimalEmoji e = new("Роза", "Цветок", "Хвост");

        Assert.AreEqual("Роза", e.Name);
        Assert.AreEqual("Цветок", e.Tag);
        Assert.AreEqual("Хвост", e.AnimalPart);
    }

    [TestMethod]
    public void TestCloneNull()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new(null);
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }
        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestCloneCorrect()
    {
        AnimalEmoji e = new("Yes", "No", "Хвост");
        AnimalEmoji clone = new(e);

        Assert.AreEqual(e.Name, clone.Name);
        Assert.AreEqual(e.Tag, clone.Tag);
        Assert.AreEqual(e.AnimalPart, clone.AnimalPart);

        e.Tag = "May be";
        Assert.AreEqual(e.Name, clone.Name);
        Assert.AreNotEqual(e.Tag, clone.Tag);
        Assert.AreEqual(e.AnimalPart, clone.AnimalPart);
    }

    [TestMethod]
    public void TestNullName()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new(null, "No", "wdsds");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestNullTag()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", null, "sfssfdfd");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestNullAnimalPart()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", "null", null);
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestEmptyTag()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", "", "выывававаф");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestEmptyName()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("", "q", "цыававапв");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestEmptyAnimalPart()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("qqqq", "q", "");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestWhiteSpaceTag()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", "                   ", "dsfdfdfdafda");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestWhiteSpaceName()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("                ", "q", "dfdddsds");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestWhiteSpaceAnimalPart()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("        q        ", "q", "                         ");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestWhiteStrangeNameTag()
    {
        AnimalEmoji e = new("       q         ", "             p              ", " sds         ");

        Assert.AreEqual("       q         ", e.Name);
        Assert.AreEqual("             p              ", e.Tag);
        Assert.AreEqual(" sds         ", e.AnimalPart);
    }
}
