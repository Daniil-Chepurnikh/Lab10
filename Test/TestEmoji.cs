using LibraryEmoji;

namespace Tests
{
    [TestClass]
    public sealed class TestEmoji
    {
        // TODO: добавить тесты IComparer ICloneable

        [TestMethod]
        public void TestCompareTo1()
        {
            Emoji e = new();
            Emoji e1 = new();

            e.Name = "Абат";
            e1.Name = "Абба";

            int res = e.CompareTo(e1);

            Assert.IsLessThan(0, res);
        }

        [TestMethod]
        public void TestCompareTo2()
        {
            Emoji e = new();
            Emoji e1 = new();

            e.Name = "Аб";
            e1.Name = "Абб";

            int res = e.CompareTo(e1);

            Assert.IsLessThan(0, res);
        }

        [TestMethod]
        public void TestCompareTo3()
        {
            Emoji e = new();
            Emoji e1 = new();

            e.Tag = "Аб";
            e1.Tag = "Ав";

            int res = e.CompareTo(e1);

            Assert.IsLessThan(0, res);
        }


        [TestMethod]
        public void TestWithoutParameters()
        {
            Emoji e = new();

            IdNumber num = new();
            
            Assert.AreEqual("Без названия", e.Name);
            Assert.AreEqual("Без тега", e.Tag);
            Assert.AreEqual(num, e._number);
        }

        [TestMethod]
        public void TestIdNumber()
        {
            Emoji e = new();
            bool isPassed = false;
            try
            {
                IdNumber num = new(-11111);
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }
            Assert.IsTrue(isPassed);
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
