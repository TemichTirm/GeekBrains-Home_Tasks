using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_6
{
    class WeightGraph
    {
        public List<Nodes> Nodes { get; set; }
        public int NodesCount { get; set; }
        static WeightGraph()
        {
            Nodes = new List<Nodes>();
        }
    }
}
