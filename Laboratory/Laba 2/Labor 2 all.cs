using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = int.Parse(Console.ReadLine());

        int prev = 0, curr = 0, next = 0;
        int localMinCount = 0;
        bool allEven = true;
        int max1 = int.MinValue, max2 = int.MinValue;

        Console.Write("Введите элемент 1: ");
        prev = int.Parse(Console.ReadLine());
        if (prev % 2 != 0)
        {
            allEven = false;
        }
        max1 = prev;

        Console.Write("Введите элемент 2: ");
        curr = int.Parse(Console.ReadLine());
        if (curr % 2 != 0)
        {
            allEven = false;
        }
        if (curr > max1)
        {
            max2 = max1;
            max1 = curr;
        }
        else
        {
            max2 = curr;
        }

        for (int i = 3; i <= n; i++)
        {
            Console.Write($"Введите элемент {i}: ");
            next = int.Parse(Console.ReadLine());

            if (next % 2 != 0)
            {
                allEven = false;
            }

            if (curr < prev && curr < next)
            {
                localMinCount++;
            }

            if (next > max1)
            {
                max2 = max1;
                max1 = next;
            }
            else if (next > max2)
            {
                max2 = next;
            }

            prev = curr;
            curr = next;
        }

        Console.WriteLine($"Количество локальных минимумов: {localMinCount}");
        Console.WriteLine($"Все элементы чётные: {allEven}");
        Console.WriteLine($"Два максимальных значения: {max1} и {max2}");
    }
}