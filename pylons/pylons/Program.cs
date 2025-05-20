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
     * Complete the 'pylons' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    public static int pylons(int k, List<int> arr)
    {
        int count = 0;
        int j = 0;
        while (j < arr.Count)
        {
            // Find the rightmost position within the range that has a 1
            int plantPosition = -1;
            for (int i = Math.Min(j + k - 1, arr.Count - 1); i >= Math.Max(j - (k - 1), 0); i--)
            {
                if (arr[i] == 1)
                {
                    plantPosition = i;
                    break;
                }
            }

            // If we couldn't find a place to plant within range, return -1 (failure case)
            if (plantPosition == -1)
            {
                Console.WriteLine("-1");
                return -1;
            }

            // Place a plant and count it
            count++;

            // Move j forward to the next uncovered city
            j = plantPosition + k;
        }
        Console.WriteLine(count);
        return count;
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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.pylons(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/pylons/problem?isFullScreen=true