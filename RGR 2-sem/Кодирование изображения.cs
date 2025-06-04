using System;
using System.Collections.Generic;
using System.IO;

public class RegionInfo
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    
    public RegionInfo(int x, int y, int w, int h)
    {
        X = x; Y = y; Width = w; Height = h;
    }
}

public class ImageEncoder
{
    private int[,] image;
    private int width, height;
    private List<string> outputLines;
    
    public ImageEncoder(int[,] img, int w, int h)
    {
        image = img;
        width = w;
        height = h;
        outputLines = new List<string>();
    }
    
    public List<string> Encode()
    {
        outputLines.Clear();
        outputLines.Add($"{width} {height}");
        
        if (IsUniform(0, 0, width, height))
        {
            outputLines.Add(image[0, 0].ToString());
        }
        else
        {
            outputLines.Add("Z");
            ProcessRegionsBFS();
        }
        
        return outputLines;
    }
    
    private void ProcessRegionsBFS()
    {
        Queue<RegionInfo> queue = new Queue<RegionInfo>();
        queue.Enqueue(new RegionInfo(0, 0, width, height));
        
        while (queue.Count > 0)
        {
            RegionInfo region = queue.Dequeue();
            ProcessSingleRegion(region, queue);
        }
    }
    
    private void ProcessSingleRegion(RegionInfo region, Queue<RegionInfo> queue)
    {
        int x = region.X;
        int y = region.Y;
        int w = region.Width;
        int h = region.Height;
        
        int leftWidth = (w + 1) / 2;
        int rightWidth = w / 2;
        int topHeight = (h + 1) / 2;
        int bottomHeight = h / 2;
        
        string lt = AnalyzeQuadrant(x, y, leftWidth, topHeight);
        string rt = AnalyzeQuadrant(x + leftWidth, y, rightWidth, topHeight);
        string lb = AnalyzeQuadrant(x, y + topHeight, leftWidth, bottomHeight);
        string rb = AnalyzeQuadrant(x + leftWidth, y + topHeight, rightWidth, bottomHeight);
        
        outputLines.Add($"{lt} {rt} {lb} {rb}");
        
        if (lt == "Z")
            queue.Enqueue(new RegionInfo(x, y, leftWidth, topHeight));
        if (rt == "Z")
            queue.Enqueue(new RegionInfo(x + leftWidth, y, rightWidth, topHeight));
        if (lb == "Z")
            queue.Enqueue(new RegionInfo(x, y + topHeight, leftWidth, bottomHeight));
        if (rb == "Z")
            queue.Enqueue(new RegionInfo(x + leftWidth, y + topHeight, rightWidth, bottomHeight));
    }
    
    private bool IsUniform(int x, int y, int w, int h)
    {
        if (w <= 0 || h <= 0) return true;
        
        int color = image[y, x];
        for (int i = y; i < y + h; i++)
        {
            for (int j = x; j < x + w; j++)
            {
                if (image[i, j] != color)
                    return false;
            }
        }
        return true;
    }
    
    private string AnalyzeQuadrant(int x, int y, int w, int h)
    {
        if (w <= 0 || h <= 0)
            return "-";
        
        if (IsUniform(x, y, w, h))
            return image[y, x].ToString();
        else
            return "Z";
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string[] lines = File.ReadAllLines("input_s1_03.txt");
            string[] dimensions = lines[0].Split();
            int width = int.Parse(dimensions[0]);
            int height = int.Parse(dimensions[1]);
            
            int[,] image = new int[height, width];
            
            for (int i = 0; i < height; i++)
            {
                string[] row = lines[i + 1].Split();
                for (int j = 0; j < width; j++)
                {
                    image[i, j] = int.Parse(row[j]);
                }
            }
            
            ImageEncoder encoder = new ImageEncoder(image, width, height);
            List<string> result = encoder.Encode();
            
            File.WriteAllLines("Output3.txt", result);
            
            Console.WriteLine("Кодирование завершено. Результат записан в Output.txt");
            Console.WriteLine("\nРезультат кодирования:");
            foreach (string line in result)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
