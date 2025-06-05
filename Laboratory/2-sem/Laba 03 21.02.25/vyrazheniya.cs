using System;
using System.Collections.Generic;

class Program
{
    static bool Proverka(string stroka)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char s in stroka)
        {
            if (s == '(' || s == '[' || s == '{')
            {
                stack.Push(s);
            }
            else if (s == ')' || s == ']' || s == '}')
            {
                if (stack.Count == 0)
                    return false;

                char top = stack.Pop();
                
                if ((s == ')' && top != '(') || (s == ']' && top != '[') || (s == '}' && top != '{'))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    static void Main()
    {
        Console.WriteLine("Введите арифметическое выражение:");
        string input = Console.ReadLine();

        if (Proverka(input))
        {
            Console.WriteLine("Скобки расставлены правильно");
        }
        else
        {
            Console.WriteLine("Скобки расставлены неправильно");
        }
    }
}
