using System;

public class Program
{
    public static void Main()
    {
        int[,] test = {
            {0, 3, int.MaxValue, 7},
            {8, 0, 2, int.MaxValue},
            {5, int.MaxValue, 0, 1},
            {2, int.MaxValue, int.MaxValue, 0},
        };

        FloydAlgorithm(test);
    }

    public static void FloydAlgorithm(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int[,] resultMatrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                resultMatrix[i, j] = int.MaxValue;
            }
        }

        for (int i = 0; i < size; i++)
        {
            resultMatrix[i, i] = 0;
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (matrix[i, j] != 0)
                {
                    resultMatrix[i, j] = matrix[i, j];
                }
            }
        }

        for (int k = 0; k < size; k++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (resultMatrix[i, k] != int.MaxValue && 
                        resultMatrix[k, j] != int.MaxValue && 
                        resultMatrix[i, k] + resultMatrix[k, j] < resultMatrix[i, j])
                    {
                        resultMatrix[i, j] = resultMatrix[i, k] + resultMatrix[k, j];
                    }
                }
            }
        }

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"из вершины {i} расстояния до остальных: {string.Join(", ", GetRow(resultMatrix, i))}");
        }
    }

    private static int[] GetRow(int[,] matrix, int row)
    {
        int size = matrix.GetLength(1);
        int[] result = new int[size];
        for (int j = 0; j < size; j++)
        {
            result[j] = matrix[row, j];
        }
        return result;
    }
}
