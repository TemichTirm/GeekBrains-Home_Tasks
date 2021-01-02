using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._4
{
    /// <summary>
    /// Класс вывода результатов подсчета в форматированном виде
    /// </summary>
    class Fibonachi
    {
        static public void PrintResult(string description, ulong result)
        {            
            string resultString = FormatString.FormatStringResult(result);
            Console.WriteLine($"{description} {resultString}");
        }
    }
}
