using LibraryEmoji;

namespace Tests
{
    [TestClass]
    public sealed class TestFaceEmoji
    {
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
