using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestEquals
{    
    [TestMethod]
    public void TestEquals1()
    {
        Emoji e1 = new("Роза", "Цветок", 1);
        Emoji e2 = new("Роза", "Цветок", 1);

        var res = e1.Equals(e2);

        Assert.IsTrue(res);
    }

    [TestMethod]
    public void TestEquals2()
    {
        Emoji e1 = new("Роза", "Цветок", 1);
        Emoji e2 = new("Роза", "Цвето", 1);

        var res = e1.Equals(e2);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals3()
    {
        Emoji e1 = new("Роза", "Цветок", 1);
        Emoji e2 = new("Роз", "Цветок", 1);

        var res = e1.Equals(e2);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals4() // null
    {
        Emoji e1 = new("Роза", "Цветок", 1);

        var res = e1.Equals(null);

        Assert.IsFalse(res);
    }

    #region Разные типы
    [TestMethod]
    public void TestEquals5()
    {
        Emoji e1 = new("Роза", "Цветок", 1);
        object obj = '_';
        var res = e1.Equals(obj);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals6()
    {
        FaceEmoji e1 = new();
        object obj = '_';
        var res = e1.Equals(obj);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals7()
    {
        AnimalEmoji e1 = new();
        object obj = '_';
        var res = e1.Equals(obj);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals8()
    {
        SmilingEmoji e1 = new();
        object obj = '_';
        var res = e1.Equals(obj);

        Assert.IsFalse(res);
    }
    #endregion
}
