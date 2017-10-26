using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesMan
{
    public static class FileHandler
    {
        

        public static bool WriteStreamToFile(object streamObject, string strategyType, int maximalEffortBound)
        {
            string filePath = Environment.CurrentDirectory + @"\" + "output.txt";
            if (strategyType.ToLower() == "so")
            {                
                var sophResultObjct = streamObject as ResultModel;

                using (var streamWriter = new StreamWriter(filePath))
                {

                    if (sophResultObjct.ExceededMEB)
                    {
                        streamWriter.WriteLine("\t ROUTE FOUND SO FAR USING BRANCH AND BOUND AT MEB(" + maximalEffortBound + ")");
                    }
                    else
                    {
                        streamWriter.WriteLine("\t OPTIMAL SOLUTIOM USING BRANCH AND BOUND");
                    }
                    streamWriter.WriteLine("------------------------------------------------------");
                    int previousCount = 0;
                    for (int i = 0; i < sophResultObjct.FinalTourPath.Count; i++)
                    {
                        var orderItemByFirstElement = sophResultObjct.FinalTourPath.Where(t => t.Item1 == sophResultObjct.FinalTourPath[i].Item1).ToList().Count;
                        previousCount += (orderItemByFirstElement);
                        if ((previousCount == sophResultObjct.FinalTourPath.Count - 1) || (previousCount >= sophResultObjct.FinalTourPath.Count))
                        {
                            streamWriter.WriteLine(sophResultObjct.FinalTourPath[previousCount-1].Item1 + " --> " + sophResultObjct.FinalTourPath[previousCount-1].Item2);
                        }
                        else
                        {
                            streamWriter.WriteLine(sophResultObjct.FinalTourPath[previousCount - 1].Item1 + " --> " + sophResultObjct.FinalTourPath[previousCount].Item1);
                        }
                        i = previousCount - 1;
                    }
                    streamWriter.WriteLine("Total cost is " + sophResultObjct.TotalCost);
                    streamWriter.WriteLine("_____________________________________________________________");
                }
            }
            else
            {                
                using (var streamWriter = new StreamWriter(filePath))
                {
                    var simpResultObject = streamObject as NearestNeighbourResultModel;
                    var finalPath = simpResultObject.FinalPath;
                    int routeCount = finalPath.Count;
                    streamWriter.WriteLine("\t SOLUTION USING NEAREST NEIGHBOUR");
                    streamWriter.WriteLine("------------------------------------------");
                    for (int i = 0; i < routeCount; i++)
                    {
                        if (i == routeCount - 1)
                        {
                            streamWriter.WriteLine(finalPath[i] + " --> " + 0);
                        }
                        else
                        {
                            streamWriter.WriteLine(simpResultObject.FinalPath[i] + " --> " + simpResultObject.FinalPath[i + 1]);
                        }
                    }
                    streamWriter.WriteLine("Total cost is " + simpResultObject.Cost);
                    streamWriter.WriteLine("______________________________________________________________________________");

                }
            }
            return true;
        }

        public static void WriteExceptionToFile(Exception ex)
        {
            string path=Environment.CurrentDirectory + @"\" + "ExceptionLog.txt";
            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("EXCEPTION OCCURED!!-" + ex.Message);
                streamWriter.WriteLine("STACK TRACE:");
                streamWriter.WriteLine("------------------------------");
                streamWriter.WriteLine(ex.StackTrace);
            }
        }
    }
}
