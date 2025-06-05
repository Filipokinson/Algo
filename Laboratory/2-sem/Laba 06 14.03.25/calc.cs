using System;

public class Calculator
{
    public int A { get; set; }
    public int B { get; set; }

    public Calculator(int a, int b)
    {
        A = a;
        B = b;
    }

    public int Add() => A + B;
    public int Subtract() => A - B;
    public int Multiply() => A * B;

    public int Divide()
    {
        if (B == 0)
            throw new DivideByZeroException("Деление на ноль()");
        return A / B;
    }
}

public delegate int OperationDelegate(Calculator calc);

class Program
{
    static void Main()
    {
        Calculator calc1 = new Calculator(10, 2);
        Calculator calc2 = new Calculator(8, 4);

        OperationDelegate del1 = calc =>
        {
            int sum = calc.Add();
            int multiply = sum * calc.B;
            return multiply / calc.B;
        };

        OperationDelegate del2 = calc =>
        {
            int division = calc.Divide();
            int subtract = division - calc.B;
            return subtract * calc.B;
        };

        try
        {
            Console.WriteLine($"Результат первого делегата: {del1(calc1)}");
            Console.WriteLine($"Результат второго делегата: {del2(calc2)}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}