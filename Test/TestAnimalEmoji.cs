using LibraryEmoji;

namespace Tests;

[TestClass]
public class TestAnimalEmoji
{
    [TestMethod]
    public void TestInit()
    {
        // 1. Подготовка: Создаем строку с ожидаемыми значениями
        // Используем Environment.NewLine для имитации нажатия Enter
        string simulatedInput = $"www{Environment.NewLine}eee{Environment.NewLine}vvv{Environment.NewLine}";

        // 2. Перенаправляем стандартный ввод на наш StringReader
        StringReader reader = new StringReader(simulatedInput);
        Console.SetIn(reader);

        // 3. Вызываем метод, который использует Console.ReadLine()
        AnimalEmoji a = new AnimalEmoji(new IdNumber(111));

        // 4. Проверяем результаты
        Assert.AreEqual("www", a.Name);
        Assert.AreEqual("eee", a.Tag);
        Assert.AreEqual("vvv", a.AnimalPart);
    }

    [TestMethod]
    public void TestClone()
    {
        AnimalEmoji emo = new AnimalEmoji { Name = "qqq", Tag = "fwfff", AnimalPart = "Нафиг унывать" };

        AnimalEmoji emoClone = (AnimalEmoji)emo.Clone();

        Assert.AreEqual(emo, emoClone);

        emo.AnimalPart = "www";
        emo.Name = "qwerty";
        emo.Tag = "zxcvb";
        emo.Number = new(3);

        Assert.AreNotEqual(emoClone.Tag, emo.Tag);
        Assert.AreNotEqual(emoClone.Name, emo.Name);
        Assert.AreNotEqual(emoClone.Number, emo.Number);
        Assert.AreNotEqual(emoClone.AnimalPart, emo.AnimalPart);
    }

    [TestMethod]
    public void TestCopy()
    {
        AnimalEmoji e = new AnimalEmoji { Name = "pppp", Tag = "oooo", Number = new(190), AnimalPart = "www" };
        AnimalEmoji copy = e.ShallowCopy();

        Assert.AreEqual(copy, e);

        copy.Name = "русский рок";
        copy.Tag = "Манчестер Красный";
        copy.Number.Number = new();
        copy.AnimalPart = "qqqqqqqqqqqqqqqqqqqqqqq";

        Assert.AreNotEqual(copy.Tag, e.Tag);
        Assert.AreNotEqual(copy.Name, e.Name);
        Assert.AreNotEqual(copy.AnimalPart, e.AnimalPart);
        Assert.AreEqual(copy.Number, e.Number);
    }

    [TestMethod]
    public void TestWithParameters()
    {
        AnimalEmoji e = new("q", "p", "h", new IdNumber(9));

        Assert.AreEqual(expected: "p", actual: e.Tag);
        Assert.AreEqual(expected: "q", actual: e.Name);
        Assert.AreEqual(expected: new IdNumber(9), actual: e.Number);
        Assert.AreEqual(expected: "h", actual: e.AnimalPart);
    }

    [TestMethod]
    public void TestGetHashCode()
    {
        AnimalEmoji e = new();

        int hash1 = e.GetHashCode();

        e.AnimalPart = "Муха вертолёт";

        int hash2 = e.GetHashCode();

        Assert.AreNotEqual(hash1, hash2);
    }

    [TestMethod]
    public void TestWithoutParameters()
    {
        AnimalEmoji e = new();

        Assert.AreEqual("Часть тела", e.AnimalPart);
    }

    [TestMethod]
    public void TestAnimalParts()
    {
        string a = AnimalEmoji.animalParts[2];

        Assert.AreEqual("хвост", a);
    }

    [TestMethod]
    public void TestAnimalPart1()
    {
        AnimalEmoji e = new();
        bool isPassed = false;
        try
        {
            e.AnimalPart = null;
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestAnimalPart2()
    {
        AnimalEmoji e = new();
        bool isPassed = false;
        try
        {
            e.AnimalPart = "";
        }
        catch (ArgumentNullException)
        {
            isPassed = true;
        }

        Assert.IsTrue(isPassed);
    }

    [TestMethod]
    public void TestAnimalPart3()
    {
        AnimalEmoji e = new();
        bool isPassed = false;
        try
        {
            e.AnimalPart = "                                      ";
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
        Random rnd = new Random();
        
        AnimalEmoji e = new(rnd);

        string toString = e.Show();
        string show = e.Show();
        string showVirtual = e.VirtualShow();

        Assert.AreEqual(showVirtual, show);
        Assert.AreEqual(toString, show);
        Assert.AreEqual(showVirtual, toString);
    }
}
