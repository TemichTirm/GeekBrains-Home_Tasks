using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Проект для сохранения данных о погоде и методов проверки введенных значений
/// </summary>
namespace WeatherInfo
{   
    public static class WeatherInfo
    {
        public static double minTemperature;
        public static double maxTemperature;
        public static double averageTemperature;
        public static int month;

        #region Метод получения значения числа с плавающей точкой из консоли с проверкой превышения значений
        /// <summary>
        /// Выводит значение в виде рационального числа с проверкой после ввода в консоли
        /// </summary>
        /// <param name="checkvalue">Максимальная величина модуля значения</param>
        /// <returns></returns>
        public static double GetValue(double checkvalue)
        {
            double value;
            string input = Console.ReadLine();
            while (!double.TryParse(input.Replace('.', ','), out value) || (Math.Abs(value) > checkvalue))
            {
                if (Math.Abs(value) > checkvalue)
                    Console.WriteLine("Вы ввели нереальное значение, пожалуйста введите снова:");
                else
                    Console.WriteLine("Вы ввели неправильное значение, пожалуйста введите снова:");
                input = Console.ReadLine();
            }
            return value;
        }
        #endregion
        
        #region Метод получения значения целого числа из консоли c проверкой превышения значений
        /// <summary>
        /// Выводит значение в виде целого числа с проверкой после ввода в консоли
        /// </summary>
        /// <param name="checkvalue">Максимальная величина модуля значения</param>
        /// <returns></returns>
        public static int GetValue(int checkvalue)
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

        #region Метод получения значения целого числа из консоли без проверки
        /// <summary>
        /// Выводит значение в виде целого числа без проверки после ввода в консоли
        /// </summary>
        public static int GetValue()
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
        static void Main()
        {

        }
    }
}
