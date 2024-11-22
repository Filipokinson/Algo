using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var stroki = new List<string>();
        string input;
        Console.WriteLine("Введите строки (пустая строка для завершения):");
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            stroki.Add(input);
        }

        //1. количество строк, содержащих a*b
        int schet = 0;

        foreach (var line in stroki)
        {
            for (int i = 0; i < line.Length - 2; i++)
            {
                if (char.ToLower(line[i]) == 'a' && char.ToLower(line[i + 2]) == 'b')
                {
                    schet++;
                    break;
                }
            }
        }

        Console.WriteLine($"Количество строк с сочетанием a*b: {schet}");

        //2. максимальная длина подстроки из сочетания abc
        Console.WriteLine("Максимальная длина подстроки abc-like в каждой строке:");

        foreach (var line in stroki)
        {
            int maxLength = 0;
            int currentLength = 0;

            foreach (char ch in line)
            {
                char lowerCh = char.ToLower(ch);
                if (lowerCh == 'a' || lowerCh == 'b' || lowerCh == 'c')
                {
                    currentLength++;
                    maxLength = Math.Max(maxLength, currentLength);
                }
                else
                {
                    currentLength = 0;
                }
            }

            Console.WriteLine($"Строка: \"{line}\" -> Максимальная длина: {maxLength}");
        }
    }
}
