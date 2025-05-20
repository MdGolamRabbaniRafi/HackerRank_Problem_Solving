using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Diagnostics;

class Result
{

    /*
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        int Rows = matrix.Count;
        int cols = matrix[0].Count;
        List<List<int>> ints = new List<List<int>>(matrix);

        int layers = Math.Min(Rows, cols) / 2;  // Determine how many layers there are

        for (int layer = 0; layer < layers; layer++)
        {
            int indexI = layer;
            int indexJ = layer;
            int maxIndexI = Rows - 1 - layer;
            int maxIndexJ = cols - 1 - layer;

            // Collect elements of the current layer
            List<int> elements = new List<int>();

            // Top row (left to right)
            for (int j = indexJ; j <= maxIndexJ; j++) elements.Add(matrix[indexI][j]);

            // Right column (top to bottom)
            for (int i = indexI + 1; i <= maxIndexI; i++) elements.Add(matrix[i][maxIndexJ]);

            // Bottom row (right to left)
            for (int j = maxIndexJ - 1; j >= indexJ; j--) elements.Add(matrix[maxIndexI][j]);

            // Left column (bottom to top)
            for (int i = maxIndexI - 1; i > indexI; i--) elements.Add(matrix[i][indexJ]);

            // Rotate elements by 'r' positions
            int len = elements.Count;
            List<int> rotated = new List<int>(new int[len]);

            for (int i = 0; i < len; i++)
            {
                rotated[(i + (len - r % len)) % len] = elements[i];
            }

            // Put rotated elements back into the matrix

            int idx = 0;

            // Top row (left to right)
            for (int j = indexJ; j <= maxIndexJ; j++) matrix[indexI][j] = rotated[idx++];

            // Right column (top to bottom)
            for (int i = indexI + 1; i <= maxIndexI; i++) matrix[i][maxIndexJ] = rotated[idx++];

            // Bottom row (right to left)
            for (int j = maxIndexJ - 1; j >= indexJ; j--) matrix[maxIndexI][j] = rotated[idx++];

            // Left column (bottom to top)
            for (int i = maxIndexI - 1; i > indexI; i--) matrix[i][indexJ] = rotated[idx++];
        }

        // Print the rotated matrix
        foreach (List<int> row in matrix)
        {
            foreach (int val in row)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        int r = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        Result.matrixRotation(matrix, r);
    }
}
//https://www.hackerrank.com/challenges/matrix-rotation-algo/problem?isFullScreen=true