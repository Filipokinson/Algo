using System;


class Program
{
    static void Main()
    {
        PhoneBook phoneBook = new PhoneBook();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить абонента");
            Console.WriteLine("2. Выборка по оператору связи");
            Console.WriteLine("3. Выборка по году подключения");
            Console.WriteLine("4. Поиск по номеру телефона");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    phoneBook.AddAbonent();
                    break;
                case "2":
                    phoneBook.SearchByOperator();
                    break;
                case "3":
                    phoneBook.SearchByYear();
                    break;
                case "4":
                    phoneBook.SearchByPhoneNumber();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
class PhoneBook
{
    public class Phone
    {
        public string PhoneNumber { get; set; }
        public string Operator { get; set; }
        public int Year { get; set; }
        public string City { get; set; }

        public Phone(string phoneNumber, string operatorName, int year, string city)
        {
            PhoneNumber = phoneNumber;
            Operator = operatorName;
            Year = year;
            City = city;
        }

        public void Display()
        {
            Console.WriteLine($"Номер: {PhoneNumber}, Оператор: {Operator}, Год подключения: {Year}, Город: {City}");
        }
    }

    public class Abonent
    {
        public string Name { get; set; }
        public Phone[] Phones { get; set; }
        public int PhoneCount { get; set; }

        public Abonent(string name)
        {
            Name = name;
            Phones = new Phone[5];
            PhoneCount = 0;
        }

        public void AddPhone(Phone phone)
        {
            if (PhoneCount < Phones.Length)
            {
                Phones[PhoneCount] = phone;
                PhoneCount++;
            }
            else
            {
                Console.WriteLine("Достигнуто максимальное количество номеров у абонента (5).");
            }
        }

        public void Display()
        {
            Console.WriteLine($"ФИО: {Name}");
            for (int i = 0; i < PhoneCount; i++)
            {
                Phones[i].Display();
            }
        }
    }

    private Abonent[] abonents = new Abonent[10];
    private int abonentCount = 0;

    public void AddAbonent()
    {
        if (abonentCount >= abonents.Length)
        {
            Console.WriteLine("Достигнуто максимальное количество абонентов (10).");
            return;
        }

        Console.WriteLine("Введите ФИО абонента:");
        string name = Console.ReadLine();
        Abonent abonent = new Abonent(name);

        bool addingPhones = true;
        while (addingPhones)
        {
            Console.WriteLine("Введите номер телефона:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Введите оператора связи:");
            string operatorName = Console.ReadLine();

            Console.WriteLine("Введите год подключения:");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите город:");
            string city = Console.ReadLine();

            Phone phone = new Phone(phoneNumber, operatorName, year, city);
            abonent.AddPhone(phone);

            Console.WriteLine("Добавить еще один номер? (да/нет)");
            string answer = Console.ReadLine();
            if (answer.ToLower() != "да")
            {
                addingPhones = false;
            }
        }

        abonents[abonentCount] = abonent;
        abonentCount++;
        Console.WriteLine("Абонент добавлен.");
    }

    public void SearchByOperator()
    {
        Console.WriteLine("Введите название оператора:");
        string operatorName = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < abonentCount; i++)
        {
            for (int j = 0; j < abonents[i].PhoneCount; j++)
            {
                if (abonents[i].Phones[j].Operator.Equals(operatorName, StringComparison.OrdinalIgnoreCase))
                {
                    abonents[i].Display();
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Нет абонентов с таким оператором.");
        }
    }

    public void SearchByYear()
    {
        Console.WriteLine("Введите год подключения:");
        int year = Convert.ToInt32(Console.ReadLine());
        bool found = false;

        for (int i = 0; i < abonentCount; i++)
        {
            for (int j = 0; j < abonents[i].PhoneCount; j++)
            {
                if (abonents[i].Phones[j].Year == year)
                {
                    abonents[i].Display();
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Нет абонентов, подключившихся в этом году.");
        }
    }

    public void SearchByPhoneNumber()
    {
        Console.WriteLine("Введите номер телефона для поиска:");
        string phoneNumber = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < abonentCount; i++)
        {
            for (int j = 0; j < abonents[i].PhoneCount; j++)
            {
                if (abonents[i].Phones[j].PhoneNumber.Equals(phoneNumber))
                {
                    abonents[i].Display();
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Абонент с таким номером не найден.");
        }
    }
}

