using System;
using System.Collections.Generic;

public class WaveAlgorithm
{
    public static void Main()
    {
        int[,] matrix = new int[,]
        {
            {0, 0, 0, 0, 0},
            {0, 1, 0, 1, 0},
            {0, 0, 1, 0, 0},
            {0, 1, 0, 1, 0},
            {0, 0, 0, 0, 0}
        };

        var start = (0, 0);
        var end = (4, 4);
        FindPath(matrix, start, end);
    }

    public static void FindPath(int[,] matrix, (int row, int col) start, (int row, int col) end)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] extendedMatrix = new int[rows + 2, cols + 2];

        for (int i = 0; i < rows + 2; i++)
        {
            for (int j = 0; j < cols + 2; j++)
            {
                if (i == 0 || i == rows + 1 || j == 0 || j == cols + 1)
                    extendedMatrix[i, j] = 1;
                else
                    extendedMatrix[i, j] = matrix[i - 1, j - 1];
            }
        }

        (int row, int col) startExtended = (start.row + 1, start.col + 1);
        (int row, int col) endExtended = (end.row + 1, end.col + 1);

        if (extendedMatrix[startExtended.row, startExtended.col] == 1 || 
            extendedMatrix[endExtended.row, endExtended.col] == 1)
        {
            Console.WriteLine("Начальная или конечная точка находится в препятствии");
            return;
        }

        int[,] distance = new int[rows + 2, cols + 2];
        for (int i = 0; i < rows + 2; i++)
        {
            for (int j = 0; j < cols + 2; j++)
            {
                distance[i, j] = -1;
            }
        }
        distance[startExtended.row, startExtended.col] = 0;

        Queue<(int row, int col)> queue = new Queue<(int, int)>();
        queue.Enqueue(startExtended);

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int currentRow = current.row;
            int currentCol = current.col;

            for (int i = 0; i < 4; i++)
            {
                int newRow = currentRow + dr[i];
                int newCol = currentCol + dc[i];

                if (extendedMatrix[newRow, newCol] == 0 && 
                    distance[newRow, newCol] == -1)
                {
                    distance[newRow, newCol] = distance[currentRow, currentCol] + 1;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        if (distance[endExtended.row, endExtended.col] == -1)
            Console.WriteLine("Путь не найден");
        else
            Console.WriteLine($"Минимальное количество шагов: {distance[endExtended.row, endExtended.col]}");
    }
}
