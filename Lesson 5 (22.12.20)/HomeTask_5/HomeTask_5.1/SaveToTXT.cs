using System;
using System.IO;

namespace HomeTask_5._1
{
    /// <summary>
    /// Записывает строку текстовый файл 
    /// </summary>
    class SaveToTXT
    {
        static void Main()
        {
            string filename = "text.txt";
            string confirmation = "Информация успешно записана.";
            
            Console.WriteLine($"Введите информацию для записи в файл {filename}:\n");
            string input = Console.ReadLine();
            File.WriteAllText(filename, input);
            Console.WriteLine($"\n{confirmation}\n");

            // Добавление строки в текстовый файл
            Console.WriteLine("Хотите добавить строку в файл? Д/Н");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y) return;
                if (key.Key == ConsoleKey.L)
                {
                    Console.WriteLine($"Введите информацию для добавления в файл {filename}:\n");
                    input = Console.ReadLine();
                    File.AppendAllText(filename, Environment.NewLine);
                    File.AppendAllText(filename, input);
                    Console.WriteLine($"\n{confirmation}");
                    return;
                }
            }
        }
    }
}
