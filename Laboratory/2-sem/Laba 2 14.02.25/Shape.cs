using System;

interface IFigura
{
    double Perimetr();
    double Ploshad();
}

class Figura
{
    public string Imya { get; set; }

    public Figura(string imya)
    {
        Imya = imya;
    }
}

class Krug : Figura, IFigura
{
    public double Radius { get; set; }

    public Krug(string imya, double radius) : base(imya)
    {
        Radius = radius;
    }

    public double Perimetr()
    {
        return 2 * Math.PI * Radius;
    }

    public double Ploshad()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

class Kvadrat : Figura, IFigura
{
    public double DlinaStorony { get; set; }

    public Kvadrat(string name, double dlinaStorony) : base(name)
    {
        DlinaStorony = dlinaStorony;
    }

    public double Perimetr()
    {
        return 4 * DlinaStorony;
    }

    public double Ploshad()
    {
        return Math.Pow(DlinaStorony, 2);
    }
}

class Treugolnik : Figura, IFigura
{
    public double DlinaStorony { get; set; }

    public Treugolnik(string imya, double dlinaStorony) : base(imya)
    {
        DlinaStorony = dlinaStorony;
    }

    public double Perimetr()
    {
        return 3 * DlinaStorony;
    }

    public double Ploshad()
    {
        return (Math.Sqrt(3) / 4) * Math.Pow(DlinaStorony, 2);
    }
}

class Программа
{
    static void Main()
    {
        Krug krug = new Krug("Круг", 5);
        Kvadrat kvadrat = new Kvadrat("Квадрат", 4);
        Treugolnik treugolnik = new Treugolnik("Равносторонний треугольник", 3);

        Console.WriteLine($"{krug.Imya} - Периметр: {krug.Perimetr()}, Площадь: {krug.Ploshad()}");
        Console.WriteLine($"{kvadrat.Imya} - Периметр: {kvadrat.Perimetr()}, Площадь: {kvadrat.Ploshad()}");
        Console.WriteLine($"{treugolnik.Imya} - Периметр: {treugolnik.Perimetr()}, Площадь: {treugolnik.Ploshad()}");
    }
}
