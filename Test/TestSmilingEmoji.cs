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

        Assert.AreEqual("Без названия", e.Name);
        Assert.AreEqual("Без тега", e.Tag);
        Assert.AreEqual("Улыбается без причины, просто счастлив в жизни", e.SmileReason);
    }

    [TestMethod]
    public void TestWithParameters()
    {
        SmilingEmoji e = new("Роза", "Цветок", "Хвост");

        Assert.AreEqual("Роза", e.Name);
        Assert.AreEqual("Цветок", e.Tag);
        Assert.AreEqual("Хвост", e.SmileReason);
    }

    [TestMethod]
    public void TestCloneNull()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new(null);
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }
        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestCloneCorrect()
    {
        SmilingEmoji e = new("Yes", "No", "Хвост");
        SmilingEmoji clone = new(e);

        Assert.AreEqual(e.Name, clone.Name);
        Assert.AreEqual(e.Tag, clone.Tag);
        Assert.AreEqual(e.SmileReason, clone.SmileReason);

        e.Tag = "May be";
        Assert.AreEqual(e.Name, clone.Name);
        Assert.AreNotEqual(e.Tag, clone.Tag);
        Assert.AreEqual(e.SmileReason, clone.SmileReason);
    }

    [TestMethod]
    public void TestNullName()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new(null, "No", "wdsds");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestNullTag()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", null, "sfssfdfd");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    // TODO: добавить тест на нал причину улыбки

    [TestMethod]
    public void TestEmptyTag()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", "", "выывававаф");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestEmptyName()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("", "q", "цыававапв");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    // TODO: добавить тест на empty причину улыбки

    [TestMethod]
    public void TestWhiteSpaceTag()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("null", "                   ", "dsfdfdfdafda");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestWhiteSpaceName()
    {
        SmilingEmoji e;
        var isPassed = false;
        try
        {
            e = new("                ", "q", "dfdddsds");
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    // TODO: добавить тест на причину улыбки только из пробельных симвоволов

    [TestMethod]
    public void TestWhiteStrangeNameTag()
    {
        SmilingEmoji e = new("       q         ", "             p              ", " sds         ");

        Assert.AreEqual("       q         ", e.Name);
        Assert.AreEqual("             p              ", e.Tag);
        Assert.AreEqual(" sds         ", e.SmileReason);
    }
}
