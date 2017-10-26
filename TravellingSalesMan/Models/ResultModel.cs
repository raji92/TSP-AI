using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesMan
{
    public class ResultModel
    {
        public ResultModel()
        {
            FinalTourPath = new List<Tuple<int, int>>();
        }
        public List<Tuple<int, int>> FinalTourPath { get; set; }
        public int TotalCost { get; set; }
        public List<Node> StateSpace { get; set; }
        public bool ExceededMEB { get; set; }
    }
}
