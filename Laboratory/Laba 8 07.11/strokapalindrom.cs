using System;

class Program
{
    static void Main()
    {
        string stroka = "А роза упала на лапу Азора";
        bool isPalindrome = IsPalindrome(stroka);
        Console.WriteLine(isPalindrome ? "Строка является палиндромом" : "Строка не является палиндромом");
    }

    static bool IsPalindrome(string text)
    {
        string chisto = text.Replace(" ", "").ToLower();
        int len = chisto.Length;
        for (int i = 0; i < len / 2; i++)
        {
            if (chisto[i] != chisto[len - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}

