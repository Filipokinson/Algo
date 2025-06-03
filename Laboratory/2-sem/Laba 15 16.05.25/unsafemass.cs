using System;

class Program
{
    unsafe static void Main()
    {
        Console.Write("Введите количество элементов массива: ");
        int size = Convert.ToInt32(Console.ReadLine());
        int[] numbers = new int[size];

        Console.WriteLine("Введите элементы массива");
        for (int index = 0; index < size; index++)
        {
            numbers[index] = Convert.ToInt32(Console.ReadLine());
        }

        fixed (int* pointer = numbers)
        {
            int* current = pointer;
            int evenCount = 0;

            for (int i = 0; i < size; i++)
            {
                if (*current % 2 == 0)
                {
                    evenCount++;
                }
                current++;
            }
            Console.WriteLine($"Количество четных элементов: {evenCount}");
        }
    }
}
