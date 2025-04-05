using System;

class Program
{
    static void Main()
    {
        int[,] test = {
            { 0, 1,   0,   0 },
            { -2, 0, 0,   0 },
            { 0, 0, 0,   0 },
            { 0, 0, 0,   0 }
        };

        FordBellman(test, 0);
    }

    static void FordBellman(int[,] test, int startVertex)
    {
        int vertexCount = test.GetLength(0);
        const int infinity = int.MaxValue;
        int[] shortestDistances = new int[vertexCount];

        for (int i = 0; i < vertexCount; i++)
        {
            shortestDistances[i] = infinity;
        }
        shortestDistances[startVertex] = 0;

        for (int iteration = 0; iteration < vertexCount - 1; iteration++)
        {
            for (int fromVertex = 0; fromVertex < vertexCount; fromVertex++)
            {
                for (int toVertex = 0; toVertex < vertexCount; toVertex++)
                {
                    if (test[fromVertex, toVertex] != 0 && 
                        shortestDistances[fromVertex] != infinity)
                    {
                        int newDistance = shortestDistances[fromVertex] + test[fromVertex, toVertex];
                        if (newDistance < shortestDistances[toVertex])
                        {
                            shortestDistances[toVertex] = newDistance;
                        }
                    }
                }
            }
        }

        bool hasNegativeCycle = false;
        for (int fromVertex = 0; fromVertex < vertexCount; fromVertex++)
        {
            for (int toVertex = 0; toVertex < vertexCount; toVertex++)
            {
                if (test[fromVertex, toVertex] != 0 && 
                    shortestDistances[fromVertex] != infinity)
                {
                    int newDistance = shortestDistances[fromVertex] + test[fromVertex, toVertex];
                    if (newDistance < shortestDistances[toVertex])
                    {
                        hasNegativeCycle = true;
                        break;
                    }
                }
            }
            if (hasNegativeCycle) break;
        }

        if (hasNegativeCycle)
        {
            Console.WriteLine("Обнаружен отрицательный цикл!");
        }
        Console.WriteLine($"Расстояния от вершины {startVertex}: {string.Join(", ", shortestDistances)}");
    }
}
