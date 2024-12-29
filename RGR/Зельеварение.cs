using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("input6.txt");
        int linesCount = System.IO.File.ReadAllLines("input6.txt").Length;
        string[] lines = new string[linesCount];
        string line = reader.ReadLine();
        lines[0] = line;

        for (int i = 1; i < linesCount; i++)
        {
            line = reader.ReadLine();
            lines[i] = line;
        }

        string[] result = new string[linesCount + 1];
        for (int i = 0; i < linesCount; i++)
        {
            string[] elem = lines[i].Split(' ');
            MatchCollection nums = Regex.Matches(lines[i], @"\d+");

            if (nums.Count == 0)
            {
                if (elem[0] == "DUST") { elem[0] = ""; result[i + 1] = $"DT{string.Join("", elem)}TD"; }
                if (elem[0] == "WATER") { elem[0] = ""; result[i + 1] = $"WT{string.Join("", elem)}TW"; }
                if (elem[0] == "FIRE") { elem[0] = ""; result[i + 1] = $"FR{string.Join("", elem)}RF"; }
                if (elem[0] == "MIX") { elem[0] = ""; result[i + 1] = $"MX{string.Join("", elem)}XM"; }
            }
            else
            {
                if (elem[0] == "WATER") { elem[0] = ""; result[i + 1] = $"WT{string.Join(",", elem)}TW"; Replace(result[i + 1], result, i + 1); }
                if (elem[0] == "DUST") { elem[0] = ""; result[i + 1] = $"DT{string.Join(",", elem)}TD"; Replace(result[i + 1], result, i + 1); }
                if (elem[0] == "FIRE") { elem[0] = ""; result[i + 1] = $"FR{string.Join(",", elem)}RF"; Replace(result[i + 1], result, i + 1); }
                if (elem[0] == "MIX") { elem[0] = ""; result[i + 1] = $"MX{string.Join(",", elem)}XM"; Replace(result[i + 1], result, i + 1); }
            }
        }

        Console.WriteLine(result[result.Length - 1].Replace(",", ""));
    }

    public static void Replace(string input, string[] arr, int idx)
    {
        arr[idx] = Regex.Replace(input, @"\d+", match =>
        {
            int refIdx = int.Parse(match.Value);
            return arr[refIdx].Replace(",", "");
        });
    }
}
