using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestSmilingEmoji
{
    [TestMethod]
    public void TestWithoutParameters()
    {
        SmilingEmoji e = new();

        Assert.AreEqual("Просто улыбается", e.SmileReason);
    }

    [TestMethod]
    public void TestWithParameters()
    {
        SmilingEmoji e = new("Роза", "Цветок", 1, "Хвост");

        Assert.AreEqual("Хвост", e.SmileReason);
    }

    [TestMethod]
    public void TestNullSmileReason()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", "ewd", 1, null);
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestEmptySmileReason()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("eeeee", "q", 1, "");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestWhiteSpaceSmileRason()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("          gghgh      ", "q", 1, "   ");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestWhiteStrangeSmileReason()
    {
        SmilingEmoji e = new("       q         ", "             p              ", 1, " sds         ");

        Assert.AreEqual(" sds         ", e.SmileReason);
    }
}
