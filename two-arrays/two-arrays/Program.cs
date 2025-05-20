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
     * Complete the 'twoArrays' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY A
     *  3. INTEGER_ARRAY B
     */
    public static void swap(int a, int b,List<int> arr)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    public static void sortASC(List<int> arr)
    {
        for(int i=0;i<arr.Count;i++)
        {
            for(int j=0;j<arr.Count-1;j++)
            {
                if (arr[j] > arr[j+1])
                {
                    swap(j, j + 1, arr);
                }
            }
        }
    }
    public static void sortDESC(List<int> arr)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = 0; j < arr.Count - 1; j++)
            {
                if (arr[j] < arr[j + 1])
                {
                    swap(j, j + 1, arr);
                }
            }
        }
    }
    public static string possibleOrNot(int k, List<int> A, List<int> B)
    {
        for(int i=0;i<A.Count;i++)
        {
            if (A[i] + B[i]<k)
            {
                return "NO";
            }
        }
        return "YES";
    }

    public static string twoArrays(int k, List<int> A, List<int> B)
    {
        sortASC(A);
        sortDESC(B);
        Console.WriteLine(possibleOrNot(k, A, B));
        
        return possibleOrNot(k, A, B);
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

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

            List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

            string result = Result.twoArrays(k, A, B);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}


//https://www.hackerrank.com/challenges/two-arrays/problem?isFullScreen=true