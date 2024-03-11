using ProductionAccounting.BL.Controller;
using ProductionAccounting.BL.Model;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace ProductionAccounting.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("ProductionAccounting.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));

            var name = Console.ReadLine();


            var userController = new UserController(name);
            var productionController = new ProductionController(userController.CurrentUser);
            var workController = new WorkController(userController.CurrentUser);

            if(userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");


                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);



            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести итоги производства");
                Console.WriteLine("A - ввести выполненную работу");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var tares = EnterProduction();
                        productionController.Add(tares.Tare, tares.Numb);

                        foreach (var item in productionController.Production.Tares)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var wrk = EnterWork();

                        workController.Add(wrk.Productivity, wrk.Begin, wrk.End);

                        foreach(var item in workController.Works)
                        {
                            Console.WriteLine($"\t{item.Productivity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }

                        break;
                    case ConsoleKey.Q:

                        Environment.Exit(0);
                        break;


                }
                Console.ReadLine();
            }



        }

        private static  (DateTime Begin, DateTime End, Productivity Productivity) EnterWork()
        {
            Console.Write("Введите название работы: ");
            var name = Console.ReadLine();

            var countPerHour = ParseDouble("количество выполненной работы за час");

            var begin = ParseDateTime("начало работы");
            var end = ParseDateTime("окончание работы");

            var productivity = new Productivity(name, countPerHour);
            return (begin, end, productivity);
        }

        private static (Tare Tare, int Numb) EnterProduction()
        {
            Console.WriteLine("Введите название тары: ");
            var tare = Console.ReadLine();


            var volume = ParseDouble("объем");
            var weight = ParseDouble("вес тары");
            var price = ParseDouble("цена");


            var numb = ParseInt("произведенное количество");
            var product = new Tare(tare, volume, price, numb, weight);

            return (Tare: product, Numb: numb);




        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;

            while (true)
            {

                Console.Write($"Введите {value} (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}.");
                }
            }
            return birthDate;

        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
        private static int ParseInt(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");

                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }

    }
}


