using LibraryEmoji;

namespace Tests
{
    [TestClass]
    public sealed class TestFaceEmoji
    {
        [TestMethod]
        public void TestCopy()
        {
            FaceEmoji smile = new FaceEmoji
            {
                Expression = "qqqq",
                Name = "pppp",
                Strength = 1,
                Tag = "oooo",
                IdNumber = new(190)
            };

            FaceEmoji smileCopy = smile.ShallowCopy();

            Assert.AreEqual(smile, smileCopy);

            smile.Name = "русский рок";
            smile.Expression = "рок жив";
            smile.Strength = 9;
            smile.Tag = "Манчестер Красный";
            smile.IdNumber.Number = new();

            Assert.AreNotEqual(smileCopy.Tag, smile.Tag);
            Assert.AreNotEqual(smileCopy.Name, smile.Name);
            Assert.AreEqual(smileCopy.IdNumber, smile.IdNumber);
            Assert.AreNotEqual(smileCopy.Expression, smile.Expression);
            Assert.AreNotEqual(smileCopy.Strength, smile.Strength);
        }

        [TestMethod]
        public void TestWithParameters()
        {
            FaceEmoji e = new("q", "p", new IdNumber(9), "h", 10);

            Assert.AreEqual(expected: "p", actual: e.Tag);
            Assert.AreEqual(expected: "q", actual: e.Name);
            Assert.AreEqual(expected: new IdNumber(9), actual: e.IdNumber);
            Assert.AreEqual(expected: "h", actual: e.Expression);
            Assert.AreEqual(expected: 10, actual: e.Strength);
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            FaceEmoji e = new();

            int hash1 = e.GetHashCode();

            e.Expression = "-----_-------";
            e.Strength = 7;

            int hash2 = e.GetHashCode();

            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void TestWithoutParameters()
        {
            FaceEmoji e = new();

            Assert.AreEqual("Нет выражения", e.Expression);
            Assert.AreEqual(0, e.Strength);
        }

        [TestMethod]
        public void TestExpression()
        {
            FaceEmoji e = new();

            bool isPassed = false;
            try
            {
                e.Expression = "                        ";
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }


        [TestMethod]
        public void TestStrength()
        {
            FaceEmoji e = new();

            bool isPassed = false;
            try
            {
                e.Strength = 1111;
            }
            catch (ArgumentOutOfRangeException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestShowToString()
        {
            Random rnd = new Random();

            FaceEmoji e = new(rnd);

            string toString = e.ToString();
            string show = e.Show();
            string showVirtual = e.VirtualShow();

            Assert.AreEqual(showVirtual, show);
            Assert.AreEqual(toString, show);
            Assert.AreEqual(showVirtual, toString);
        }
    }
}
