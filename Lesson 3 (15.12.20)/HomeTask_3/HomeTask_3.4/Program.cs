using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeTask_3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n         МОРСКОЙ БОЙ!!!\n");
            Field battleField = new Field(); // Создание нового экземпляра поля
            battleField.Draw();              // Вывод поля на консоль

            List<Ships> listOfShips = new List<Ships>(); // Инициализация списка кораблей

            // Цикл создания кораблей и проверки возможности расположения на поле
            for (int i = 4; i > 0; i--)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    bool canPut;
                    do
                    {
                        Ships ship = new Ships(i);              // Создание нового экземпляра корабля
                        canPut = battleField.IsFieldFree(ship); // Проверка наличия свободных ячеек для корабля
                        if (canPut) listOfShips.Add(ship);      // Добавление корабля в список, если проверка успешна
                    }
                    while (!canPut);
                }
            }

            // Вывод всех кораблей из списка на консоль
            foreach (Ships ship in listOfShips)
            {
                ship.Draw();
                Thread.Sleep(200);
            }

            Console.SetCursorPosition(0, 15);
            Console.ReadLine();
        }
    }
}
