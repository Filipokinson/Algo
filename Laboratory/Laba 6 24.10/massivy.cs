using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размеры массива m x n:");
        int m = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] array = new int[m, n];
        
        Console.WriteLine("Введите элементы массива построчно:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("Исходный массив:");
        PrintArray(array, m, n);

        // 1. Сортировка столбцов по возрастанию их сумм
        for (int j1 = 0; j1 < n - 1; j1++)
        {
            for (int j2 = j1 + 1; j2 < n; j2++)
            {
                int sum1 = 0, sum2 = 0;

              
                for (int i = 0; i < m; i++)
                {
                    sum1 += array[i, j1];
                    sum2 += array[i, j2];
                }

                if (sum1 > sum2)
                {
                    for (int i = 0; i < m; i++)
                    {
                        int temp = array[i, j1];
                        array[i, j1] = array[i, j2];
                        array[i, j2] = temp;
                    }
                }
            }
        }

        Console.WriteLine("Массив после сортировки столбцов по возрастанию их сумм:");
        PrintArray(array, m, n);

        // 2. Определение номеров пар строк с одинаковыми элементами
        Console.WriteLine("Номера пар строк с одинаковыми элементами:");
        bool foundPair = false;
        for (int i1 = 0; i1 < m - 1; i1++)
        {
            for (int i2 = i1 + 1; i2 < m; i2++)
            {
                bool isEqual = true;
                for (int j = 0; j < n; j++)
                {
                    if (array[i1, j] != array[i2, j])
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual)
                {
                    foundPair = true;
                    Console.WriteLine($"Строка {i1 + 1} и строка {i2 + 1}");
                }
            }
        }
        if (!foundPair)
        {
            Console.WriteLine("Таких строк нет.");
        }

        // 3. Определение положения минимаксов
        Console.WriteLine("Положение минимаксов:");
        for (int i = 0; i < m; i++)
        {
            //макс в строке
            int rowMin = array[i, 0];
            int rowMax = array[i, 0];
            int rowMinIndex = 0;
            int rowMaxIndex = 0;

            for (int j = 1; j < n; j++)
            {
                if (array[i, j] < rowMin)
                {
                    rowMin = array[i, j];
                    rowMinIndex = j;
                }
                if (array[i, j] > rowMax)
                {
                    rowMax = array[i, j];
                    rowMaxIndex = j;
                }
            }

            //минимум на макс в столбце
            bool isMinimaxMin = true;
            for (int k = 0; k < m; k++)
            {
                if (array[k, rowMinIndex] > rowMin)
                {
                    isMinimaxMin = false;
                    break;
                }
            }
            if (isMinimaxMin)
            {
                Console.WriteLine($"({i + 1}, {rowMinIndex + 1})");
            }

            //макс на минимум в столбце
            bool isMinimaxMax = true;
            for (int k = 0; k < m; k++)
            {
                if (array[k, rowMaxIndex] < rowMax)
                {
                    isMinimaxMax = false;
                    break;
                }
            }
            if (isMinimaxMax)
            {
                Console.WriteLine($"({i + 1}, {rowMaxIndex + 1})");
            }
        }
    }
  
    static void PrintArray(int[,] array, int m, int n)
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
