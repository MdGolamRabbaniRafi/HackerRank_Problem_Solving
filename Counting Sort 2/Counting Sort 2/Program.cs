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
     * Complete the 'countingSort' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> countingSort(List<int> arr)
    {
        int max = arr.Max();  // optional for later sorting logic'
        Console.WriteLine("max:" + max);
        List<int> countArr = Enumerable.Repeat(0, 100).ToList();
        List<int> result = new List<int>();
        foreach (int i in arr)
        {
            countArr[i] = countArr[i] + 1;
        }
        foreach (int i in countArr)
        {
            //countArr[i] = countArr[i] + 1;
            Console.Write(i + " ");
        }

        for (int i = 0; i < countArr.Count; i++)
        {

            //int index = i;
            //int indexValue = countArr[i];
            //for (int j = index; j > 0; j--)
            //{
            //    countArr[j] = indexValue;
            //    //  countArr[index - j] = indexValue;
            //}
            if (countArr[i]!=0)
            {
                for(int j=0;j<countArr[i];j++)
                {
                    result.Add(i);

                }
            }
        }
        Console.WriteLine("countArr:" + countArr.Count);


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

        List<int> result = Result.countingSort(arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
