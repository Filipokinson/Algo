using System;

public class Program
{
    public static void Main()
    {
        int[,] test = {
            {0, -1, 4, 0, 0},
            {0, 0, 3, 2, 2},
            {0, 0, 0, 0, 0},
            {0, 1, 5, 0, 0},
            {0, 0, 0, -3, 0}
        };

        FordBellman(test, 0);
    }

    public static void FordBellman(int[,] matrix, int start)
    {
        int n = matrix.GetLength(0);
        int[] lambda = new int[n];
        for (int i = 0; i < n; i++)
        {
            lambda[i] = int.MaxValue;
        }
        lambda[start] = 0;

        for (int k = 0; k < n - 1; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != 0 && lambda[i] != int.MaxValue &&
                        lambda[i] + matrix[i, j] < lambda[j])
                    {
                        lambda[j] = lambda[i] + matrix[i, j];
                    }
                }
            }
        }

        bool hasNegativeCycle = false;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] != 0 && lambda[i] != int.MaxValue &&
                    lambda[i] + matrix[i, j] < lambda[j])
                {
                    hasNegativeCycle = true;
                    break;
                }
            }
            if (hasNegativeCycle) break;
        }

        if (hasNegativeCycle)
        {
            Console.WriteLine("Есть отрицательный цикл");
        }

        Console.WriteLine($"от {start} до остальных вершин: {string.Join(", ", lambda)}");
    }
}
