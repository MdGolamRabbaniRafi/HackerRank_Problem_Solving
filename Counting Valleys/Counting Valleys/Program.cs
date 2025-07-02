
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
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */

    public static int countingValleys(int steps, string path)
    {
        int countZero = 0;
        int count = 0;
        foreach(char b in path)
        {
            if(b=='U')
            {
                count++;
                Console.WriteLine("Count inside U:" + count);

                if (count == 0)
                {
                    Console.WriteLine("count inside U:" + count);

                    countZero++;
                    Console.WriteLine("countZero:" + countZero);

                }
            }
            else if(b=='D')
            {
                count--;
                Console.WriteLine("Count inside D:" + count);

                //if (count == 0)
                //{
                //    Console.WriteLine("count inside D:" + count);
                //    countZero++;
                //    Console.WriteLine("countZero:" + countZero);

                //}
            }

        }
        Console.WriteLine("return countZero:" + countZero);


        return countZero;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.countingValleys(steps, path);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}


//https://www.hackerrank.com/challenges/counting-valleys/problem?isFullScreen=true