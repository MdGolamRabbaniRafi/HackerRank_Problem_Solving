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
     * Complete the 'gradingStudents' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY grades as parameter.
     */

    public static List<int> gradingStudents(List<int> grades)
    {
        List<int> newgrades = new List<int>();

        int count = 0;
        foreach (int g in grades)
        {
           

                int a = g;
                for (int i = 0; i < 3; i++)
                {
                    a++;
                    count++;
                    if (a % 5 == 0)
                    {
                      //  Console.WriteLine("a:" + a + " g:" +g+ " count:" + count);
                        break;
                    }

                }
                if (count < 3 && a>=40)
                {
                    newgrades.Add(a);
                    count = 0;
                }
                else
                {
                    newgrades.Add(g);
                    count = 0;
                }
            
        }
        return newgrades;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        List<int> result = Result.gradingStudents(grades);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}



//https://www.hackerrank.com/challenges/grading/problem?isFullScreen=true