using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input_s1_03.txt");
        int N = int.Parse(lines[0]);
        string[] coords = lines[1].Split(' ');
        int X1 = int.Parse(coords[0]);
        int Y1 = int.Parse(coords[1]);
        int X2 = int.Parse(coords[2]);
        int Y2 = int.Parse(coords[3]);
        
        int result = FindShortestPath(N, X1, Y1, X2, Y2);
        
        File.WriteAllText("Output3.txt", result == -1 ? "NO" : result.ToString());
    }
    
    static int FindShortestPath(int N, int startX, int startY, int endX, int endY)
    {
        if (startX < 1 || startX > N || startY < 1 || startY > N ||
            endX < 1 || endX > N || endY < 1 || endY > N)
            return -1;
            
        if (startX == endX && startY == endY)
            return 0;
        
        Queue<(int x, int y, int moves)> queue = new Queue<(int, int, int)>();
        bool[,] visited = new bool[N + 1, N + 1];
        
        queue.Enqueue((startX, startY, 0));
        visited[startX, startY] = true;
        
        int[] knightDx = { 2, 2, 1, 1, -1, -1, -2, -2 };
        int[] knightDy = { 1, -1, 2, -2, 2, -2, 1, -1 };
        
        int[] whiteDx = { 0, 0, 1, -1 };
        int[] whiteDy = { 1, -1, 0, 0 };
        
        while (queue.Count > 0)
        {
            var (x, y, moves) = queue.Dequeue();
            
            bool isBlack = (x + y) % 2 == 1;
            
            int[] dx = isBlack ? knightDx : whiteDx;
            int[] dy = isBlack ? knightDy : whiteDy;
            
            for (int i = 0; i < dx.Length; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];
                
                if (newX >= 1 && newX <= N && newY >= 1 && newY <= N)
                {
                    if (newX == endX && newY == endY)
                        return moves + 1;
                    
                    if (!visited[newX, newY])
                    {
                        visited[newX, newY] = true;
                        queue.Enqueue((newX, newY, moves + 1));
                    }
                }
            }
        }
        
        return -1;
    }
}
