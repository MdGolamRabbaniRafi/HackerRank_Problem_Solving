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
     * Complete the 'closestNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> closestNumbers(List<int> arr)
    {
        arr.Sort();
        List<int> result = new List<int>();
        result.Add(0);
        int ABS = int.MaxValue;


        for(int i=0;i<arr.Count-1;i++)
        {
            if (Math.Abs(arr[i] - arr[i+1])<ABS)
            {
                ABS = Math.Abs(arr[i] - arr[i + 1]);
                result.Clear();
                result.Add(arr[i]);
                result.Add(arr[i+1]);
            }
            else if (Math.Abs(arr[i] - arr[i + 1]) == ABS)
            {
                result.Add(arr[i]);
                result.Add(arr[i + 1]);
            }
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
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.closestNumbers(arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/closest-numbers/problem?isFullScreen=true