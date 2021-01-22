using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
             // Вычисление значения числа Фибоначчи с возможностью повторения
            do
            {
                Console.WriteLine("Вычисление значения последовательности Фибоначчи для заданного индекса.\n");
                int index = GetValue(maxValue : 92); // 92 т.к. при индексе 93 идет переполнение через верхнюю границу значений типа ulong

                PrintMenu();

                ConsoleKeyInfo choiceKey = Console.ReadKey(true);
                switch (choiceKey.Key)
                {
                    case ConsoleKey.D1: // Вычисление значения последовательности Фибоначчи для заданного индекса 
                                        // классической методом рекурсии
                        {
                            stopwatch.Restart();
                            PrintResult(ClassicFibonachi(index));
                            stopwatch.Stop();
                            Console.WriteLine($"\nВремя выполнения методом классической рекурсии - " +
                                $"{FormatElapsedTime(stopwatch)}");
                            stopwatch.Reset();
                            break;
                        }
                    case ConsoleKey.D2: // Вычисление значения последовательности Фибоначчи для заданного индекса 
                                        // методом оптимизированной рекурсии 
                        {
                            stopwatch.Restart();
                            PrintResult(OptimizedFibonachi.Fibonachi(index));
                            stopwatch.Stop();
                            Console.WriteLine($"\nВремя выполнения методом оптимизированной рекурсии - " +
                                $"{FormatElapsedTime(stopwatch)}");
                            break;
                        }
                    case ConsoleKey.D3: // Вычисление значений последовательности Фибоначчи для заданного индекса 
                                        // в цикле
                        {
                            stopwatch.Restart();
                            PrintResult(CycleFibonachi(index));
                            stopwatch.Stop();
                            Console.WriteLine($"\nВремя выполнения в цикле - " +
                                $"{FormatElapsedTime(stopwatch)}");                         
                            break;
                        }
                }
                Console.WriteLine("\nЕсли хотите повторить вычисления, нажмите любую клавишу. Для выхода нажмите ESC");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
                Console.Clear();
            }
            while (true);
        }        
        /// <summary>
        /// Выводит меню в консоль
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine("\nВыберите метод подсчета элемента последовательности Фибоначчи по индексу?\n");
            Console.WriteLine("1 - метод классической рекурсии (Внимание! При индексе более 50 время расчета может быть значительным.)");
            Console.WriteLine("2 - метод оптимизированной рекурсии.");
            Console.WriteLine("3 - метод подсчета в цикле.\n");
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
            while (!int.TryParse(Console.ReadLine(), out value) || (value < minValue) || (value > maxValue))
            {
                Console.WriteLine($"Вы ввели неправильное значение, пожалуйста введите целое число в диапазоне" +
                    $" от {minValue} до {maxValue}:");
            }
            return value;
        }
        /// <summary>
        /// Выводит в консоль результат в форматированном виде
        /// </summary>
        /// <param name="result">Результат подсчета</param>
        static public void PrintResult(ulong result)
        {
            string description = "Значение последовательности Фибоначчи для заданного индекса будет равно:";
            string resultString = result == 0 ? "0" : result.ToString("#,#", new CultureInfo("ru-RU"));
            Console.WriteLine($"{description} {resultString}");
        }
        /// <summary>
        /// Вычисляет число из последовательности Фибоначчи для указанного индекса методом рекурсии
        /// </summary>
        /// <param name="index">Индекс элемента последовательности</param>
        /// <returns>Значение из последовательности Фибоначчи</returns>
        static public ulong ClassicFibonachi(int index)
        {
            if (index <= 1) return (ulong)index;    // Условие терминации рекурсии
            else
            {
                return ClassicFibonachi(index - 1) + ClassicFibonachi(index - 2);
            }
        }
        /// <summary> 
        /// Вычисляет в цикле число из последовательности Фибоначчи по индексу
        /// </summary>
        /// <param name="index">Индекс элемента последовательности</param>
        /// <returns>Значение из последовательности Фибоначчи</returns>
        static public ulong CycleFibonachi(int index)
        {
            ulong sumPrev = 0;
            ulong sum = 1;
            for (int i = 1; i <= index; i++)
            {
                ulong next = sum + sumPrev;
                sumPrev = sum;
                sum = next;
            }
            return sumPrev;
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
    /// <summary>
    /// Класс вычисления оптимизированной рекурсии. Создан специально для организации функции памяти
    /// </summary>
    class OptimizedFibonachi
    {
        static ulong[] memory = new ulong[93];  // Массив для хранения значений последовательности
                                             // для оптимизации рекурсивного вычисления   
                                             // размерность 93 элемента, т.к. при индексе 92 идет 
                                             // переполнение верхней границы значений для типа ulong
        /// <summary>
        /// Вычисляет число из последовательности Фибоначчи для указанного индекса методом рекурсии (оптимизирован)
        /// </summary>
        /// <param name="index">Индекс элемента последовательности</param>
        /// <returns>Значение из последовательности Фибоначчи</returns>
        static public ulong Fibonachi(int index)
        {
            if (index <= 1) return (ulong)index;    // Условие терминации рекурсии
            else if (memory[index] != 0) return memory[index];
            else
            {
                memory[index] = Fibonachi(index - 1) + Fibonachi(index - 2);
                return memory[index];
            }
        }
    }
}
