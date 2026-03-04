using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestAnimalEmoji
{
    [TestMethod]
    public void TestWithoutParameters()
    {
        AnimalEmoji e = new();

        Assert.AreEqual("Часть тела", e.AnimalPart);
    }

    [TestMethod]
    public void TestWithParameters()
    {
        AnimalEmoji e = new("Роза", "Цветок",1, "Хвост");

        Assert.AreEqual("Хвост", e.AnimalPart);
    }

    [TestMethod]
    public void TestEmptyAnimalPart()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("qqqq", "q", 1, "");
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
            e = new("q", "q", 1, "     ");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestStrangeAnimalPart()
    {
        AnimalEmoji e = new("д", "п", 1, " sds         ");

        Assert.AreEqual(" sds         ", e.AnimalPart);
    }
}
