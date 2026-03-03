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
        AnimalEmoji e = new("Роза", "Цветок", "Хвост");

        Assert.AreEqual("Хвост", e.AnimalPart);
    }

    [TestMethod]
    public void TestCloneCorrect()
    {
        AnimalEmoji e = new("Yes", "No", "Хвост");
        AnimalEmoji clone = new(e);

        Assert.AreEqual(e.AnimalPart, clone.AnimalPart);

        e.AnimalPart = "May be";

        Assert.AreNotEqual(e.AnimalPart, clone.AnimalPart);
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
    public void TestWhiteSpaceAnimalPart()
    {
        AnimalEmoji e;
        var isPassed = false;
        try
        {
            e = new("q", "q", "     ");
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
        AnimalEmoji e = new("д", "п", " sds         ");

        Assert.AreEqual(" sds         ", e.AnimalPart);
    }
}
