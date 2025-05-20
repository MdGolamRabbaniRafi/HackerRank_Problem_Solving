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
     * Complete the 'organizingContainers' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts 2D_INTEGER_ARRAY container as parameter.
     */
    

    public static string organizingContainers(List<List<int>> container)
    {
        List<long> row= new List<long>();
        List<long> col = new List<long>();

        foreach (List<int> con in container)
        {
            row.Add(con.Sum(x => (long)x));
        }
        for(int i=0;i<container.Count;i++)
        {
            long count = 0;
            for (int j = 0; j < container.Count; j++)
            {
                count +=(long) container[j][i];
            }
            col.Add(count);

        }
        row.Sort();
        col.Sort();

        for(int i = 0; i < row.Count; i++)
        {
            if (row[i] != col[i])
            {
               return "Impossible";
            }
        }




        return "Possible";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Result.organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}





//https://www.hackerrank.com/challenges/organizing-containers-of-balls/problem?isFullScreen=true
