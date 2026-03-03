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
        }

        [TestMethod]
        public void TestWithParameters()
        {
            Emoji e = new("Роза", "Цветок");

            Assert.AreEqual("Роза", e.Name);
            Assert.AreEqual("Цветок", e.Tag);
        }

        [TestMethod]
        public void TestCloneCorrect()
        {
            FaceEmoji e = new("n", "n", "null");

            Assert.AreEqual("null", e.Expression);
        }

        [TestMethod]
        public void TestEmptyExpression()
        {
            FaceEmoji e;
            var isPassed = false;
            try
            {
                e = new("ddd", "No", "");
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
                e = new("null", "null", null);
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
                e = new("null", "null", "  ");
            }
            catch (ArgumentException)
            {
                isPassed = true;
            }

            Assert.IsTrue(isPassed);
        }
    }
}
