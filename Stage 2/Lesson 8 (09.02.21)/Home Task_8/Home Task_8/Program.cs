using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8
{
    class Program
    {
        /// <summary>
        /// Программа реализующая метод Bucket sort
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] initialArray = new int[100000];   //Начальный массив чисел
            int maxValue = 1000;
            int blocksNumbers = (int)Math.Sqrt(initialArray.Length); //Вычисление размера блока (взяли корень от общего количества записей)
            int numbersInBlock = blocksNumbers;     //Количество чисел в блоке
            int remains = initialArray.Length - blocksNumbers * numbersInBlock; //Расчет остатка
            blocksNumbers = remains != 0 ? blocksNumbers + 1 : blocksNumbers;   //Корректировка кол-ва блоков
            int[][] arrayOfBlocks = new int[blocksNumbers][];   //Инициализация массива блоков 
            //Заполнение начального массива случайными числами и вывод в консоль
            Random rnd = new Random();
            for (int i = 0; i < initialArray.Length; i++)
            {
                initialArray[i] = rnd.Next(0, maxValue);
                Console.Write(initialArray[i] + " ");
            }
            //Создание массива списков, куда записываются уже отсортированные в каждом блоке значения
            List<int>[] arrayOfList = new List<int>[blocksNumbers]; 
            for (int i = 0; i < blocksNumbers; i++)
            {
                //Обработка блока с остатком 
                if ((i == blocksNumbers - 1) && (remains != 0))
                {
                    arrayOfBlocks[i] = new int[remains];
                    Array.Copy(initialArray, i * numbersInBlock, arrayOfBlocks[i], 0, remains);
                    arrayOfList[i] = MergeSort(arrayOfBlocks[i]).ToList();
                    continue;
                }
                //Обработка основного массива. Разделение на блоки, сортировка методом Merge sort, запись в массив списков
                arrayOfBlocks[i] = new int[numbersInBlock];
                Array.Copy(initialArray, i * numbersInBlock, arrayOfBlocks[i], 0, numbersInBlock);
                arrayOfList[i] = MergeSort(arrayOfBlocks[i]).ToList();
            }

            //Объединенеие данных из блоков, хранящихся в отсортированных списках с помощью массива
            int?[] valuesFromLists = new int?[blocksNumbers];
            for (int i = 0; i < blocksNumbers; i++)
            {
                valuesFromLists[i] = arrayOfList[i][0];
                arrayOfList[i].RemoveAt(0);
            }
            for (int i = 0; i < initialArray.Length; i++)
            {
                int? currentValue = null;
                int index = 0;
                //Нахождение минимального числа из всех минимальных значений в блоках
                for (int j = 0; j < blocksNumbers; j++)
                {
                    if (currentValue == null && valuesFromLists[j] != null)
                    {
                        currentValue = valuesFromLists[j];
                        index = j;
                    }
                    else if (valuesFromLists[j] != null && valuesFromLists[j] < currentValue)
                    {
                        currentValue = valuesFromLists[j];
                        index = j;
                    }
                }
                initialArray[i] = (int)currentValue;    //Запись очередного значения в первоначальный массив
                //Восполнение массива мин. значений из блока
                if (arrayOfList[index].Count != 0)
                {
                    valuesFromLists[index] = arrayOfList[index][0];
                    arrayOfList[index].RemoveAt(0);
                }
                //Если значения в блоке закончились, то в массиве мин. значений по этому индексу будет null
                else
                    valuesFromLists[index] = null;
            }

            //Вывод отсортированного массива в консоль для проверки
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < initialArray.Length; i++)
            {
                Console.Write(initialArray[i] + " ");
            }
            Console.ReadLine();

        }
        /// <summary>
        /// Сортировка массива методом Merge sort
        /// </summary>
        /// <param name="array">Неотсортированный массив</param>
        /// <returns>Отсортированный массив</returns>
        public static int[] MergeSort(int[] array)
        {
            if (array.Length > 2)
            {
                //Разделение исходного массива на две половины
                int half = array.Length / 2 + array.Length % 2;
                int[] part1 = new int[half];
                int[] part2 = new int[array.Length / 2];
                Array.Copy(array, 0, part1, 0, half);
                Array.Copy(array, half, part2, 0, array.Length / 2);
                //Рекурсивный вызов методасортировки для каждой половины
                part1 = MergeSort(part1);
                part2 = MergeSort(part2);

                //Объединение двух отсортированных частей массивов с помощью очереди
                Queue<int> queue1 = new Queue<int>();
                Queue<int> queue2 = new Queue<int>();
                for (int i = 0; i < part1.Length; i++)
                {
                    queue1.Enqueue(part1[i]);
                }
                for (int i = 0; i < part2.Length; i++)
                {
                    queue2.Enqueue(part2[i]);
                }
                int? num1 = null;
                int? num2 = null;
                if (queue1.Count != 0)
                    num1 = queue1.Dequeue();
                if (queue2.Count != 0)
                    num2 = queue2.Dequeue();
                for (int i = 0; i < array.Length; i++)
                {
                    if (num1 != null && num2 != null)
                        if (num1 < num2)
                        {
                            array[i] = (int)num1;
                            if (queue1.Count != 0)
                                num1 = queue1.Dequeue();
                            else
                                num1 = null;
                        }
                        else
                        {
                            array[i] = (int)num2;
                            if (queue2.Count != 0)
                                num2 = queue2.Dequeue();
                            else
                                num2 = null;
                        }
                    else if (num1 != null)
                    {
                        array[i] = (int)num1;
                        if (queue1.Count != 0)
                            num1 = queue1.Dequeue();
                        else
                            num1 = null;
                    }
                    else if (num2 != null)
                    {
                        array[i] = (int)num2;
                        if (queue2.Count != 0)
                            num2 = queue2.Dequeue();
                        else
                            num2 = null;
                    }
                }
                return array;
            }
            //Если неотсортированный массив содержит не более 2 значений (базовое условие выхода из рекурсии)
            else
            {
                if (array.Length == 2)
                {
                    if (array[0] > array[1])
                    {
                        (array[0], array[1]) = (array[1], array[0]);
                    }
                }
                return array;
            }
        }
    }
}
