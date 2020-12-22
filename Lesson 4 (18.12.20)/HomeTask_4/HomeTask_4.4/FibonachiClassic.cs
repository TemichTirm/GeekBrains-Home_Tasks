using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._4
{
    /// <summary>
    /// Класс вычисления числа из последовательности Фибоначчи для указанного индекса рекурсивным способом
    /// </summary>
    class FibonachiClassic : Fibonachi
    {
        /// <summary>
        /// Вычисляет число из последовательности Фибоначчи для указанного индекса методом рекурсии
        /// </summary>
        /// <param name="index">Индекс элемента последовательности</param>
        /// <returns>Значение из последовательности Фибоначчи</returns>
        static public ulong CalculateFibonachi(int index)
        {
            if (index <= 1) return (ulong)index;    // Условие терминации рекурсии
            else
            {
                return CalculateFibonachi(index - 1) + CalculateFibonachi(index - 2);
            }
        }
        
    }
}
