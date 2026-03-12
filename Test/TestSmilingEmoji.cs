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
    public void TestSmileReasons()
    {
        string s = SmilingEmoji.smileReasons[1];

        Assert.AreEqual("победа команды", s);
    }

    [TestMethod]
    public void TestSmileReason1()
    {
        SmilingEmoji e = new();
        bool isPassed = false;
        try
        {
            e.SmileReason = "     ";
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestSmileReason2()
    {
        SmilingEmoji e = new();
        bool isPassed = false;
        try
        {
            e.SmileReason = "";
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestSmileReason3()
    {
        SmilingEmoji e = new();
        bool isPassed = false;
        try
        {
            e.SmileReason = "q q q";
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestShowToString()
    {
        Random rnd = new Random();

        SmilingEmoji e = new(rnd);

        string toString = e.ToString();
        string show = e.ToString();
        string showVirtual = e.ToString();

        Assert.AreEqual(showVirtual, show);
        Assert.AreEqual(toString, show);
        Assert.AreEqual(showVirtual, toString);
    }
}
