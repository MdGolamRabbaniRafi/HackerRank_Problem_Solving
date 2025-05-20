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
     * Complete the 'serviceLane' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY cases
     */

    public static List<int> serviceLane(int n, List<int> width, List<List<int>> cases)
    {
        int min=0;
        List<int> result=new List<int>();
        for(int i=0;i<cases.Count;i++)
        {
            min = width[cases[i][0]];
            for(int j = cases[i][0]; j <= cases[i][1];j++)
            {
                if (min > width[j])
                {
                    min = width[j];
                }
            }
            result.Add(min);


        }
        Console.WriteLine("Result:");
        foreach(int r in result)
        {
            Console.WriteLine(r);
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

        int t = Convert.ToInt32(firstMultipleInput[1]);

        List<int> width = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(widthTemp => Convert.ToInt32(widthTemp)).ToList();

        List<List<int>> cases = new List<List<int>>();

        for (int i = 0; i < t; i++)
        {
            cases.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(casesTemp => Convert.ToInt32(casesTemp)).ToList());
        }

        List<int> result = Result.serviceLane(n, width, cases);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/service-lane/problem?isFullScreen=true