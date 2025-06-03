using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Computer
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }

    class OperatingSystem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool HasLaptop { get; set; }
        public int? LaptopBrandId { get; set; }
        public int? OsId { get; set; }
    }

    static void Main()
    {
        var computers = new List<Computer>
        {
            new Computer { Id = 1, Brand = "HP", Model = "Pavilion" },
            new Computer { Id = 2, Brand = "Dell", Model = "Inspiron" },
            new Computer { Id = 3, Brand = "Apple", Model = "MacBook Air" }
        };

        var osList = new List<OperatingSystem>
        {
            new OperatingSystem { Id = 1, Name = "Windows 11" },
            new OperatingSystem { Id = 2, Name = "macOS" }
        };

        var users = new List<User>
        {
            new User { Id = 1, FullName = "Воронина Алина", HasLaptop = true, LaptopBrandId = 1, OsId = 1 },
            new User { Id = 2, FullName = "Кудряшов Андрей", HasLaptop = false, LaptopBrandId = null, OsId = null },
            new User { Id = 3, FullName = "Новиков Семен", HasLaptop = true, LaptopBrandId = 3, OsId = 2 }
        };

        Console.WriteLine("1. Группировка по наличию ноутбука:");
        var groupByLaptop = users.GroupBy(u => u.HasLaptop);
        foreach (var group in groupByLaptop)
        {
            Console.WriteLine(group.Key ? "Есть ноутбук:" : "Нет ноутбука:");
            foreach (var user in group)
                Console.WriteLine($"  {user.FullName}");
        }

        Console.WriteLine("\n2. Группировка по марке ноутбука:");
        var groupByBrand = users
            .Where(u => u.HasLaptop)
            .GroupBy(u => u.LaptopBrandId)
            .ToList();
        foreach (var group in groupByBrand)
        {
            var brand = computers.FirstOrDefault(c => c.Id == group.Key)?.Brand ?? "Неизвестно";
            Console.WriteLine($"Марка: {brand}");
            foreach (var user in group)
                Console.WriteLine($"  {user.FullName}");
        }

        Console.WriteLine("\n3. Группировка по операционной системе:");
        var groupByOs = users
            .Where(u => u.HasLaptop)
            .GroupBy(u => u.OsId)
            .ToList();
        foreach (var group in groupByOs)
        {
            var os = osList.FirstOrDefault(o => o.Id == group.Key)?.Name ?? "Неизвестно";
            Console.WriteLine($"ОС: {os}");
            foreach (var user in group)
                Console.WriteLine($"  {user.FullName}");
        }

        Console.WriteLine("\n4. Все данные по пользователям:");
        foreach (var user in users)
        {
            string hasLaptop = user.HasLaptop ? "Да" : "Нет";
            string brand = user.HasLaptop ? computers.FirstOrDefault(c => c.Id == user.LaptopBrandId)?.Brand : "-";
            string model = user.HasLaptop ? computers.FirstOrDefault(c => c.Id == user.LaptopBrandId)?.Model : "-";
            string os = user.HasLaptop ? osList.FirstOrDefault(o => o.Id == user.OsId)?.Name : "-";
            Console.WriteLine($"{user.FullName} | Есть ноутбук: {hasLaptop} | Марка: {brand} | Модель: {model} | ОС: {os}");
        }
    }
}
