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
using System.Drawing;

class Result
{

    /*
     * Complete the 'fairRations' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY B as parameter.
     */

    public static string fairRations(List<int> B)
    {
        int sum=B.Sum();
        if(sum%2!=0)
        {
            return "NO";
        }
        int count = 0;
        for(int  i=0; i<B.Count-1;i++)
        {
            if (B[i]%2==0)
            {
                continue;
            }
            else
            {
                B[i]++;
                B[i + 1]++;
                count=count+2;
            }
        }
        Console.WriteLine(count);
        string result = count.ToString();


        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int N = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

        string result = Result.fairRations(B);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

//https://www.hackerrank.com/challenges/fair-rations/problem?isFullScreen=true