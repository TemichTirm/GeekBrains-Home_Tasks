using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons__рекурсия_
{
    class Program
    {
        /// <summary>
        /// Вывод массива в консоль рекурсивным методом
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <param name="i">Индекс используемый для рекурсии. При первом вызове является необязательным параметром</param>
        static void PrintArray(int[] array, int i = 0)
        {
            if (i < array.Length)
            {
                Console.Write($"{array[i]} ");
                PrintArray(array, ++i);
            }
        }
        /// <summary>
        /// Подсчет суммы чисел в массиве рекурсивным методом
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <param name="i">Индекс используемый для рекурсии. При первом вызове является необязательным параметром</param>
        /// <returns>Сумма всех чисел в массиве</returns>
        static int SumArray(int[] array, int i = 0)
        {
            if (i >= array.Length) { return 0; }
            return array[i] + SumArray(array, ++i);
        }
        /// <summary>
        /// Подсчет суммы цифр в числе рекурсивным методом
        /// </summary>
        /// <param name="num">Исходное число</param>
        /// <returns>Сумма цифр</returns>
        static long SumDigits(long num)
        {
            if (num / 10 == 0) { return num % 10; }
            return (num % 10) + SumDigits(num / 10);
        }
        static void Main(string[] args)
        {
            int[] array = { 5, 12, 64, 78, 3, 9, 18, 51 };
            long str = 4346657567657551;
            Console.Write("Массив: ");
            PrintArray(array);
            Console.Write("\nСумма всех чисел в массиве равна = ");
            Console.WriteLine(SumArray(array));
            Console.Write($"\nСумма всех цифр в числе \"{str}\" равна = ");
            Console.WriteLine(SumDigits(str));
            Console.ReadLine();
        }
    }
}
