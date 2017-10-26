using System;
using System.Collections.Generic;

namespace TravellingSalesMan
{
    public static class BranchAndBoundHandler
    {
        private static readonly int MAX=int.MaxValue;

        public static Node CreateNewNode(int[,] previousCostMatrix, List<Tuple<int, int>> route, int height, int sourceNode, int destinationNode, int numberOfCities)
        {
            
            var node = new Node();
            node.Route = route;
            if (height != 0)
            {
                node.Route.Add(new Tuple<int, int>(sourceNode, destinationNode));
            }
            node.ReducedMatrix = new int[numberOfCities, numberOfCities];
            Array.Copy(previousCostMatrix, node.ReducedMatrix, previousCostMatrix.Length);

            for (int k = 0; (height != 0 && k < numberOfCities); k++)
            {
                node.ReducedMatrix[sourceNode, k] = MAX;
                node.ReducedMatrix[k, destinationNode] = MAX;
            }

            node.ReducedMatrix[destinationNode, 0] = MAX;
            node.Height = height;
            node.Vertex = destinationNode;
            return node;
        }

        public static int FindCost(int[,] reducedMatrix, int numberOfCities)
        {
            int edgeCost = 0;
            int[] row = new int[numberOfCities];
            FindRowMinima(reducedMatrix, row, numberOfCities);
            int[] col = new int[numberOfCities];
            FindColumnMinima(reducedMatrix, col, numberOfCities);
            for (int i = 0; i < numberOfCities; i++)
            {
                edgeCost += (row[i] != MAX) ? row[i] : 0;
                edgeCost += (col[i] != MAX) ? col[i] : 0;
            }

            return edgeCost;
        }

        private static void FindRowMinima(int[,] reducedMatrix, int[] row, int numberOfCities)
        {

            for (int t = 0; t < numberOfCities; t++)
            {
                row[t] = MAX;
            }

            for (int i = 0; i < numberOfCities; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    if (reducedMatrix[i, j] < row[i])
                    {
                        row[i] = reducedMatrix[i, j];
                    }
                }
            }

            for (int i = 0; i < numberOfCities; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    if (reducedMatrix[i, j] != MAX && row[i] != MAX)
                    {
                        reducedMatrix[i, j] -= row[i];
                    }
                }
            }
        }

        private static void FindColumnMinima(int[,] reducedMatrix, int[] col, int numberOfCities)
        {
            for (int t = 0; t < numberOfCities; t++)
            {
                col[t] = MAX;
            }

            for (int i = 0; i < numberOfCities; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    if (reducedMatrix[i, j] < col[j])
                    {
                        col[j] = reducedMatrix[i, j];
                    }
                }
            }
            for (int i = 0; i < numberOfCities; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    if (reducedMatrix[i, j] != MAX && col[j] != MAX)
                    {
                        reducedMatrix[i, j] -= col[j];
                    }
                }
            }
        }
    }
}
