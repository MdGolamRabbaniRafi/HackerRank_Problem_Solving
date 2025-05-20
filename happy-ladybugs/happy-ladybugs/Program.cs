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
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */

    public static string happyLadybugs(string b)
    {
      /*  char[] characters = b.ToArray();
        Array.Sort(characters);
        b= new string(characters);*/
        bool _contains=b.Contains("_");
        string retVal="NO";
        // bool check=false;

        if (!_contains)
        {
            if (b.Length <= 1)
            {
                Console.WriteLine(retVal);
                return retVal;
            }

            if (b[b.Length - 1] != b[b.Length - 2])
            {
                Console.WriteLine(retVal);
                return retVal;
            }
            for (int i = 1;i<b.Length-1;i++)
            {
                if (b[i] != b[i - 1] && b[i] != b[i+1])
                {
                    Console.WriteLine("b[i]:" + b[i] + " b[i-1]:" + b[i - 1] + " b[i+1]:" + b[i + 1]);
                    Console.WriteLine(retVal);
                    return retVal;
                }

            }
            retVal = "YES";
            Console.WriteLine(retVal);
            return retVal;
        }
        else
        {
            
            for(int i=0;i<=b.Length-1;i++)
            {
                if (b[i] == '_')
                {
                    continue;
                }
                bool found=false;
                for(int j=0;j<=b.Length-1;j++)
                {
                    if (b[j]=='_'||i==j)
                    {
                        continue;
                    }
                    Console.WriteLine("b[i:]:" + b[i] + " b[j]:" + b[j]);
                    if (b[i] == b[j])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine(retVal);
                    return retVal;
                }
            }
            retVal = "YES";
            Console.WriteLine(retVal);
            return retVal;
        }

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
//    https://www.hackerrank.com/challenges/happy-ladybugs/problem?isFullScreen=true
