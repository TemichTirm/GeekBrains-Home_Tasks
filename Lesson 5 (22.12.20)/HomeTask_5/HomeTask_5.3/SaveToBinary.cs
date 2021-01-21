using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeTask_5._3
{
    /// <summary>
    /// Сохранение целых чисел в бинарный файл 
    /// </summary>
    class SaveToBinary
    {
        /// <summary>
        /// Сохранение целых чисел, введенных пользователем с клавиатуры через пробел в бинарный файл
        /// </summary>
        static void Main()
        {
            byte minValue = byte.MinValue;
            byte maxValue = byte.MaxValue;
            string filename = "numbers.bin";
            string greeting = $"Пожалуйста введите набор целых чисел от {minValue} " +
                $"до {maxValue} через пробел для сохранения их в бинарном файле {filename}";
            string attention = "(Внимание! Символы, вещественные числа или числа за указанным " +
                "диапазоном будут игнорироваться!)\n";
            string confirmation = "Информация успешно сохранена";

            // Приветствие и ввод чисел пользователем
            Console.WriteLine(greeting);
            Console.WriteLine(attention);
            string input = Console.ReadLine();

            // Запись в файл в бинарном формате
            File.WriteAllBytes(filename, Numbers(input));
            Console.WriteLine();
            Console.WriteLine(confirmation);

            // Проверка правильности записи чисел
            Console.WriteLine("Проверка:");
            for (int i = 0; i < File.ReadAllBytes(filename).Length; i++)
            {
                Console.WriteLine(File.ReadAllBytes(filename)[i]);
            }
            
            Console.ReadLine();
        }
        /// <summary>
        /// Выдает массив целых чисел, разделенных пробелами, в передаваемой строке. 
        /// Игнорирует символы, вещественные числа и числа за диапазоном значений типа byte.
        /// </summary>
        /// <param name="str">Строка из которой берутся числа</param>
        /// <returns>Массив чисел</returns>
        static byte[] Numbers(string str)
        {
            List<byte> numbers = new List<byte>();
            // Разделение полученной строки на массив подстрок. Разделитель - пробел.
            string[] stringNumbers = str.Split(' '); 
            // Формирование списка чисел 
            for (int i = 0; i < stringNumbers.Length; i++)
            {
                if (byte.TryParse(stringNumbers[i], out byte value))
                    numbers.Add(value);
            }
            return numbers.ToArray();
        }
    }
}
