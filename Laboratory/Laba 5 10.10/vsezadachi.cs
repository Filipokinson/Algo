//дан массив из n положительных целых элементов

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество элементов массива:");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        // 1) Подсчет количества чисел, все цифры которых четные
        int countchet = 0;
        foreach (int num in array)
        {
            if (AllDigitsEven(num))
            {
                countchet++;
            }
        }

        Console.WriteLine($"Количество чисел, все цифры которых четные: {countchet}");

        // 2) Замена четных элементов на 0, нечетных - на 1
        int[] transformedArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            transformedArray[i] = (array[i] % 2 == 0) ? 0 : 1;
        }

        Console.WriteLine("Трансформированный массив:");
        Console.WriteLine(string.Join(" ", transformedArray));

        // 3) Формирование выходного массива, где сначала все четные элементы, а потом нечетные
        List<int> chet = new List<int>();
        List<int> Nechet = new List<int>();

        foreach (int num in array)
        {
            if (num % 2 == 0)
            {
                chet.Add(num);
            }
            else
            {
                Nechet.Add(num);
            }
        }

        chet.AddRange(Nechet);
        int[] outputArray = chet.ToArray();

        Console.WriteLine("Выходной массив (сначала четные, потом нечетные):");
        Console.WriteLine(string.Join(" ", outputArray));
    }

    static bool AllDigitsEven(int num)
    {
        while (num > 0)
        {
            int digit = num % 10;
            if (digit % 2 != 0) return false;
            num /= 10;
        }
        return true;
    }
}
