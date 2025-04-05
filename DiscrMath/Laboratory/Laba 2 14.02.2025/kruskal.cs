using System;
using System.Collections.Generic;

public class Edge
{
    public int start;
    public int end;
    public int weight;
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

        List<Edge> result = AlgorithmKruskal(test);
        Console.WriteLine("Ребра в дереве:");
        foreach (var edge in result)
        {
            Console.WriteLine($"({edge.start}, {edge.end}) вес {edge.weight}");
        }
    }

    static List<Edge> AlgorithmKruskal(int[,] matrix)
    {
        List<Edge> edgeArray = new List<Edge>();
        List<Edge> resArrayEdge = new List<Edge>();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int element = matrix[i, j];
                if (element != 0)
                {
                    edgeArray.Add(new Edge { start = i, end = j, weight = element });
                }
            }
        }

        edgeArray.Sort((a, b) => a.weight - b.weight);

        int[] conArray = new int[matrix.GetLength(0)];
        for (int i = 0; i < conArray.Length; i++)
        {
            conArray[i] = i;
        }

        int Find(int vertex)
        {
            while (conArray[vertex] != vertex)
            {
                vertex = conArray[vertex];
            }
            return vertex;
        }

        foreach (var edge in edgeArray)
        {
            int start = Find(edge.start);
            int end = Find(edge.end);

            if (start != end)
            {
                resArrayEdge.Add(edge);
                conArray[end] = start;
            }
        }

        return resArrayEdge;
    }
}
