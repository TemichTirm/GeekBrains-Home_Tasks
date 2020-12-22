using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook myPhoneBook = new PhoneBook(); //Создание экземпляра телефонного справочника
            Console.WriteLine("Телефонный справочник по умолчанию:\n");
            myPhoneBook.Print();

            // Запрос на изменение записей
            while (true)
            {
                Console.Write("\nХотите изменить какую-нибудь запись? Д/Н");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.L)
                {
                    Console.Write("\nВведите номер записи,которую хотите изменить:");
                    myPhoneBook.ChangeRecord(GetValue(myPhoneBook.NumbersOfRecords()));
                    Console.Clear();
                    Console.WriteLine("Обновленный телефонный справочник:\n");
                    myPhoneBook.Print();
                }
                else if (key.Key == ConsoleKey.Y)
                {
                    return;
                }
            }

        }
        #region Метод получения значения целого числа из консоли c проверкой превышения значений
        /// <summary>
        /// Выводит значение в виде целого числа с проверкой после ввода в консоли
        /// </summary>
        /// <param name="checkvalue">Максимальная величина модуля значения</param>
        /// <returns></returns>
        static int GetValue(int checkvalue)
        {
            int value;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out value) || (value > checkvalue) || (value <= 0))
            {
                Console.WriteLine("Вы ввели неправильное значение, пожалуйста введите снова:");
                input = Console.ReadLine();
            }
            return value;
        }
        #endregion
    }
}
