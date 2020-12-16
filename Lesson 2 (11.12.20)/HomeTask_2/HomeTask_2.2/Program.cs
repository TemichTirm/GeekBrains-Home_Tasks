using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2._2
{
    /// <summary>
    /// Перечисление месяцев
    /// </summary>
    enum Months
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    public class HomeTask2_1
    {
        #region Метод получения значения целого числа из консоли c проверкой превышения значений
        /// <summary>
        /// Выводит значение в виде целого числа с проверкой после ввода в консоли
        /// </summary>
        /// <param name="checkvalue">Максимальная величина модуля значения</param>
        /// <returns></returns>
        static int GetValue(int checkvalue)
        {
            int value;
            string input = Console.ReadLine();
            while (!int.TryParse(input.Replace('.', ','), out value) || (value > checkvalue) || (value <= 0))
            {
                if ((value > checkvalue) || (value <= 0))
                    Console.WriteLine("Вы ввели нереальное значение, пожалуйста введите снова:");
                else
                    Console.WriteLine("Вы ввели неправильное значение, пожалуйста введите снова:");
                input = Console.ReadLine();
            }
            return value;
        }
        #endregion
        public static int GetMonth()
        {

            // Запрос номера месяца
            Console.WriteLine("Пожалуйста введите порядковый номер месяца:");
            int month = GetValue(12);

            //Вывод результатов на экран
            Console.Clear();
            Console.WriteLine($"Вы выбрали месяц: {(Months)month}");

            Console.ReadLine();
            return month;
        }
        static void Main()
        {
            int month = GetMonth();
        }
    }
}
