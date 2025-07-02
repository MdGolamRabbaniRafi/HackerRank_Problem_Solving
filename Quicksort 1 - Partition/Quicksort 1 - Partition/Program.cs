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
     * Complete the 'quickSort' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> quickSort(List<int> arr)
    {
        int pivot = arr[0];
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        List<int> result = new List<int>();
        for (int i = 1; i < arr.Count; i++) {
            if (arr[i]>pivot)
            {
                //if(right!=null)
                //{
                    right.Add(arr[i]);
                    //int j = right.Count - 1;
                    for (int j2 = right.Count - 1; j2 > 0; j2--)
                    {
                        if (right[j2] < right[j2-1])
                        {
                            int temp = right[j2];
                            right[j2] = right[j2];
                            right[j2] = temp;
                        }
                    }


                //}

            }
            else
            {
                left.Add(arr[i]);
                for (int j2 = left.Count - 1; j2 > 0; j2--)
                {
                    if (left[j2] < left[j2 - 1])
                    {
                        int temp = left[j2];
                        left[j2] = left[j2];
                        left[j2] = temp;
                    }
                }

            }
        }

        foreach (int i in left)
        {
            result.Add(i);
        }
        result.Add((int)pivot);
        foreach(int i in right)
            { result.Add(i); }
        foreach (var item in result)
        {
            Console.WriteLine(item + " ");
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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.quickSort(arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
