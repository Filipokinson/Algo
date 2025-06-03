using System;
using System.Collections.Generic;
using System.Linq;

struct LoanInfo
{
    public DateTime? IssueDate;
    public DateTime? ReturnDate;
}

class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Publisher { get; set; }
    public LoanInfo LoanInfo { get; set; }
}

class Program
{
    static void Main()
    {
        List<Book> library = new List<Book>
        {
           new Book
            {
                Author = "Лев Толстой",
                Title = "Война и мир",
                Year = 2023,
                Publisher = "АСТ",
                LoanInfo = new LoanInfo
                {
                    IssueDate = null,
                    ReturnDate = null
                }
            },
            new Book
            {
                Author = "Фёдор Достоевский",
                Title = "Преступление и наказание",
                Year = 2022,
                Publisher = "Эксмо",
                LoanInfo = new LoanInfo
                {
                    IssueDate = new DateTime(2025, 4, 15),
                    ReturnDate = new DateTime(2025, 5, 1)
                }
            },
            new Book
            {
                Author = "Антон Чехов",
                Title = "Три сестры",
                Year = 2024,
                Publisher = "Азбука",
                LoanInfo = new LoanInfo
                {
                    IssueDate = null,
                    ReturnDate = null
                }
            },
        };

        var notLoanedBooks = library.Where(b => !b.LoanInfo.IssueDate.HasValue).ToList();
        Console.WriteLine("Книги, которые ни разу не выдавались:");
        foreach (var book in notLoanedBooks)
        {
            Console.WriteLine($"{book.Author} - {book.Title} ({book.Year}, {book.Publisher})");
        }

        var notReturnedBooks = library.Where(b => 
            b.LoanInfo.IssueDate.HasValue && !b.LoanInfo.ReturnDate.HasValue).ToList();
        Console.WriteLine("\nКниги, которые не возвращены:");
        foreach (var book in notReturnedBooks)
        {
            Console.WriteLine($"{book.Author} - {book.Title} ({book.Year}, {book.Publisher})");
        }
    }
}
