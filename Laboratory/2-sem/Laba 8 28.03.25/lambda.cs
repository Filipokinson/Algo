using System;

class Program
{
    static void Main()
    {
        int a = 10;
        int b = 0;

        Func<int, int, int> add = (x, y) => x + y;
        Func<int, int, int> subtract = (x, y) => x - y;
        Func<int, int, int> multiply = (x, y) => x * y;
        Func<int, int, int> divide = (x, y) => y != 0 ? x / y : throw new DivideByZeroException("Ошибка: деление на ноль");

        Console.WriteLine($"Сложение: {add(a, b)}");
        Console.WriteLine($"Вычитание: {subtract(a, b)}");
        Console.WriteLine($"Умножение: {multiply(a, b)}");
        Console.WriteLine($"Деление: {divide(a,b)}");
    }
}
