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
        public void TestWhiteStrangeNameTag()
        {
            Emoji e = new("       q         ", "             p              ");

            Assert.AreEqual("       q         ", e.Name);
            Assert.AreEqual("             p              ", e.Tag);
        }

        [TestMethod]
        public void TestEquals1()
        {
            Emoji e1 = new("Роза", "Цветок");
            Emoji e2 = new("Роза", "Цветок");

            var res = e1.Equals(e2);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestEquals2()
        {
            Emoji e1 = new("Роза", "Цветок");
            Emoji e2 = new("Роза", "Цвето");

            var res = e1.Equals(e2);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void TestEquals3()
        {
            Emoji e1 = new("Роза", "Цветок");
            Emoji e2 = new("Роз", "Цветок");

            var res = e1.Equals(e2);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void TestEquals4()
        {
            Emoji e1 = new("Роза", "Цветок");

            var res = e1.Equals(null);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void TestEquals5()
        {
            Emoji e1 = new("Роза", "Цветок");
            AnimalEmoji e = new();
            var res = e1.Equals(e);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void TestEquals6()
        {
            Emoji e1 = new("Роза", "Цветок");
            FaceEmoji e2 = new();
            
            var res = e1.Equals(e2);

            Assert.IsFalse(res);
        }
    }
}
