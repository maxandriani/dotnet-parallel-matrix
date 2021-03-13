using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations
{
    public static class MatrixParallelExtensions
    {
        public static void MultiplyAsParallel(this double[,] left, double[,] right, double[,] result)
        {
            int leftCols = left.GetLength(1);
            int rightCols = right.GetLength(1);
            int leftRows = left.GetLength(0);

            Parallel.For(0, leftRows, row =>
            {
                for (int rightCol = 0; rightCol < rightCols; rightCol++)
                {
                    double res = 0;
                    for (int leftCol = 0; leftCol < leftCols; leftCol++)
                    {
                        res += left[row, leftCol] * right[row, rightCol];
                    }
                    result[row, rightCol] = res;
                }
            });
        }
    }
}
