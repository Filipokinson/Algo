using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int maxSum = 0;
        int currentSum = 0; 

        for (int i = 1; i <= n; i++)
        {
            Console.Write($"Введите элемент {i}: ");
            int curr = Convert.ToInt32(Console.ReadLine());

            if (curr % 2 == 0)
            {
                currentSum += curr;
            }
            else
            {
                maxSum = Math.Max(maxSum, currentSum);
                currentSum = 0;
            }
        }

        maxSum = Math.Max(maxSum, currentSum);

        if (maxSum > 0)
        {
            Console.WriteLine($"Максимальная сумма подпоследовательности из четных элементов: {maxSum}");
        }
        else
        {
            Console.WriteLine("Четных элементов в последовательности нет.");
        }
    }
}
