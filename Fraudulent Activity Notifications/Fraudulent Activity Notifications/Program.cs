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
     * Complete the 'activityNotifications' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY expenditure
     *  2. INTEGER d
     */

    /*public static int activityNotifications(List<int> expenditure, int d)
    {
        int notice = 0;
        int i = 0;
        while (i < expenditure.Count)
        {
           // int j = i;
            List<int> result= new List<int>();
            for (int j = i; j < Math.Min(i + d, expenditure.Count); j++)
            {
                result.Add(expenditure[j]);
            }
            result.Sort();
            double median = 0;
            if(result.Count%2!=0)
            {
                median = result[result.Count/2];
            }
            else
            {
                median = (double)((result[result.Count/2]+result[(result.Count/2)-1]))/2;
            }
            if (i + d >= expenditure.Count) // Prevent accessing out-of-bounds index
            {
                break;
            }

            if (expenditure[i + d] >= (2 * median))
            {
                notice++;
            }
            i++;

        }
        
        return notice;
    }*///time complecity problem
    public static int activityNotifications(List<int> expenditure, int d)
    {
        int notice = 0;
        int[] freq = new int[201]; 
        for (int i = 0; i < d; i++)
        {
            freq[expenditure[i]]++;
        }

        double GetMedian(int[] freq, int d)
        {
            int count = 0;
            if (d % 2 != 0)
            {
                for (int i = 0; i < freq.Length; i++)
                {
                    count += freq[i];
                    if (count > d / 2)
                    {
                        return i;
                    }
                }
            }
            else
            {
                int first = -1, second = -1;
                for (int i = 0; i < freq.Length; i++)
                {
                    count += freq[i];
                    if (first == -1 && count >= d / 2)
                    {
                        first = i;
                    }
                    if (count >= (d / 2) + 1)
                    {
                        second = i;
                        return (first + second) / 2.0;
                    }
                }
            }
            return 0; 
        }

        for (int i = d; i < expenditure.Count; i++)
        {
            double median = GetMedian(freq, d);

            if (expenditure[i] >= 2 * median)
            {
                notice++;
            }

            freq[expenditure[i]]++;
            freq[expenditure[i - d]]--; 
        }

        return notice;
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

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

        int result = Result.activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}



//https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem?isFullScreen=true