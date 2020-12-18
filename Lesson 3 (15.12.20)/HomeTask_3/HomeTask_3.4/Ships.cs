using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3._4
{
    /// <summary>
    /// Класс описывающий корабли
    /// </summary>
    class Ships
    {
        private bool isVertical;    // Переменная отражающая направление корабля по вертикали илигоризонтали
        private Random random = new Random();
        private (int x, int y) initialCoordinates; // Начальные координаты кормы корабля
        public List<PartOfShip> pList;             // Список, хранящий все элементы корабля
        private char sym = 'X';                    // Символ изображающий элемент корабля на консоли
        /// <summary>
        /// Создание корабля заданного размера с проверкой возможности его расположения на поле
        /// </summary>
        /// <param name="size">Размер корабля от 1 до 4</param>
        public Ships(int size)
        {
            while (true)
            {
                pList = new List<PartOfShip>(); // Создание пустого списка, в который добавляются элементы корабля
                
                // Задание координат расположения кормы и направления корабля случайным образом
                initialCoordinates.x = random.Next(0, 10);
                initialCoordinates.y = random.Next(0, 10);
                isVertical = Convert.ToBoolean(random.Next(2));

                // Проверка возможности расположения корабля в границах поля
                if ((isVertical && (initialCoordinates.y + size) >= 10) ||
                    (!isVertical && (initialCoordinates.x + size) >= 10))
                    continue; // Если проверка не пройдена, запускается новая итерация создания корабля
                else // В случае прохождения проверки, создание всех элементов корабля и добавление в список
                {
                    pList.Add(new PartOfShip(initialCoordinates.x, initialCoordinates.y, sym));
                    for (int i = 0; i < size-1; i++)
                    {
                        PartOfShip nextPart = GetNextPart(); //Получение следующего элемента корабля
                        pList.Add(nextPart); // Добавление элемента в список
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// Создание следующего элемента корабля
        /// </summary>
        /// <returns>Возвращает следующий элемент корабля</returns>
        private PartOfShip GetNextPart()
        {
            // Создание пового элемента путем копирования последнего элемента из списка
            PartOfShip nextPart = new PartOfShip(pList.Last()); 

            // Смещение нового элемента на одну клетку в направлении расположения корабля
            nextPart.Move(1, isVertical);
            return nextPart;
        }
        /// <summary>
        /// Вывод корабля на консоль
        /// </summary>
        public void Draw()
        {
            // Вывод на консоль казждого элемента корабля по его координатам
            foreach (PartOfShip part in pList)
            {
                int offset = 2;
                Console.SetCursorPosition(6 + part.x * offset, 5 + part.y);
                Console.Write(sym);
            }
        }
    }
}
