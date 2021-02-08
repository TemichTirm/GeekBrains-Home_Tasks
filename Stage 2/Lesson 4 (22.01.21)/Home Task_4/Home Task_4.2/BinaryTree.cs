using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Home_Task_4._2
{
    class BinaryTree
    {
        private int NodeCount { get; set; }
        private int TreeHeight { get; set; }
        private const int cellSize = 4; // Размер строки для отображения узла дерева два символа на скобки и два на само число
        public Node RootNode { get; set; }
        /// <summary>
        /// Добавление узла в дерево
        /// </summary>
        /// <param name="value">Значение нового узла</param>
        public void Add(int value)
        {
            if (RootNode == null)
            {
                RootNode = new Node(value);
                NodeCount++;
                TreeHeight++;
            }
            else
            {
                Add(value, RootNode);
            }
        }
        /// <summary>
        /// Добавление узла, если корневой узел уже существует
        /// </summary>
        /// <param name="value">Значениенового узла</param>
        /// <param name="root">Корневой узел</param>
        /// <param name="currentLayerCount"></param>
        private void Add(int value, Node root, int currentLayerCount = 1)
        {
            if ( value < root.Value)
            {
                if (root.LeftNode == null)
                {
                    root.LeftNode = new Node(value) {ParentNode = root};
                    NodeCount++;
                    currentLayerCount++;
                }
                else
                    Add(value, root.LeftNode, currentLayerCount + 1);
            }
            if (value > root.Value)
                {
                if (root.RightNode == null)
                {
                    root.RightNode = new Node(value) {ParentNode = root};
                    NodeCount++;
                    currentLayerCount++;
                }
                else
                    Add(value, root.RightNode, currentLayerCount + 1);
            }
            TreeHeight = currentLayerCount > TreeHeight? currentLayerCount : TreeHeight;
        }
        /// <summary>
        /// Бинарный поиск значения в дереве
        /// </summary>
        /// <param name="value">Искомое значение</param>
        public void BinarySearch(int value)
        {
            // Если дерево пустое, поиск не идет
            if (RootNode == null)
            {
                Console.WriteLine("Дерево пустое!");
                return;
            }
            Node currentNode = RootNode;
            while (currentNode != null )
            {
                // Если искомое значение найдено покрасить этот узел зеленым
                if (value == currentNode.Value)
                {
                    PrintNode(currentNode, true);
                    Console.WriteLine("Искомый элемент найден");
                    Console.ReadLine();
                    return;
                }
                // Если значение не найдено - покрасить узел красным и двигаться дальше по дереву
                PrintNode(currentNode, false);
                if (value < currentNode.Value)
                {
                    currentNode = currentNode.LeftNode;
                    Thread.Sleep(100);
                }
                else if (value > currentNode.Value)
                {
                    currentNode = currentNode.RightNode;
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine("Искомый элемент не найден!");
            Console.ReadLine();
        }    
        /// <summary>
        /// Рекурсивный поиск узла по значению в дереве
        /// </summary>
        /// <param name="value">Искомое значение</param>
        /// <param name="root">Стартовый узел</param>
        /// <returns>Узел с искомым значением</returns>
        private Node FindNode(int value, Node root)
        {
            if (value == root.Value)
                return root;
            else if (value < root.Value && root.LeftNode != null)
                return FindNode(value, root.LeftNode);
            else if (value > root.Value && root.RightNode != null)
                return FindNode(value, root.RightNode);
            else return null;
        }
        /// <summary>
        /// Удаление узла с заданным значением
        /// </summary>
        /// <param name="value">Значение узла, который нужно удалить</param>
        public void Delete(int value)
        {
            Node deleteNode = FindNode(value, RootNode);
            // Если узел с искомым значением отсутствует
            if (deleteNode == null)
            {
                Console.WriteLine("Нет узла с указанным значением");
                Console.ReadLine();
            }
            else
            {
                #region Если у удаляемого узла нет потомка справа
                // До
                //       10(this)     
                //      /     
                //     8     
                //    /         
                //   5     
                //     
                // После     
                //       8     
                //      /     
                //     5  
                #endregion
                if (deleteNode.RightNode == null)
                {
                    // Если удаляемый узел является корнем дерева
                    if (deleteNode == RootNode)
                    {
                        if (deleteNode.LeftNode != null)
                        {
                            deleteNode.LeftNode.ParentNode = null;
                            RootNode = deleteNode.LeftNode;
                        }
                        else RootNode = null;
                    }
                    // Если удаляемый узел не является корнем дерева
                    else
                    {
                        if (deleteNode.ParentNode.LeftNode == deleteNode)
                            deleteNode.ParentNode.LeftNode = deleteNode.LeftNode;
                        else
                            deleteNode.ParentNode.RightNode = deleteNode.LeftNode;
                    }
                    NodeCount--;
                }
                #region Если у удаляемого узла есть потомок справа, у которого нет потомков слева
                // До
                //       10(this)     
                //      /  \  
                //     8    15 
                //    /         
                //   5     
                //     
                // После  
                //         15
                //        /
                //       8     
                //      /     
                //     5  
                #endregion
                else if (deleteNode.RightNode.LeftNode == null)
                {
                    // Если удаляемый узел является корнем дерева
                    if (deleteNode == RootNode)
                    {                        
                        RootNode = deleteNode.RightNode;
                        RootNode.LeftNode = deleteNode.LeftNode;
                    }
                    // Если удаляемый узел не является корнем дерева
                    else
                    {
                        if (deleteNode.ParentNode.LeftNode == deleteNode)
                            deleteNode.ParentNode.LeftNode = deleteNode.RightNode;
                        else
                            deleteNode.ParentNode.RightNode = deleteNode.RightNode;
                    }
                    deleteNode.RightNode.LeftNode = deleteNode.LeftNode;
                    deleteNode.RightNode.ParentNode = deleteNode.ParentNode;
                    if (deleteNode.LeftNode != null)
                            deleteNode.LeftNode.ParentNode = deleteNode.RightNode;
                    NodeCount--;
                }
                #region Если у удаляемого узла есть потомок справа, у которого есть потомки слева
                // До
                //       10(this)     
                //      /  \  
                //     8    15 
                //    /    /    
                //   5    13
                //     
                // После  
                //         13
                //        /  \
                //       8    15  
                //      /     
                //     5  
                #endregion
                else
                {
                    Node insertNode = FindLeft(deleteNode.RightNode);
                    if (insertNode.RightNode != null)
                        insertNode.RightNode.ParentNode = insertNode.ParentNode;
                    insertNode.ParentNode.LeftNode = insertNode.RightNode;
                    deleteNode.Value = insertNode.Value;
                    NodeCount--;
                }
                TreeHeight = 0;
                CheckTreeHeight(RootNode);
            }
        }
        /// <summary>
        /// Поиск самого левого потомка длязаданного узла
        /// </summary>
        /// <param name="root">Заданный узел</param>
        /// <returns>Самый левый потомок</returns>
        private Node FindLeft(Node root)
        {
            if (root.LeftNode == null)
                return root;
            else return FindLeft(root.LeftNode);
        }        
        /// <summary>
        /// Перекрашивание заданного узла
        /// </summary>
        /// <param name="node">Узел дерева</param>
        /// <param name="status">True - узел зеленый, False - узел красный</param>        
        private void PrintNode(Node node, bool status)
        {
            if (node == null)
                return;
            // Создание двумерного массива для хранения элементов дерева
            int[,] treeStructure = new int[TreeHeight * 2 - 1, (int)Math.Pow(2, TreeHeight)];
           
            // Текущая строка в которой должно находится значение узла
            int currentline = 0;
            
            // Текущая колонка в которой должно находится значение узла
            int column = (int)Math.Pow(2, TreeHeight - 1);
            
            // Сдвиг по горизонтали от текущей колонки
            int offset = 0;
            int treeStartTopPosition = 2;   // Отступ сверху на 2 строки для отображения кол-ва элементов и высоты дерева
            
            // Заполнение двумерного массива значениями элементов дерева и линиями
            treeStructure = GetTreeStructure(RootNode, currentline, treeStructure, column, offset);
            int currentTopCursorPosition = Console.CursorTop;
            
            // Изменение цвета заданного узла в зависимости от того, найден он или нет
            for (int i = 0; i < treeStructure.GetLength(0); i++)
            {
                for (int j = 0; j < treeStructure.GetLength(1); j++)
                {
                    if (treeStructure[i, j] == node.Value)
                    {
                        Console.CursorTop = treeStartTopPosition + i;
                        Console.CursorLeft = j * cellSize;
                        Console.ForegroundColor = status ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.WriteLine(string.Format("[{0,2}]", treeStructure[i, j]));
                        Console.ResetColor();
                        Console.CursorTop = currentTopCursorPosition;
                        Console.CursorLeft = 0;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Вывод дерева в консоль
        /// </summary>
        public void Print()
        {
            if (RootNode == null)
                return;
            // Создание двумерного массива строк размерность которого зависит от уровней дерева 
            int[,] treeStructure = new int[TreeHeight * 2 - 1, (int)Math.Pow(2, TreeHeight)];
            // Текущая строка в которой должен находится значение узла
            int currentline = 0;
            // Текущая колонка в которой должен находится значение узла
            int column = (int)Math.Pow(2, TreeHeight - 1);
            // Сдвиг по горизонтали от текущей колонки
            int offset = 0;
            // Заполнение двумерного массива значениями элементов дерева и линиями
            int treeStartTopPosition = 2;
            treeStructure = GetTreeStructure(RootNode, currentline, treeStructure, column, offset);

            Console.WriteLine($"Количество элементов: {NodeCount}");
            Console.WriteLine($"Высота дерева: {TreeHeight}\n");

            // Вывод элементов дерева в консоль
            for (int i = 0; i < treeStructure.GetLength(0); i++)
            {
                for (int j = 0; j < treeStructure.GetLength(1); j++)
                {
                    // При значении по умолчанию в ячейке двумерного массива, следующая итерация
                    if (treeStructure[i, j] != 0)
                    {
                        Console.CursorTop = treeStartTopPosition + i;
                        Console.CursorLeft = j * cellSize;
                        switch (treeStructure[i, j])
                        {
                            case -1:                // Вывод горизонтальных линий
                                Console.WriteLine(new string('_', cellSize));
                                break;
                            case -2:                // Вывод обратного слэша
                                Console.WriteLine(new string(' ', cellSize - 1) + '/');
                                break;
                            case -3:                // Вывод прямого слэша
                                Console.WriteLine('\\');
                                break;
                            default:                // Вывод значения узла
                                Console.WriteLine(string.Format("[{0,2}]", treeStructure[i,j]));
                                Thread.Sleep(100);
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Рекурсивное заполнение двумерного массива значениями элементов дерева и линиями
        /// </summary>
        /// <param name="root">Корневой узел</param>
        /// <param name="currentLine">Текущая строка массива</param>
        /// <param name="tree">Двумерный массив дерева</param>
        /// <param name="column">Текущая колонка массива</param>
        /// <param name="offset">Смещение по горизонтали</param>
        private int[,] GetTreeStructure(Node root, int currentLine, int[,] tree, int column, int offset)
        {
            column += offset;
            // Добавление значения узла дерева в массив
            tree[currentLine * 2, column] = root.Value;
            currentLine++;
            // Расчет смещения для элементов следующего уровня
            offset = (int)Math.Pow(2, (TreeHeight - 1) - currentLine);
            // Проход по левому поддереву
            if (root.LeftNode != null)
            {
                for (int i = column - 1; i > column - offset; i--)
                {
                    // Вывод горизонтальных линий
                    tree[(currentLine - 1) * 2, i] = (int)Lines.GorisontalLine;
                }
                // Вывод вертикальных линий 
                tree[(currentLine) * 2 - 1, column - offset] = (int)Lines.BackSlash;
                // Рекурсивный переход на следующий уровень
                tree = GetTreeStructure(root.LeftNode, currentLine, tree, column, -offset);
            }
            // Проход по правому поддереву
            if (root.RightNode != null)
            {
                for (int i = column + 1; i < column + offset; i++)
                {
                    // Вывод горизонтальных линий
                    tree[(currentLine - 1) * 2, i] = (int)Lines.GorisontalLine;
                }
                // Вывод вертикальных линий 
                tree[(currentLine) * 2 - 1, column + offset] = (int)Lines.DirectSlash;
                // Рекурсивный переход на следующий уровень
                tree = GetTreeStructure(root.RightNode, currentLine, tree, column, offset);
            }
            return tree;
        }
        /// <summary>
        /// Рекурсивная проверка высоты дерева. Необходима после операции удаления для корректного вывода в консоль
        /// </summary>
        /// <param name="root">Корневой узел</param>
        /// <param name="currentLayerCount">Номер текущего уровня</param>
        private void CheckTreeHeight(Node root, int currentLayerCount = 0)
        {
            if (RootNode != null)
            {
                currentLayerCount++;
                if (root.LeftNode != null)
                {
                    CheckTreeHeight(root.LeftNode, currentLayerCount);
                }
                if (root.RightNode != null)
                {
                    CheckTreeHeight(root.RightNode, currentLayerCount);
                }
                TreeHeight = currentLayerCount > TreeHeight ? currentLayerCount : TreeHeight;
            }
            else TreeHeight = 0;
        }
        /// <summary>
        /// Вывод меню в консоль
        /// </summary>
        public static void PrintMenu(int menuItemsMax)
        {
            Console.Write("\nДля изменения дерева выберите операцию\n" +
                              "1 - Добавить элемент\n");
            if (menuItemsMax > 1)
                Console.WriteLine("2 - Удалить элемент\n" +
                                "3 - Поиск элемента в ширину\n" +
                                "4 - Поиск элемента в глубину\n" +
                                "5 - Бинарный поиск элемента");
            Console.WriteLine("\n0 - Выход");            
        }
        /// <summary>
        /// Перечисления типов линий
        /// </summary>
        private enum Lines
        {
            DirectSlash = -3,           //       "\"
            BackSlash,                  //       "/"
            GorisontalLine              //       "_"
        }
        /// <summary>
        /// Поиск значения в ширину c помощью очереди
        /// </summary>
        /// <param name="searchValue">Искомое значение</param>
        public void BFS(int searchValue)
        {
            // Если дерево пустое, поиск не идет
            if (RootNode == null)
            {
                Console.WriteLine("Дерево пустое!");
                return;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(RootNode);
            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();
                // Если значение найдено, покрасить узел зеленым и завершить поиск
                if (currentNode.Value == searchValue)
                {
                    PrintNode(currentNode, true);
                    Console.WriteLine("Искомый элемент найден");
                    Console.ReadLine();
                    return;
                }

                // В противном случае продолжить поиск
                else
                {
                    PrintNode(currentNode, false);
                    if (currentNode.LeftNode != null)
                        queue.Enqueue(currentNode.LeftNode);
                    if (currentNode.RightNode != null)
                        queue.Enqueue(currentNode.RightNode);
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine("Искомый элемент не найден!");
            Console.ReadLine();
        }
        /// <summary>
        /// Поиск значения в глубину с помощью стека
        /// </summary>
        /// <param name="searchValue">Искомое значение</param>
        public void DFS(int searchValue)
        {
            // Если дерево пустое, поиск не идет
            if (RootNode == null)
            {
                Console.WriteLine("Дерево пустое!");
                return;
            }
            Stack<Node> stack = new Stack<Node>();
            stack.Push(RootNode);
            while (stack.Count != 0)
            {
                Node currentNode = stack.Pop();
                // Если значение найдено, покрасить узел зеленым и завершить поиск
                if (currentNode.Value == searchValue)
                {
                    PrintNode(currentNode, true);
                    Console.WriteLine("Искомый элемент найден");
                    Console.ReadLine();
                    return;
                }
                // В противном случае продолжить поиск
                else
                {
                    PrintNode(currentNode, false);
                    if (currentNode.RightNode != null)
                        stack.Push(currentNode.RightNode);
                    if (currentNode.LeftNode != null)
                        stack.Push(currentNode.LeftNode);
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine("Искомый элемент не найден!");
            Console.ReadLine();
        }
    }
}
