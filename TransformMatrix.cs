using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGraph_2
{
    public static class TransformMatrix
    {
        public static T[,] ResizeMatrix<T>(T[,] original, int rows, int columns)
        {
            var newMatrix = new T[rows, columns];
            int minRows = rows;
            int minColumns = columns;
            if (original != null)
            {
                minRows = Math.Min(rows, original.GetLength(0));
                minColumns = Math.Min(columns, original.GetLength(1));
            }
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minColumns; j++)
                    if (original != null)
                        newMatrix[i, j] = original[i, j];
                    else newMatrix[i, j] = default(T);
            return newMatrix;
        }
        public static T[,] ReduceMatrix<T>(int row, int column, T[,] original)
        {
            T[,] newMatrix = new T[original.GetLength(0) - 1, original.GetLength(1) - 1];
            for (int i = 0, j = 0; i < original.GetLength(0); i++)
            {
                if (i == row)
                    continue;
                for (int m = 0, n = 0; m < original.GetLength(1); m++)
                {
                    if (m == column)
                        continue;
                    newMatrix[j, n] = original[i, m];
                    n++;
                }
                j++;
            }
            return newMatrix;
        }
    }
}
