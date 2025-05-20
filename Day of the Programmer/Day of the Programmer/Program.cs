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
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        if (year == 1918) return "26.09.1918"; // special case for 1918
        else if (year > 1918)
        {
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) return "12.09." + year; // Gregorian calendar
            else return "13.09." + year; // Gregorian calendar
        }
        else // Julian calendar
        {
            if (year % 4 == 0) return "12.09." + year; // Julian calendar
            else return "13.09." + year; // Julian calendar

        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

//https://www.hackerrank.com/challenges/day-of-the-programmer/problem?isFullScreen=true