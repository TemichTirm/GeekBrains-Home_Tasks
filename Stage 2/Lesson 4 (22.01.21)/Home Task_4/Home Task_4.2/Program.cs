using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            #region Предварительное наполнение дерева элементами


            #endregion
            int choice;
            int minValue = 1;
            int maxValue = 99;
            do
            {
                binaryTree.Print();
                int menuItemsMax = binaryTree.RootNode == null ? 1 : 5;
                BinaryTree.PrintMenu(menuItemsMax);
                choice = GetValue(0, menuItemsMax);
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:         // Добавление элемента
                        Console.WriteLine($"Введите значение, которое хотите добавить в диапазоне от {minValue} до {maxValue}");
                        binaryTree.Add(GetValue(minValue, maxValue));
                        break;
                    case 2:         // Удаление элемента
                        Console.WriteLine($"Введите значение, которое хотите удалить в диапазоне от {minValue} до {maxValue}");
                        binaryTree.Delete(GetValue(minValue, maxValue));
                        break;
                    case 3:         // Поиск элемента в ширину
                        Console.WriteLine($"Введите значение, которое хотите найти в диапазоне от {minValue} до {maxValue}");
                        binaryTree.BFS(GetValue(minValue, maxValue));
                        break;
                    case 4:         // Поиск элемента в глубину
                        Console.WriteLine($"Введите значение, которое хотите найти в диапазоне от {minValue} до {maxValue}");
                        binaryTree.DFS(GetValue(minValue, maxValue));
                        break;
                    case 5:         // Бинарный поиск элемента
                        Console.WriteLine($"Введите значение, которое хотите найти в диапазоне от {minValue} до {maxValue}");
                        binaryTree.BinarySearch(GetValue(minValue, maxValue));
                        break;
                }
                Console.Clear();
            }
            while (choice != 0);
        }
        /// <summary>
        /// Выводит значение в виде числа типа Int от минимального до максимального значения включительно с проверкой после ввода в консоли 
        /// </summary>
        /// <param name="minValue">Минимальная величина значения</param>
        /// <param name="maxValue">Максимальная величина значения</param>
        /// <returns></returns>
        private static int GetValue(int minValue, int maxValue)
        {
            int value;
            string input = Console.ReadLine();
            int line = Console.CursorTop;
            while (!int.TryParse(input, out value) || (value > maxValue) || (value < minValue))
            {
                Console.Write($"Ошибка! Вы ввели неверное значение, пожалуйста введите число от {minValue} до {maxValue}: ");
                input = Console.ReadLine();
            }
            return value;
        }
    }
}
