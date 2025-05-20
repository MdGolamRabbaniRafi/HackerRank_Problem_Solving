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
     * Complete the 'surfaceArea' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY A as parameter.
     */

    public static int surfaceArea(List<List<int>> A)
    {
        int height=A.Count; 
        int width = A[0].Count;
        int count=2*height*width;
        for (int i=0;i<A.Count;i++)
        {
            for(int j = 0; j < A[i].Count;j++)
            {
             //   count += A[i][j];

                if(j==0)
                {
                    count = count+ A[i][j];
                }
                else
                {
                    count =count+ Math.Max(0,A[i][j] - A[i][j - 1]);
                }
                if(j==width-1)
                {
                    count = count + A[i][j];
                }
                else
                {
                    count = count + Math.Max(0, A[i][j] - A[i][j + 1]);
                }

                if (i == 0)
                {
                    count = count + A[i][j];
                }
                else
                {
                    count = count + Math.Max(0,A[i][j] - A[i - 1][j]);
                }
                 if(i==height-1)
                {
                    count = count + A[i][j];
                }
                 else
                {
                    count = count + Math.Max(0, A[i][j] - A[i + 1][j]);

                }

                // count=count+topToRightDif+RightToLeftDif;
            }
        }
        Console.WriteLine(count);

        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int H = Convert.ToInt32(firstMultipleInput[0]);

        int W = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
        }

        int result = Result.surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//