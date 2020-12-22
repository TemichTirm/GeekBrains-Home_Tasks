using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._4
{
    /// <summary>
    /// Вычисление значения последовательности Фибоначчи для заданного индекса
    /// </summary>
    class CalculateFibonnachi
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            int minValue = 0;
            int maxValue = 92;
            string description = "Значение последовательности Фибоначчи для заданного индекса будет равно:";
            string requestForIndex = "Пожалуйста введите индекс, для расчета последовательности Фибоначчи в диапазоне от";

            // Вычисление значения числа Фибоначчи с возможностью повторения
            do
            {
                Console.WriteLine("Вычисление значения последовательности Фибоначчи для заданного индекса.\n");
                Console.WriteLine($"{requestForIndex} {minValue} до {maxValue}:");
                int index = GetValue(minValue, maxValue);

                PrintMenu();

                #region Вычисление значения числа Фибоначчи тремя способами на выбор пользователя 
                bool choice = true;
                while (choice) // 
                {
                    ConsoleKeyInfo choiceKey = Console.ReadKey(true);
                    switch (choiceKey.Key)
                    {
                        case ConsoleKey.D1: // Вычисление значения последовательности Фибоначчи для заданного индекса 
                                            // классической методом рекурсии
                            {
                                stopwatch.Start();
                                FibonachiClassic.PrintResult(description, FibonachiClassic.CalculateFibonachi(index));
                                stopwatch.Stop();
                                Console.WriteLine($"\nВремя выполнения методом классической рекурсии - " +
                                    $"{ElapsedTime.FormatElapsedTime(stopwatch)}");
                                stopwatch.Reset();
                                choice = false;
                                break;
                            }
                        case ConsoleKey.D2: // Вычисление значения последовательности Фибоначчи для заданного индекса 
                                            // методом оптимизированной рекурсии 
                            {
                                stopwatch.Start();
                                FibonachiUpdated.PrintResult(description, FibonachiUpdated.CalculateFibonachi(index));
                                stopwatch.Stop();
                                Console.WriteLine($"\nВремя выполнения методом оптимизированной рекурсии - " +
                                    $"{ElapsedTime.FormatElapsedTime(stopwatch)}");
                                stopwatch.Reset(); choice = false;
                                break;
                            }
                        case ConsoleKey.D3: // Вычисление значений последовательности Фибоначчи для заданного индекса 
                                            // в цикле
                            {
                                stopwatch.Start();
                                FibonachiCycle.PrintResult(description, FibonachiCycle.CalculateFibonachi(index));
                                stopwatch.Stop();
                                Console.WriteLine($"\nВремя выполнения в цикле - " +
                                    $"{ElapsedTime.FormatElapsedTime(stopwatch)}");
                                stopwatch.Reset(); choice = false;
                                break;
                            }
                    }
                }
                #endregion

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
        #region Вывод меню
        static void PrintMenu()
        {
            Console.WriteLine("\nВыберите метод подсчета элемента последовательности Фибоначчи по индексу?\n");
            Console.WriteLine("1 - метод классической рекурсии (Внимание! При индексе более 50 время расчета может быть значительным.)");
            Console.WriteLine("2 - метод оптимизированной рекурсии.");
            Console.WriteLine("3 - метод подсчета в цикле.\n");
        }
        #endregion
        #region Метод получения значения целого числа из консоли c проверкой по границам значений
        /// <summary>
        /// Выводит значение в виде целого числа от минимального до максимального значения включительно с проверкой  после ввода в консоли 
        /// </summary>
        /// <param name="minValue">Минимальная величина значения</param>
        /// <param name="maxValue">Максимальная величина значения</param>
        /// <returns></returns>
        static int GetValue(int minValue, int maxValue)
        {
            int value;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out value) || (value > maxValue) || (value < minValue))
            {
                Console.WriteLine($"Ошибка! Вы ввели неверное значение, пожалуйста введите число от {minValue} до {maxValue}:");
                input = Console.ReadLine();
            }
            return value;
        }
        #endregion
    }
}
