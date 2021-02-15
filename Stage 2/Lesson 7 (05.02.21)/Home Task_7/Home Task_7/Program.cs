using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 10;             // Высота поля
            int n = 10;             // Ширина поля
            int choice;
            int[,] field = new int[m, n];
            do
            {
                CalculatePath(m - 1, n - 1, field);
                PrintField(field);
                Menu();
                choice = GetValue(0, 1);
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        // Генерация препятствия на поле случайным образом
                        Random rnd = new Random();
                        int row;
                        int column;
                        do
                        {
                            row = rnd.Next(0, m - 1);
                            column = rnd.Next(0, n - 1);
                        }
                        while ((row == 0 && column == 0) || (row == (m - 1) || column == (n - 1)));
                        field[row, column] = -1;
                        // Обнуление матрицы поля с сохранением препятствий
                        for (int i = 0; i < field.GetLength(0); i++)
                        {
                            for (int j = 0; j < field.GetLength(1); j++)
                            {
                                field[i, j] = field[i, j] == -1 ? field[i, j] : 0;
                            }
                        }
                        Console.Clear();
                        break;
                }
            }
            while (choice != 0);
        }
        /// <summary>
        /// Подсчет количества путей из верхнего левого угла поля в правый нижний
        /// Ходить можно только вправо либо вниз
        /// </summary>
        /// <param name="i">Высота поля</param>
        /// <param name="j">Ширина поля</param>
        /// <param name="field">Матрица поля</param>
        /// <returns></returns>
        private static int CalculatePath (int i, int j, int [,] field)
        {
            if (i == 0 && j == 0)               // Левая верхняя клетка
                return field[i, j] = 1;
            if (i == 0 && j != 0)               // Верхняя строка
            {
                if (field[i, j - 1] == -1)      // Если клетка с препятствием
                    return field[i, j] = 0;
                if (field[i, j - 1] != 0)       // Если значение уже подсчитано ранее 
                    return field[i, j] = field[i, j - 1];
                else
                    return field[i, j] = CalculatePath(i, j - 1, field); 
            }
            if (i != 0 && j == 0)               // Левый столбец
            {
                if (field[i - 1, j] == -1)      // Если клетка с препятствием
                    return field[i, j] = 0;
                if (field[i - 1, j] != 0)       // Если значение уже подсчитано ранее 
                    return field[i, j] = field[i - 1, j];
                else
                    return field[i, j] = CalculatePath(i - 1, j, field);
            }
            // Для всех остальных клеток поля
            int up;
            if (field[i - 1, j] == -1)          // Если клетка с препятствием
                up = 0;
            else
                up = field[i - 1, j] != 0 ? field[i - 1, j] : CalculatePath(i - 1, j, field);
            int right;
            if (field[i, j - 1] == -1)          // Если клетка с препятствием
                right = 0;
            else
                right = field[i, j - 1] != 0 ? field[i, j - 1] : CalculatePath(i, j - 1, field);
            return field[i, j] = right + up;
        }
        /// <summary>
        /// Вывод поля в консоль
        /// </summary>
        /// <param name="field">Матрица поля</param>
        private static void PrintField(int[,] field)
        {
            string line = new string('-', field.GetLength(1)*8);
            Console.WriteLine(line);
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1) ; j++)
                {
                    Console.Write($"| {field[i, j]}\t");
                }
                Console.WriteLine("|");
                Console.WriteLine(line);
            }
        }
        /// <summary>
        /// Вывод меню
        /// </summary>
        private static void Menu()
        {
            Console.WriteLine("Чтобы добавить заблокированную клетку - 1\n" +
                              "\nВыход - 0");
        }
        /// <summary>
        /// Выводит значение в виде числа типа Int от минимального до максимального значения включительно с проверкой после ввода в консоли 
        /// </summary>
        /// <param name="minValue">Минимальная величина значения</param>
        /// <param name="maxValue">Максимальная величина значения</param>
        /// <returns></returns>
        private static int GetValue(int minValue, int maxValue)
        {
            int value;
            string input = Console.ReadLine();
            int line = Console.CursorTop;
            while (!int.TryParse(input, out value) || (value > maxValue) || (value < minValue))
            {
                Console.Write($"Ошибка! Вы ввели неверное значение, пожалуйста введите число от {minValue} до {maxValue}: ");
                input = Console.ReadLine();
            }
            return value;
        }
    }
}
