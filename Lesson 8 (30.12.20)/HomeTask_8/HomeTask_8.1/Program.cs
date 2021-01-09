using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Properties.Settings.Default.greeting);

            if (string.IsNullOrEmpty(Properties.Settings.Default.userName))
            {
                Console.WriteLine("\nПожалуйста введите своё имя:");
                Properties.Settings.Default.userName = Console.ReadLine();
                Console.WriteLine("\nПожалуйста введите свой возраст:");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int userAge))
                    {
                        if ((userAge > 0) && (userAge <= 120))
                        {
                            Properties.Settings.Default.userAge = userAge;
                            break;
                        }
                    }
                    Console.WriteLine("Вы ввели неверные данные, пожалуйста попробуйте снова:");
                }
                Console.WriteLine("\nПожалуйста введите свой род деятельности:");
                Properties.Settings.Default.userJob = Console.ReadLine();
                Properties.Settings.Default.Save();
                Console.WriteLine("Ваши данные успешно сохранены в настройках.");
            }
            else
            {
                string userName = Properties.Settings.Default.userName;
                int userAge = Properties.Settings.Default.userAge;
                string userJob = Properties.Settings.Default.userJob;
                Console.WriteLine($"{Properties.Settings.Default.userGreeting} {userName}");
                Console.WriteLine($"Ваш возраст: {userAge}");
                Console.WriteLine($"Ваша род деятельности: {userJob}");
            }
            Console.ReadLine();
            //Properties.Settings.Default.Reset();            
        }
    }
}
