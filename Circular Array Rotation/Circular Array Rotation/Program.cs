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
     * Complete the 'circularArrayRotation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER k
     *  3. INTEGER_ARRAY queries
     */

    public static List<int> circularArrayRotation(List<int> a, int k, List<int> queries)
    {
        /* int divident = k % (a.Count);
         for (int j = 0; j < divident; j++)
         {
             int temp = a[0];
             a[0] = a[a.Count - 1];
             for (int i = 1; i < a.Count; i++)
             {
                 int temp2 = a[i];
                 a[i] = temp;
                 temp = temp2;
             }
         }

         List<int> result = new List<int>();
         for (int i = 0;i<queries.Count;i++)
         {
            result.Add(a[queries[i]]);
         }*///time limit problem
        List<int> result = new List<int>();
        int n = a.Count;
        k = k % n;

        foreach (int query in queries)
        {
            // Calculate the new index after k rotations to the right
            int newIndex = (query - k + n) % n;  // Adjust for right rotation
            result.Add(a[newIndex]);
        }
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

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        int q = Convert.ToInt32(firstMultipleInput[2]);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> queries = new List<int>();

        for (int i = 0; i < q; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<int> result = Result.circularArrayRotation(a, k, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/circular-array-rotation/problem?isFullScreen=true