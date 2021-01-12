using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_5._5
{
    /// <summary>
    /// Класс описывающий задачи
    /// </summary>
    class ToDo
    {
        public string Title { get; set; }   // Название задачи
        public bool IsDone { get; set; }    // Статус выполнения
        public byte Count { get; set; }     // Порядковый номер задачи
        /// <summary>
        /// Конструктор по умолчанию. Необходим для десериализации
        /// </summary>
        public ToDo()
        {

        }
        /// <summary>
        /// Конструктор для создания экземпляра класса задач
        /// </summary>
        /// <param name="count">порядковый номер задачи</param>
        /// <param name="title">Название задачи</param>
        /// <param name="isDone">Статус выполнения</param>
        public ToDo(byte count, string title, bool isDone = false) 
        {
            Title = title;
            IsDone = isDone;
            Count = count;
        }
        /// <summary>
        /// Форматированный вывод задачи на консоль
        /// </summary>
        public void Print ()
        {
            string status = IsDone ? "[x]" : "[ ]";
            string output = String.Format(" {0}\t   {1}\t\t{2}", Count, status, Title );
            Console.WriteLine(output);
        }
        /// <summary>
        /// Метод изменения текущего статуса задачи
        /// </summary>
        public void ChangeStatus()
        {
            IsDone = !IsDone;
        }
        /// <summary>
        /// Метод изменения названия задачи
        /// </summary>
        /// <param name="newTitle">Новое название</param>
        public void ChangeTitle(string newTitle)
        {
            Title = newTitle ?? Title;
        }
    }
}
