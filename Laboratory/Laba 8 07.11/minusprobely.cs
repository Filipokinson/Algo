using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку с лишними пробелами");
        string n =Convert.ToString(Console.ReadLine());
        
        string formatted = string.Join(" ", n.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        Console.WriteLine($"Отформатированная строка: '{formatted}'");
    }
}