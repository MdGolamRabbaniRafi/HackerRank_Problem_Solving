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
using static System.Net.Mime.MediaTypeNames;

class Result
{

    /*
     * Complete the 'gridSearch' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING_ARRAY G
     *  2. STRING_ARRAY P
     */

    public static string gridSearch(List<string> G, List<string> P)
    {
     
        int gridCount=G.Count;
        int patternCount = P.Count;
        int patternDigit = P[0].Length;
        int index;
        for(int i=0;i<=gridCount-patternCount;i++)
        {
            index = G[i].IndexOf(P[0]);
            while(index!=-1)
            {
                bool patternFound = true;

                for (int k=1;k<patternCount;k++)
                {
                    int index2 = G[k+i].IndexOf(P[k]);
                    string pattern= G[i + k].Substring(index, patternDigit);
                    if (pattern != P[k])
                    {
                        patternFound = false;
                        break;
                    }

                }
                if(patternFound)
                {
                    return "YES";
                }
                index = G[i].IndexOf(P[0],index+1);
            }

        }
        


        return "NO";    

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int R = Convert.ToInt32(firstMultipleInput[0]);

            int C = Convert.ToInt32(firstMultipleInput[1]);

            List<string> G = new List<string>();

            for (int i = 0; i < R; i++)
            {
                string GItem = Console.ReadLine();
                G.Add(GItem);
            }

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(secondMultipleInput[0]);

            int c = Convert.ToInt32(secondMultipleInput[1]);

            List<string> P = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string PItem = Console.ReadLine();
                P.Add(PItem);
            }

            string result = Result.gridSearch(G, P);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/the-grid-search/problem?isFullScreen=true