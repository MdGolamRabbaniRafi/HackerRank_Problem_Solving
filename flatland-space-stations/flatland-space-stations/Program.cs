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

class Solution
{

    // Complete the flatlandSpaceStations function below.
    static int flatlandSpaceStations(int n, int[] c)
    {
        int max = 0;
        int miniDistance;
        Array.Sort(c);
        HashSet<int> stations = new HashSet<int>(c);


        for (int i = 0; i < n; i++)
        {
            if (stations.Contains(i)) // Skip if there's a station
            {
                continue;
            }
            miniDistance = int.MaxValue; // Reset for each city
                                         //    int mid = c.Count() / 2;

            int left = 0;
            int right = c.Length - 1;
            while (right>=left)
            {
                int mid = left + (right - left) / 2;
                if (c[mid]>i)
                {
                    right = mid - 1;
                }
                if (c[mid]<i)
                {
                    left = mid + 1;
                }
              //  mid = (right / left) / 2;
            }
            if (left < c.Length)
            {
                miniDistance = Math.Min(miniDistance, Math.Abs(c[left] - i));
            }
            if (right >= 0)
            {
                miniDistance = Math.Min(miniDistance, Math.Abs(c[right] - i));
            }
           // miniDistance = Math.Min(Math.Abs(i - c[left]), Math.Abs(i - c[right]));



            /*  for (int j = 0; j < c.Length; j++)
              {
                  miniDistance = Math.Min(miniDistance, Math.Abs(i - c[j]));


                  if (miniDistance == 0)
                  {
                      break;
                  }


              }*/


            max = Math.Max(max, miniDistance);
         //   Console.WriteLine($"i: {i}, miniDistance: {miniDistance}, max: {max}");
        }

        Console.WriteLine(max);


        return max;
    }

    static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = flatlandSpaceStations(n, c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
