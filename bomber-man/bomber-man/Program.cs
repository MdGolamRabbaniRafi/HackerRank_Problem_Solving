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

class Result
{

    /*
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */
    public static List<string> explode(int n, List<string> grid)
    {
        List<string> result = new List<string>();

        Console.WriteLine("3rd if");
        int row = grid.Count;
        int col = grid[0].Length;
        List<StringBuilder> newGrid = new List<StringBuilder>();
        foreach (var line in grid)
        {
            newGrid.Add(new StringBuilder(line));
        }
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (grid[i][j] == 'O')
                {
                    if (j > 0)
                    {
                        newGrid[i][j - 1] = '.';
                    }
                    if (j < col - 1)
                    {
                        newGrid[i][j + 1] = '.';

                    }
                    if (i > 0)
                    {
                        newGrid[i - 1][j] = '.';
                    }
                    if (i < row - 1)
                    {
                        newGrid[i + 1][j] = '.';

                    }
                    newGrid[i][j] = '.';
                }
                else
                {
                    if (i != 0 && grid[i - 1][j] == 'O')
                    {
                        continue;
                    }
                    if (j != 0 && grid[i][j - 1] == 'O')
                    {
                        continue;
                    }

                    newGrid[i][j] = 'O';
                }
            }
        }
        foreach (var sb in newGrid)
        {
            result.Add(sb.ToString());
        }
        return result;
    }


    public static List<string> bomberMan(int n, List<string> grid)
    {
       // Console.WriteLine(".......O.OO..O...OO..........O.........OO..O..O.O..OOO.O.O..O...O..O..O...OOO.....OO........O.O..O..O..O.O.O..OO..O.......OO........O...OO.O....O...O.....OO....O..OO.O...OO.O.OO...OO......OOO..");
        List<string> result = new List<string>();
       // 

        if (n%2==0)
        {
            Console.WriteLine("1st if");
            for(int i=0;i<=grid.Count-1;i++)
            {
                string p="O";
                p = String.Concat(Enumerable.Repeat(p, grid[0].Length));
                result.Add(p);
            }
            foreach (var sb in result)
            {
                Console.WriteLine(sb.ToString());
            }
            return result;
        }
        else if(n==1)
        {
            Console.WriteLine("2nd if");
            foreach (var sb in result)
            {
                Console.WriteLine(sb.ToString());
            }
            return grid;
        }
        else if((n-3)%4==0&&n>=3)
        {
            result = explode(n, grid);
            foreach (var sb in result)
            {
                Console.WriteLine(sb.ToString());
            }
            return result;

        }
        else if ((n - 5) % 4 == 0 && n >= 5)
        {
            result = explode(n, grid);
            result = explode(n, result);
            foreach (var sb in result)
            {
                Console.WriteLine(sb.ToString());
            }
            return result;
        }

            /* foreach (var sb in result)
             {
                 Console.WriteLine(sb.ToString());
             }*/

            return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.bomberMan(n, grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/bomber-man/problem?isFullScreen=true