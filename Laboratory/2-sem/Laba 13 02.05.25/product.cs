using System;
using System.Collections.Generic;
using System.Linq;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ProductMovement
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public string Prefix { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerUnit { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var suppliers = new List<Supplier>
        {
            new Supplier { Id = 1, Name = "Поставщик 1", Phone = "123456" },
            new Supplier { Id = 2, Name = "Поставщик 2", Phone = "654321" }
        };

        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Носки" },
            new Product { Id = 2, Name = "Футболки" }
        };

        var movements = new List<ProductMovement>
        {
            new ProductMovement { ProductId = 1, SupplierId = 1, Prefix = "Поступление", Date = DateTime.Parse("2025-06-01"), Quantity = 100, PricePerUnit = 10 },
            new ProductMovement { ProductId = 2, SupplierId = 2, Prefix = "Поступление", Date = DateTime.Parse("2025-06-02"), Quantity = 50, PricePerUnit = 20 },
            new ProductMovement { ProductId = 1, SupplierId = 1, Prefix = "Продажа", Date = DateTime.Parse("2025-06-03"), Quantity = 30, PricePerUnit = 15 },
            new ProductMovement { ProductId = 2, SupplierId = 2, Prefix = "Продажа", Date = DateTime.Parse("2025-06-04"), Quantity = 10, PricePerUnit = 25 }
        };

        var stock = products.Select(p => new
        {
            Product = p.Name,
            Stock = movements
                .Where(m => m.ProductId == p.Id)
                .Sum(m => m.Prefix == "Поступление" ? m.Quantity : -m.Quantity)
        });

        Console.WriteLine("Остатки товаров:");
        foreach (var item in stock)
            Console.WriteLine($"{item.Product}: {item.Stock}");

        var suppliesBySupplier = movements
            .Where(m => m.Prefix == "Поступление")
            .GroupBy(m => m.SupplierId)
            .Select(g => new
            {
                Supplier = suppliers.First(s => s.Id == g.Key).Name,
                Products = g.Select(m => products.First(p => p.Id == m.ProductId).Name).Distinct()
            });

        Console.WriteLine("\nТовары по поставщикам (только поставки):");
        foreach (var group in suppliesBySupplier)
        {
            Console.WriteLine($"{group.Supplier}: {string.Join(", ", group.Products)}");
        }

        var salesByDate = movements
            .Where(m => m.Prefix == "Продажа")
            .GroupBy(m => m.Date.Date)
            .Select(g => new
            {
                Date = g.Key,
                Products = g.Select(m => products.First(p => p.Id == m.ProductId).Name).Distinct()
            });

        Console.WriteLine("\nТовары по продажам, сгруппированные по дате продажи:");
        foreach (var group in salesByDate)
        {
            Console.WriteLine($"{group.Date.ToShortDateString()}: {string.Join(", ", group.Products)}");
        }
    }
}
