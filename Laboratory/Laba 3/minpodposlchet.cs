using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите элемент 1: ");
        int prev = int.Parse(Console.ReadLine());

        int minLength = int.MaxValue;
        int currentLength = 0; 
        bool chet = false;
        
        if (prev % 2 == 0)
        {
            currentLength = 1;
            chet = true;
        }

        for (int i = 2; i <= n; i++)
        {
            Console.Write($"Введите элемент {i}: ");
            int curr = int.Parse(Console.ReadLine());

            if (curr % 2 == 0)
            {
                if (prev % 2 == 0)
                {
                    currentLength++;
                }
                else
                {
                    currentLength = 1;
                }

                chet = true;
            }
            else
            {
                if (currentLength > 0 && currentLength < minLength)
                {
                    minLength = currentLength;
                }
                currentLength = 0;
            }

            prev = curr;
        }

        if (currentLength > 0 && currentLength < minLength)
        {
            minLength = currentLength;
        }

        if (chet)
        {
            Console.WriteLine($"Минимальная длина подпоследовательности из четных элементов: {minLength}");
        }
        else
        {
            Console.WriteLine("Четных элементов в последовательности нет.");
        }
    }
}
