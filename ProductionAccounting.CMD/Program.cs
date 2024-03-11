using ProductionAccounting.BL.Controller;
using ProductionAccounting.BL.Model;
using System;
using System.ComponentModel;

namespace ProductionAccounting.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение ProductionApplication");
            Console.WriteLine("Введите имя пользователя");

           var name = Console.ReadLine();


            var userController = new UserController(name);
            var productionController = new ProductionController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                
                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести итоги производства");
            var key = Console.ReadKey();

            if(key.Key == ConsoleKey.E)
            {
                var tares = EnterProduction();
                productionController.Add(tares.Tare, tares.Numb);

                foreach(var item in productionController.Production.Tares)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }

            }
            Console.ReadLine();


        }

        private static (Tare Tare, int Numb) EnterProduction()
        {
            Console.WriteLine("Введите название тары: ");
            var tare = Console.ReadLine();


            var volume = ParseDouble("объем");
            var weight = ParseDouble("вес тары");
            var price = ParseDouble("цена");


            var numb = ParseInt("произведенное количество");
            var product = new Tare(tare,volume, price, numb, weight) ;

            return (Tare: product,Numb:  numb);

            


        }

        private static DateTime ParseDateTime()
            {
                DateTime birthDate;

                while (true)
                {

                    Console.Write("Введите дату рождения (dd.MM.yyyy): ");

                    if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты рождения.");
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
