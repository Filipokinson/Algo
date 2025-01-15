using System;

namespace TrainStation
{
    public class TrainInfo
    {
        public string TrainNumber { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }

        public TrainInfo(string trainNumber, string destination, string departure, string departureTime)
        {
            TrainNumber = trainNumber;
            Destination = destination;
            Departure = departure;
            DepartureTime = departureTime;
        }
    }

    public class StationInfo
    {
        public string StationName { get; set; }
        public TrainInfo[] Trains { get; set; }
        public int MaxTrains { get; set; }

        public StationInfo(string stationName, int maxTrains)
        {
            StationName = stationName;
            MaxTrains = maxTrains;
            Trains = new TrainInfo[maxTrains];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StationInfo station = new StationInfo("Central Station", 3);
            bool isDataEntered = false;

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Ввод данных о поездах");
                Console.WriteLine("2. Поиск поездов по месту отправления");
                Console.WriteLine("3. Поиск поездов по месту назначения");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие: ");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        AddTrainData(station);
                        isDataEntered = true;
                        break;
                    case "2":
                        if (isDataEntered)
                        {
                            Console.Write("Введите пункт отправления: ");
                            string userDeparture = Console.ReadLine();
                            FindTrainsByDeparture(station, userDeparture);
                        }
                        else
                        {
                            Console.WriteLine("Нет добавленных поездов");
                        }
                        break;
                    case "3":
                        if (isDataEntered)
                        {
                            Console.Write("Введите пункт назначения: ");
                            string userDestination = Console.ReadLine();
                            FindTrainsByDestination(station, userDestination);
                        }
                        else
                        {
                            Console.WriteLine("Нет добавленных поездов");
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private static void AddTrainData(StationInfo station)
        {
            for (int i = 0; i < station.MaxTrains; i++)
            {
                Console.Write("Введите номер поезда: ");
                string trainNumber = Console.ReadLine();
                Console.Write("Введите пункт назначения: ");
                string destination = Console.ReadLine();
                Console.Write("Введите пункт отправления: ");
                string departure = Console.ReadLine();
                Console.Write("Введите время отправления: ");
                string departureTime = Console.ReadLine();

                TrainInfo train = new TrainInfo(trainNumber, destination, departure, departureTime);
                station.Trains[i] = train;
                Console.WriteLine("Данные о поезде успешно добавлены.");
            }
        }

private static void FindTrainsByDeparture(StationInfo station, string departure)
        {
            foreach (TrainInfo train in station.Trains)
            {
                if (train.Departure == departure)
                {
                    Console.WriteLine($"Номер поезда: {train.TrainNumber}, Отправление: {train.Departure}, Назначение: {train.Destination}, Время: {train.DepartureTime}");
                }
            }
        }

        private static void FindTrainsByDestination(StationInfo station, string destination)
        {
            foreach (TrainInfo train in station.Trains)
            {
                if (train.Destination == destination)
                {
                    Console.WriteLine($"Номер поезда: {train.TrainNumber}, Отправление: {train.Departure}, Назначение: {train.Destination}, Время: {train.DepartureTime}");
                }
            }
        }
    }
}
