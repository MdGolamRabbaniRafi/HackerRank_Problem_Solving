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
     * Complete the 'absolutePermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     */

    public static List<int> absolutePermutation(int n, int k)
    {
        List<int> result = new List<int>(n); // Initialize with capacity n
        HashSet<int> used = new HashSet<int>(); // To track used numbers
        for(int i=1;i<=n;i++)
        {
              int add=i+k;
              int sub = i - k;
            if (sub > 0 && !used.Contains(sub))
            {
                result.Add(sub);
                used.Add(sub);
            }
            else if (add <= n && !used.Contains(add))
            {
                result.Add(add);
                used.Add(add);
            }
            else
            {
                return new List<int> { -1 };

            }


        }

          return result;//time limit problem

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> result = Result.absolutePermutation(n, k);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

//https://www.hackerrank.com/challenges/absolute-permutation/problem?isFullScreen=true