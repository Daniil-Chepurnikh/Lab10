using LibraryEmoji;

namespace Tests
{
    [TestClass]
    public sealed class TestEmoji
    {
        [TestMethod]
        public void TestWithoutParameters()
        {
            Emoji e = new();

            Assert.AreEqual("Без названия", e.Name);
            Assert.AreEqual("Без тега", e.Tag);
        } 

    }

}
