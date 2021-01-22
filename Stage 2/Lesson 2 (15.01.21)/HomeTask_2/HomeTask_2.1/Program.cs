using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация двусвязного списка инаполнение его элементами
            DoubleLinkedList dList = new DoubleLinkedList();
            
            dList.AddNode(2);
            dList.AddNode(5);
            dList.AddNode(10);
            dList.AddNode(15);
            dList.AddNode(20);
            dList.AddNode(30);
            dList.AddNode(40);
            dList.AddNode(50);
            dList.AddNode(60);
            dList.AddNode(10);
            dList.AddNode(70);

            dList.PrintList();
            Console.WriteLine();

            #region Пример поиска элемента c начала, вставки нового элемента в середину списка и удаление элемента
            //Node node = dList.FindNodeFromStart(30);
            //dList.AddNodeAfter(node, 35);
            //dList.RemoveNode(node);
            //dList.PrintList();
            //Console.WriteLine();
            #endregion

            #region Пример поиска элемента с конца и удаление элемента по индексу
            //node = dList.FindNodeFromEnd(5);
            //dList.RemoveNode(10);
            //dList.RemoveNode(node);
            //dList.PrintList();
            //Console.WriteLine();
            #endregion

            #region Пример переворачивания списка
            //dList.Reverse();
            //dList.PrintList();
            //Console.WriteLine();
            #endregion

            #region Вывод значения следующего элемента за искомым
            //Console.WriteLine(dList.FindNodeFromIndex(10, 3)?.NextNode?.Value);
            #endregion

            #region Пример сортировки значений элементов списка по возрастанию
            //dList.SortUp();
            //dList.PrintList();
            //Console.WriteLine();
            #endregion

            #region Пример сортировки значений элементов списка по убыванию
            //dList.SortDown();
            //dList.PrintList();
            //Console.WriteLine();
            #endregion

            Console.ReadLine();
        }
    }
}
