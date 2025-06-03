using System;

class Program
{
    unsafe static void Main()
    {
        Console.Write("Введите количество строк: ");
        int lineCount = int.Parse(Console.ReadLine());
        string[] lines = new string[lineCount];

        for (int i = 0; i < lineCount; i++)
        {
            Console.Write($"Строка {i + 1}: ");
            lines[i] = Console.ReadLine();
        }

        int* freq = stackalloc int[256];
        for (int i = 0; i < 256; i++)
            freq[i] = 0;

        for (int i = 0; i < lineCount; i++)
        {
            string line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];
                if (c < 256)
                    freq[c]++;
            }
        }

        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < 256; i++)
        {
            if (freq[i] > 0 && freq[i] < min)
                min = freq[i];
            if (freq[i] > max)
                max = freq[i];
        }

        Console.Write("Реже всего встречались: ");
        bool foundMin = false;
        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == min)
            {
                Console.Write($"'{(char)i}' ");
                foundMin = true;
            }
        }
        if (!foundMin) Console.Write("Нет символов");

        Console.WriteLine();

        Console.Write("Чаще всего встречались: ");
        bool foundMax = false;
        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == max && max > 0)
            {
                Console.Write($"'{(char)i}' ");
                foundMax = true;
            }
        }
        if (!foundMax) Console.Write("Нет символов");

        Console.WriteLine();
    }
}
