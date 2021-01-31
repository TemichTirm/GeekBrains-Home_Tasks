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
        private const int cellSize = 4; // Размер строки для отображения узла дерева два символа на скобки идва на само число
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
        /// Поиск значения в дереве
        /// </summary>
        /// <param name="value">Искомое значение</param>
        /// <returns>True - значение найдено, False - значение не найдено</returns>
        public bool Find(int value)
        {
            bool result = FindNode(value, RootNode) != null;
            return result;
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
        /// Вывод дерева в консоль
        /// </summary>
        public void Print()
        {
            if (RootNode == null)
                return;
            Node root = RootNode;
            // Создание двумерного массива строк размерность которого зависит от уровней дерева 
            string[,] stringTree = new string[TreeHeight * 2 - 1, (int)Math.Pow(2, TreeHeight)];
            // Текущая строка в которой должен находится значение узла
            int currentline = 0;
            // Текущая колонка в которой должен находится значение узла
            int column = (int)Math.Pow(2, TreeHeight - 1);
            // Сдвиг по горизонтали от текущей колонки
            int offset = 0;
            // Заполнение двумерного массива строк значениями элементов дерева и линиями
            AddValueInStringTree(root, currentline, stringTree, column, offset);

            Console.WriteLine($"Количество элементов: {NodeCount}");
            Console.WriteLine($"Высота дерева: {TreeHeight}\n");

            // Формирование строк из подстрок двумерного массива для вывода в консоль
            StringBuilder[] finalTree = new StringBuilder[stringTree.GetLength(0)];
            for (int i = 0; i < stringTree.GetLength(0); i++)
            {
                finalTree[i] = new StringBuilder();
                for (int j = 0; j < stringTree.GetLength(1); j++)
                {
                    // При отсутствии значения в ячейке двумерного массива, ячейка заполняется пустой строкой из пробелов
                    if (stringTree[i, j] == null)
                    {
                        stringTree[i, j] = new string(' ', cellSize);
                    }
                    finalTree[i].Append(stringTree[i, j]);
                }
                Console.WriteLine(finalTree[i]);
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// Заполнение двумерного массива строк значениями элементов дерева и линиями
        /// </summary>
        /// <param name="root">Корневой узел</param>
        /// <param name="currentLine">Текущая строка массива</param>
        /// <param name="tree">Двумерный массив строк дерева</param>
        /// <param name="column">Текущая колонка массива</param>
        /// <param name="offset">Смещение по горизонтали</param>
        private void AddValueInStringTree(Node root, int currentLine, string[,] tree, int column, int offset)
        {
            column += offset;
            // Добавление значения узла дерева в массив
            tree[currentLine * 2, column] = string.Format("[{0,2}]", root.Value);
            currentLine++;
            // Расчет смещения для элементов следующего уровня
            offset = (int)Math.Pow(2, (TreeHeight - 1) - currentLine);
            // Проход по левому поддереву
            if (root.LeftNode != null)
            {
                for (int i = column - 1; i > column - offset; i--)
                {
                    // Вывод горизонтальных линий
                    tree[(currentLine-1) * 2, i] = new string('_', cellSize);
                }
                // Вывод вертикальных линий 
                tree[(currentLine) * 2 - 1, column - offset] = "   /";
                // Рекурсивный переход на следующий уровень
                AddValueInStringTree(root.LeftNode, currentLine, tree, column, -offset);
            }
            // Проход по правому поддереву
            if (root.RightNode != null)
            {
                for (int i = column + 1; i < column + offset; i++)
                {
                    // Вывод горизонтальных линий
                    tree[(currentLine - 1) * 2, i] = new string('_', cellSize);
                }
                // Вывод вертикальных линий 
                tree[(currentLine) * 2 - 1, column + offset] = "\\   ";
                // Рекурсивный переход на следующий уровень
                AddValueInStringTree(root.RightNode, currentLine, tree, column, offset);
            }
            else return;
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
        public static void PrintMenu()
        {
            Console.WriteLine("\nДля изменения дерева выберите операцию" +
                              "\n1 - Добавить элемент" +
                              "\n2 - Удалить элемент\n" +
                              "\n0 - Выход");
            
        }
    }
}
