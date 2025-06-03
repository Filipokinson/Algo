using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFilePath = "input.txt";
        string outputFilePath = "output.txt";

        List<string> resultLines = new List<string>();

        foreach (string line in File.ReadLines(inputFilePath))
        {
            MatchCollection matches = Regex.Matches(line, @"\d+");
            foreach (Match match in matches)
            {
                string number = match.Value;
                char lastDigit = number[number.Length - 1];
                if ("02468".Contains(lastDigit))
                {
                    resultLines.Add(line);
                    break;
                }
            }
        }

        File.WriteAllLines(outputFilePath, resultLines);
    }
}
