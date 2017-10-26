using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesMan
{
    public interface IBranchAndBound
    {
        ResultModel SolveTSPProblem(int[,] initialCostMatrix, int maximumEffortBound);
    }
}
