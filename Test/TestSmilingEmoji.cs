using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestSmilingEmoji
{
    [TestMethod]
    public void TestInit()
    {
        // 1. Подготовка: Создаем строку с ожидаемыми значениями
        // Используем Environment.NewLine для имитации нажатия Enter
        string simulatedInput = $"www{Environment.NewLine}eee{Environment.NewLine}qqq{Environment.NewLine}5{Environment.NewLine}vvv{Environment.NewLine}";

        // 2. Перенаправляем стандартный ввод на наш StringReader
        StringReader reader = new StringReader(simulatedInput);
        Console.SetIn(reader);

        // 3. Вызываем метод, который использует Console.ReadLine()
        SmilingEmoji a = new SmilingEmoji(new IdNumber(111));

        // 4. Проверяем результаты
        Assert.AreEqual("www", a.Name);
        Assert.AreEqual("eee", a.Tag);
        Assert.AreEqual("vvv", a.SmileReason);
        Assert.AreEqual("qqq", a.Expression);
        Assert.AreEqual(5, a.Strength);
    }


    [TestMethod]
    public void TestCopy()
    {
        SmilingEmoji smile = new SmilingEmoji
        {
            Expression = "qqqq",
            Name = "pppp",
            SmileReason = "hhhh",
            Strength = 1,
            Tag = "oooo",
            Number = new(190)
        };

        SmilingEmoji smileCopy = smile.ShallowCopy();

        Assert.AreEqual(smile, smileCopy);

        smile.Name = "русский рок";
        smile.Expression = "рок жив";
        smile.Strength = 9;
        smile.Tag = "Манчестер Красный";
        smile.Number.Number = new();
        smile.SmileReason = "ssss";

        Assert.AreNotEqual(smileCopy.Tag, smile.Tag);
        Assert.AreNotEqual(smileCopy.Name, smile.Name);
        Assert.AreEqual(smileCopy.Number, smile.Number);
        Assert.AreNotEqual(smileCopy.Expression, smile.Expression);
        Assert.AreNotEqual(smileCopy.Strength, smile.Strength);
    }

    [TestMethod]
    public void TestClone()
    {
        SmilingEmoji emo = new SmilingEmoji { Name = "qqq", Tag = "fwfff", SmileReason = "Нафиг унывать", Expression = ":)))", Strength = 1 };

        SmilingEmoji emoClone = (SmilingEmoji)emo.Clone();

        Assert.AreEqual(emo, emoClone);

        emo.SmileReason = "www";
        emo.Strength = 9;
        emo.Expression = "*_*";
        emo.Name = "qwerty";
        emo.Tag = "zxcvb";
        emo.Number = new(3);

        Assert.AreNotEqual(emoClone.Tag, emo.Tag);
        Assert.AreNotEqual(emoClone.Name, emo.Name);
        Assert.AreNotEqual(emoClone.Number, emo.Number);
        Assert.AreNotEqual(emoClone.Expression, emo.Expression);
        Assert.AreNotEqual(emoClone.Strength, emo.Strength);
    }

    [TestMethod]
    public void TestWithParameters()
    {
        SmilingEmoji e = new("q", "p", "h", "o", 10, new IdNumber(9));

        Assert.AreEqual(expected: "p", actual: e.Tag);
        Assert.AreEqual(expected: "q", actual: e.Name);
        Assert.AreEqual(expected: new IdNumber(9), actual: e.Number);
        Assert.AreEqual(expected: "h", actual: e.Expression);
        Assert.AreEqual(expected: 10, actual: e.Strength);
        Assert.AreEqual(expected: "o", actual: e.SmileReason);
    }

    [TestMethod]
    public void TestGetHashCode()
    {
        SmilingEmoji e = new();

        int hash1 = e.GetHashCode();

        e.SmileReason = "Реал Мадрид";

        int hash2 = e.GetHashCode();

        Assert.AreNotEqual(hash1, hash2);
    }

    [TestMethod]
    public void TestWithoutParameters()
    {
        SmilingEmoji e = new();

        Assert.AreEqual("Просто улыбается", e.SmileReason);
    }

    [TestMethod]
    public void TestSmileReasons()
    {
        string s = SmilingEmoji.smileReasons[1];

        Assert.AreEqual("победа команды", s);
    }

    [TestMethod]
    public void TestSmileReason1()
    {
        SmilingEmoji e = new();
        bool isPassed = false;
        try
        {
            e.SmileReason = "     ";
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestSmileReason2()
    {
        SmilingEmoji e = new();
        bool isPassed = false;
        try
        {
            e.SmileReason = "";
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestSmileReason3()
    {
        SmilingEmoji e = new();
        bool isPassed = false;
        try
        {
            e.SmileReason = "q q q";
        }
        catch (ArgumentException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestShowToString()
    {
        Random rnd = new Random();

        SmilingEmoji e = new(rnd);

        string toString = e.ToString();
        string show = e.Show();
        string showVirtual = e.VirtualShow();

        Assert.AreEqual(showVirtual, show);
        Assert.AreEqual(toString, show);
        Assert.AreEqual(showVirtual, toString);
    }
}
