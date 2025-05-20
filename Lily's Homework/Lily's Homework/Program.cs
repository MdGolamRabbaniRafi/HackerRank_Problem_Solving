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
     * Complete the 'lilysHomework' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int lilysHomework(List<int> arr)
    {
        int CalculateSwaps(List<int> original, List<int> sorted)
        {
            Dictionary<int, int> indexMap = new Dictionary<int, int>();
            for (int i = 0; i < original.Count; i++)
            {
                indexMap[original[i]] = i;
            }

            int swaps = 0;
            List<int> arrCopy = new List<int>(original);
            for (int i = 0; i < sorted.Count; i++)
            {
                if (arrCopy[i] == sorted[i])
                {
                    continue;
                }

                swaps++;

                int correctIndex = indexMap[sorted[i]];
                indexMap[arrCopy[i]] = correctIndex;
                indexMap[sorted[i]] = i;

                int temp = arrCopy[i];
                arrCopy[i] = arrCopy[correctIndex];
                arrCopy[correctIndex] = temp;
            }

            return swaps;
        }

        List<int> sortedAsc = new List<int>(arr);
        sortedAsc.Sort();

        List<int> sortedDesc = new List<int>(sortedAsc);
        sortedDesc.Reverse();

        int ascSwaps = CalculateSwaps(arr, sortedAsc);
        int descSwaps = CalculateSwaps(arr, sortedDesc);

        return Math.Min(ascSwaps, descSwaps);
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

        int result = Result.lilysHomework(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/lilys-homework/problem?isFullScreen=true