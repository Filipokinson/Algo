using System;

namespace Animal
{
    internal class Program
    {
        public class Животное
        {
            public string Имя { get; set; }

            public Животное(string имя)
            {
                Имя = имя;
            }
        }

        public class Птица : Животное
        {
            public string Обитание { get; set; }
            public string Зимовка { get; set; }

            public Птица(string имя, string обитание, string зимовка) : base(имя)
            {
                Обитание = обитание;
                Зимовка = зимовка;
            }
        }

        public class Млекопитающее : Животное
        {
            public string Обитание { get; set; }
            public int Вес { get; set; }

            public Млекопитающее(string имя, string обитание, int вес) : base(имя)
            {
                Обитание = обитание;
                Вес = вес;
            }
        }

        static void Main(string[] args)
        {
            bool естьДанныеОМлекопитающих = false;
            bool естьДанныеOPтиц = false;
            const int размерМассива = 3;
            Млекопитающее[] массивМлекопитающих = new Млекопитающее[размерМассива];
            Птица[] массивПтиц = new Птица[размерМассива];

            while (true)
            {
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Ввод информации о птицах");
                Console.WriteLine("2. Ввод информации о млекопитающих");
                Console.WriteLine("3. Поиск млекопитающих по обитанию");
                Console.WriteLine("4. Поиск птиц по обитанию");
                Console.WriteLine("5. Поиск млекопитающих по весу");
                Console.WriteLine("6. Поиск птиц по зимовке");
                Console.WriteLine("7. Выход");
                Console.Write("Выберите действие: ");
                string выбор = Console.ReadLine();

                switch (выбор)
                {
                    case "1":
                        ДобавитьПтиц(массивПтиц);
                        естьДанныеOPтиц = true;
                        break;
                    case "2":
                        ДобавитьМлекопитающих(массивМлекопитающих);
                        естьДанныеОМлекопитающих = true;
                        break;
                    case "3":
                        if (естьДанныеОМлекопитающих)
                        {
                            Console.Write("Введите обитание: ");
                            string пользовательскоеОбитание = Console.ReadLine();
                            НайтиМлекопитающихПоОбитанию(массивМлекопитающих, пользовательскоеОбитание);
                        }
                        else
                        {
                            Console.WriteLine("Данные о млекопитающих не введены.");
                        }
                        break;
                    case "4":
                        if (естьДанныеOPтиц)
                        {
                            Console.Write("Введите обитание: ");
                            string пользовательскоеОбитание = Console.ReadLine();
                            НайтиПтицПоОбитанию(массивПтиц, пользовательскоеОбитание);
                        }
                        else
                        {
                            Console.WriteLine("Данные о птицах не введены.");
                        }
                        break;
                    case "5":
                        if (естьДанныеОМлекопитающих)
                        {
                            Console.Write("Введите вес: ");
                            string пользовательскийВес = Console.ReadLine();
                            НайтиМлекопитающихПоВесу(массивМлекопитающих, пользовательскийВес);
                        }
                        else
                        {
                            Console.WriteLine("Данные о млекопитающих не введены.");
                        }
                        break;
                    case "6":
                        if (естьДанныеOPтиц)
                        {
                            Console.Write("Введите зимовку: ");
                            string пользовательскаяЗимовка = Console.ReadLine();
                            НайтиПтицПоЗимовке(массивПтиц, пользовательскаяЗимовка);
                        }
                        else
                        {
                            Console.WriteLine("Данные о птицах не введены.");
                        }
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private static void ДобавитьМлекопитающих(Млекопитающее[] млекопитающие)
        {
            for (int i = 0; i < млекопитающие.Length; i++)
            {
                Console.Write("Введите имя млекопитающего: ");
                string имя = Console.ReadLine();
                Console.Write("Введите обитание: ");
                string обитание = Console.ReadLine();
                Console.Write("Введите вес: ");
                int вес = Convert.ToInt32(Console.ReadLine());
                Млекопитающее млекопитающее = new Млекопитающее(имя, обитание, вес);
                млекопитающие[i] = млекопитающее;
                Console.WriteLine("Данные о млекопитающем успешно добавлены.");
            }
        }

        private static void ДобавитьПтиц(Птица[] птицы)
        {
            for (int i = 0; i < птицы.Length; i++)
            {
                Console.Write("Введите имя птицы: ");
                string имя = Console.ReadLine();
                Console.Write("Введите обитание: ");
                string обитание = Console.ReadLine();
                Console.Write("Введите зимовку: ");
                string зимовка = Console.ReadLine();
                Птица птица = new Птица(имя, обитание, зимовка);
                птицы[i] = птица;
                Console.WriteLine("Данные о птице успешно добавлены.");
            }
        }

        private static void НайтиМлекопитающихПоОбитанию(Млекопитающее[] млекопитающие, string обитание)
        {
            foreach (Млекопитающее млекопитающее in млекопитающие)
            {
                if (млекопитающее != null && млекопитающее.Обитание == обитание)
                {
                    Console.WriteLine($"Имя: {млекопитающее.Имя}");
                }
            }
        }

        private static void НайтиМлекопитающихПоВесу(Млекопитающее[] млекопитающие, string вес)
        {
            int весЧисло = Convert.ToInt32(вес);
            foreach (Млекопитающее млекопитающее in млекопитающие)
            {
                if (млекопитающее != null && млекопитающее.Вес == весЧисло)
                {
                    Console.WriteLine($"Имя: {млекопитающее.Имя}");
                }
            }
        }

        private static void НайтиПтицПоОбитанию(Птица[] птицы, string обитание)
        {
            foreach (Птица птица in птицы)
            {
                if (птица != null && птица.Обитание == обитание)
                {
                    Console.WriteLine($"Имя: {птица.Имя}");
                }
            }
        }

        private static void НайтиПтицПоЗимовке(Птица[] птицы, string зимовка)
        {
            foreach (Птица птица in птицы)
            {
                if (птица != null && птица.Зимовка == зимовка)
                {
                    Console.WriteLine($"Имя: {птица.Имя}");
                }
            }
        }
    }
}
