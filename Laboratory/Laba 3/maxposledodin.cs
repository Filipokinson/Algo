using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите элемент 1: ");
        int prev = Convert.ToInt32(Console.ReadLine());

        int maxLength = 1;
        int currentLength = 1;

        for (int i = 2; i <= n; i++)
        {
            Console.Write($"Введите элемент {i}: ");
            int curr = Convert.ToInt32(Console.ReadLine());

            if (curr == prev)
            {
                currentLength++;
            }
            else
            {
                maxLength = Math.Max(maxLength, currentLength);
                currentLength = 1;
            }

            prev = curr;
        }

        maxLength = Math.Max(maxLength, currentLength);

        Console.WriteLine($"Максимальная длина подпоследовательности из одинаковых элементов: {maxLength}");
    }
}
