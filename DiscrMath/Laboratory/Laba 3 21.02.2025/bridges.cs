using System;
using System.Collections.Generic;

public class Edge
{
    public int Start { get; set; }
    public int End { get; set; }
    public int Weight { get; set; }
}

public class Program
{
    public static void Main()
    {
        int[,] testMatrix = {
            {0, 1, 0, 0},
            {1, 0, 2, 0},
            {0, 2, 0, 3},
            {0, 0, 3, 0}
        };

        AlgorithmBridge(testMatrix);
    }

    public static void AlgorithmBridge(int[,] matrix)
    {
        List<Edge> bridgeEdges = new List<Edge>();
        int originalComponentCount = GetMaxComponent(AlgorithmConnect(matrix));

        List<Edge> mstEdges = AlgorithmKruskal(matrix);

        foreach (var edge in mstEdges)
        {
            matrix[edge.Start, edge.End] = 0;
            matrix[edge.End, edge.Start] = 0;

            int tempComponentCount = GetMaxComponent(AlgorithmConnect(matrix));

            if (originalComponentCount < tempComponentCount)
            {
                bridgeEdges.Add(edge);
                Console.WriteLine($"Мост {edge.Start} - {edge.End}");
            }

            matrix[edge.Start, edge.End] = edge.Weight;
            matrix[edge.End, edge.Start] = edge.Weight;
        }

        if (bridgeEdges.Count == 0)
        {
            Console.WriteLine("нет мостов");
        }
    }

    private static List<ComponentNode> AlgorithmConnect(int[,] matrix)
    {
        return new List<ComponentNode>();
    }

    private static List<Edge> AlgorithmKruskal(int[,] matrix)
    {
        return new List<Edge>();
    }

    private static int GetMaxComponent(List<ComponentNode> components)
    {
        return 0;
    }

    private class ComponentNode
    {
        public int Node { get; set; }
        public int Component { get; set; }
    }
}
