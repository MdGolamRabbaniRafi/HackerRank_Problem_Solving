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
     * Complete the 'insertionSort' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    /*  public static int insertionSort(List<int> arr)
      {
          /*int count = 0;
          for(int i=0;i<arr.Count;i++)
          {
              for (int j = 0; j < arr.Count-1; j++)
              {
                  if (arr[j] > arr[j+1])
                  {
                      int temp = arr[j];
                      arr[j] = arr[j + 1];
                      arr[j + 1] = temp;
                      count++;
                  }
              }

          }*///Time limit problem
    /* int count = 0;
     for (int i = 1; i < arr.Count; i++)
     {
         int key = arr[i];
         int j = i - 1;
         while (j >= 0 && arr[j] > key)
         {
             arr[j + 1] = arr[j];
             j--;
             count++;
         }
         arr[j + 1] = key;
     }*///time complexity problem
    /*  List<int> result = new List<int>(arr);
      int items = arr.Count;
      int index = 0;
      int count = 0;
      while(items>0)
      {
          int min=result.Min();
          int minIndex=arr.IndexOf(min);
          count += Math.Abs(index - minIndex);
          arr.Remove(min);
          items--;
          index++;
      }
     return count;
  }*/
    public static int insertionSort(List<int> arr)
    {
        int len = arr.Count;
        if (len <= 1) return 0;

        int mid = len / 2;
        List<int> arrL = arr.GetRange(0, mid);
        List<int> arrR = arr.GetRange(mid, len - mid);

        int ret = insertionSort(arrL) + insertionSort(arrR);

        int i = 0;
        int l = 0;
        int r = 0;

        while (l < arrL.Count && r < arrR.Count)
        {
            if (arrL[l] <= arrR[r])
            {
                arr[i++] = arrL[l++];
            }
            else
            {
                arr[i++] = arrR[r++];
                ret += mid - l;
            }
        }

        while (l < arrL.Count)
        {
            arr[i++] = arrL[l++];
        }

        while (r < arrR.Count)
        {
            arr[i++] = arrR[r++];
        }
        Console.WriteLine("ret:" + ret);

        return ret;
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.insertionSort(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}




//https://www.hackerrank.com/challenges/insertion-sort/problem?isFullScreen=true