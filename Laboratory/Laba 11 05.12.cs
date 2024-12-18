using System;
using System.Linq;

class Student
{
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public string MotherName { get; set; }
    public string FatherName { get; set; }
    public string Address { get; set; }
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[0];
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Заполнить данные");
            Console.WriteLine("2. Изменить данные");
            Console.WriteLine("3. Поиск учеников по первой букве");
            Console.WriteLine("4. Поиск учеников по улице");
            Console.WriteLine("5. Выборка по году рождения");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите опцию: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    students = AddStudents(students);
                    break;
                case 2:
                    ModifyStudent(students);
                    break;
                case 3:
                    SearchByInitial(students);
                    break;
                case 4:
                    SearchByStreet(students);
                    break;
                case 5:
                    FilterByBirthYear(students);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static Student[] AddStudents(Student[] students)
    {
        Console.Write("Введите количество учеников для добавления: ");
        int count = int.Parse(Console.ReadLine());
        Array.Resize(ref students, students.Length + count);

        for (int i = students.Length - count; i < students.Length; i++)
        {
            students[i] = new Student();
            Console.Write("Введите ФИО ученика: ");
            students[i].FullName = Console.ReadLine();
            Console.Write("Введите год рождения: ");
            students[i].BirthYear = int.Parse(Console.ReadLine());
            Console.Write("Введите ФИО мамы (можно оставить пустым): ");
            students[i].MotherName = Console.ReadLine();
            Console.Write("Введите ФИО папы (можно оставить пустым): ");
            students[i].FatherName = Console.ReadLine();
            Console.Write("Введите адрес (улица, дом, квартира): ");
            students[i].Address = Console.ReadLine();
        }

        return students;
    }

    static void ModifyStudent(Student[] students)
    {
        if (students.Length == 0)
        {
            Console.WriteLine("Массив пустой.");
            return;
        }

        Console.Write("Введите ФИО ученика для модификации: ");
        string fullName = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.FullName == fullName);

        if (student == null)
        {
            Console.WriteLine("Ученик не найден.");
            return;
        }

        Console.Write("Введите новый год рождения: ");
        student.BirthYear = int.Parse(Console.ReadLine());
        Console.Write("Введите новое ФИО мамы (можно оставить пустым): ");
        student.MotherName = Console.ReadLine();
        Console.Write("Введите новое ФИО папы (можно оставить пустым): ");
        student.FatherName = Console.ReadLine();
        Console.Write("Введите новый адрес (улица, дом, квартира): ");
        student.Address = Console.ReadLine();
    }

    static void SearchByInitial(Student[] students)
    {
        Console.Write("Введите начальную букву: ");
        char initial = Console.ReadLine()[0];

        var results = students.Where(s => s.FullName.StartsWith(initial.ToString(), StringComparison.OrdinalIgnoreCase)).ToArray();
      if (results.Length == 0)
        {
            Console.WriteLine("Нет учеников, начинающихся на заданную букву.");
        }
        else
        {
            Console.WriteLine("Найденные ученики:");
            foreach (var student in results)
            {
                Console.WriteLine(student.FullName);
            }
        }
    }

    static void SearchByStreet(Student[] students)
    {
        Console.Write("Введите название улицы: ");
        string street = Console.ReadLine();

        var results = students.Where(s => s.Address.Contains(street, StringComparison.OrdinalIgnoreCase)).ToArray();

        if (results.Length == 0)
        {
            Console.WriteLine("Нет учеников, проживающих на заданной улице.");
        }
        else
        {
            Console.WriteLine("Найденные ученики:");
            foreach (var student in results)
            {
                Console.WriteLine(student.FullName);
            }
        }
    }

    static void FilterByBirthYear(Student[] students)
    {
        Console.Write("Введите год рождения: ");
        int year = int.Parse(Console.ReadLine());

        var results = students.Where(s => s.BirthYear == year).ToArray();

        if (results.Length == 0)
        {
            Console.WriteLine("Нет учеников, родившихся в заданном году.");
        }
        else
        {
            Console.WriteLine("Найденные ученики:");
            foreach (var student in results)
            {
                Console.WriteLine(student.FullName);
            }
        }
    }
}
