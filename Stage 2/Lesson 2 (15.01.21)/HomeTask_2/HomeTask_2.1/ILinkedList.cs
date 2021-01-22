using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2._1
{
    /// <summary>
    /// Интерфейс реализации двусвязанного списка
    /// </summary>
    public interface ILinkedList 
    {        
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNodeFromStart(int searchValue); // ищет элемент по его значению с начала списка
        Node FindNodeFromEnd(int searchValue); // ищет элемент по его значению с конца списка
        Node FindNodeFromIndex(int searchValue, int index); // ищет элемент по его значению, начиная с указанного индекса
        Node FindNodeByIndex(int index); // ищет элемент по его порядковому номеру
        int GetValue(int index); // возвращает значение элемента списка по его порядковому номеру
        void Reverse(); // изменяет порядок элементов списка на обратный
        void PrintList(); // выводит все элементы списка в консоль
        void SortUp(); // сортирует элементы списка в порядке возрастания
        void SortDown(); // сортирует элементы списка в порядке убывания
    }
}
