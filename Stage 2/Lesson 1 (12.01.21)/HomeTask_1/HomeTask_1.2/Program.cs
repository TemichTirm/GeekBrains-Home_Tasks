using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)  // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    {
                        int y = 0; // O(1)
                        if (j != 0)
                        {
                            y = k / j; // O(1)
                        }
                        sum += inputArray[i] + i + k + j + y; // O(1)
                    }
                }
            }
            return sum; // O(1)
        }
        // Асимптотическая сложность алгоритма = О(1) + О(N)*O(N)*O(N)*O(1+1+1) + O(1) = O(N^3)
    }
}
