using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._4
{
    /// <summary>
    /// Класс форматирования времени исполнения кода
    /// </summary>
    class ElapsedTime
    {
        /// <summary>
        /// Форматирует время выполнения кода в привычную форму hh:mm:ss:msms
        /// </summary>
        /// <param name="stopwatch">Объект типа Stopwatch</param>
        /// <returns>Форматированная строка</returns>
        static public string FormatElapsedTime(Stopwatch stopwatch)
        {
            TimeSpan ts = stopwatch.Elapsed;
            return String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                                ts.Hours, ts.Minutes, ts.Seconds,
                                                ts.Milliseconds);
        }
    }
}
