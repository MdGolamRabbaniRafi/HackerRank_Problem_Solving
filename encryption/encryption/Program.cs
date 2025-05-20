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
using System.Xml.Linq;

class Result
{

    /*
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        string result = "";
        long length=s.Length; 
        double sqrt=Math.Sqrt(length);
        long ceil = (long)Math.Ceiling(sqrt);
        List<string> finalResult = new List<string>();
        string count = "";

        for (int i = 0; i < s.Length; i++) // Use < instead of <=
        {
            if (i % ceil == 0&&i!=0)
            {
                result += " ";

            }
            result=result+ s[i];

        }
        finalResult = result.Split(' ').ToList();
        int mxVal = finalResult.Max(row => row.Length);

        for (int i = 0; i < mxVal; i++) // Use < instead of <=
        {
            for (int j = 0; j < finalResult.Count; j++)
            {
                if (i < finalResult[j].Length) // Ensure index i is within bounds of the current row
                {
                    count += finalResult[j][i];
                 //   Console.WriteLine($"i: {i}, j: {j}, finalResult[i]: {finalResult[i]}, finalResult[j][i]: {finalResult[j][i]},count in Loop: {count}");

                    Console.WriteLine();
                }

            }
            if(i< mxVal - 1)
            {
                count += " ";

            }

        }
       /* foreach(string r in finalResult)
        {
            Console.Write("finalResult:" + r);
        }*/



        return count;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/encryption/problem?isFullScreen=true