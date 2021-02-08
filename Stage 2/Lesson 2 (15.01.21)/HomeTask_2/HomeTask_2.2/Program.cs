using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 5, 6, 9, 1, 7, 3, 8, 4, 10 };
            int result = (BinarySearch(6, array));
            Console.WriteLine((result == -1) ? "Такого элемента нет!" : $"{result}");
            foreach (int a in array)
                Console.Write($"{a}, ");
            Console.ReadLine();
        }
        static int BinarySearch(int searchValue, int[] array)
        {
            if (array == null) return -1;
            Array.Sort(array);
            int minIndex = 0;
            int maxIndex = array.Length - 1;
            while(minIndex <= maxIndex)
            {
                int midIndex = (maxIndex + minIndex) / 2;
                if (array[midIndex] == searchValue) return midIndex;
                else
                {
                    if (array[midIndex] > searchValue) maxIndex = midIndex - 1; 
                    else minIndex = midIndex + 1;
                }
            }
            return -1;
            // Асимптотическая сложность бинарного поиска О(log(N) по основанию 2)
        }
    }
}
