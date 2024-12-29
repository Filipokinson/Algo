using System;
using System.Globalization;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        using (StreamReader fileReader = new StreamReader("input6.txt"))
        {
            int totalLines = Convert.ToInt32(fileReader.ReadLine());
            double minPrice = double.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < totalLines; i++)
            {
                string line = fileReader.ReadLine();

                double price = CalculatePrice(line);

                if (price < minPrice)
                {
                    minPrice = price;
                    minIndex = i + 1;
                }
            }

            Console.WriteLine($"Результат: {minIndex} {Math.Round(minPrice, 2)}");
        }
    }

    static double CalculatePrice(string dataLine)
    {
        string[] lineData = dataLine.Split(' ');

        int length1 = int.Parse(lineData[0]);
        int width1 = int.Parse(lineData[1]);
        int height1 = int.Parse(lineData[2]);
        int length2 = int.Parse(lineData[3]);
        int width2 = int.Parse(lineData[4]);
        int height2 = int.Parse(lineData[5]);
        double cost1 = double.Parse(lineData[6], CultureInfo.InvariantCulture);
        double cost2 = double.Parse(lineData[7], CultureInfo.InvariantCulture);

        double surfaceArea1 = 2 * (length1 * width1 + width1 * height1 + length1 * height1);
        double surfaceArea2 = 2 * (length2 * width2 + width2 * height2 + length2 * height2);
        double volume1 = length1 * width1 * height1;
        double volume2 = length2 * width2 * height2;

        double price = (-cost1 + (surfaceArea1 * cost2) / surfaceArea2) / (-((volume1 - surfaceArea1) / 1000) + (surfaceArea1 * ((volume2 - surfaceArea2) / 1000)) /
        surfaceArea2);

        return price;
    }
}
