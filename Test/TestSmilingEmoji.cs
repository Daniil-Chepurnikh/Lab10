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
}
