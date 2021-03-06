﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3._1
{
    /// <summary>
    /// Класс случайных двумерных квадратных массивов положительных целых чисел
    /// </summary>
    class RandomArray
    {
        private int sizeArray;
        private int[,] array;
        private Random random = new Random();
        private int maxValue;
        private int numberOfDigits;
        /// <summary>
        /// Создание экземпляра случайного двумерного квадратного массива положительных целых чисел
        /// </summary>
        /// <param name="size">Размер квадратного массива</param>
        /// <param name="maxValue">Максимальное значение для генерации элементов массива</param>
        public RandomArray(int size, int maxValue)
        {
            sizeArray = size;
            this.maxValue = maxValue;
            array = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = GenerateDigit(random, maxValue);
                }
            }
        }
        /// <summary>
        /// Вывод массива на консоль
        /// </summary>
        public void Print()
        {
            numberOfDigits = 0;
            int countDigits = this.maxValue;
            do
            {
                numberOfDigits++;
                countDigits /= 10;
            } while (countDigits != 0);

            for (int i = 0; i < sizeArray; i++)
            {
                for (int j = 0; j < sizeArray; j++)
                {
                    string output = "";
                    switch (numberOfDigits)
                    {
                        case 1: { output = string.Format("{0,1} ", array[i, j]); break; }
                        case 2: { output = string.Format("{0,2} ", array[i, j]); break; }
                        case 3: { output = string.Format("{0,3} ", array[i, j]); break; }
                        case 4: { output = string.Format("{0,4} ", array[i, j]); break; }
                        case 5: { output = string.Format("{0,5} ", array[i, j]); break; }
                        case 6: { output = string.Format("{0,6} ", array[i, j]); break; }
                        case 7: { output = string.Format("{0,7} ", array[i, j]); break; }
                    }
                 Console.Write(output);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Вывод диагоналей массива на консоль
        /// </summary>
        /// <param name="isMain">Параметр, определяющий какую диагональ выводить (true - главная, false - побочная)</param>
        public void PrintDiagonal(bool isMain)
        {
            Console.WriteLine();
            if (isMain)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    string str = new String(' ', i * (numberOfDigits + 1));
                    Console.WriteLine($"{str}{array[i, i]}");
                }
            }
            else
            {
                for (int j = array.GetLength(1)-1; j >= 0; j--)
                {
                    string str = new String(' ', j * (numberOfDigits + 1));
                    Console.WriteLine($"{str}{array[array.GetLength(1) - 1 - j, j]}");
                }
            }
        }
        /// <summary>
        /// Генерация случайных целых чисел
        /// </summary>
        /// <param name="random">экземпляр класса Random</param>
        /// <param name="maxValue">Максимальное значение случайных чисел</param>
        /// <returns></returns>
          private int GenerateDigit(Random random, int maxValue)
        {
            return random.Next(0, maxValue);
        }
    }
}
