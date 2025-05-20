
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
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */
    public static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public static int LCM(int a, int b)
    {
        return (a * b) / GCD(a, b);
    }
    public static int GCDArray(int[] numbers)
    {
        int result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result = GCD(result, numbers[i]);
        }
        return result;
    }
    public static int LCMArray(int[] numbers)
    {
        int result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result = LCM(result, numbers[i]);
        }
        return result;
    }
    public static int getTotalX(List<int> a, List<int> b)
    {
        int lcmA = LCMArray(a.ToArray());
        int gcdB = GCDArray(b.ToArray());

        // Find all x such that: LCM(A) <= x <= GCD(B)
        // And x is multiple of LCM(A) and factor of GCD(B)
        List<int> result = new List<int>();
        for (int x = lcmA; x <= gcdB; x += lcmA)
        {
            if (gcdB % x == 0)
            {
                result.Add(x);
            }
        }

        Console.WriteLine("Valid x values:");
        foreach (int x in result)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine(result.Count);

        return result.Count;


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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}


//https://www.hackerrank.com/challenges/between-two-sets/problem?isFullScreen=true