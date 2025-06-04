using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int INF = int.MaxValue;

    static int[,] costMatrix = {
        { INF, 14, 15, 16, 11 },
        { 3, INF, 2, 5, 12 },
        { 4, 2, INF, 3, 13 },
        { 6, 3, 2, INF, 14 },
        { 7, 4, 3, 4, INF }
    };

    static void Main()
    {
        int result = LittlesAlgorithm(costMatrix);
        Console.WriteLine(result);
    }

    static int LittlesAlgorithm(int[,] inputMatrix)
    {
        int[,] matrix = (int[,])inputMatrix.Clone();
        int totalCost = 0;

        for (int step = 0; step < matrix.GetLength(0); step++)
        {
            List<int[]> zeroList = new List<int[]>();

            int[] minRows = Enumerable.Range(0, matrix.GetLength(0))
                .Select(i => MinInRow(matrix, i)).ToArray();
            SubtractRowMinima(matrix, minRows);

            int[] minCols = Enumerable.Range(0, matrix.GetLength(1))
                .Select(j => MinInColumn(matrix, j)).ToArray();
            SubtractColMinima(matrix, minCols);

            totalCost += minRows.Where(x => x != INF).Sum();
            totalCost += minCols.Where(x => x != INF).Sum();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        int penalty = ZeroPenalty(matrix, i, j);
                        zeroList.Add(new int[] { i, j, penalty });
                    }
                }
            }

            if (zeroList.Count == 0)
                break;

            var bestZero = zeroList.OrderByDescending(arr => arr[2]).First();
            int rowToRemove = bestZero[0];
            int colToRemove = bestZero[1];

            matrix = ShrinkMatrix(matrix, rowToRemove, colToRemove);
        }
        return totalCost;
    }

    static int MinInRow(int[,] matrix, int row)
    {
        int min = INF;
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (matrix[row, j] < min)
                min = matrix[row, j];
        return min;
    }

    static int MinInColumn(int[,] matrix, int col)
    {
        int min = INF;
        for (int i = 0; i < matrix.GetLength(0); i++)
            if (matrix[i, col] < min)
                min = matrix[i, col];
        return min;
    }

    static void SubtractRowMinima(int[,] matrix, int[] minRows)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
            if (minRows[i] != INF)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] != INF)
                        matrix[i, j] -= minRows[i];
    }

    static void SubtractColMinima(int[,] matrix, int[] minCols)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (minCols[j] != INF)
                for (int i = 0; i < matrix.GetLength(0); i++)
                    if (matrix[i, j] != INF)
                        matrix[i, j] -= minCols[j];
    }

    static int ZeroPenalty(int[,] matrix, int row, int col)
    {
        int minRow = INF;
        int minCol = INF;

        for (int j = 0; j < matrix.GetLength(1); j++)
            if (j != col && matrix[row, j] < minRow)
                minRow = matrix[row, j];

        for (int i = 0; i < matrix.GetLength(0); i++)
            if (i != row && matrix[i, col] < minCol)
                minCol = matrix[i, col];

        minRow = (minRow == INF) ? 0 : minRow;
        minCol = (minCol == INF) ? 0 : minCol;

        return minRow + minCol;
    }

    static int[,] ShrinkMatrix(int[,] matrix, int removeRow, int removeCol)
    {
        int n = matrix.GetLength(0);
        if (n <= 1)
            return new int[0, 0];

        int[,] newMatrix = new int[n - 1, n - 1];

        int r = 0;
        for (int i = 0; i < n; i++)
        {
            if (i == removeRow) continue;
            int c = 0;
            for (int j = 0; j < n; j++)
            {
                if (j == removeCol) continue;
                newMatrix[r, c] = matrix[i, j];
                c++;
            }
            r++;
        }
        if (removeCol < newMatrix.GetLength(0) && removeRow < newMatrix.GetLength(1))
            newMatrix[removeCol, removeRow] = INF;

        return newMatrix;
    }
}
