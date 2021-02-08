using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_4._2
{
    class Node
    {
        public int Value { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Node ParentNode { get; set; }
        public Node(int value)
        {
            Value = value;
        }
    }
}
