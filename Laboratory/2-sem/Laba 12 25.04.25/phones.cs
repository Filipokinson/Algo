using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneDatabase
{
    class Phone
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Phone> phones = new List<Phone>();
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Добавить телефон");
                Console.WriteLine("2. Сгруппировать телефоны по стране");
                Console.WriteLine("3. Найти телефоны по году выпуска");
                Console.WriteLine("4. Сгруппировать телефоны по марке");
                Console.WriteLine("5. Выйти");
                Console.Write("Выберите пункт меню: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Марка: ");
                    string brand = Console.ReadLine();
                    Console.Write("Год выпуска: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Страна использования: ");
                    string country = Console.ReadLine();
                    phones.Add(new Phone { Brand = brand, Year = year, Country = country });
                    Console.WriteLine("Телефон добавлен!");
                }
                else if (choice == "2")
                {
                    var groupedByCountry = phones.GroupBy(p => p.Country);
                    foreach (var group in groupedByCountry)
                    {
                        Console.WriteLine($"\nСтрана: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"  Марка: {phone.Brand}, Год: {phone.Year}");
                        }
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Введите год выпуска: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    var byYear = phones.Where(p => p.Year == year);
                    Console.WriteLine($"\nТелефоны {year} года:");
                    foreach (var phone in byYear)
                    {
                        Console.WriteLine($"Марка: {phone.Brand}, Страна: {phone.Country}");
                    }
                }
                else if (choice == "4")
                {
                    var groupedByBrand = phones.GroupBy(p => p.Brand);
                    foreach (var group in groupedByBrand)
                    {
                        Console.WriteLine($"\nМарка: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"  Год: {phone.Year}, Страна: {phone.Country}");
                        }
                    }
                }
                else if (choice == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный пункт меню.");
                }
            }
        }
    }
}
