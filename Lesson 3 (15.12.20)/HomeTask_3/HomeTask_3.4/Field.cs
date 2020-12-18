using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3._4
{
    /// <summary>
    /// Класс описывающий поле для морского юоя 10х10
    /// </summary>
    class Field
    {
        private bool[,] field; // Представление поля для морского боя в виде двумерного массива булевых переменных 
        /// <summary>
        /// Инициализация пустого поля в виде двумерного массива булевых переменных со значением по умолчанию false
        /// </summary>
        public Field()
        { 
            field = new bool[10,10]; //False значит поле свободно, true - занято
        }
        /// <summary>
        /// Вывод поля на консоль
        /// </summary>
        public void Draw ()
        {
            string offset = new string(' ',1); // Задание сдвига по горизонтали, чтобы поле выглядело квадратным
            
            // Вывод подписей столбщов
            char sign = 'A';
            Console.Write($"     ");
            for (int i = 1; i <= 10; i++) Console.Write($"{offset}{sign++}");
            Console.WriteLine();

            // Вывод по строчный подписей строк и самого поля
            for (int j = 1; j <= 10; j++)
            {
                Console.Write("\n {0,2}  ",j); // Вывод подписей строк
                for (int i = 1; i <=10; i++)
                {
                    if (field[i-1, j-1])
                        Console.Write($"{offset}0"); // В случае если ячейка занята
                    else
                        Console.Write($"{offset}."); // В случае если ячейка свободна
                }
            }
            
        }
        /// <summary>
        /// Проверка свободных ячеек на поле для возможности установки корабля
        /// </summary>
        /// <param name="ship">Объект класса корабли</param>
        /// <returns>Истина, если все ячейки поля для всех элементов корабля свободны, иначе - ложь</returns>
        public bool IsFieldFree(Ships ship)
        {
            bool answer = false;

            // Проверка наличия свободной ячейки поля для каждого элемента корабля
            foreach (PartOfShip part in ship.pList)
            {
                if (!field[part.x, part.y]) answer = true;
                else
                {
                    answer = false;
                    break;
                }
            }

            // Если для какого-то элемента ячейка на поле будет занята, будет возвращено значение false
            // и корабль установлен не будет
            if (!answer)
            {
                return answer;
            }  

            // Если для всех элементов корабля ячейки свободные, устанавливается параметр "занято"
            // для ячейки под этим элементом и для всех ячеек вокруг него
            foreach (PartOfShip part in ship.pList)
            {
                field[part.x, part.y] = true;
                if (part.x - 1 >= 0) field[part.x - 1, part.y] = true;
                if (part.x + 1 < 10) field[part.x + 1, part.y] = true;
                if (part.y - 1 >= 0) field[part.x, part.y - 1] = true;
                if (part.y + 1 < 10) field[part.x, part.y + 1] = true;
                if ((part.x - 1 >= 0) && (part.y - 1 >= 0)) field[part.x - 1, part.y - 1] = true;
                if ((part.x - 1 >= 0) && (part.y + 1 < 10)) field[part.x - 1, part.y + 1] = true;
                if ((part.x + 1 < 10) && (part.y - 1 >= 0)) field[part.x + 1, part.y - 1] = true;
                if ((part.x + 1 < 10) && (part.y + 1 < 10)) field[part.x + 1, part.y + 1] = true;
            }
                return answer;
        }

    }
}
