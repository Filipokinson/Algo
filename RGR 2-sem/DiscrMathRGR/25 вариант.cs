using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        string[] lines = File.ReadAllLines("input3.txt");
        
        int n = int.Parse(lines[0]);
        int[,] matrix = new int[n, n];
        
        for (int i = 0; i < n; i++)
        {
            string[] row = lines[i + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(row[j]);
            }
        }
        
        FloydAlgorithm(matrix);
    }

    public static void FloydAlgorithm(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int[,] dist = (int[,])matrix.Clone();
        
        for (int k = 0; k < size; k++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (dist[i, k] != int.MaxValue && 
                        dist[k, j] != int.MaxValue && 
                        dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }
        
        for (int i = 0; i < size; i++)
        {
            if (dist[i, i] < 0)
            {
                Console.WriteLine(-1);
                return;
            }
        }
        
        int minDistance = int.MaxValue;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i != j && dist[i, j] < minDistance)
                {
                    minDistance = dist[i, j];
                }
            }
        }
        
        Console.WriteLine(minDistance != int.MaxValue ? minDistance : -1);
    }
}
