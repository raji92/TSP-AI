using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesMan
{
    public class NearestNeighbour
    {
        public NearestNeighbourResultModel SimpleSearch(int[,] costMatrix, int maximumEffortBound)
        {
            int length = costMatrix.GetLength(0);
            var result = new NearestNeighbourResultModel();
            var unVisitedNodes = new List<int>();
            for (int i = 0; i < length; i++)
            {
                unVisitedNodes.Add(i);
            }
            var route = new List<int>();

            int currentNode = unVisitedNodes[0];
            route.Add(currentNode);
            unVisitedNodes.RemoveAt(0);

            while (unVisitedNodes.Count > 0)
            {
                int minimumCost = int.MaxValue;
                int minInd = 0;

                for (int i = 0; i < unVisitedNodes.Count; i++)
                {
                    int tempNode = unVisitedNodes[i];
                    if (costMatrix[currentNode, tempNode] < minimumCost)
                    {
                        minimumCost = costMatrix[currentNode, tempNode];
                        minInd = i;
                    }
                }
                currentNode = unVisitedNodes[minInd];
                route.Add(currentNode);
                unVisitedNodes.RemoveAt(minInd);
            }
            int totalCost = 0;
            for (int j = 0; j < length; j++)
            {
                if (j == length - 1)
                {
                    totalCost += costMatrix[j, 0];
                }
                else
                {
                    totalCost += costMatrix[route[j], route[j + 1]];
                }
            }
            result.Cost = totalCost;
            result.FinalPath = route;
            return result;
        }

    }
}
