using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    class RegionTask
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    static int[,] image;
    static List<string[]> parameters;
    static int paramPtr;
    static Queue<RegionTask> taskQueue = new Queue<RegionTask>();

    static void Main()
    {
        var lines = File.ReadAllLines("input_s1_03.txt");
        int W = int.Parse(lines[0].Split()[0]);
        int H = int.Parse(lines[0].Split()[1]);
        
        image = new int[H, W];
        
        parameters = new List<string[]>();
        for (int i = 2; i < lines.Length; i++)
        {
            parameters.Add(lines[i].Split());
        }
        paramPtr = 0;
        
        if (lines[1] == "Z")
        {
            taskQueue.Enqueue(new RegionTask { X = 0, Y = 0, Width = W, Height = H });
            ProcessTasks();
        }
        else
        {
            FillArea(0, 0, W, H, int.Parse(lines[1]));
        }
        
        WriteOutput(H, W);
    }

    static void ProcessTasks()
    {
        while (taskQueue.Count > 0)
        {
            var task = taskQueue.Dequeue();
            if (paramPtr >= parameters.Count) continue;
            
            var parts = parameters[paramPtr++];
            ProcessRegion(task.X, task.Y, task.Width, task.Height, parts);
        }
    }

    static void ProcessRegion(int x, int y, int w, int h, string[] parts)
    {
        int splitLeft = (w + 1) / 2;
        int splitRight = w / 2;
        int splitTop = (h + 1) / 2;
        int splitBottom = h / 2;
        
        ProcessPart(x, y, splitLeft, splitTop, parts[0]);
        ProcessPart(x + splitLeft, y, splitRight, splitTop, parts[1]);
        ProcessPart(x, y + splitTop, splitLeft, splitBottom, parts[2]);
        ProcessPart(x + splitLeft, y + splitTop, splitRight, splitBottom, parts[3]);
    }

    static void ProcessPart(int x, int y, int w, int h, string part)
    {
        if (w == 0 || h == 0 || part == "-") return;
        
        if (part == "Z")
        {
            taskQueue.Enqueue(new RegionTask { X = x, Y = y, Width = w, Height = h });
        }
        else
        {
            FillArea(x, y, w, h, int.Parse(part));
        }
    }

    static void FillArea(int x, int y, int w, int h, int color)
    {
        for (int i = y; i < y + h && i < image.GetLength(0); i++)
            for (int j = x; j < x + w && j < image.GetLength(1); j++)
                image[i, j] = color;
    }

    static void WriteOutput(int H, int W)
    {
        using (var writer = new StreamWriter("Output3.txt"))
        {
            for (int i = 0; i < H; i++)
                writer.WriteLine(string.Join(" ", GetRow(i)));
        }
    }

    static IEnumerable<string> GetRow(int row)
    {
        for (int j = 0; j < image.GetLength(1); j++)
            yield return image[row, j].ToString();
    }
}
