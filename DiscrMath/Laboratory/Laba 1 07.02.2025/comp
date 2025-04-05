using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[,] test = {
            { 0, 1, 0, 0, 0 },
            { 1, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

        Algorithm1(test);
    }

    static void Algorithm1(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        bool[] visited = new bool[n];
        List<List<int>> conArray = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(i);
                visited[i] = true;

                List<int> comp = new List<int>();

                while (stack.Count > 0)
                {
                    int current = stack.Pop();
                    comp.Add(current);

                    for (int neighbor = 0; neighbor < n; neighbor++)
                    {
                        if (matrix[current, neighbor] == 1 && !visited[neighbor])
                        {
                            visited[neighbor] = true;
                            stack.Push(neighbor);
                        }
                    }
                }

                conArray.Add(comp);
            }
        }

        int res = conArray.Count;
        Console.WriteLine("Количество компонент-связности: " + res);
    }
}
