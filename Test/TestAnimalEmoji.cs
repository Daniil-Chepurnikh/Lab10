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
}
