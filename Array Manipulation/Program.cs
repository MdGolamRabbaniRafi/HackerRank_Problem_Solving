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
     * Complete the 'arrayManipulation' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static long arrayManipulation(int n, List<List<int>> queries)
    {
        //List<long> result = Enumerable.Repeat(0L, n).ToList();

        //foreach(var i in result)
        //{
        //    Console.WriteLine(i);

        //}
        //long max = 0;

        //foreach (var query in queries)
        //{
        //    for (int i = query[0]-1; i < query[1]; i++)
        //    {
        //       //// Console.WriteLine(query[i]);
        //       // Console.WriteLine(query[0]);
        //       // Console.WriteLine(query[1]);

        //       // Console.WriteLine(query[2]);
        //        Console.WriteLine("i:"+i);


        //        result[i] = result[i] + query[2];
        //        if (max < result[i])
        //        {
        //            max = result[i];
        //        }
        //        //foreach (var j in result)
        //        //{
        //        //    Console.Write(j+" ");

        //        //}
        //    }
        //}
        List<long> result = Enumerable.Repeat(0L, n + 2).ToList();  // +2 to avoid out-of-range
        long max = 0;

        foreach (var query in queries)
        {
            int a = query[0];
            int b = query[1];
            int k = query[2];

            result[a - 1] += k;  // safe now even if a == 1
            result[b] -= k;      // safe now even if b == n
        }


        long current = 0;
        for (int i = 0; i < n; i++)               // One prefix sum pass — O(n)
        {
            current += result[i];
            max = Math.Max(max, current);

        }


        return max;


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

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        long result = Result.arrayManipulation(n, queries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}





//https://www.hackerrank.com/challenges/crush/problem?isFullScreen=true