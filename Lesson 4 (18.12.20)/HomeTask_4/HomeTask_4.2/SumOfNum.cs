using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._2
{
    class SumOfNum
    {
        /// <summary>
        /// Вычисление суммы целых чисел, содержащихся в строке и разделенных пробелами
        /// </summary>
        static void Main()
        {
            string greeting = "Пожалуйста введите набор целых чисел через пробел для вычисления суммы";
            string attention = "(Внимание! Символы, а также числа с плавающей точкой будут игнорироваться!)\n";
            string result = "Сумма введенных Вами чисел равна";
            
            Console.WriteLine(greeting);
            Console.WriteLine(attention);
            string input = Console.ReadLine();
            
            Console.WriteLine($"{result} {SumOfNumbers(input)}");
            Console.ReadLine();
        }
        /// <summary>
        /// Выдает сумму всех целых чисел, разделенных пробелами, в передаваемой строке. Игнорирует символы и числа с плавающей запятой.
        /// </summary>
        /// <param name="str">Строка из которой берутся числа</param>
        /// <returns>Сумма всех целых чисел в строке</returns>
        static int SumOfNumbers(string str)
        {
            int sum = 0;
            string[] numbers = str.Split(' ');  // Разделение полученной строки на массив подстрок. Разделитель - пробел.
            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.TryParse(numbers[i], out int value))
                    sum += value;
            }
            return sum;
        }
    }
}
