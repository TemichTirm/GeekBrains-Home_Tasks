using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите пожалуйста строку, которую необходимо инвертировать:");
            string initialString = Console.ReadLine();
            char[] charArray = new char[initialString.Length];
            for (int i = initialString.Length-1; i >= 0; i--)
            {
                charArray[(initialString.Length-1) - i] = initialString[i];
            }
            string invertString = new string(charArray);
            Console.WriteLine($"\nИнвертированная строка:\n{invertString}");
            Console.ReadLine();
        }
    }
}
