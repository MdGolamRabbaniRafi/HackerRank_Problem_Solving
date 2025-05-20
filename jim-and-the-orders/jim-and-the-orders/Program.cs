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
     * Complete the 'jimOrders' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts 2D_INTEGER_ARRAY orders as parameter.
     */
    public static void sort(List<List<int>> arr)
    {
        for (int i = 0;i<arr.Count-1;i++)
        {
            for (int j = 0; j < arr.Count - 1; j++)
            {
                if (arr[j][1] > arr[j + 1][1])
                {
                    var temp= arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
                else if(arr[j][1] == arr[j + 1][1] && arr[j][0] > arr[j + 1][0])
                {
                    var temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    public static List<int> jimOrders(List<List<int>> orders)
    {
        List<int> result = new List<int>();
        List<List<int>> serveTimeOfCustomer = new List<List<int>>();
        for(int i=0;i<orders.Count;i++)
        {
            List<int> result2 = new List<int>();
            result2.Add(i+1);
            result2.Add(orders[i][0] + orders[i][1]);
            serveTimeOfCustomer.Add(result2);

        }
        sort(serveTimeOfCustomer);
        for(int i = 0; i < serveTimeOfCustomer.Count; i++)
        {
            result.Add(serveTimeOfCustomer[i][0]);
        }
        foreach(int r in result)
        {
            Console.Write(r+" ");
        }



        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> orders = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            orders.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ordersTemp => Convert.ToInt32(ordersTemp)).ToList());
        }

        List<int> result = Result.jimOrders(orders);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/jim-and-the-orders/problem?isFullScreen=true