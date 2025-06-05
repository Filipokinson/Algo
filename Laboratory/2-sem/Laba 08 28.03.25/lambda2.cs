using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> words = new List<string> {"мопед", "мыло", "машина", "стол", "Москва", "дверь"};
        var filteredWords = words.Where(word => word.ToLower().StartsWith("м"));
        Console.WriteLine("Слова, начинающиеся на 'м':");
        foreach (var word in filteredWords)
        {
            Console.WriteLine(word);
        }
    }
}
