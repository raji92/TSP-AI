using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesMan
{
    public class Node
    {
        public Node()
        {
            Route = new List<Tuple<int, int>>();
        }
        public List<Tuple<int, int>> Route { get; set; }

        public int[,] ReducedMatrix { get; set; }

        public int Cost { get; set; }

        public int Vertex { get; set; }

        public int Height { get; set; }
    }
}
