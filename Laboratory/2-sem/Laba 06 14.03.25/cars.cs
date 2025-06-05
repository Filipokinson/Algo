using System;
using System.Collections.Generic;

namespace CarWashExample
{
    public delegate void CarWashDelegate(Car car);

    public class Car
    {
        public int Year { get; set; }
        public string Model { get; }
        public string Color { get; }
        public bool IsDirty { get; set; }

        public Car(int year, string model, string color, bool isDirty)
        {
            Year = year;
            Model = model;
            Color = color;
            IsDirty = isDirty;
        }

        public override string ToString()
        {
            return $"{Color} {Model} {Year} года. Состояние: {(IsDirty ? "грязная" : "чистая")}";
        }
    }

    public class Garage
    {
        private List<Car> cars = new List<Car>();

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public List<Car> GetAllCars()
        {
            return cars;
        }

        public void SendCarsToWash(CarWashDelegate washAction)
        {
            foreach (var car in cars)
            {
                washAction(car);
            }
        }
    }

    public class CarWash
    {
        public void WashCar(Car car)
        {
            if (car.IsDirty)
            {
                car.IsDirty = false;
                Console.WriteLine($"Машина {car.Model} помыта");
            }
            else
            {
                Console.WriteLine($"Машина {car.Model} уже чистая");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            garage.AddCar(new Car(2020, "Toyota Camry", "Красный", true));
            garage.AddCar(new Car(2018, "Honda Civic", "Синий", false));
            garage.AddCar(new Car(2019, "Ford F-150", "Черный", true));

            CarWash carWash = new CarWash();
            CarWashDelegate washDelegate = new CarWashDelegate(carWash.WashCar);

            Console.WriteLine("Начало мойки\n");
            garage.SendCarsToWash(washDelegate);
            Console.WriteLine("\nКонец мойки");

            Console.WriteLine("\n\nСостояние машин после мойки:");
            foreach (var car in garage.GetAllCars())
            {
                Console.WriteLine(car);
            }
        }
    }
}