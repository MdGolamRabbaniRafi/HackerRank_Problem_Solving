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
     * Complete the 'countSort' function below.
     *
     * The function accepts 2D_STRING_ARRAY arr as parameter.
     */
    /* public static void Swap(List<List<string>> arr,int a, int b)
     {
         List<string> temp = arr[a];
         arr[a] = arr[b];
         arr[b] = temp;
     }

     public static void countSort(List<List<string>> arr)
     {
         for(int i=0;i<(arr.Count/2);i++)
         {
             arr[i][1] = "-";
         }
         for(int i=0; i<arr.Count-1;i++)
         {
             for(int j=0;j<arr.Count-1;j++)
             {
                 if (Int32.Parse(arr[j][0]) > Int32.Parse(arr[j + 1][0]))
                 {
                     Swap(arr, j, j + 1);
                 }
             }
         }
         foreach (List<string> arr2 in arr)
         {

                 Console.Write(arr2[1] +" ");

         }
     }*///time limit problem
    /* public static void countSort(List<List<string>> arr)
     {
         for (int i = 0; i < (arr.Count / 2); i++)
         {
             arr[i][1] = "-";
         }
         int maxKey = 0;
         foreach (List<string> a in arr)
         {
             int key = Int32.Parse(a[0]);
             if (key > maxKey)
             {
                 maxKey = key;
             }
         }

         // Step 3: Initialize a list of lists (buckets) with empty sub-lists
         List<List<string>> arr2 = new List<List<string>>();
         for (int i = 0; i <= maxKey; i++)
         {
             arr2.Add(new List<string>()); // Add an empty list for each possible key
         }
         foreach (List<string> a in arr)
         {
             int key = Int32.Parse(a[0]);
             arr2[key].Add(a[1]);
         }
         foreach (List<string> a in arr2) {
             foreach(string s in a)
             {
                 Console.Write(s + " ");

             }
         }

     }*///time limit problem
    /*public static void countSort(List<List<string>> arr)
    {
        int n = arr.Count;
        for (int i = 0; i < n / 2; i++)
        {
            arr[i][1] = "-";
        }

        int maxKey = 0;
        foreach (List<string> a in arr)
        {
            int key = Int32.Parse(a[0]);
            if (key > maxKey)
            {
                maxKey = key;
            }
        }

        List<List<string>> buckets = new List<List<string>>(new List<string>[maxKey + 1]);
        for (int i = 0; i <= maxKey; i++)
        {
            buckets[i] = new List<string>();
        }

        foreach (List<string> a in arr)
        {
            int key = Int32.Parse(a[0]);
            buckets[key].Add(a[1]);
        }

        StringBuilder output = new StringBuilder();
        foreach (var bucket in buckets)
        {
            foreach (var s in bucket)
            {
                output.Append(s).Append(" ");
            }
        }

        Console.WriteLine(output.ToString().TrimEnd());
    }*///timme limit problem
    public static void countSort(List<List<string>> arr)
    {
        int n = arr.Count;
        for (int i = 0; i < n / 2; i++)
        {
            arr[i][1] = "-";
        }

        int maxKey = 0;
        foreach (var a in arr)
        {
            int key = int.Parse(a[0]);
            if (key > maxKey) maxKey = key;
        }

        List<string>[] buckets = new List<string>[maxKey + 1];
        for (int i = 0; i <= maxKey; i++)
        {
            buckets[i] = new List<string>();
        }

        foreach (var a in arr)
        {
            int key = int.Parse(a[0]);
            buckets[key].Add(a[1]);
        }

        StringBuilder output = new StringBuilder();
        foreach (var bucket in buckets)
        {
            if (bucket.Count > 0)
            {
                output.Append(string.Join(" ", bucket)).Append(" ");
            }
        }

        Console.WriteLine(output.ToString().TrimEnd());
    }





}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> arr = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        Result.countSort(arr);
    }
}
