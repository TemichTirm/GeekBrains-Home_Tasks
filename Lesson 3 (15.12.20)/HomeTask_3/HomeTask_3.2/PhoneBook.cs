using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3._2
{ 
    /// <summary>
    /// Класс, описывающий телефонный справочник
    /// </summary>
    class PhoneBook
    {
        private string[,] phoneBook = new string[5,2] //Инициализациятелефонного справочника по умолчанию
        {
            { "Иванов А.А.",     "+73458329042" }, 
            { "Петров Б.Б.",     "+73876528469" },
            { "Сидоров В.В.",    "+79876543455" },
            { "Кузнецов Д.Д.",   "+75678765431" },
            { "Васечкин Г.Г.",   "+79767656734" },
        };
        /// <summary>
        /// Вывод телефонного справочника в консоль
        /// </summary>
        public void Print()
        {
            Console.WriteLine($" №\tФамилия\t\t\tНомер телефона\n");
            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
               Console.WriteLine($" {i+1}\t{phoneBook[i, 0]}\t\t{phoneBook[i, 1]}");
            }
        }
        /// <summary>
        /// Возвращает количество записей в телефонном справочнике
        /// </summary>
        /// <returns></returns>
        public int NumbersOfRecords()
        {
            return phoneBook.GetLength(0);
        }
        /// <summary>
        /// Внесит изменения в запись телефонного справочника
        /// </summary>
        /// <param name="numOfRecord">Номер записи, которую нужно изменить</param>
        public void ChangeRecord(int numOfRecord)
        {
            Console.WriteLine("\nВведите новую фамилию:");
            phoneBook[numOfRecord-1, 0] = Console.ReadLine();
            Console.WriteLine("\nВведите новый номер телефона:");
            phoneBook[numOfRecord-1, 1] = Console.ReadLine();
        }

    }
}
