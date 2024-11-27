using System;

class Laba
{
    private int a;
    private int b;

    public Laba()
    {
        a = 0;
        b = 0;
    }

    public Laba(int firstValue)
    {
        a = firstValue;
        b = 0;
    }

    public Laba(int firstValue, int secondValue)
    {
        a = firstValue;
        b = secondValue;
    }

    public int Sum()
    {
        return a + b;
    }

    public int Umnozh()
    {
        return a * b;
    }

    public int Raznost()
    {
        return a - b;
    }

    public double Delenie()
    {
        if (b == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль.");
            return Double.NaN;
        }

        return (double)a / b;
    }

    public void DisplayValues()
    {
        Console.WriteLine($"a = {a}, b = {b}");
    }
}

class Program
{
    static void Main()
    {
        Laba obj1 = new Laba();
        obj1.DisplayValues();
        Console.WriteLine($"Сумма: {obj1.Sum()}");
        Console.WriteLine($"Произведение: {obj1.Umnozh()}");
        Console.WriteLine($"Разность: {obj1.Raznost()}");
        Console.WriteLine($"Частное: {obj1.Delenie()}");

        Console.WriteLine();

        Laba obj2 = new Laba(5);
        obj2.DisplayValues();
        Console.WriteLine($"Сумма: {obj2.Sum()}");
        Console.WriteLine($"Произведение: {obj2.Umnozh()}");
        Console.WriteLine($"Разность: {obj2.Raznost()}");
        Console.WriteLine($"Частное: {obj2.Delenie()}");

        Console.WriteLine();

        Laba obj3 = new Laba(10, 2);
        obj3.DisplayValues();
        Console.WriteLine($"Сумма: {obj3.Sum()}");
        Console.WriteLine($"Произведение: {obj3.Umnozh()}");
        Console.WriteLine($"Разность: {obj3.Raznost()}");
        Console.WriteLine($"Частное: {obj3.Delenie()}");
    }
}
