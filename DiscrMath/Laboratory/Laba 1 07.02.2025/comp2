using System;
using System.Collections.Generic;

public class GraphVertex
{
    public int VertexId { get; set; }
    public int ConnectedComponent { get; set; }
    public List<int> Neighbors { get; set; } = new List<int>();
}

class Program
{
    static void Main()
    {
        int[,] test = {
            { 0, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 1, 0, 0, 0, 0 }
        };

        GraphVertex[] connectedComponents = FindConnectedComponents(test);

        Console.WriteLine("Компоненты связности:");
        foreach (var vertex in connectedComponents)
        {
            Console.WriteLine($"Вершина {vertex.VertexId}: Компонента {vertex.ConnectedComponent}");
        }
    }

    static GraphVertex[] FindConnectedComponents(int[,] matrix)
    {
        int numberOfVertices = matrix.GetLength(0);
        List<GraphVertex> vertices = new List<GraphVertex>();

        for (int i = 0; i < numberOfVertices; i++)
        {
            GraphVertex vertex = new GraphVertex
            {
                VertexId = i,
                ConnectedComponent = 0,
                Neighbors = new List<int>()
            };

            for (int j = 0; j < numberOfVertices; j++)
            {
                if (matrix[i, j] != 0)
                {
                    vertex.Neighbors.Add(j);
                }
            }

            vertices.Add(vertex);
        }

        int componentCounter = 1;

        for (int i = 0; i < numberOfVertices; i++)
        {
            GraphVertex vertex = vertices[i];

            if (vertex.VertexId == 0)
            {
                vertex.ConnectedComponent = componentCounter;
            }
            else if (vertex.Neighbors.Contains(vertex.VertexId))
            {
                vertex.ConnectedComponent = vertex.ConnectedComponent;
            }
            else if (vertex.Neighbors.Count > 0 && vertices[vertex.Neighbors[0]].ConnectedComponent != 0)
            {
                vertex.ConnectedComponent = vertices[vertex.Neighbors[0]].ConnectedComponent;
            }
            else
            {
                componentCounter++;
                vertex.ConnectedComponent = componentCounter;
            }
        }

        for (int i = 0; i < numberOfVertices; i++)
        {
            GraphVertex vertex = vertices[i];

            if (vertex.Neighbors.Count > 0 && vertex.ConnectedComponent != vertices[vertex.Neighbors[0]].ConnectedComponent)
            {
                vertex.ConnectedComponent = vertices[vertex.Neighbors[0]].ConnectedComponent;
            }
        }

        return vertices.ToArray();
    }
}
