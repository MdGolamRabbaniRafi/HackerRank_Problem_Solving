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
     * Complete the 'howManyGames' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER d
     *  3. INTEGER m
     *  4. INTEGER s
     */

    /* public static int howManyGames(int p, int d, int m, int s)
     {

         if(p>s||s<m)
         {
             return 0;
         }
         long count = 1;
         long totalCost = (long)p;
         long i = (long)p;
         long check = 0;

         while(totalCost<s) {
             if (check > s)
             {
                    Console.WriteLine("check:" + check);
                    Console.WriteLine("s:" + s);
                 break;

             }

             if (i-d>m && totalCost+(i-d)<=s)
             {
                 totalCost= totalCost+(i-d);
                 i= i-d;
                 if(totalCost>s)
                 {
                     break;
                 }
                 count++;
                 check = totalCost + (i - d);
             }
             else if(i-d<=m &&totalCost+(i-d)<s)
             {
                 totalCost = totalCost+m;
                 if (totalCost > s)
                 {
                     break;
                 }
                 count++;
                 check = totalCost + m;
             }



         }
            Console.WriteLine("count:" + count);

         // Return the number of games you can buy
         return (int)count;

     }*/

    public static int howManyGames(int p, int d, int m, int s)
    {
        int count = 0;
        long totalCost = 0;

        while (totalCost + p <= s) 
        {
            totalCost += p;  
            count++;         

            p -= d;         

            if (p < m)
            {
                p = m;      
            }
        }

        return count; 
    }




}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int p = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        int m = Convert.ToInt32(firstMultipleInput[2]);

        int s = Convert.ToInt32(firstMultipleInput[3]);

        int answer = Result.howManyGames(p, d, m, s);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}

//https://www.hackerrank.com/challenges/halloween-sale/problem?isFullScreen=true