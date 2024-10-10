using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите элементы последовательности: ");
        int n = int.Parse(Console.ReadLine());
        int r = 0;
        while(n>0)
        {
        while(n > 0)
        {
            if (n%10%2!=0)
            {
                r=r*10+n%10;
                n/=10;
            }
        
            else
            {
                n/=10;
            }
        }
        
        if (r==0)
        {
            Console.WriteLine("Нет нечетных");
        }
        
        else
        {
            Console.WriteLine(r);
        }
        r=0;
        n = Convert.ToInt32(Console.ReadLine());
        }
    }
}
