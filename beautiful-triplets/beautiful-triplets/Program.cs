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
     * Complete the 'beautifulTriplets' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER d
     *  2. INTEGER_ARRAY arr
     */

    public static int beautifulTriplets(int d, List<int> arr)
    {
        int count = 0;

        // Loop through the array to find beautiful triplets
        for (int i = 0; i < arr.Count; i++)
        {
            int b = arr[i] + d;
            int c = arr[i] + 2 * d;

            // Check if both b and c exist in the array
            if (arr.Contains(b) && arr.Contains(c))
            {
                count++;
                Console.WriteLine("Triplet found: arr[i] = " + arr[i] + ", b = " + b + ", c = " + c);
            }
        }

        Console.WriteLine("Total beautiful triplets: " + count);
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

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.beautifulTriplets(d, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}




//https://www.hackerrank.com/challenges/beautiful-triplets/problem?isFullScreen=true
