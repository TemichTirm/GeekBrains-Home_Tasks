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
            //binaryTree.Add(11);
            //binaryTree.Add(15);
            //binaryTree.Add(7);
            //binaryTree.Add(6);
            //binaryTree.Add(9);
            //binaryTree.Add(7);
            //binaryTree.Add(8);
            //binaryTree.Add(5);
            //binaryTree.Add(12);
            //binaryTree.Add(25);
            //binaryTree.Add(30);
            //binaryTree.Add(14);
            //binaryTree.Add(19);
            //binaryTree.Add(10);
            #endregion
            int choice = 1;
            int minValue = 0;
            int maxValue = 99;
            while (choice != 0)
            {
                binaryTree.Print();
                BinaryTree.PrintMenu();
                choice = GetValue(0, 2);
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
                }
                Console.Clear();       
            }
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
                Console.Write($"Ошибка! Вы ввели неверное значение, пожалуйста введите число от {minValue} до {maxValue}:");
                input = Console.ReadLine();
            }
            return value;
        }
    }
}
