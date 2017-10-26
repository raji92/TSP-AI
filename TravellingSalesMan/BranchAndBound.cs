using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesMan
{
    public class BranchAndBound : IBranchAndBound
    {
        public ResultModel SolveTSPProblem(int[,] costMatrix, int maximumEffortBound)
        {
            int MAX = int.MaxValue;
            var stateSpace = new List<Node>();
            var unSortedNodesList = new List<Node>();
            var minimumCostRoute = new ResultModel();
            var v = new List<Tuple<int, int>>();
            int length = costMatrix.GetLength(0);
            var root = BranchAndBoundHandler.CreateNewNode(costMatrix, v, 0, -1, 0, length);
            int iterationsCount = 0;
            root.Cost = BranchAndBoundHandler.FindCost(root.ReducedMatrix, length);

            unSortedNodesList.Add(root);
            stateSpace.Add(root);
            while (unSortedNodesList.Count > 0)
            {
                iterationsCount++;
                var nodeWithMinumCost = unSortedNodesList.OrderBy(t => t.Cost).FirstOrDefault();
                unSortedNodesList.RemoveAll(t => t.Cost != 0);
                int i = nodeWithMinumCost.Vertex;
                if (nodeWithMinumCost.Height == (length - 1))
                {
                    nodeWithMinumCost.Route.Add(new Tuple<int, int>(i, 0));
                    minimumCostRoute.FinalTourPath = nodeWithMinumCost.Route;
                    minimumCostRoute.TotalCost = nodeWithMinumCost.Cost;
                    minimumCostRoute.StateSpace = stateSpace;
                    minimumCostRoute.ExceededMEB = (iterationsCount == maximumEffortBound ? true : false);
                    return minimumCostRoute;
                }
                for (int j = 0; j < length; j++)
                {
                    iterationsCount++;
                    if (nodeWithMinumCost.ReducedMatrix[i, j] != MAX)
                    {
                        var childNode = BranchAndBoundHandler.CreateNewNode(nodeWithMinumCost.ReducedMatrix, nodeWithMinumCost.Route, nodeWithMinumCost.Height + 1, i, j, length);
                        childNode.Cost = nodeWithMinumCost.Cost + nodeWithMinumCost.ReducedMatrix[i, j] + BranchAndBoundHandler.FindCost(childNode.ReducedMatrix, length);
                        unSortedNodesList.Add(childNode);
                        stateSpace.Add(childNode);
                    }
                    if(maximumEffortBound==iterationsCount && maximumEffortBound!=0)
                    {
                        minimumCostRoute.FinalTourPath = nodeWithMinumCost.Route;
                        minimumCostRoute.TotalCost = nodeWithMinumCost.Cost;
                        minimumCostRoute.StateSpace = stateSpace;
                        minimumCostRoute.ExceededMEB = true;
                        return minimumCostRoute;
                    }
                }
            }
            return minimumCostRoute;
        }
    }
}
