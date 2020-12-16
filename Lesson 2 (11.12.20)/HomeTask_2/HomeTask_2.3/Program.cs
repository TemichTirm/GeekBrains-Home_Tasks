using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2._3
{
    public class HomeTask2_3
    {
        #region Метод получения значения целого числа из консоли без проверки
        /// <summary>
        /// Выводит значение в виде целого числа без проверки после ввода в консоли
        /// </summary>
        static int GetValue()
        {
            int value;
            string input = Console.ReadLine();
            while (!int.TryParse(input.Replace('.', ','), out value))
            {
                Console.WriteLine("Вы ввели неправильное значение, пожалуйста введите снова:");
                input = Console.ReadLine();
            }
            return value;
        }
        #endregion

        public static void IsIven()
        {
            // Запрос целого числа
            Console.WriteLine("Пожалуйста введите целое число:");
            int number = GetValue();

            Console.Clear();

            // Определение четности числа
            if (number % 2 == 0)
                Console.WriteLine($"Число {number} является четным");
            else
                Console.WriteLine($"Число {number} является нечетным");

            Console.ReadLine();
        }
        static void Main()
        {
            IsIven();
        }
    }
}
