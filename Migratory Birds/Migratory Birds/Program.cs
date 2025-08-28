using Microsoft.VisualBasic;
using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

class Result
{

    /*
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {
        var frequency = new Dictionary<int, int>();
        foreach(var bird in arr)
        {
            if (frequency.ContainsKey(bird))
            {
                frequency[bird]++;
            }
            else
            {
                frequency[bird] = 1;
            }
        }
        int result = int.MaxValue;
        int maxCount = 0;

        foreach (var kvp in frequency) {
            if (kvp.Value > maxCount||(kvp.Value==maxCount && kvp.Key<result)) { 
                maxCount = kvp.Value;
                result = kvp.Key;
            
            }
        }
        Console.WriteLine(result);

        return result;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
