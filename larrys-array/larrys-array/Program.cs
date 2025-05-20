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
     * Complete the 'larrysArray' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY A as parameter.
     */
   /* public static bool IsArraySorted(List<int> arr)
    {
        for (int i = 0; i < arr.Count - 1; i++)
        {
            if (arr[i] != arr[i + 1] - 1)
            {
                return false;  
            }
        }
        return true;  
    }*/
    public static void swap(int a,int b,int c, List<int> A)
    {
        int temp = A[a];
        A[a]=A[b];
        A[b]=A[c];
        A[c]=temp;

    }

    public static string larrysArray(List<int> A)
    {

        int minimum = A.Min();
        int maximum = A.Max();
        for(int i=0;i<A.Count-2;i++)
        {
            if(minimum==maximum)
            {
                break;
            }
            if (A[i]==minimum)
            {
                minimum++;

                continue;

            }
            else if (A[i+1]==minimum)
            {
                swap(i, i + 1, i + 2,A);
                minimum++;

                continue;
            }
            for (int j=i+2;j<A.Count;j++)
            {
                if (A[j]==minimum)
                {
                    int index = j;
                    while(index!=i)
                    {
                       if(index-2==i)
                        {
                            swap(index - 2, index - 1, index, A);
                            swap(index - 2, index - 1, index, A);
                            break;

                        }
                       if(index-1==i)
                        {
                            swap(index - 1, index, index+1, A);
                            break ;

                        }
                        swap(index - 2, index - 1, index, A);
                        index--;
                    }
                   
                }
            }
            minimum++;
        }
        foreach(int i in A)
        {
            Console.Write(i + " ");
        }
        if (A[A.Count -1]==maximum)
        {
            Console.WriteLine("YES");
            return "YES";
        }
        Console.WriteLine("NO");
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

            string result = Result.larrysArray(A);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/larrys-array/problem?isFullScreen=true