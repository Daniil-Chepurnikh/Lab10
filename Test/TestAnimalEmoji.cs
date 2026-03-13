using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestAnimalEmoji
{
    [TestMethod]
    public void TestGetHashCode()
    {
        AnimalEmoji e = new();

        int hash1 = e.GetHashCode();

        e.AnimalPart = "Муха вертолёт";

        int hash2 = e.GetHashCode();

        Assert.AreNotEqual(hash1, hash2);
    }

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

        string toString = e.Show();
        string show = e.Show();
        string showVirtual = e.VirtualShow();

        Assert.AreEqual(showVirtual, show);
        Assert.AreEqual(toString, show);
        Assert.AreEqual(showVirtual, toString);
    }
}
