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
            Emoji e = new("Роза", "Цветок");

            Assert.AreEqual("Роза", e.Name);
            Assert.AreEqual("Цветок", e.Tag);
        }

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

        [TestMethod]
        public void TestCloneCorrect()
        {
            Emoji e = new("Yes", "No");
            Emoji clone = new(e);

            Assert.AreEqual(e.Name, clone.Name);
            Assert.AreEqual(e.Tag, clone.Tag);

            e.Tag = "May be";
            Assert.AreNotEqual(e.Tag, clone.Tag);
            Assert.AreEqual(e.Name, clone.Name);
        }

        [TestMethod]
        public void TestStrangeNameTag()
        {
            Emoji e = new("       q         ", "             p              ");

            Assert.AreEqual("       q         ", e.Name);
            Assert.AreEqual("             p              ", e.Tag);
        }

        [TestMethod]
        public void TestNumberString()
        {
            var isPassed = false;
            try
            {
                Emoji e = new("1", "");
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
                Emoji e = new("llsslssk", "      w r w       p              ");
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

    }
}
