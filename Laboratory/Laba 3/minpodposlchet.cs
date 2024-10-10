using System;

class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int a;  
        int currentLength = 0;
        int minLength = n + 1;

        for (int i = 0; i < n; i++)
        {
            a = Convert.ToInt32(Console.ReadLine());

            if (a % 2 == 0)
            {
                currentLength++;
            }
            else
            {
                if (currentLength > 0) 
                {
                    minLength = Math.Min(currentLength, minLength);
                }
                currentLength = 0;
            }
        }

        if (currentLength > 0) 
        {
            minLength = Math.Min(currentLength, minLength); 
        }

        if (minLength == n + 1)
        {
            Console.WriteLine("Четных элементов в последовательности нет.");
        }
        else
        {
            Console.WriteLine($"Минимальная длина подпоследовательности из четных элементов: {minLength}");
        }
    }
}
