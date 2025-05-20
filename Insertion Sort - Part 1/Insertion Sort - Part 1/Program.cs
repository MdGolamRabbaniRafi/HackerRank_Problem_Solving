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
     * Complete the 'insertionSort1' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */
    public static void PrintArray(List<int> arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }

    public static void insertionSort1(int n, List<int> arr)
    {
        int lastElement = arr[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            //Console.WriteLine("i:" + i);
            //Console.WriteLine("i+1:" + (i + 1));
            //Console.WriteLine("arr[i] > lastElement:" + (arr[i] > lastElement));
            if (arr[i] > lastElement)
            {

                //Console.WriteLine("arr[i + 1]:" + arr[i + 1]);
                //Console.WriteLine("arr[i]:"+arr[i]);
                arr[i + 1] = arr[i];
                PrintArray(arr);
            }
            else
            {
               // Console.WriteLine("arr[i + 1]:"+arr[i + 1]);
                arr[i + 1] = lastElement;
                PrintArray(arr);
                return;
            }
            if (arr[0] == arr[1])
            {
                arr[0] = lastElement;
                PrintArray(arr);
            }

        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.insertionSort1(n, arr);
    }
}



//https://www.hackerrank.com/challenges/insertionsort1/problem?isFullScreen=true
