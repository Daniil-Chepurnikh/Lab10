using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestEquals
{
    [TestMethod]
    public void TestEquals1()
    {
        FaceEmoji e1 = new();
        object obj = '_';
        var res = e1.Equals(obj);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals2()
    {
        AnimalEmoji e1 = new();
        object obj = '_';
        var res = e1.Equals(obj);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals3()
    {
        SmilingEmoji e1 = new();
        object obj = '_';
        var res = e1.Equals(obj);

        Assert.IsFalse(res);
    }

    [TestMethod]
    public void TestEquals4()
    {
        Emoji e1 = new();
        object obj = '_';
        var res = e1.Equals(obj);

        Assert.IsFalse(res);
    }

}
