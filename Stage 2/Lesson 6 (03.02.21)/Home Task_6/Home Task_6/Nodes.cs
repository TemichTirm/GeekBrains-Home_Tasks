using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_6
{
    class Nodes
    {
        public int Num { get; set; }
        public List<Edges> Edges { get; set; }
        public int Value { get; set; }
        public Nodes()
        {
            Edges = new List<Edges>();
        }
    }
    class Edges
    {
        public Nodes Node { get; set; }
        public int Weight { get; set; }
    }
}
