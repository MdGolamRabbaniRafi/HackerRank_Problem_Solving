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
using System.Runtime.InteropServices;

class Result
{

    /*
     * Complete the 'almostSorted' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    public static bool IsSorted(List<int>arr)
    {
        for (int i = 0;i<arr.Count-1;i++)
        {
            if (arr[i] > arr[i+1])
            {
                return false;
            }
        }
        return true;
    }
    public static void swap(int a,int b, List<int> arr)
    {
      //  Console.WriteLine($"a:{a} b:{b}");
        int temp = arr[a];
      //  Console.WriteLine($"a:{a} b:{b} arr[a]:{arr[a]} temp:{temp}");
        arr[a] =arr[b];
      //  Console.WriteLine($"a:{a} b:{b} arr[a]:{arr[a]} arr[b]:{arr[b]} temp:{temp}");
        arr[b]=temp;
      //  Console.WriteLine($"a:{a} b:{b} arr[a]:{arr[a]} arr[b]:{arr[b]} temp:{temp}");
    }
    public static bool IsReversePossible(List<int> arr)
    {
        for (int i = 0; i < arr.Count - 1; i++)
        {
            if (arr[i+1] != arr[i]+1)
            {
                return false;
            }
        }
        return true;
    }
    public static void Reverse(int startIndex,int endIndex,List<int>arr)
    {
        Console.WriteLine($"startIndex:{startIndex} endIndex:{endIndex}");
        int i=startIndex;
        int j=endIndex;
        while(i<j)
        {
            swap(i, j, arr);
            i++;
            j--;
        }
    }
    public static void almostSorted(List<int> arr)
    {
       // int unSortedIndexStarted;
       List<int> unSortedIndexStarted= new List<int>();
        if (IsSorted(arr))
        {
            Console.WriteLine("yes");
        }
        else
        {
            for(int i=0;i<arr.Count-1;i++)
            {
                if(i==0&&arr[i] > arr[i + 1])
                {
                    unSortedIndexStarted.Add(i);
                    continue;
                }
                if ((arr[i] > arr[i + 1]))
                {
                    if (unSortedIndexStarted.Count == 0)
                    {
                        unSortedIndexStarted.Add(i);
                    }
                   /* else if (arr[i] < arr[i - 1] && arr[unSortedIndexStarted[0]] > arr[i])
                    {
                        unSortedIndexStarted.Add(i);
                    }
                    else 
                    if (arr[i]> arr[i - 1]&& arr[unSortedIndexStarted[0]] > arr[i+1])
                    {
                        if (!unSortedIndexStarted.Contains(i + 1))
                        {
                            unSortedIndexStarted.Add(i + 1);
                        }

                    }*/
                   if(unSortedIndexStarted.Count != 0)
                    {
                        unSortedIndexStarted.Add(i+1);
                    }

                }
            }
        }
        if(unSortedIndexStarted.Count==1)
        {
            for (int i = 0; i < unSortedIndexStarted.Count; i++)
            {
               // Console.WriteLine("count=1:"+unSortedIndexStarted[i]);
            }
            if (unSortedIndexStarted[0]==0)
            {
                swap(0, 1, arr);
            }
            else if (unSortedIndexStarted[0]==arr.Count-2) {
                swap(arr.Count-1, arr.Count-2, arr);
            }
            if (IsSorted(arr))
            {
                Console.WriteLine("yes");
                Console.WriteLine($"swap {unSortedIndexStarted[0]+1} {unSortedIndexStarted[0] + 2}");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        else if(unSortedIndexStarted.Count == 2)
        {
            for (int i=0;i<unSortedIndexStarted.Count;i++)
            {
              //  Console.WriteLine("count=2:" + unSortedIndexStarted[i]);
            }

            swap(unSortedIndexStarted[0], unSortedIndexStarted[1], arr);
            if (IsSorted(arr))
            {
                Console.WriteLine("yes");
                Console.WriteLine($"swap {unSortedIndexStarted[0]+1} {unSortedIndexStarted[1]+1}");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        else if (unSortedIndexStarted.Count == 3)
        {
            for (int i = 0; i < unSortedIndexStarted.Count; i++)
            {
              //  Console.WriteLine("count=3:" + unSortedIndexStarted[i]);
            }

            swap(unSortedIndexStarted[0], unSortedIndexStarted[2], arr);
            if (IsSorted(arr))
            {
                Console.WriteLine("yes");
                Console.WriteLine($"swap {unSortedIndexStarted[0] + 1} {unSortedIndexStarted[2] + 1}");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        else if(unSortedIndexStarted.Count > 3)
        {
            for (int i = 0; i < unSortedIndexStarted.Count; i++)
            {
             //   Console.WriteLine("count>3:" + unSortedIndexStarted[i]);
            }
            if (IsReversePossible(unSortedIndexStarted))
            {
                Reverse(unSortedIndexStarted[0], unSortedIndexStarted[unSortedIndexStarted.Count-1],arr);
                if (IsSorted(arr))
                {
                    Console.WriteLine("yes");
                    Console.WriteLine($"reverse {unSortedIndexStarted[0] + 1} {unSortedIndexStarted[unSortedIndexStarted.Count - 1] + 1}");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
          //  else if()
            else
            {
                Console.WriteLine("no");
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

        Result.almostSorted(arr);
    }
}

//https://www.hackerrank.com/challenges/almost-sorted/problem?isFullScreen=true