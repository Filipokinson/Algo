using System;

interface IФигура
{
    double Периметр();
    double Площадь();
}

class Фигура
{
    public string Имя { get; set; }

    public Фигура(string имя)
    {
        Имя = имя;
    }
}

class Круг : Фигура, IФигура
{
    public double Радиус { get; set; }

    public Круг(string имя, double радиус) : base(имя)
    {
        Радиус = радиус;
    }

    public double Периметр()
    {
        return 2 * Math.PI * Радиус;
    }

    public double Площадь()
    {
        return Math.PI * Math.Pow(Радиус, 2);
    }
}

class Квадрат : Фигура, IФигура
{
    public double ДлинаСтороны { get; set; }

    public Квадрат(string name, double длинаСтороны) : base(name)
    {
        ДлинаСтороны = длинаСтороны;
    }

    public double Периметр()
    {
        return 4 * ДлинаСтороны;
    }

    public double Площадь()
    {
        return Math.Pow(ДлинаСтороны, 2);
    }
}

class Треугольник : Фигура, IФигура
{
    public double ДлинаСтороны { get; set; }

    public Треугольник(string имя, double длинаСтороны) : base(имя)
    {
        ДлинаСтороны = длинаСтороны;
    }

    public double Периметр()
    {
        return 3 * ДлинаСтороны;
    }

    public double Площадь()
    {
        return (Math.Sqrt(3) / 4) * Math.Pow(ДлинаСтороны, 2);
    }
}

class Программа
{
    static void Main()
    {
        Круг круг = new Круг("Круг", 5);
        Квадрат квадрат = new Квадрат("Квадрат", 4);
        Треугольник треугольник = new Треугольник("Равносторонний треугольник", 3);

        Console.WriteLine($"{круг.Имя} - Периметр: {круг.Периметр()}, Площадь: {круг.Площадь()}");
        Console.WriteLine($"{квадрат.Имя} - Периметр: {квадрат.Периметр()}, Площадь: {квадрат.Площадь()}");
        Console.WriteLine($"{треугольник.Имя} - Периметр: {треугольник.Периметр()}, Площадь: {треугольник.Площадь()}");
    }
}
