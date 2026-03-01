using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestEquals
{
    [TestMethod]
    public void TestEquals1()
    {
        Emoji e1 = new("Роза", "Цветок");
        Emoji e2 = new("Роза", "Цветок");

        var res = e1.Equals(e2);

        Assert.IsTrue(res);
    }

    [TestMethod]
    public void TestEquals2()
    {
        Emoji e1 = new("Роза", "Цветок");
        Emoji e2 = new("Роза", "Цвето");

        var res = e1.Equals(e2);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals3()
    {
        Emoji e1 = new("Роза", "Цветок");
        Emoji e2 = new("Роз", "Цветок");

        var res = e1.Equals(e2);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals4()
    {
        Emoji e1 = new("Роза", "Цветок");

        var res = e1.Equals(null);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals5()
    {
        Emoji e1 = new("Роза", "Цветок");
        AnimalEmoji e = new();
        var res = e1.Equals(e);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals6()
    {
        Emoji e1 = new("Роза", "Цветок");
        FaceEmoji e2 = new();

        var res = e1.Equals(e2);

        Assert.IsFalse(res);
    }
}
