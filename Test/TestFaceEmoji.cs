using LibraryEmoji;

namespace Tests
{
    [TestClass]
    public sealed class TestFaceEmoji
    {
        [TestMethod]
        public void TestWithoutParameters()
        {
            FaceEmoji e = new();

            Assert.AreEqual("Нет выражения", e.Expression);
            Assert.AreEqual(0, e.Strength);
        }

        [TestMethod]
        public void TestWithParameters()
        {
            FaceEmoji e = new("Роза", "Цветок", 1, "0^0", 7);

            Assert.AreEqual("0^0", e.Expression);
            Assert.AreEqual(7, e.Strength);
        }

        [TestMethod]
        public void TestEmptyExpression()
        {
            FaceEmoji e;
            var isPassed = false;
            try
            {
                e = new("ddd", "No", 1, "", 7);
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestNullExpression()
        {
            FaceEmoji e;
            var isPassed = false;
            try
            {
                e = new("null", "null", 1, null, 7);
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestWhiteSpaceExpression()
        {
            FaceEmoji e;
            var isPassed = false;
            try
            {
                e = new("null", "null", 1, "  ", 7);
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }

        [TestMethod]
        public void TestBigStrength()
        {
            var isPassed = false;
            try
            {
                FaceEmoji e = new("Роза", "Цветок", 1, "0^0", 11);
            }
            catch (ArgumentOutOfRangeException)
            {
                isPassed = true;
            }
            Assert.IsTrue(isPassed);
        }
    }
}
