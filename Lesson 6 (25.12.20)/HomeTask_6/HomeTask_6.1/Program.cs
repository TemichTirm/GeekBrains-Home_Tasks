using System;
using System.Diagnostics;
using System.Globalization;

namespace HomeTask_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();   // Получение списка процессов

            // Формирование заголовка списка в форматированном виде
            string pattern = "{0,-40}{1,6}  {2}\t{3}    {4}";
            string header = String.Format(pattern, "Имя процесса", "ID", "Приоритет", "Память", "Время запуска" +
                    "\n=============================================================================================");
            Console.WriteLine(header);

            // Вывод списка процессов в консоль в форматированном виде
            foreach (Process process in processes)
            {
                string time;
                try { time = process.StartTime.ToString(); }
                catch { time = "Нет доступа"; }
                // Приведение значения выделенной памяти к КБ
                string memorySize = (process.PagedMemorySize64 / 1024).ToString("#,#", new CultureInfo("ru-RU"));                
                pattern = "{0,-40}{1,6}  {2}\t  {3,9} КБ    {4}"; // Формирование шаблона вывода
                string output = String.Format(pattern, process.ProcessName, process.Id, process.BasePriority, memorySize, time);
                Console.WriteLine(output);
            }

            // Запрос на выход или завершение процесса по имени или ID
            while(true)
            {
                Console.WriteLine("\nДля завершения процесса введите его имя или ID:    (Esc - выход)");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) { return; } // Выход из программы по кнопне Esc
                else
                {
                    string input = key.KeyChar + Console.ReadLine();                    
                    if (int.TryParse(input, out int id))    //  Завершение процесса по ID
                    {
                        foreach (Process process in processes)
                        {
                            if (process.Id == id)
                            {
                                KillProcess(process);
                                return;
                            }                            
                        }
                    }
                    else                                    // Завершение процесса по имени
                    {
                        foreach (Process process in processes)
                        {
                            if (process.ProcessName == input)
                            {
                                KillProcess(process);
                                return;
                            }
                        }
                    }
                }
                Console.WriteLine("Неправильно указано имя или ID");
            }
        }
        /// <summary>
        /// Завершение процесса и вывод информационного сообщения
        /// </summary>
        /// <param name="process">Объект процесса</param>
        static void KillProcess(Process process)
        {
            try
            {
                process.Kill();
                Console.WriteLine("Процесс завершен.");
                Console.ReadLine();                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }            
        }
    }
}
