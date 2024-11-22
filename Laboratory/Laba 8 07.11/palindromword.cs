using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string stroka = Console.ReadLine();
        Console.WriteLine("Слова-палиндромы:");

        int start = 0;
        while (start < stroka.Length)
        {
            int probel = stroka.IndexOf(' ', start);

            if (probel == -1) 
                probel = stroka.Length;

            string word = stroka.Substring(start, probel - start);

            if (IsPalindrome(word))
            {
                Console.WriteLine(word);
            }

            start = probel + 1;
        }
    }

    static bool IsPalindrome(string word)
    {
        int len = word.Length;
        for (int i = 0; i < len / 2; i++)
        {
            if (word[i] != word[len - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}
