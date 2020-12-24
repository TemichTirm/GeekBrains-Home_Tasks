using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeTask_5._2
{
    class Startup
    {
        /// <summary>
        /// Запись времени старта программы в файл startup.txt
        /// </summary>
        static void Main()
        {
            string filename = "startup.txt";
            string greeting = "Эта программа записывает время её запуска в файл startup.txt";
            string confirmation = "Информация успешно внесена!";

            Console.WriteLine(greeting);
            DateTime startTime = DateTime.Now;
            string input = $"Start Time: {startTime.ToString("HH:mm:ss")}\n";
            File.AppendAllText(filename, input);

            Console.WriteLine(confirmation);
            Console.ReadLine();
        }
    }
}
