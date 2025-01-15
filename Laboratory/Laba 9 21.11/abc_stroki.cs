using System;

class Program
{
    static void Main(string[] args)
    {
        //1: Определить количество строк, в которых присутствует сочетание "a*b"
        string input = Console.ReadLine().ToLower();
        int count = 0;
        while (input != "")
        {
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == 'a' && input[i + 2] == 'b')
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            count = 0;
            input = Console.ReadLine();
        }

        //2: Определить максимальную длину подстроки, состоящей из "abc"
        string input2 = Console.ReadLine();
        int maxLength = 0;
        while (input2 != "")
        {
            input2 = input2.ToLower();
            string temp = "a";
            int currentLength = 0;

            while (input2.Contains(temp))
            {
                currentLength++;
                int len = temp.Length + 1;
                if (len % 3 == 1)
                {
                    temp += "a";
                }
                else if (len % 3 == 2)
                {
                    temp += "b";
                }
                else
                {
                    temp += "c";
                }
            }
            maxLength = Math.Max(maxLength, currentLength);
            Console.WriteLine(maxLength);
            input2 = Console.ReadLine();
            temp = "a";
            maxLength = 0;
            currentLength = 0;
        }
    }
}
