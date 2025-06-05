using System;
using System.Collections.Generic;

public class Phone
{
    public string Number { get; set; }
    public string FullName { get; set; }
    public string Operator { get; set; }
}

class Program
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        
        Console.WriteLine("Сколько телефонов добавить?");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите данные телефона {i + 1}:");
            
            Console.Write("Номер: ");
            string number = Console.ReadLine();
            
            Console.Write("ФИО: ");
            string fullName = Console.ReadLine();
            
            Console.Write("Оператор: ");
            string operatorName = Console.ReadLine();
            
            phones.Add(new Phone
            {
                Number = number,
                FullName = fullName,
                Operator = operatorName
            });
        }

        var operatorCounts = new Dictionary<string, int>();
        foreach (var phone in phones)
        {
            if (operatorCounts.ContainsKey(phone.Operator))
                operatorCounts[phone.Operator]++;
            else
                operatorCounts.Add(phone.Operator, 1);
        }

        string mostPopularOperator = "";
        int maxCount = 0;
        foreach (var pair in operatorCounts)
        {
            if (pair.Value > maxCount)
            {
                maxCount = pair.Value;
                mostPopularOperator = pair.Key;
            }
        }

        if (!string.IsNullOrEmpty(mostPopularOperator))
        {
            Console.WriteLine($"Самый популярный оператор: {mostPopularOperator}");
            Console.WriteLine($"Количество: {maxCount}");
        }
        else
        {
            Console.WriteLine("Нет данных");
        }
    }
}