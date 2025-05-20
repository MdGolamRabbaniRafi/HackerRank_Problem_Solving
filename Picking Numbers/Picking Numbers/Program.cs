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
     * Complete the 'pickingNumbers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int pickingNumbers(List<int> a)
    {
        a.Sort();
        List<List<int>> subArrays = new List<List<int>>();
        int count = 0;
        for(int i=0;i<a.Count;i++)
        {
            List<int> subArray = new List<int>();
            int j = i+1;
            int value = a[i];
            subArray.Add(a[i]);

            while (j < a.Count)
            {
                if (Math.Abs(a[i] - a[j])>1)
                {
                   // i = j;
                    break;
                }
                subArray.Add(a[j]);
                j++;
            }
            subArrays.Add(subArray);
            
        }
        foreach(List<int> subarray in subArrays)
        {
            foreach(int i in subarray)
            {
                Console.Write(i+" ");

            }
            Console.WriteLine();
            if (subarray.Count > count) {
            
                count= subarray.Count;
            }
        }
        Console.WriteLine("count:" + count);

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

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.pickingNumbers(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}



//https://www.hackerrank.com/challenges/picking-numbers/problem?isFullScreen=true