using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.AddNode(10);
            binaryTree.AddNode(8);
            binaryTree.AddNode(15);
            binaryTree.AddNode(6);
            binaryTree.AddNode(7);
            binaryTree.AddNode(9);
            binaryTree.AddNode(5);
            binaryTree.AddNode(13);
            binaryTree.AddNode(20);
            binaryTree.AddNode(30);
            Console.Read();
            binaryTree.Print();
            Console.ReadLine();
        }
    }
}
