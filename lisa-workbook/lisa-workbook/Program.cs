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
     * Complete the 'workbook' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER_ARRAY arr
     */

    /* public static int workbook(int n, int k, List<int> arr)
     {
         int page = 0;
         int special = 0;
        for(int i = 0;i<n; i++)
        {
             for(int j = 1; j <= arr[i];j++)
             {
                 if(arr[i]<k)
                 {
                     page++;
                     if (j == page)
                     {

                         special++;

                     }
                    // page++;
                     Console.WriteLine("Inside Break page:" + page + " j:" + j + " a[i]:" + arr[i] + " special:" + special);
                     page++;
                     break;
                 }
                  if(j%k==0)
                 {
                     Console.WriteLine("page:" + page + " j:" + j + " a[i]:" + arr[i] + " special:" + special);

                     if (arr[i]>j)
                     {
                         j++;
                         page++;

                     }
                     else if (arr[i]==j)
                     {
                       //  page++;
                         Console.WriteLine("Inside 2nd break page:" + page + " j:" + j + " a[i]:" + arr[i] + " special:" + special);
                         break;
                     }
                     if (j == page)
                     {

                         special++;

                     }
                       Console.WriteLine("page:" + page + " j:" + j + " a[i]:" + arr[i] + " special:" + special);

                 }
                  if (j == arr[i] && j % k!=0)
                 {
                     page++;
                   //  Console.WriteLine("Inside (j == arr[i] && j % k!=0: page:" + page + " j:" + j + " a[i]:" + arr[i] + " special:" + special);

                 }
                 else if(j%k!=0 && page==0)
                 {
                     page++;
                 }

                 if (j==page)
                 {

                     special++;

                 }
                 Console.WriteLine("page:" + page + " j:" + j + " a[i]:" + arr[i] + " special:" + special);
             }
         }
        Console.WriteLine(special); 
        return special;
     }*/

    public static int workbook(int n, int k, List<int> arr)
    {
        int page = 1;
        int special = 0;
        for(int i=0;i<arr.Count;i++)
        {
          //  int l = arr[i];
            for(int j = 1; j <= arr[i];j++)
            {

               
                if (page == j)
                {
                    special++;

                }
                if (j % k == 0 || j == arr[i])
                {
                    page++;
                }


                Console.WriteLine("page:" + page + " j:" + j + " a[i]:" + arr[i] + " special:" + special);
            }
        }
        Console.WriteLine(special);
        return special;

    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.workbook(n, k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

//https://www.hackerrank.com/challenges/lisa-workbook/problem?isFullScreen=true