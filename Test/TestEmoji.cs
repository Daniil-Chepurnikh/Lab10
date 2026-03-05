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

        [TestMethod]
        public void TestTagsArray()
        {
            string t = Emoji.tags[2];

            Assert.AreEqual("мат", t);
        }

        [TestMethod]
        public void TestNamesArray()
        {
            string n = Emoji.names[2];

            Assert.AreEqual("мат", n);
        }

    }

}
