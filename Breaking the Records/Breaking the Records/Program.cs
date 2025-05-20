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
     * Complete the 'breakingRecords' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY scores as parameter.
     */

    public static List<int> breakingRecords(List<int> scores)
    {
        int max = scores[0];
        int min = scores[0];
        int maxCount = 0;
        int minCount = 0;
        List<int> result = new List<int>();
        foreach (int i in scores) { 
            Console.WriteLine("i:"+i);
            Console.WriteLine("max:" + max);
            Console.WriteLine("maxCount:" + maxCount);
            Console.WriteLine("min:" + min);
            Console.WriteLine("minCount:" + minCount);
            if (i>max)
            {
                maxCount++;
                max = i;
                Console.WriteLine("max:"+max);
                Console.WriteLine("maxCount:"+maxCount);
            }
            else if(i<min)
            {
                minCount++;
                min = i;
                Console.WriteLine("min:"+min);
                Console.WriteLine("minCount:"+minCount);
            }
        }
        result.Add(maxCount);
        result.Add(minCount);
        return result;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

        List<int> result = Result.breakingRecords(scores);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}


