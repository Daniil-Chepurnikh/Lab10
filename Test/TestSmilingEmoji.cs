using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestSmilingEmoji
{
    // TODO: изменить тесты на причину улыбки, когда придумаю и добавлю в свойства ограничения
    // TODO: проверить все тесты на логичность

    [TestMethod]
    public void TestWithoutParameters()
    {
        SmilingEmoji e = new();

        Assert.AreEqual("Просто улыбается", e.SmileReason);
    }

    [TestMethod]
    public void TestWithParameters()
    {
        SmilingEmoji e = new("Роза", "Цветок", "Хвост");

        Assert.AreEqual("Хвост", e.SmileReason);
    }

    [TestMethod]
    public void TestCloneCorrect()
    {
        SmilingEmoji e = new("Yes", "No", "Хвост");
        SmilingEmoji clone = new(e);

        Assert.AreEqual(e.SmileReason, clone.SmileReason);

        e.SmileReason = "May be";

        Assert.AreNotEqual(e.SmileReason, clone.SmileReason);
    }

    [TestMethod]
    public void TestNullSmileReason()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", "ewd", null);
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
            e = new("eeeee", "q", "");
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
            e = new("          gghgh      ", "q", "   ");
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
        SmilingEmoji e = new("       q         ", "             p              ", " sds         ");

        Assert.AreEqual(" sds         ", e.SmileReason);
    }
}
