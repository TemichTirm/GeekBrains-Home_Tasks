using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._4
{
    /// <summary>
    /// Класс форматирования представления результата чисел формата ulong
    /// </summary>
    class FormatString
    {
        /// <summary>
        /// Метод форматирования представления результата
        /// </summary>
        /// <param name="result">Входной параметр</param>
        /// <returns>Результат в виде форматированной строки</returns>
        static public string FormatStringResult(ulong result)
        {
            if (result == 0) return result.ToString();
            return String.Format("{0: ### ### ### ### ### ### ###}", result);
        }
    }
}
