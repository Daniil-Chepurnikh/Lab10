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
}
