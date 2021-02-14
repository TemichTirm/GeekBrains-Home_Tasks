using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация взвешенного графа
            Console.WriteLine(@"
                    (0)
            2______/ | \_________4
            /        |1           \
         (1)        (2)          (3)
          |\___3      \______6  2/ |
         7|    \             \  /  | 8
          | 5__(4)______4    (5)   |
          | /     \ 2   \    / \ 2 |
         (6)___2__(7)    \__/   \  |
          | \     /      /  \____\ |
          |  \ 1  |3    /        (8)
          |   \  /_____/8        / \
          |   (9)               /   \
        10|     \____6_____    /5    \2
          |________________\  /       \
                           (10)       (11)       (3) - порядковый номер вершины графа, 4 - вес ребра
                                       ");

            // Представляется в виде таблицы смежностей, где в пересечении строк и столбцов, обозначающих узлы, указывается вес ребра
            int[,] relationTable = new int[,] {
            { 0, 2, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0 },    // 0
            { 2, 0, 0, 0, 3, 0, 7, 0, 0, 0, 0, 0 },    // 1
            { 1, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0 },    // 2
            { 4, 0, 0, 0, 0, 2, 0, 0, 8, 0, 0, 0 },    // 3
            { 0, 3, 0, 0, 0, 0, 5, 2, 4, 0, 0, 0 },    // 4
            { 0, 0, 6, 2, 0, 0, 0, 0, 2, 8, 0, 0 },    // 5
            { 0, 7, 0, 0, 5, 0, 0, 2, 0, 1, 10, 0 },   // 6
            { 0, 0, 0, 0, 2, 0, 2, 0, 0, 3, 0, 0 },    // 7
            { 0, 0, 0, 8, 4, 2, 0, 0, 0, 0, 5, 2 },    // 8
            { 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 6, 0 },    // 9
            { 0, 0, 0, 0, 0, 0, 10, 0, 5, 6, 0, 0 },   // 10
            { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 } };  // 11
          //  0  1  2  3  4  5  6  7  8  9  10 11

            Random rnd = new Random();
            int maxValue = 100;
            WeightGraph graph = new WeightGraph();
            // Наполнение узлов графа значениями
            for (int i = 0; i < relationTable.GetLength(0); i++)
            {
                Nodes node = new Nodes() { Num = i, Value = rnd.Next(0, maxValue) };
                graph.Nodes.Add(node);
                graph.NodesCount++;
            }
            // Внесение связей в узлы (ребра графа)
            for (int i = 0; i < relationTable.GetLength(0); i++)
            {
                for (int j = 0; j < relationTable.GetLength(1); j++)
                {
                    if (relationTable[i, j] != 0)
                    {
                        Edges edge = new Edges() { Node = graph.Nodes[j], Weight = relationTable[i, j] };
                        graph.Nodes[i].Edges.Add(edge);
                    }
                }
            }
            // Меню для поиска значенияв графе
            int choice;
            do
            {
                PrintMenu();
                choice = GetValue(0, 2);
                switch (choice)
                {
                    case 0:                     // Выход
                        break;
                    case 1:                     // Поиск в ширину
                        graph.BFS();
                        Console.Clear();
                        break;
                    case 2:                     // Поиск в глубину
                        graph.DFS();
                        Console.Clear();
                        break;
                }
            }
            while (choice != 0);
        }
        /// <summary>
        /// Выводит значение в виде числа типа Int от минимального до максимального значения включительно с проверкой после ввода в консоли 
        /// </summary>
        /// <param name="minValue">Минимальная величина значения</param>
        /// <param name="maxValue">Максимальная величина значения</param>
        /// <returns>Целочисленное значение</returns>
        public static int GetValue(int minValue, int maxValue)
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
        /// <summary>
        /// Вывод меню в консоль
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("Выберите метод поиска значения в графе:\n" +
                              "1 - Поиск в ширину\n" +
                              "2 - Поиск в глубину\n" +
                              "\n0 - Выход");
        }
        
    }
}
