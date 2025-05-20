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
using System.Runtime.InteropServices;
using System.Collections.Specialized;

class Result
{

    /*
     * Complete the 'cavityMap' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static List<string> cavityMap(List<string> grid)
    {
        for(int i=1;i<=grid.Count-2;i++)
        {
            for(int j=1;j<=grid.Count-2;j++)
            {
                if (grid[i][j] > grid[i - 1][j] && grid[i][j] > grid[i][j - 1] && grid[i][j] > grid[i + 1][j] && grid[i][j] > grid[i][j+1])
                {
                    char[] c = grid[i].ToCharArray();
                    c[j] = 'X';
                    grid[i] = new string(c);

                }
            }
        }
        foreach(string s in grid)
        {
            Console.WriteLine(s);

        }
        return grid;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.cavityMap(grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/cavity-map/problem?isFullScreen=true