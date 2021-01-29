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
        private static int NodeCount { get; set; }
        private static int Layers { get; set; }
        //private static int currentLayerCount = 0;
        private const int cellSize = 4;
        public Node RootNode { get; set; }
        public void AddNode(int value, Node root = null, int currentLayerCount = 0)
        {
            if (RootNode == null)
            {
                Node newNode = new Node(value);
                RootNode = newNode;
                NodeCount++;
                currentLayerCount++;
            }
            else
            {
                root = root ?? RootNode;
                currentLayerCount++;
                if (root.Value > value)
                {
                    if (root.LeftNode == null)
                    {
                        Node newNode = new Node(value);
                        root.LeftNode = newNode;
                        newNode.ParentNode = root;
                        NodeCount++;
                        currentLayerCount++;
                    }
                    else
                        AddNode(value, root.LeftNode, currentLayerCount);
                }
                else
                {
                    if (root.RightNode == null)
                    {
                        Node newNode = new Node(value);
                        root.RightNode = newNode;
                        newNode.ParentNode = root;
                        NodeCount++;
                        currentLayerCount++;
                    }
                    else
                        AddNode(value, root.RightNode, currentLayerCount);
                }
            }
            Layers = currentLayerCount > Layers ? currentLayerCount : Layers;
        }
        public void Print()
        {
            Node root = RootNode;
            int currentline = 0;
            string[,] stringTree = new string[Layers * 2 - 1, (int)Math.Pow(2, Layers)];
            int column = (int)Math.Pow(2, Layers - 1);
            int offset = 0;
            AddValueInStringTree(root, currentline, stringTree, column, offset);

            Console.WriteLine($"Количество элементов: {NodeCount}");
            Console.WriteLine($"Высота дерева: {Layers}\n");

            StringBuilder[] finalTree = new StringBuilder[stringTree.GetLength(0)];
            for (int i = 0; i < stringTree.GetLength(0); i++)
            {
                finalTree[i] = new StringBuilder();
                for (int j = 0; j < stringTree.GetLength(1); j++)
                {
                    if (stringTree[i, j] == null)
                        stringTree[i, j] = new string(' ', cellSize);
                    finalTree[i].Append(stringTree[i, j]);
                }
                Console.WriteLine(finalTree[i]);
                Thread.Sleep(300);
            }
        }
        private void AddValueInStringTree(Node root, int currentLine, string[,] tree, int column, int offset)
        {
            column += offset;
            tree[currentLine * 2, column] = string.Format("({0,2})", root.Value);
            currentLine++;
            offset = (int)Math.Pow(2, (Layers - 1) - currentLine);

            if (root.LeftNode != null)
            {
                for (int i = column - 1; i > column - offset; i--)
                {
                    tree[(currentLine-1) * 2, i] = new string('_', cellSize);
                }
                tree[(currentLine) * 2 - 1, column - offset] = "   /";
                AddValueInStringTree(root.LeftNode, currentLine, tree, column, -offset);
            }
            if (root.RightNode != null)
            {
                for (int i = column + 1; i < column + offset; i++)
                {
                    tree[(currentLine - 1) * 2, i] = new string('_', cellSize);
                }
                tree[(currentLine) * 2 - 1, column + offset] = "\\   ";
                AddValueInStringTree(root.RightNode, currentLine, tree, column, offset);
            }
            else return;
        }
    }
}
