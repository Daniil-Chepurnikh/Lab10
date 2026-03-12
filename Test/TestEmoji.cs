using LibraryEmoji;

namespace Tests
{
    [TestClass]
    public sealed class TestEmoji
    {
        // TODO: добавить тесты интерефейсов




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

            Assert.AreEqual("печаль", n);
        }

        [TestMethod]
        public void TestName1()
        {
            Emoji e = new();
            bool isPassed = false;
            try
            {
                e.Name = "1234";
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestName2()
        {
            Emoji e = new();
            bool isPassed = false;
            try
            {
                e.Name = "q q q";
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestName3()
        {
            Emoji e = new();
            bool isPassed = false;
            try
            {
                e.Name = "";
            }
            catch (ArgumentNullException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestTag1()
        {
            Emoji e = new();
            bool isPassed = false;
            try
            {
                e.Tag = "1234";
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestRTag2()
        {
            Emoji e = new();
            bool isPassed = false;
            try
            {
                e.Tag = "q q q";
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestTag3()
        {
            Emoji e = new();
            bool isPassed = false;
            try
            {
                e.Tag = "";
            }
            catch (ArgumentNullException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestShowToString()
        {
            Emoji e = new();

            string toString = e.ToString();
            string show = e.ToString();
            string showVirtual = e.ToString();

            Assert.AreEqual(showVirtual, show);
            Assert.AreEqual(toString, show);
            Assert.AreEqual(showVirtual, toString);
        }
    }
}
