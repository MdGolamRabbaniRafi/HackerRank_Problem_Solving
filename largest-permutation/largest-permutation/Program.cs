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
     * Complete the 'largestPermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */
    public static void swap(int a,int b, List<int> arr)
    {
        int temp =arr[a]; 
        arr[a]=arr[b]; 
        arr[b]=temp;
    }
    public static List<int> largestPermutation(int k, List<int> arr)
    {
        Console.WriteLine("K:" + k);
        List<int> result = new List<int>(arr);
        int maxValue = result.Max();
        int index = 0;
        int count = 0;
        while(count<k)
        {
            int maxValueIndex = result.IndexOf(maxValue);
            if(maxValueIndex==-1)
            {
                break;
            }
            else if(maxValueIndex>index)
            {
                swap(maxValueIndex, index, result);
                count++;

            }

            index++;
            maxValue--;
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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.largestPermutation(k, arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/largest-permutation/problem?isFullScreen=true