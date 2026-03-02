using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestFaceEmoji
{
    // Написать тесты
    
    [TestMethod]
    public void TestCloneNull()
    {
        Emoji e;
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
}
