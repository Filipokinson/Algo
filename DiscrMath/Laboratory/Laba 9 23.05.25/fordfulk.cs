using System;
using System.Collections.Generic;

class MaxFlowSolver
{
    public static int FindMaxFlow(int[,] capacityMatrix, int startNode, int endNode)
    {
        int nodeCount = capacityMatrix.GetLength(0);
        var residual = (int[,])capacityMatrix.Clone();

        int maxFlow = 0;

        while (true)
        {
            int[] previous = new int[nodeCount];
            Array.Fill(previous, -1);
            Queue<int> bfsQueue = new Queue<int>();
            bfsQueue.Enqueue(startNode);
            previous[startNode] = -2;

            while (bfsQueue.Count > 0)
            {
                int current = bfsQueue.Dequeue();
                for (int next = 0; next < nodeCount; next++)
                {
                    if (previous[next] == -1 && residual[current, next] > 0)
                    {
                        previous[next] = current;
                        bfsQueue.Enqueue(next);
                        if (next == endNode)
                        {
                            bfsQueue.Clear();
                            break;
                        }
                    }
                }
            }

            if (previous[endNode] == -1)
                break;

            int mincapacity = int.MaxValue;
            int node = endNode;
            while (node != startNode)
            {
                int prev = previous[node];
                mincapacity = Math.Min(mincapacity, residual[prev, node]);
                node = prev;
            }

            node = endNode;
            while (node != startNode)
            {
                int prev = previous[node];
                residual[prev, node] -= mincapacity;
                residual[node, prev] += mincapacity;
                node = prev;
            }

            maxFlow += mincapacity;
        }

        return maxFlow;
    }

    static void Main()
    {
        int[,] capacityMatrix = new int[,]
        {
            {  0,  8, 23,  0, 19,  0 },
            {  0,  0,  0,  9, 15, 21 },
            {  0,  0,  0,  0,  7, 12 },
            {  0,  0, 18,  0,  0, 11 },
            {  0,  0,  0,  0,  0, 27 },
            {  0,  0,  0,  0,  0,  0 }
        };

        int source = 0;
        int sink = 5;

        int result = FindMaxFlow(capacityMatrix, source, sink);
        Console.WriteLine("Максимальный поток: " + result);
    }
}
