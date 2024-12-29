using System;
using System.IO;

class Program
{

    static void Main()
    {
        using (StreamReader sr = new StreamReader($"input_s1_07.txt"))
        {
            int n = Convert.ToInt32(sr.ReadLine());

            int result = gruppa(n);

            Console.WriteLine($"Результат: {result}");
        }
    }
    static int gruppa(int n)
    {
        if (n < 3)
        {
            return 0;
        }

        if (n == 3)
        {
            return 1;
        }

        int chetGroup = gruppa(n / 2);
        int nechetGroup = gruppa((n + 1) / 2);

        return chetGroup + nechetGroup;
    }
}
