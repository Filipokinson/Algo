using System;
using System.Collections.Generic;

public class Edge
{
    public int ToVertex { get; set; }
    public int Weight { get; set; }
}

class Program
{
    static void Main()
    {
        int[,] test = {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        FindMinimumTree(test);
    }

    static void FindMinimumTree(int[,] test)
    {
        int vertexCount = test.GetLength(0);
        List<List<Edge>> graph = new List<List<Edge>>();
        List<int> mstWeights = new List<int>();
        bool[] visited = new bool[vertexCount];

        for (int currentVertex = 0; currentVertex < vertexCount; currentVertex++)
        {
            graph.Add(new List<Edge>());
            for (int neighborVertex = 0; neighborVertex < vertexCount; neighborVertex++)
            {
                if (test[currentVertex, neighborVertex] != 0)
                {
                    graph[currentVertex].Add(new Edge
                    {
                        ToVertex = neighborVertex,
                        Weight = test[currentVertex, neighborVertex]
                    });
                }
            }
        }

        visited[0] = true;

        while (mstWeights.Count < vertexCount - 1)
        {
            Edge currentMinEdge = null;

            for (int fromVertex = 0; fromVertex < vertexCount; fromVertex++)
            {
                if (visited[fromVertex])
                {
                    foreach (var edge in graph[fromVertex])
                    {
                        if (!visited[edge.ToVertex] &&
                            (currentMinEdge == null || edge.Weight < currentMinEdge.Weight))
                        {
                            currentMinEdge = edge;
                        }
                    }
                }
            }

            if (currentMinEdge != null)
            {
                mstWeights.Add(currentMinEdge.Weight);
                visited[currentMinEdge.ToVertex] = true;
            }
        }

        Console.WriteLine($"Сумма минимального остовного дерева: {mstWeights.Sum()}");
    }
}
