using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Определение простого числа с помощью алгоритма из блок-схемы
            Stopwatch stopWatch = new Stopwatch();
            int number = GetValue();
            stopWatch.Start();
            Console.WriteLine($"Число {number} - {(IsSimpleNumber(number) ? "простое" : "не простое")}!");
            stopWatch.Stop();
            Console.WriteLine($"Время выполнения алгоритма в соответствии с блок-схемой - " +
                              $"{FormatElapsedTime(stopWatch)}");

            // Определение простого числа с помощью оптимизированного алгоритма
            stopWatch.Restart();
            Console.WriteLine($"\nЧисло {number} - {(IsSimpleNumber_Optimized(number) ? "простое" : "не простое")}!");
            stopWatch.Stop();
            Console.WriteLine($"Время выполнения оптимизированного алгоритма - " +
                              $"{FormatElapsedTime(stopWatch)}");
            Console.ReadLine();
        }
        /// <summary>
        /// Получение с консоли целочисленного значения в указанном диапазоне значений. Если диапазон не указан,
        /// то по умолчанию он устанавливается от 0 до int.maxValue (2 147 483 647).
        /// </summary>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <returns>Целое число в указанном диапазоне</returns>
        static int GetValue(int minValue = 0, int maxValue = int.MaxValue)
        {
            int value;
            string min = minValue == 0 ? "0" : minValue.ToString("#,#", new CultureInfo("ru-RU"));
            string max = maxValue == 0 ? "0" : maxValue.ToString("#,#", new CultureInfo("ru-RU"));
            Console.WriteLine($"Пожалуйста введите целое число в диапазоне от {min} до {max}:");
            while(!int.TryParse(Console.ReadLine(), out value) || (value < minValue) || (value > maxValue))
            {
                Console.WriteLine($"Вы ввели неправильное значение, пожалуйста введите целое число в диапазоне" +
                    $" от {minValue} до {maxValue}:");
            }
            return value;
        }
        /// <summary>
        /// Определение является ли указанное число простым (алгоритм по блок-схеме)
        /// </summary>
        /// <param name="number">Целое число для проверки</param>
        /// <returns>True - если число простое, False - если нет</returns>
        static bool IsSimpleNumber(int number)
        {
            int d = 0, i = 2;
            while(i < number)
            {
                d = number % i == 0 ? d++ : d;
                i++;
            }
            return d == 0;
        }
        /// <summary>
        /// Определение является ли указанное число простым по оптимизированному алгоритму
        /// </summary>
        /// <param name="number">Целое число для проверки</param>
        /// <returns>True - если число простое, False - если нет</returns>
        static bool IsSimpleNumber_Optimized(int number)
        {
            int d = 0, i = 2;
            while ((i < number) && (d == 0))
            {
                d = number % i == 0 ? d++ : d;
                i++;
            }
            return d == 0;
        }
        /// <summary>
        /// Форматирует время выполнения кода в привычную форму hh:mm:ss:msms
        /// </summary>
        /// <param name="stopwatch">Объект типа Stopwatch</param>
        /// <returns>Форматированная строка</returns>
        static public string FormatElapsedTime(Stopwatch stopwatch)
        {
            TimeSpan ts = stopwatch.Elapsed;
            return String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                                ts.Hours, ts.Minutes, ts.Seconds,
                                                ts.Milliseconds);
        }
    }
}
