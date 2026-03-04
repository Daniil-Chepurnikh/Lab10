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
        public void TestWithParameters()
        {
            Emoji e = new("Роза", "Цветок", 1);

            Assert.AreEqual("Роза", e.Name);
            Assert.AreEqual("Цветок", e.Tag);
        }

        [TestMethod]
        public void TestStrangeNameTag()
        {
            Emoji e = new("       q         ", "             p              ", 1);

            Assert.AreEqual("       q         ", e.Name);
            Assert.AreEqual("             p              ", e.Tag);
        }

        [TestMethod]
        public void TestNumberString()
        {
            var isPassed = false;
            try
            {
                Emoji e = new("1", "", 11);
            }
            catch (ArgumentException)
            {
                isPassed = true; 
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestLongString()
        {
            var isPassed = false;
            try
            {
                Emoji e = new("llsslssk", "g g w p", 1);
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestSpecialString()
        {
            Emoji e = new("!", "@ p", 1);

            Assert.AreEqual("!", e.Name);
            Assert.AreEqual("@ p", e.Tag);
        }

    }

}
