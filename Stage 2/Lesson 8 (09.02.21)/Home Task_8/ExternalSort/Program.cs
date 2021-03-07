using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSort
{
    class Program
    {
        /// <summary>
        /// Программа реализующая метод External sort
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            string filename = "input.txt";
            uint numOfRecords = 1000000;
            int recordsInBlock = 100;
            int maxValue = int.MaxValue;

            //Инициализация начального массива случайными числами и запись ихв файл
            Random rnd = new Random();
            StreamWriter sWriter = new StreamWriter(filename);
            for (int i = 0; i < numOfRecords; i++)
            {
                sWriter.WriteLine(rnd.Next(0, maxValue));
            }
            sWriter.Close();

            //Подсчет количества блоков, на которые нужно разбивать исходный файл
            int remains = (int)(numOfRecords % recordsInBlock);
            int blockNumbers = remains != 0 ? (int)(numOfRecords / recordsInBlock) + 1 : (int)(numOfRecords / recordsInBlock);
            StreamReader sReader = new StreamReader(filename);
            List<string> tempFiles = new List<string>();        //Список имен временных файлов
            int blockSize;
            int tempFilesCount = 0;

            //Чтение исходного файла по частям и запись во временные файлы
            for (int i = 0; i < blockNumbers; i++)
            {
                blockSize = ((i == blockNumbers - 1) && (remains != 0)) ? remains : recordsInBlock;         
                int[] blockArray = new int[blockSize];
                for (int j = 0; j < blockArray.Length; j++)
                {
                    int.TryParse(sReader.ReadLine(), out blockArray[j]);
                }
                blockArray = MergeSort(blockArray);     //Сортировка сформированного блока методом Merge sort
                string file = $"{tempFilesCount}_" + filename;
                tempFiles.Add(file);
                tempFilesCount ++;
                //Запись отсортированного блока в файл
                using (sWriter = new StreamWriter(file))
                {
                    foreach (int num in blockArray)
                    {
                        sWriter.WriteLine(num);
                    }
                }
            }
            sReader.Close();
            //Объединение значений из временных файлов в конечный файл
            while (tempFiles.Count != 1)
            {
                //Если количество файлов не превышает допустимого числа записей в одном блоке
                if (tempFiles.Count <= recordsInBlock)
                {
                    string file = $"sorted_" + filename;
                    MargeInFile(tempFiles, file);
                    tempFiles.Add(file);
                }
                //Если количество файлов больше допустимого числа записей в одном блоке
                else
                {
                    List<string> partFiles = new List<string>();
                    partFiles.AddRange(tempFiles.GetRange(0, recordsInBlock));
                    tempFiles.RemoveRange(0, recordsInBlock);
                    string file = $"{tempFilesCount}_" + filename;
                    tempFilesCount++;
                    MargeInFile(partFiles, file);
                    tempFiles.Add(file); 
                }
            }            
        }
        /// <summary>
        /// Метод объединения значений, хранящихся во временных файлах, в один файл.
        /// </summary>
        /// <param name="files">Список исходных  файлов</param>
        /// <param name="resultFile">Имя результирующего файла</param>
        public static void MargeInFile(List<string> files, string resultFile)
        {
            //Создание массива минимальныхзначений из каждого файла
            int?[] valuesFromBlocks = new int?[files.Count];
            StreamReader[] arrayReaders = new StreamReader[files.Count];
            for (int i = 0; i < files.Count; i++)
            {
                arrayReaders[i] = new StreamReader(files[i]);
                int.TryParse(arrayReaders[i].ReadLine(), out int value);
                valuesFromBlocks[i] = value;
            }
            StreamWriter sWriter = new StreamWriter(resultFile);
            //Каждое значение должно добавляться в файл отдельно но для ускорения открыт один поток
            //sWriter.Close(); 
            int? currentValue = 0;
            while (currentValue != null)
            {
                currentValue = null;
                int index = 0;
                //Нахождение минимального значения из минимальных значений в каждом файле
                for (int j = 0; j < files.Count; j++)
                {
                    if (currentValue == null && valuesFromBlocks[j] != null)
                    {
                        currentValue = valuesFromBlocks[j];
                        index = j;
                    }
                    else if (valuesFromBlocks[j] != null && valuesFromBlocks[j] < currentValue)
                    {
                        currentValue = valuesFromBlocks[j];
                        index = j;
                    }
                }
                //Добавление очередного значения в результирующий файл
                //Каждое значение должно добавляться в файл отдельно но для ускорения открыт один поток
                //sWriter = new StreamWriter(resultFile, true);

                sWriter.WriteLine(currentValue);    
                //sWriter.Close();

                //Восполнение массива мин. значений из временных файлов
                if (int.TryParse(arrayReaders[index].ReadLine(), out int value))
                {
                    valuesFromBlocks[index] = value;
                }
                else
                {
                    valuesFromBlocks[index] = null;
                }
            }
            //Каждое значение должно добавляться в файл отдельно но для ускорения открыт один поток
            sWriter.Close(); 
            //Удаление временных файлов
            for (int i = 0; i < arrayReaders.Length; i++)
            {
                arrayReaders[i].Close();
                File.Delete(files[i]);
            }
            files.Clear();
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
