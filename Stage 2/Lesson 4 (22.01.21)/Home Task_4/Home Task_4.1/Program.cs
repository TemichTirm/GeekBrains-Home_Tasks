using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Task_4._1
{
    public class BechmarkClass
    {
        // Инициализация массива и HashSet
        const int numberOfString = 10_000;
        static string[] randomString = new string[numberOfString];
        static HashSet<string> hashSetString = new HashSet<string>();
        /// <summary>
        /// Конструктор класса Benchmark наполняющий масиив и hashset случайными строками
        /// </summary>
        static BechmarkClass()
        {
            int stringLength = 10;
            Random rnd = new Random();
            for (int i = 0; i < numberOfString; i++)
            {
                randomString[i] = GenerateString(stringLength);
                hashSetString.Add(GenerateString(stringLength));
            }
        }
        /// <summary>
        /// Генерирует случайную строку зананной длины
        /// </summary>
        /// <param name="length">Длина строки</param>
        /// <returns>Случайная строка</returns>
        private static string GenerateString(int length)
        {
            string charsSample = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(charsSample[random.Next(0, charsSample.Length - 1)]);
            }
            return sb.ToString();
        }

        [Benchmark(Description = "Поиск строки в массиве")]
        public void TestSearchInArray()
        {
            string searchString = GenerateString(10);
            bool isStringExist = false;
            foreach (string str in randomString)
            {
                if (str == searchString)
                {
                    isStringExist = true;
                    break;
                }
            }
        }
        [Benchmark(Description = "Поиск строки в HashSet")]
        public void TestSearchInHashSet()
        {
            string searchString = GenerateString(10);
            bool isStringExist = false;
            if (hashSetString.Contains(searchString))
            isStringExist = true;                 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
                BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
