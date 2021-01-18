using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2._1
{
    /// <summary>
    /// Класс элементов двусвязного списка
    /// </summary>
    public class Node
    {
        public int Value { get; set; }          // Значение элемента списка
        public Node NextNode { get; set; }      // Ссылка на следующий элемент списка
        public Node PrevNode { get; set; }      // Ссылка на предыдущий элемент списка
    }
}
