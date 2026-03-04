using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestEquals
{
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
}
