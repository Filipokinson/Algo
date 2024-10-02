using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите элемент 1: ");
        int prev = int.Parse(Console.ReadLine());
        
        int maxLength = 1;
        int currentLength = 1;

        for (int i = 2; i <= n; i++)
        {
            Console.Write($"Введите элемент {i}: ");
            int curr = int.Parse(Console.ReadLine());

            if (curr == prev)
            {
                currentLength++;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }
                currentLength = 1;
            }

            prev = curr;
        }

        if (currentLength > maxLength)
        {
            maxLength = currentLength;
        }

        Console.WriteLine($"Максимальная длина подпоследовательности из одинаковых элементов: {maxLength}");
    }
}
