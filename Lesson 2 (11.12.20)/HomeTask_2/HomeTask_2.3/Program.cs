using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запрос целого числа
            Console.WriteLine("Пожалуйста введите целое число:");
            int number = WeatherInfo.WeatherInfo.GetValue();

            Console.Clear();

            // Определение четности числа
            if (number%2 == 0)
                Console.WriteLine($"Число {number} является четным");
            else
                Console.WriteLine($"Число {number} является нечетным");

            Console.ReadLine();
        }
    }
}
