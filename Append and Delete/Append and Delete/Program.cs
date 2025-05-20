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
     * Complete the 'appendAndDelete' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. STRING t
     *  3. INTEGER k
     */

    public static string appendAndDelete(string s, string t, int k)
    {
        char[] chars = s.ToCharArray();
        char[] chars2 = t.ToCharArray();
        int Count = 0;
        int j = 0;
        while(j<chars.Length&&j<chars2.Length-1)
        {
            if (chars[j] != chars2[j])
            {
                break;
            }
            j++;
        }
        if(j==chars.Length&&j==chars2.Length)
        {
            Console.WriteLine("Yes");
            return "Yes";
        }

        int remainChar= chars2.Length-j;
        Count += remainChar;
        int NewChar = chars.Length-j;
        Count += NewChar;
        if (Count <= k && (k - Count) % 2 == 0 || k >= s.Length + t.Length)
        {
            Console.WriteLine("Yes");
            return "Yes";
        }
        Console.WriteLine("No");
        return "No";

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        string s = Console.ReadLine();

        string t = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.appendAndDelete(s, t, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/append-and-delete/problem?isFullScreen=true