using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesMan
{
    public static class CostFunctions
    {
        public static int CostFunction1(int x, int y)
        {
            if (x == y)
                return 0;
            else if (x < 3 && y < 3)
                return 1;
            else if (x < 3)
                return 200;
            else if (y < 3)
                return 200;
            else if (x % 7 == y % 7)
                return 2;
            else
            {
                var diff = Math.Abs(x - y) + 3;
                return diff;
            }

        }
        public static int CostFunction2(int x, int y)
        {
            if (x == y)
                return 0;
            else if (x + y < 10)
            {
                int value = Math.Abs(x - y) + 4;
                return value;
            }
            else if ((x + y) % 11 == 0)
                return 3;
            else
            {
                int diff = Convert.ToInt32(Math.Pow(Math.Abs(x - y), 2)) + 10;
                return diff;
            }

        }
        public static int CostFunction3(int x, int y)
        {
            if (x == y)
                return 0;

            else
            {
                int diff = Convert.ToInt32(Math.Pow((x + y), 2));
                return diff;
            }

        }
    }
}
