using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._1
{
    class Concatenate
    {
        /// <summary>
        /// Объединяет три строковые переменные в одну внутри отдельного метода
        /// </summary>
        static void Main()
        {
            // Массив из кортежей, содержащих отдельные записи фамилии, имени и отчества
            // сделан, чтобы заменить ручной ввод с консоли
            (string firstName, string lastName, string patronymic)[] names = 
            {
                ("Иван", "Иванов", "Иванович"),
                ("Петр", "Петров", "Петрович"),
                ("Сидор", "Сидоров", "Сидорович"),
                ("Игорь", "Кузьмин", "Валентинович"),
                ("Полиграф", "Шариков", "Полиграфович"),
            };

            Console.WriteLine("Полное ФИО:");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(GetFullName(names[i].firstName, names[i].lastName, names[i].patronymic));
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Формирует полное ФИО из отдельных элементов
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <returns>ФИО ввиде строкового значения</returns>
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return ($"{lastName} {firstName} {patronymic}");
        }
    }
}
