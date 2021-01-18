using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2._1
{
    /// <summary>
    /// Класс реализации двусвязного списка
    /// </summary>
    class DoubleLinkedList : ILinkedList
    {
        private Node StartNode { get; set; }    // Содержит начальный элемент списка
        private Node EndNode { get; set; }      // Содержит конечный элемент списка
        private int Count { get; set; }         // Содержит количество элементов списка

        /// <summary>
        /// Добавляет новый элемент в конец списка
        /// </summary>
        /// <param name="value">Значение нового элемента списка</param>
        public void AddNode(int value)
        {
            Node newNode = new Node { Value = value };
            if (Count == 0)
            {
                StartNode = newNode;
                EndNode = StartNode;
                Count++;
            }
            else
            {
                EndNode.NextNode = newNode;
                newNode.PrevNode = EndNode;
                EndNode = newNode;
                Count++;
            }
        }
        /// <summary>
        /// Добавляет новый элемент списка после указанного элемента.
        /// </summary>
        /// <param name="node">Элемент, после которого добавляется новый элемент.
        /// <param name="value">Значение нового элемента списка</param>
        public void AddNodeAfter(Node node, int value)
        {
            if (node == null) return;
            Node newNode = new Node { Value = value };
            newNode.PrevNode = node;
            newNode.NextNode = node.NextNode;
            node.NextNode.PrevNode = newNode;
            node.NextNode = newNode;
            Count++;
        }

        /// <summary>
        /// Ищет элемент по его значению с начала списка
        /// </summary>
        /// <param name="searchValue">Искомое значение</param>
        /// <returns>Элемент списка</returns>
        public Node FindNodeFromStart(int searchValue)
        {
            if (Count == 0) { return null; }
            return FindNodeFromIndex(searchValue, 0);
        }

        /// <summary>
        /// Ищет элемент по его значению с конца списка
        /// </summary>
        /// <param name="searchValue">Искомое значение</param>
        /// <returns>Элемент списка</returns>
        public Node FindNodeFromEnd(int searchValue)
        {
            if (Count == 0) { return null; }
            Node currentNode = EndNode;
            do
            {
                if (currentNode.Value == searchValue) { return currentNode; }
                currentNode = currentNode.PrevNode;
            }
            while (currentNode != null);
            return null;
        }

        /// <summary>
        /// Ищет элемент по его значению, начиная с указанного индекса
        /// </summary>
        /// <param name="searchValue">Искомое значение</param>
        /// <param name="index">Порядковый номер элемента с которого начинается поиск</param>
        /// <returns>Элемент списка</returns>
        public Node FindNodeFromIndex(int searchValue, int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException();
            }
            Node currentNode = FindNodeByIndex(index);
            do
            {
                if (currentNode.Value == searchValue) { return currentNode; }
                currentNode = currentNode.NextNode;
            }
            while (currentNode != null);
            return null;
        }

        /// <summary>
        /// Ищет элемент по его порядковому номеру
        /// </summary>
        /// <param name="index">Порядковый номер элемента</param>
        /// <returns>Элемент списка</returns>
        public Node FindNodeByIndex(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0) return StartNode;
            else if (index == (Count - 1)) return EndNode;
            else
            {
                Node currentNode;
                if (index < Count / 2)
                {
                    currentNode = StartNode;
                    int count = 0;
                    do
                    {
                        currentNode = currentNode.NextNode;
                        count++;
                    }
                    while (count != index);
                }
                else
                {
                    currentNode = EndNode;
                    int count = Count - 1;
                    do
                    {
                        currentNode = currentNode.PrevNode;
                        count--;
                    }
                    while (count != index);
                }
                return currentNode;
            }
        }

        /// <summary>
        /// Возвращает количество элементов в списке
        /// </summary>
        /// <returns>Количество элементов списка</returns>
        public int GetCount()
        {
            return Count;
        }

        /// <summary>
        /// Возвращает значение элемента списка по его порядковому номеру
        /// </summary>
        /// <param name="index">Порядковый номер элемента</param>
        /// <returns></returns>
        public int GetValue(int index)
        {
            return FindNodeByIndex(index).Value;
        }

        /// <summary>
        /// Выводит все элементы списка в консоль
        /// </summary>
        public void PrintList()
        {
            Console.WriteLine($"Элемент списка\t\tЗначение\n" +
                              $"=======================================");
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"\t{i}\t\t{GetValue(i)}");
            };
        }

        /// <summary>
        /// Удаляет элемент по порядковому номеру
        /// </summary>
        /// <param name="index">Порядковый номер элемента</param>
        public void RemoveNode(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException();
            }
            RemoveNode(FindNodeByIndex(index));
        }

        /// <summary>
        /// Удаляет указанный элемент
        /// </summary>
        /// <param name="node">Элемент списка, который необходимо удалить</param>
        public void RemoveNode(Node node)
        {
            if (node == null) return;
            if (node == StartNode)
            {
                node.NextNode.PrevNode = null;
                StartNode = node.NextNode;
            }
            else if (node == EndNode)
            {
                node.PrevNode.NextNode = null;
                EndNode = node.PrevNode;
            }
            else
            {
                node.PrevNode.NextNode = node?.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
            Count--;
        }

        /// <summary>
        /// Изменяет порядок элементов списка на обратный
        /// </summary>
        public void Reverse()
        {
            if (Count == 0) return;
            for (int i = 0; i < Count/2; i++)
            {
                Node first = FindNodeByIndex(i);
                Node second = FindNodeByIndex(Count - 1 - i);
                (first.Value, second.Value) = (second.Value, first.Value);
            }

        }

        /// <summary>
        /// Cортирует элементы списка в порядке возрастания
        /// </summary>
        public void SortUp()
        {
            if ((Count == 0) || (Count == 1)) { return; }
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 1; j < Count; j++)
                {
                    if (GetValue(j) < GetValue(j-1))
                    {
                        Node first = FindNodeByIndex(j);
                        Node second = first.PrevNode;
                        (first.Value, second.Value) = (second.Value, first.Value);
                    }
                }

            }
        }

        /// <summary>
        /// Cортирует элементы списка в порядке убывания
        /// </summary>
        public void SortDown()
        {
            if ((Count == 0) || (Count == 1)) { return; }
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 1; j < Count; j++)
                {
                    if (GetValue(j) > GetValue(j - 1))
                    {
                        Node first = FindNodeByIndex(j);
                        Node second = first.PrevNode;
                        (first.Value, second.Value) = (second.Value, first.Value);
                    }
                }
            }
        }
    }
}
