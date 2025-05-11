using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Stack<int> stack = new Stack<int>();

        foreach (string element in elements)
        {
            switch (element)
            {
                case "+":
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    stack.Push(operand1 + operand2);
                    break;
                case "-":
                    operand2 = stack.Pop();
                    operand1 = stack.Pop();
                    stack.Push(operand1 - operand2);
                    break;
                case "*":
                    operand2 = stack.Pop();
                    operand1 = stack.Pop();
                    stack.Push(operand1 * operand2);
                    break;
                case "/":
                    operand2 = stack.Pop();
                    operand1 = stack.Pop();
                    if (operand2 == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль.");
                        return;
                    }
                    stack.Push(operand1 / operand2);
                    break;
                default:
                    stack.Push(Convert.ToInt32(element));
                    break;
            }
        }

        Console.WriteLine($"Результат: {stack.Pop()}");
    }
}
