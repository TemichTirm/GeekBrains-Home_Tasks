using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3._1
{
    class Program
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
            while (!int.TryParse(input, out value) || (value > checkvalue) || (value <= 0))
            {
                Console.WriteLine("Вы ввели неправильное значение, пожалуйста введите снова:");
                input = Console.ReadLine();
            }
            return value;
        }
        #endregion
        static void Main(string[] args)
        {
            // Запрос размера квадратного массива
            Console.WriteLine("Пожалуйста введите размер квадратного массива от 1 до 10:");
            int size = GetValue(10);

            // Запрос диапазона генерации чисел массива
            Console.WriteLine("Пожалуйста введите максимальное значение  чисел в массиве от 0 до 1 000 000:");
            int maxValue = GetValue(1000000);

            Console.WriteLine("\nИсходный массив целых чисел:\n");
            RandomArray myArray = new RandomArray(size, maxValue);
            myArray.Print();

            // Запрос вывода диагонали
            Console.WriteLine("\nКакую диагональ массива вывести на экран? 1 - главную; 0 - побочную");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    myArray.PrintDiagonal(true);
                    break;
                }
                else if (key.Key == ConsoleKey.D0)
                {
                    myArray.PrintDiagonal(false);
                    break;
                }
            }
            
            Console.ReadLine();
        }
    }
}
