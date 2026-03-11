using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestEquals
{
    #region Тестирование SimpleEquals
    [TestMethod]
    public void TestSimpleEquals1()
    {
        Emoji e = new();
        Emoji e1 = new();

        bool isEqual = e.Equals(e1);

        Assert.IsTrue(isEqual);
    }

    [TestMethod]
    public void TestSimpleEquals2()
    {
        Emoji e = new();
        Emoji e1 = new();

        e.Name = "рок жив";

        bool isEqual = e.Equals(e1);

        Assert.IsFalse(isEqual);
    }

    [TestMethod]
    public void TestSimpleEquals3()
    {
        Emoji e = new();
        Emoji e1 = new();

        e.Tag = "рок жив";

        bool isEqual = e.Equals(e1);

        Assert.IsFalse(isEqual);
    }

    [TestMethod]
    public void TestSimpleEquals4()
    {
        Emoji e = new();
        Emoji e1 = new();

        e.Tag = "рок жив";

        bool isEqual = e.Equals(e1);

        Assert.IsFalse(isEqual);
    }

    [TestMethod]
    public void TestSimpleEquals5()
    {
        FaceEmoji e = new();
        FaceEmoji e1 = new();

        e1.Strength = 10;

        bool isEqual = e1.Equals(e);

        Assert.IsFalse(isEqual);
    }

    [TestMethod]
    public void TestSimpleEquals6()
    {        
        FaceEmoji e = new();
        FaceEmoji e1 = new();

        bool isEqual = e1.Equals(e);

        Assert.IsTrue(isEqual);
    }

    [TestMethod]
    public void TestSimpleEquals7()
    {
        FaceEmoji e = new();
        FaceEmoji e1 = new();

        bool isEqual = e1.Equals(e);

        Assert.IsTrue(isEqual);
    }

    [TestMethod]
    public void TestSimpleEquals8()
    {
        AnimalEmoji e = new();
        AnimalEmoji e1 = new();

        e.AnimalPart = "рога";

        bool isEqual = e1.Equals(e);

        Assert.IsFalse(isEqual);
    }

    [TestMethod]
    public void TestSimpleEquals9()
    {
        SmilingEmoji e = new();
        SmilingEmoji e1 = new();

        e.SmileReason = "рога";

        bool isEqual = e1.Equals(e);

        Assert.IsFalse(isEqual);
    }
    #endregion

    #region Тестирование Equals
    [TestMethod]
    public void TestEmojiEquals()
    {
        Emoji e = new();
        Emoji e1 = new();

        bool isEqual = e.Equals(e1);

        Assert.IsTrue(isEqual);
    }

    [TestMethod]
    public void TestFaceEmojiEquals()
    {
        FaceEmoji e = new();
        FaceEmoji e1 = new();

        bool isEqual = e1.Equals(e);

        Assert.IsTrue(isEqual);
    }

    [TestMethod]
    public void TestAnimalEmojiEquals1()
    {
        AnimalEmoji e = new();
        AnimalEmoji e1 = new();

        bool isEqual = e1.Equals(e);

        Assert.IsTrue(isEqual);
    }

    [TestMethod]
    public void TestAnimalEmojiEquals2()
    {
        AnimalEmoji e = new();
        SmilingEmoji e1 = new();

        bool isEqual = e1.Equals(e);

        Assert.IsFalse(isEqual);
    }

    [TestMethod]
    public void TestSmilingEmojiEquals1()
    {
        SmilingEmoji e = new();
        SmilingEmoji e1 = new();

        bool isEqual = e1.Equals(e);

        Assert.IsTrue(isEqual);
    }

    [TestMethod]
    public void TestSmilingEmojiEquals2()
    {
        SmilingEmoji e = new();
        Emoji e1 = new();

        bool isEqual = e.Equals(e1);

        Assert.IsFalse(isEqual);
    }

    [TestMethod]
    public void TestEquals1()
    {
        SmilingEmoji e1 = new();

        bool isEqual = e1.Equals(e1);

        Assert.IsTrue(isEqual);
    }
    #endregion
}
