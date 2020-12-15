using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Домашнее задание 2.1
/// </summary>
namespace HomeTask_2._1
{
    public static class HomeTask2_1
    {
        #region Метод получения значения числа с плавающей точкой из консоли с проверкой превышения значений
        /// <summary>
        /// Выводит значение в виде числа с плавающей точкой с проверкой после ввода в консоли
        /// </summary>
        /// <param name="checkvalue">Максимальная величина модуля значения</param>
        /// <returns></returns>
        static double GetValue(double checkvalue)
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

        public static double GetAverageTemp()
        {
            // Запрос минимальной температуры за сутки
            Console.WriteLine("Пожалуйста введите минимальную температуру за сутки, градусы Цельсия:");
            double minTemperature = GetValue(100.0);

            // Запрос максимальной температуры за сутки
            Console.WriteLine("Пожалуйста введите максимальную температуру за сутки, градусы Цельсия:");
            double maxTemperature = GetValue(100.0);

            //Расчет среднего значения температуры за сутки
            double averageTemperature = (maxTemperature + minTemperature) / 2;

            //Вывод результатов на экран
            Console.Clear();
            Console.WriteLine($"Минимальная температура за сутки: {minTemperature} град. Цельсия;");
            Console.WriteLine($"Максимальная температура за сутки: {maxTemperature} град. Цельсия;");
            Console.WriteLine($"\nСредняя температура за сутки: {averageTemperature} град. Цельсия.");

            Console.ReadLine();
            return averageTemperature;
        }

        /// <summary>
        /// Вычисление средней температуры за сутки на основе мин. и макс. значений, введенных пользователем
        /// </summary>
        static void Main()
        {
            double averageTemperature = GetAverageTemp();
        }
    }
}
