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
    public void TestAnimalParts()
    {
        string a = AnimalEmoji.animalParts[2];

        Assert.AreEqual("хвост", a);
    }

    [TestMethod]
    public void TestAnimalPart1()
    {
        AnimalEmoji e = new();
        bool isPassed = false;
        try
        {
            e.AnimalPart = null;
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestAnimalPart2()
    {
        AnimalEmoji e = new();
        bool isPassed = false;
        try
        {
            e.AnimalPart = "";
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestAnimalPart3()
    {
        AnimalEmoji e = new();
        bool isPassed = false;
        try
        {
            e.AnimalPart = "                                      ";
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestShowToString()
    {
        Random rnd = new Random();
        
        AnimalEmoji e = new(rnd);

        string toString = e.ToString();
        string show = e.ToString();
        string showVirtual = e.ToString();

        Assert.AreEqual(showVirtual, show);
        Assert.AreEqual(toString, show);
        Assert.AreEqual(showVirtual, toString);
    }
}
