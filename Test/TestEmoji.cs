using LibraryEmoji;

namespace Tests
{
    [TestClass]
    public sealed class TestEmoji
    {
        // TODO: добавить тесты ICloneable

        // TODO: добавить тесты конкструктора с параметрами

        [TestMethod]
        public void TestGetHashCode()
        {
            Emoji e = new();

            int hash1 = e.GetHashCode();

            e.Name = "Cristiano Ronaldo";
            e.Tag = "Manchester United";
            e._number = new(7);

            int hash2 = e.GetHashCode();

            Assert.AreNotEqual(hash1, hash2);
        }

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
        public void TestIdNumber1()
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
        public void TestIdNumber2()
        {
            IdNumber e = new(5);
            IdNumber e1 = new(1);
            
            Assert.IsFalse(e.Equals(e1));
        }

        [TestMethod]
        public void TestIdNumber3()
        {
            IdNumber e = new(1);
            IdNumber e1 = new(1);

            Assert.IsTrue(e1.Equals(e));
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

            string toString = e.Show();
            string show = e.Show();
            string showVirtual = e.VirtualShow();

            Assert.AreEqual(showVirtual, show);
            Assert.AreEqual(toString, show);
            Assert.AreEqual(showVirtual, toString);
        }

        [TestMethod]
        public void TestCompare1()
        {
            Emoji[] emojis = { new Emoji(), new Emoji() };

            emojis[0].Name = "Test";
            emojis[1].Name = "A";
            
            Array.Sort(emojis, new EmojiComparer());

            string name = emojis[0].Name;
            Assert.AreEqual("A", name);
            
        }

        [TestMethod]
        public void TestCompare2() // очень странно. Почему нельзя просто вернуть то же самое исключение что
            // сгенерилось внутри, зачем делать новое под предлогом возникновения старого
        {
            Emoji[] emojis = { new Emoji(), null };
            
            bool isPassed = false;
            try
            {
                Array.Sort(emojis, new EmojiComparer());
            }
            catch (InvalidOperationException)
            {
                isPassed= true;
            }

            Assert.IsTrue(isPassed);
        }

        public void TestCompare3()
        {
            Emoji[] emojis = { null, new Emoji() };

            bool isPassed = false;
            try
            {
                Array.Sort(emojis, new EmojiComparer());
            }
            catch (InvalidOperationException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        public void TestCompare4()
        {
            Emoji[] emojis = { null, null };

            bool isPassed = false;
            try
            {
                Array.Sort(emojis, new EmojiComparer());
            }
            catch (InvalidOperationException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }
    }
}
