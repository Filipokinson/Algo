using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    class Plate
    {
        public int Number, X1, Y1, X2, Y2, Depth;
        public bool CoversPoint(int x, int y) => x >= X1 && x <= X2 && y >= Y1 && y <= Y2;
    }

    class Movement
    {
        public int PlateNumber, Direction, Distance;
    }

    static void Main()
    {
        var lines = File.ReadAllLines("input_s1_03.txt");
        var firstLine = lines[0].Split();
        int n = int.Parse(firstLine[0]), k = int.Parse(firstLine[1]);

        var plates = new List<Plate>();
        for (int i = 1; i <= n; i++)
        {
            var p = lines[i].Split();
            plates.Add(new Plate
            {
                Number = int.Parse(p[0]), X1 = int.Parse(p[1]), Y1 = int.Parse(p[2]),
                X2 = int.Parse(p[3]), Y2 = int.Parse(p[4]), Depth = int.Parse(p[5])
            });
        }

        var target = plates.First(p => p.Number == k);
        var above = plates.Where(p => p.Depth < target.Depth).OrderBy(p => p.Depth).ToList();

        int bestDist = int.MaxValue;
        List<Movement> bestMoves = new List<Movement>();

        for (int x = target.X1; x <= target.X2; x++)
        {
            for (int y = target.Y1; y <= target.Y2; y++)
            {
                var covering = above.Where(p => p.CoversPoint(x, y)).ToList();
                if (!covering.Any()) { bestDist = 0; bestMoves.Clear(); break; }

                var options = covering.Select(plate => new List<Movement>
                {
                    new Movement { PlateNumber = plate.Number, Direction = 1, Distance = x - plate.X1 + 1 },
                    new Movement { PlateNumber = plate.Number, Direction = 2, Distance = y - plate.Y1 + 1 },
                    new Movement { PlateNumber = plate.Number, Direction = 3, Distance = plate.X2 - x + 1 },
                    new Movement { PlateNumber = plate.Number, Direction = 4, Distance = plate.Y2 - y + 1 }
                }.Where(m => m.Distance > 0).ToList()).ToList();

                var (dist, moves) = FindBest(options);
                if (dist < bestDist) { bestDist = dist; bestMoves = moves; }
            }
            if (bestDist == 0) break;
        }

        using (var w = new StreamWriter("Output3.txt"))
        {
            w.WriteLine(bestDist);
            foreach (var m in bestMoves.OrderBy(m => m.PlateNumber))
                w.WriteLine($"{m.PlateNumber} {m.Direction} {m.Distance}");
        }
    }

    static (int, List<Movement>) FindBest(List<List<Movement>> options)
    {
        int best = int.MaxValue;
        List<Movement> bestMoves = new List<Movement>();
        
        void Generate(int i, List<Movement> current)
        {
            if (i >= options.Count)
            {
                int total = current.Sum(m => m.Distance);
                if (total < best) { best = total; bestMoves = new List<Movement>(current); }
                return;
            }
            foreach (var move in options[i])
            {
                current.Add(move);
                Generate(i + 1, current);
                current.RemoveAt(current.Count - 1);
            }
        }
        
        Generate(0, new List<Movement>());
        return (best, bestMoves);
    }
}
