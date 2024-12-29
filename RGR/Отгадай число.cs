using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputLines = File.ReadAllLines("input_s1_08.txt");

            int calculationResult = 0;
            int multiplier = 1;

            for (int i = 1; i < inputLines.Length - 1; i++)
            {
                string[] operationParts = inputLines[i].Split(' ');
                char operation = Convert.ToChar(operationParts[0]);
                string operand = operationParts[1];

                if (operand != "x")
                {
                    int number = Convert.ToInt32(operand);
                    if (operation == '+') calculationResult += number;
                    if (operation == '*') { calculationResult *= number; multiplier *= number; }
                    if (operation == '-') calculationResult -= number;
                }
                else
                {
                    if (operation == '+') multiplier += 1;
                    if (operation == '-') multiplier -= 1;
                }
            }

            int finalResult = (Convert.ToInt32(inputLines[inputLines.Length - 1]) - calculationResult) / multiplier;
            Console.WriteLine($"Результат: {finalResult}");
        }
    }
}
