using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._4
{
    /// <summary>
    /// Класс вычисления числа из последовательности Фибоначчи по индексу в цикле
    /// </summary>
    class FibonachiCycle : Fibonachi

    {
        /// <summary> 
        /// Вычисляет в цикле число из последовательности Фибоначчи по индексу
        /// </summary>
        /// <param name="index">Индекс элемента последовательности</param>
        /// <returns>Значение из последовательности Фибоначчи</returns>
        static public ulong CalculateFibonachi(int index)
        {
            ulong sumPrev = 0;
            ulong sum = 1;
            for (int i = 1; i <= index; i++)
            {
                ulong next = sum + sumPrev;
                sumPrev = sum;
                sum = next;
            }
            return sumPrev;
        }
    }
}
