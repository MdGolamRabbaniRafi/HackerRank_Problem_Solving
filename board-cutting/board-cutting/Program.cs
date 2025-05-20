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
using System.Numerics;

class Result
{

    /*
     * Complete the 'boardCutting' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY cost_y
     *  2. INTEGER_ARRAY cost_x
     */
    public static void swap(int a,int b, List<int> arr)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    public static void sortDesc(List<int> arr)
    {
        for(int i=0;i<arr.Count; i++)
        {
            for(int j=0;j<arr.Count-1;j++)
            {
                if (arr[j] < arr[j+1])
                {
                    swap(j, j + 1, arr);
                }
            }
        }
    }
  
    public static int boardCutting(List<int> cost_y, List<int> cost_x)
    {
        int MOD = 1000000007;
     //  sortDesc(cost_y);
     // sortDesc(cost_x);
        cost_y.Sort((a, b) => b.CompareTo(a));
        cost_x.Sort((a, b) => b.CompareTo(a));


        int h = 1;
        int v = 1;
        long totalCost = 0; 
        int i = 0, j = 0;

        while (i < cost_y.Count || j < cost_x.Count)
        {
            if (i < cost_y.Count && (j >= cost_x.Count || cost_y[i] >= cost_x[j]))
            {
                totalCost = (totalCost + (long)cost_y[i] * v) % MOD;
                h++;
                i++;
            }
            else
            {
                totalCost = (totalCost + (long)cost_x[j] * h) % MOD;
                v++;
                j++;
            }
        }
        Console.WriteLine("totalCost:" + (int)totalCost);
        return (int)totalCost; 
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int m = Convert.ToInt32(firstMultipleInput[0]);

            int n = Convert.ToInt32(firstMultipleInput[1]);

            List<int> cost_y = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cost_yTemp => Convert.ToInt32(cost_yTemp)).ToList();

            List<int> cost_x = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cost_xTemp => Convert.ToInt32(cost_xTemp)).ToList();

            int result = Result.boardCutting(cost_y, cost_x);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

//https://www.hackerrank.com/challenges/board-cutting/problem?isFullScreen=true