
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
     * Complete the 'equalizeArray' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int equalizeArray(List<int> arr)
    {
        int maxCount = 0;
        int maxElement = 0;
        int deletionCount = 0;

        // Finding the element with the maximum frequency
        for (int i = 0; i < arr.Count; i++)
        {
            int count = 0;
            for (int j = 0; j < arr.Count; j++)
            {
                if (arr[i] == arr[j])
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxElement = arr[i];
                    }
                }
            }
        }

        // Removing elements that are not the maxElement
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] != maxElement)
            {
               // Console.WriteLine("i: " + i);
               // Console.WriteLine("arr[i]: " + arr[i]);

                arr.RemoveAt(i);
                i--; // Important to decrement to avoid skipping elements
               // Console.WriteLine("arr.Count: " + arr.Count);
                deletionCount++;
            }
        }

        // Print the final state of the array after deletions

       // Console.WriteLine("Array after deletions:");
        for (int i = 0; i < arr.Count; i++)
        {
            Console.WriteLine(arr[i]);

            //Console.WriteLine("i:"+i+" arr:"+arr[i] + ' '+"count:"+arr.Count);
        }

        return deletionCount;
    }
}


    class Solution
{
    public static void Main(string[] args)
    {
        // Fallback to console if OUTPUT_PATH is not set
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");

        // If the environment variable is null, output to the console
        TextWriter textWriter = outputPath != null ?
            new StreamWriter(outputPath, true) : Console.Out;

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList()
            .Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.equalizeArray(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/equality-in-a-array/problem?isFullScreen=true