using System;

public class Field
{
    public int MinX { get; }
    public int MaxX { get; }
    public int MinY { get; }
    public int MaxY { get; }

    public Field(int minX, int maxX, int minY, int maxY)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }
}

public class Point
{
    public event EventHandler OnExitField;

    private int _x;
    private int _y;
    private Field _field;

    public int X => _x;
    public int Y => _y;

    public Point(int x, int y, Field field)
    {
        _x = x;
        _y = y;
        _field = field;
    }

    public void Move(int deltaX, int deltaY)
    {
        int newX = _x + deltaX;
        int newY = _y + deltaY;

        _x = newX;
        _y = newY;

        if (!IsInField(newX, newY))
        {
            OnExitField?.Invoke(this, EventArgs.Empty);
        }
    }

    private bool IsInField(int x, int y)
    {
        return x >= _field.MinX && x <= _field.MaxX && y >= _field.MinY && y <= _field.MaxY;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Field field = new Field(0, 100, 0, 100);
        Point point = new Point(50, 50, field);
        point.OnExitField += HandleFieldExit;

        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int dx = rand.Next(-20, 21);
            int dy = rand.Next(-20, 21);
            Console.WriteLine($"Попытка перемещения на ({dx}, {dy})");
            point.Move(dx, dy);
            Console.WriteLine($"Текущая позиция: ({point.X}, {point.Y})\n");
        }
    }

    static void HandleFieldExit(object sender, EventArgs e)
    {
        Console.WriteLine("Точка вышла за пределы поля\n");
    }
}