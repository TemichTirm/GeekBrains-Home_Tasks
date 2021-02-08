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
            //                 (1)
            //         2______/ | \_________4
            //         /        |1           \
            //      (2)        (3)          (4)
            //       |\___3      \______6  2/ |
            //      7|    \             \  /  | 8
            //       | 5__(5)______4    (6)   |
            //       | /     \ 2   \    / \ 2 |
            //      (7)___2__(8)    \__/   \  |
            //       | \     /      /  \____\ |
            //       |  \ 1  |3    /        (9)
            //       |   \  /_____/8        /
            //       |   (10)              /
            //     10|      \___6_____    /5
            //       |________________\  /
            //                        (11)

            // Представляется в виде таблицы смежности, где в пересечении строк и столбцов, обозначающих узлы, указывается вес ребра
            int[,] relationTable = new int[,] {
            {0, 2, 1, 4, 0, 0, 0, 0, 0, 0, 0,
             2, 0, 0, 0, 3, 0, 7, 0, 0, 0, 0,
             1, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0,
             4, 0, 0, 0, 0, 2, 0, 0, 8, 0, 0,
             0, 3, 0, 0, 0, 0, 5, 2, 4, 0, 0,
             0, 0, 6, 2, 0, 0, 0, 0, 2, 8, 0,
             0, 7, 0, 0, 5, 0, 0, 2, 0, 1, 10,
             0, 0, 0, 0, 2, 0, 2, 0, 0, 3, 0,
             0, 0, 0, 8, 4, 2, 0, 0, 0, 0, 5,
             0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 6,
             0, 0, 0, 0, 0, 0, 10, 0, 5, 6, 0}
            };
            WeightGraph graph = new WeightGraph();
            for (int i = 0; i < relationTable.GetLength(0); i++)
            {
                Nodes node = new Nodes() { Num = i + 1 };
                graph.Nodes.Add(node);
                graph.NodesCount++;
            }

            for (int i = 0; i < relationTable.GetLength(0); i++)
            {
                for (int j = 0; j < relationTable.GetLength(1); j++)
                {
                    if (relationTable[i,j] != 0)
                    {
                        Edges edge = new Edges() { Node = graph.Nodes[j], Weight = relationTable[i, j] };
                        graph.Nodes[i].Links.Add(edge);
                    }
                }
            }
        }
    }
}
