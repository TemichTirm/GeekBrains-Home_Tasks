using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Home_Task_6
{
    class WeightGraph
    {
        public List<Nodes> Nodes { get; set; }
        public int NodesCount { get; set; }
        public WeightGraph()
        {
            Nodes = new List<Nodes>();
        }
        /// <summary>
        /// Метод поиска в ширину
        /// </summary>
        public void BFS()
        {
            // Если граф пустой
            if (Nodes.Count == 0)
            {
                Console.WriteLine("У графа нет вершин!");
                Console.ReadLine();
                return;
            }
            (int searchValue, int startNode) = Invitation();
            List<Nodes> chekedNodes = new List<Nodes>();
            Queue<Nodes> queue = new Queue<Nodes>();
            queue.Enqueue(Nodes[startNode]);
            chekedNodes.Add(Nodes[startNode]);
            while (queue.Count != 0)
            {
                Nodes currentNode = queue.Dequeue();
                // Если значение найдено, вывести и завершить поиск
                if (currentNode.Value == searchValue)
                {
                    PrintNode(currentNode);
                    Console.WriteLine("Искомый элемент найден!");
                    Console.ReadLine();
                    return;
                }
                // В противном случае продолжить поиск
                else
                {
                    PrintNode(currentNode);
                    foreach (var edge in currentNode.Edges)
                    {
                        bool check = false;
                        foreach (var node in chekedNodes)
                        {
                            if (node == edge.Node)
                            {
                                check = true;
                                break;
                            }
                        }
                        if (!check)
                        {
                            queue.Enqueue(edge.Node);
                            chekedNodes.Add(edge.Node);
                        }
                    }
                }
            }
            Console.WriteLine("Искомый элемент не найден!");
            Console.ReadLine();
        }
        /// <summary>
        /// Метод поиска в глубину
        /// </summary>
        public void DFS()
        {

            // Если граф пустой
            if (Nodes.Count == 0)
            {
                Console.WriteLine("У графа нет вершин!");
                Console.ReadLine();
                return;
            }
            (int searchValue, int startNode) = Invitation();
            List<Nodes> chekedNodes = new List<Nodes>();
            Stack<Nodes> stack = new Stack<Nodes>();
            stack.Push(Nodes[startNode]);
            chekedNodes.Add(Nodes[startNode]);
            while (stack.Count != 0)
            {
                Nodes currentNode = stack.Pop();
                // Если значение найдено, вывести и завершить поиск
                if (currentNode.Value == searchValue)
                {
                    PrintNode(currentNode);
                    Console.WriteLine("Искомый элемент найден!");
                    Console.ReadLine();
                    return;
                }
                // В противном случае продолжить поиск
                else
                {
                    PrintNode(currentNode);
                    foreach (var edge in currentNode.Edges)
                    {
                        bool check = false;
                        foreach (var node in chekedNodes)
                        {
                            if (node == edge.Node)
                            {
                                check = true;
                                break;
                            }
                        }
                        if (!check)
                        {
                            stack.Push(edge.Node);
                            chekedNodes.Add(edge.Node);
                        }
                    }
                }
            }
            Console.WriteLine("Искомый элемент не найден!");
            Console.ReadLine();
        }
        /// <summary>
        /// Выводит в консоль порядковый номер узла и его значение
        /// </summary>
        /// <param name="node">Узел графа</param>
        private void PrintNode(Nodes node)
        {
            Console.WriteLine($"Узел {node.Num}, значение {node.Value}");
        }
        /// <summary>
        /// Приглашает ввести значение для поиска и стартовый узел графа
        /// </summary>
        /// <returns>Искомое значение и порядковый номер узла графа</returns>
        private (int, int) Invitation()
        {
            int minNode = 0;
            int maxNode = NodesCount - 1;
            int minValue = 0;
            int maxValue = 100;
            Console.Write($"Введите значение, которое Вы хотите найти в диапазоне от {minValue} до {maxValue}: ");
            int searchValue = Program.GetValue(minValue, maxValue);
            Console.Write($"Введите порядковый номер узла с которого начать поиск в ширину в диапазоне от {minNode} до {maxNode}: ");
            int startNode = Program.GetValue(minNode, maxNode);
            return (searchValue, startNode);
        }

    }
}
