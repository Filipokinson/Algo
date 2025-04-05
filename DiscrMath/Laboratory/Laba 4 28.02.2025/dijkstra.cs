using System;

public class Program
{
    public static void Main()
    {
        int[,] test = {
            {0, 6, 6, 0, 0, 4},
            {0, 0, 0, 87, 0, 0},
            {4, 0, 0, 0, 54, 56},
            {0, 5, 0, 0, 3, 0},
            {58, 3, 0, 0, 0, 0},
            {6, 0, 8, 6, 0, 0},
        };
        
        int result = AlgorithmDijkstra(test, 0, 2);
        Console.WriteLine(result);
    }

    public static int AlgorithmDijkstra(int[,] matrix, int start, int end)
    {
        int n = matrix.GetLength(0);
        bool[] visited = new bool[n];
        int[] width = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            width[i] = int.MaxValue;
        }
        width[start] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int minVertex = FindMinVertex(width, visited);
            if (minVertex == -1)
                break;
            
            visited[minVertex] = true;

            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && matrix[minVertex, j] != 0 && width[minVertex] != int.MaxValue)
                {
                    if (width[minVertex] + matrix[minVertex, j] < width[j])
                    {
                        width[j] = width[minVertex] + matrix[minVertex, j];
                    }
                }
            }
        }
        
        return width[end];
    }

    private static int FindMinVertex(int[] width, bool[] visited)
    {
        int minDistance = int.MaxValue;
        int minIndex = -1;
        
        for (int i = 0; i < width.Length; i++)
        {
            if (!visited[i] && width[i] <= minDistance)
            {
                minDistance = width[i];
                minIndex = i;
            }
        }
        
        return minIndex;
    }
}
