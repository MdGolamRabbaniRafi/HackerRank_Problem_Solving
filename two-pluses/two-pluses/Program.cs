
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
using static System.Runtime.InteropServices.JavaScript.JSType;

class Result
{

    /*
     * Complete the 'twoPluses' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static int twoPluses(List<string> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Length;
        int[,] convertedGrid = new int[rows, cols];

        // Convert the grid, 'G' becomes 0, 'B' becomes -1
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 'G')
                    convertedGrid[i, j] = 0;  // G becomes 0
                else
                    convertedGrid[i, j] = -1; // B becomes -1
            }
        }

        // Helper method to check the plus size at position (i, j)
        int getMaxPlusSize(int i, int j, int[,] grid)
        {
            int size = 0;
            while (i - size >= 0 && i + size < rows && j - size >= 0 && j + size < cols &&
                   grid[i - size, j] == 0 && grid[i + size, j] == 0 &&
                   grid[i, j - size] == 0 && grid[i, j + size] == 0)
            {
                size++;
            }
            return size - 1;
        }

        int maxProduct = 0;

        // Loop through every possible first plus
        for (int i1 = 0; i1 < rows; i1++)
        {
            for (int j1 = 0; j1 < cols; j1++)
            {
                // Check if the first plus can be formed at (i1, j1)
                if (convertedGrid[i1, j1] == 0)
                {
                    int maxFirstPlus = getMaxPlusSize(i1, j1, convertedGrid);

                    // Mark the first plus on a temporary grid and check for the second plus
                    for (int s1 = 0; s1 <= maxFirstPlus; s1++)
                    {
                        int firstArea = 1 + 4 * s1;

                        int[,] tempGrid = (int[,])convertedGrid.Clone();

                        // Mark the first plus
                        for (int k = 0; k <= s1; k++)
                        {
                            tempGrid[i1 - k, j1] = -1;
                            tempGrid[i1 + k, j1] = -1;
                            tempGrid[i1, j1 - k] = -1;
                            tempGrid[i1, j1 + k] = -1;
                        }

                        // Now search for the second plus in the modified grid
                        for (int i2 = 0; i2 < rows; i2++)
                        {
                            for (int j2 = 0; j2 < cols; j2++)
                            {
                                if (tempGrid[i2, j2] == 0)
                                {
                                    int maxSecondPlus = getMaxPlusSize(i2, j2, tempGrid);

                                    // For each possible size of the second plus
                                    for (int s2 = 0; s2 <= maxSecondPlus; s2++)
                                    {
                                        int secondArea = 1 + 4 * s2;
                                        int product = firstArea * secondArea;

                                        // Update max product
                                        maxProduct = Math.Max(maxProduct, product);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return maxProduct;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        int result = Result.twoPluses(grid);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}



//https://www.hackerrank.com/challenges/two-pluses/problem?isFullScreen=true