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
     * Complete the 'stones' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER a
     *  3. INTEGER b
     */

    public static List<int> stones(int n, int a, int b)
    {
        List<int> ints = new List<int>();
        int count = 0;
        int aCount = 0;
        int bCount = 0;

        ints.Add(a*(n-1));
        ints.Add(b * (n - 1));

        for (int i = 1; i < n-1; i++) {
            aCount = a * i;
            bCount = b * (n-1-i);
            count=aCount + bCount;
            ints.Add(count);
        }
        HashSet<int> uniqueNumbers = new HashSet<int>(ints);
        List<int> distinctNumbers = uniqueNumbers.ToList();

        distinctNumbers.Sort();
      /*  Console.WriteLine("Output...");
        foreach(int i in distinctNumbers) { 
        Console.Write(i+" ");
        
        }
        Console.WriteLine();*/
        return distinctNumbers;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true); int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int a = Convert.ToInt32(Console.ReadLine().Trim());

            int b = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> result = Result.stones(n, a, b);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

