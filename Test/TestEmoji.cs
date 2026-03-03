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
            Assert.AreEqual(e.Name, clone.Name);
            Assert.AreNotEqual(e.Tag, clone.Tag);
        }

        [TestMethod]
        public void TestNullName()
        {
            Emoji e;
            var isPassed = false;
            try
            {
                e = new(null, "No");
            }
            catch(ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestNullTag()
        {
            Emoji e;
            var isPassed = false;
            try
            {
                e = new("null", null);
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestEmptyTag()
        {
            Emoji e;
            var isPassed = false;
            try
            {
                e = new("null", "");
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
            Emoji e;
            var isPassed = false;
            try
            {
                e = new("", "q");
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestWhiteSpaceTag()
        {
            Emoji e;
            var isPassed = false;
            try
            {
                e = new("null", "                   ");
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
            Emoji e;
            var isPassed = false;
            try
            {
                e = new("                ", "q");
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestStrangeNameTag()
        {
            Emoji e = new("       q         ", "             p              ");

            Assert.AreEqual("       q         ", e.Name);
            Assert.AreEqual("             p              ", e.Tag);
        }

        [TestMethod]
        public void TestNumberTag()
        {
            var isPassed = false;
            try
            {
                Emoji e = new("1", "             p              ");
            }
            catch (ArgumentException)
            {
                isPassed = true; 
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestNumberName()
        {
            var isPassed = false;
            try
            {
                Emoji e = new("p", "1");
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }
    }
}
