using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа через пробел:");
        string input = Console.ReadLine();
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        List<int> numbers = new List<int>();
        foreach (string part in parts)
        {
            numbers.Add(Convert.ToInt32(part));
        }
        
        HashSet<int> uniqueSet = new HashSet<int>(numbers);

        Dictionary<int, int> frequencyDict = new Dictionary<int, int>();
        foreach (int num in numbers)
        {
            if (frequencyDict.ContainsKey(num))
            {
                frequencyDict[num]++;
            }
            else
            {
                frequencyDict[num] = 1;
            }
        }

        Console.WriteLine("Частота появления элементов:");
        foreach (int element in uniqueSet)
        {
            Console.WriteLine($"Элемент {element} встречается {frequencyDict[element]} раз(а)");
        }
    }
}
