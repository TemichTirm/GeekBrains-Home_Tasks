using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeTask_5._4
{
    /// <summary>
    /// Реализация прохода по дереву каталогов и файлов по заданному пути исохранение данных в файл "dirinfo.txt"
    /// </summary>
    class DirInfo
    {
        static void Main()
        {
            string filename = "dirinfo.txt";
            string confirmation = $"Информация успешно сохранена в файл {filename}.";
            Console.WriteLine($"Укажите путь директории, содержимое которой необходимо записать в файл {filename}:");
            string path = Console.ReadLine();

            // Открытие потока для записи информации в новый файл
            StreamWriter streamWriter = new StreamWriter(filename, false);
            string input = String.Format($"Путь к директории:\n" +
                                         $"{path}\n");
            streamWriter.WriteLine(input);
            if (!Directory.Exists(path))    // Проверка на корректность заданного пути
            {
                Console.WriteLine("Указан неверный путь, такой директории не существует!");
                streamWriter.WriteLine("Указан неверный путь, такой директории не существует!");
                streamWriter.Close();
                Console.ReadLine();
                return;
            }
            else
            {
                try { Directory.SetCurrentDirectory(path); }    // Переход в указанную директорию для исключения полного пути
                catch (UnauthorizedAccessException)             // Обработка отсутствия авторизациипользователя
                {
                    Console.WriteLine("Нет аторизации для доступа к указанной директории");
                    streamWriter.WriteLine("Нет аторизации для доступа к указанной директории");
                    streamWriter.Close();
                    Console.ReadLine();
                    return;
                }
                path = @".\";
            }
            streamWriter.WriteLine($"Содержимое директории:");

            // Выбор способа прохода по дереву каталогов и файлов
            Console.WriteLine("\nПожалуйста выберите способ проверки содержимого директории:\n" +
                              "1 - С использованием рекурсии;\n" +
                              "2 - Без использования рекурсии.\n");
            while (true)
            {              
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)       // Выбор рекурсивного метода 
                {
                    Console.WriteLine($"Содержимое директории:");
                    foreach (string s in GetDirInfoByRecursion(path))
                    {
                        streamWriter.WriteLine(s);
                        Console.WriteLine(s);
                    }
                    break;
                }
                if (key.Key == ConsoleKey.D2)       // Метод без рекурсии
                {
                    Console.WriteLine($"Содержимое директории:");
                    foreach (string s in GetDirInfoWithoutRecursion(path))
                    {
                        streamWriter.WriteLine(s);
                        Console.WriteLine(s);
                    }
                    break;
                }
            }
            // Запись информации в файл и подтверждение успешности операции
            streamWriter.Close();
            Console.WriteLine($"\n{confirmation}");
            Console.ReadLine();
        }
        /// <summary>
        /// Получение информации о дереве каталогов и файлов рекурсивным способом
        /// </summary>
        /// <param name="path">Путь к директории которую нужно просканировать</param>
        /// <param name="count">Счетчик. Нужен для подсчета количества вложений при формировании отступа для каждого 
        /// следующего уровня вложенных директорий</param>
        /// <returns>Список поддиректорий и файлов хранящихся по указанному пути</returns>
        static List<string> GetDirInfoByRecursion(string path, int count = 0)
        {
            List<string> dList = new List<string>();
            string[] subDirInfo = null;
            try { subDirInfo = Directory.GetDirectories(path); }    // Получение информации о наличии поддиректорий
            catch (UnauthorizedAccessException e) { dList.Add(e.ToString()); }  // Обработка исключения отсутствия авторизации
            catch (DirectoryNotFoundException e) { dList.Add(e.ToString()); }   // Обработка исключения отсутствия директории
            string offset = new string('\t', count);    // Установка сдвига для каждого последующего уровня вложенности
            if (subDirInfo != null)
            {
                foreach (string dir in subDirInfo)
                {
                    dList.Add(offset + dir);
                    dList.AddRange(GetDirInfoByRecursion(dir, count + 1));  // Рекурсивный вызов метода для каждой поддиректории
                }
            }
            string[] fileInfo;
            try { fileInfo = Directory.GetFiles(path); }    // Получение информации о наличии файлов в директории
            catch (UnauthorizedAccessException e)           // Обработка исключения отсутствия авторизации
            {
                dList.Add(offset + e.ToString());
                return dList;
            }
            foreach (string file in fileInfo)
            {
                dList.Add(offset + file);
            }
            return dList;
        }
        /// <summary>
        /// Получение информации о дереве каталогов и файлов без рекурсии
        /// </summary>
        /// <param name="path">Путь к директории которую нужно просканировать</param>
        /// <returns>Список поддиректорий и файлов хранящихся по указанному пути</returns>
        static List<string> GetDirInfoWithoutRecursion(string path)
        {
            List<string> dList = new List<string>();
            // Получение информации о дереве каталогов и файлов
            try { dList = Directory.GetFileSystemEntries(path, "*", SearchOption.AllDirectories).ToList(); }
            catch (UnauthorizedAccessException e) { dList.Add(e.ToString()); } // Обработка исключения отсутствия авторизации
            return dList;
        }
    }

}
