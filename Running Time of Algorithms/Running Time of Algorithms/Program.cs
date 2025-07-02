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
     * Complete the 'runningTime' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int runningTime(List<int> arr)
    {
        var j = 0;
        int count = 0;
        for (var i = 1; i < arr.Count; i++)
        {
            var value = arr[i];
            j = i - 1;
            while (j >= 0 && value < arr[j])
            {
                arr[j + 1] = arr[j];
                j = j - 1;
                count++;
            }
            arr[j + 1] = value;
               Console.WriteLine("inside outer loop:"+string.Join(" ", arr));

        }
        Console.WriteLine(string.Join(" ", arr));
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
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.runningTime(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/runningtime/problem?isFullScreen=true