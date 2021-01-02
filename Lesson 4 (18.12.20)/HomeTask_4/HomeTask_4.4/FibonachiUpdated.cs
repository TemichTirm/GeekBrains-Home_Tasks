using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._4
{
    /// <summary>
    /// Класс вычисления числа из последовательности Фибоначчи по индексу рекурсивным способом (с памятью)
    /// </summary>
    class FibonachiUpdated : Fibonachi
    {
        private static ulong[] memory = new ulong[92];  // Массив для хранения значений последовательности
                                                        // для оптимизации рекурсивного вычисления
                                                        // размерность 92 элемента, т.к. при 93 идет 
                                                        // переполнение верхней границы значений для типа ulong
        /// <summary>
        /// Вычисляет число из последовательности Фибоначчи для указанного индекса методом рекурсии (оптимизирован)
        /// </summary>
        /// <param name="index">Индекс элемента последовательности</param>
        /// <returns>Значение из последовательности Фибоначчи</returns>
        static public ulong CalculateFibonachi(int index)
        {
            if (index <= 1) return (ulong)index;    // Условие терминации рекурсии
            else if (memory[index] != 0) return memory[index];
            else
            {
                memory[index] = CalculateFibonachi(index - 1) + CalculateFibonachi(index - 2);
                return memory[index];
            }
        }
    }
}
