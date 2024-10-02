using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = int.Parse(Console.ReadLine());

        int maxSum = int.MinValue;
        int currentSum = 0;
        bool chet = false;
        
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"Введите элемент {i}: ");
            int curr = int.Parse(Console.ReadLine());

            if (curr % 2 == 0)
            {
                currentSum += curr;
                chet = true;
            }
            else
            {
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                currentSum = 0;
            }
        }
        
        if (currentSum > maxSum)
        {
            maxSum = currentSum;
        }

        if (chet)
        {
            Console.WriteLine($"Максимальная сумма подпоследовательности из четных элементов: {maxSum}");
        }
        else
        {
            Console.WriteLine("Четных элементов в последовательности нет.");
        }
    }
}
