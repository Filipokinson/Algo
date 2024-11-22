//дан ступенчатый массив размерностью 4 (4 ссылки на массивы)

using System;

class Program
{
    static void Main()
    {
        int[][] stupmass = new int[4][];

        for (int i = 0; i < stupmass.Length; i++)
        {
            Console.Write($"Введите количество элементов для строки {i + 1}: ");
            int length = Convert.ToInt32(Console.ReadLine());
            stupmass[i] = new int[length];

            Console.WriteLine($"Введите элементы для строки {i + 1}: ");
            for (int j = 0; j < length; j++)
            {
                stupmass[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        for (int i = 0; i < stupmass.Length; i++)
        {
            int chet = 0;
            int nechet = 0;
            int summa = 0;

            for (int j = 0; j < stupmass[i].Length; j++)
            {
                if (stupmass[i][j] % 2 == 0)
                    chet++;
                else
                    nechet++;

                summa += stupmass[i][j];
            }

            Console.WriteLine($"Строка {i + 1}: Четных элементов - {chet}, Нечетных элементов - {nechet}");

            bool found = false;
            for (int j = 0; j < stupmass[i].Length; j++)
            {
                int otherSum = summa - stupmass[i][j];
                if (stupmass[i][j] > otherSum)
                {
                    Console.WriteLine($"В строке {i + 1} элемент на позиции {j+1} больше суммы остальных элементов.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"В строке {i + 1} нет элемента, значение которого больше суммы остальных.");
            }
        }
    }
}
