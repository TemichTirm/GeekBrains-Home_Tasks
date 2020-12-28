using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_5._5
{
    class UserInterface
    {
        public static void PrintToDo(List<ToDo> toDoList)
        {
            Console.Clear();
            string header = String.Format("\t\tС П И С О К  З А Д А Ч\n" +
                " №\tВыполнено\tЗадача\n" +
                "=======================================================================\n");
            Console.WriteLine(header);
            foreach (ToDo task in toDoList)
            {
                task.Print();
            }
            string footer = String.Format("\n=======================================================================");
            Console.WriteLine(footer);
        }

        public static (bool isNeed, byte value) NeedChanges(byte toDoListLenght)
        {
            Console.WriteLine("Хотите внести изменения в список задач? Д/Н");
            while(true)
            {
                byte minValue = 0;
                byte maxValue = toDoListLenght;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y) return (false, 0);
                if (key.Key == ConsoleKey.L)
                {

                    Console.WriteLine("\nДля изменения статуса или названия задачи выберите её номер.\n" +
                        "Для добавления новой задачи - 0");
                    return (true, GetValue(minValue, maxValue));
                }

            }
        }
        #region Метод получения значения целого числа из консоли c проверкой по границам значений
        /// <summary>
        /// Выводит значение в виде числа типа byte от минимального до максимального значения включительно с проверкой  после ввода в консоли 
        /// </summary>
        /// <param name="minValue">Минимальная величина значения</param>
        /// <param name="maxValue">Максимальная величина значения</param>
        /// <returns></returns>
        private static byte GetValue(byte minValue, byte maxValue)
        {
            byte value;
            string input = Console.ReadLine();
            int line = 0;
            while (!byte.TryParse(input, out value) || (value > maxValue) || (value < minValue))
            {
                Console.Write($"Ошибка! Вы ввели неверное значение, пожалуйста введите число от {minValue} до {maxValue}:");
                line = Console.CursorTop;
                ClearLine(--line);
                Console.SetCursorPosition(0, line);
                input = Console.ReadLine();
            }
            ClearLine(++line);
            Console.SetCursorPosition(0, line);
            Console.WriteLine();
            return value;
        }
        #endregion
        private static void ClearLine(int line)
        {
            Console.MoveBufferArea(0, line, Console.BufferWidth, 1, Console.BufferWidth, line, ' ', Console.ForegroundColor, Console.BackgroundColor);
        }
    }
}
