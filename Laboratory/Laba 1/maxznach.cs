using System;

class Program
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        int max = (a + b + Math.Abs(a - b)) / 2;

        Console.WriteLine($"Наибольшее значение: {max}");
    }
}
