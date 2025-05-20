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
     * Complete the 'maximumPeople' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. LONG_INTEGER_ARRAY p
     *  2. LONG_INTEGER_ARRAY x
     *  3. LONG_INTEGER_ARRAY y
     *  4. LONG_INTEGER_ARRAY r
     */

  /*  public static long maximumPeople(List<long> p, List<long> x, List<long> y, List<long> r)
    {
        // Track cloud ranges
        List<List<long>> cloudRange = new List<List<long>>();
        List<List<long>> LocationCoverage = new List<List<long>>();
        long count = 0;
        long sunny = 0;

        // Calculate the range for each cloud
        for (int i = 0; i < y.Count; i++)
        {
            List<long> ranges = new List<long> { y[i] - r[i], y[i] + r[i] };
            cloudRange.Add(ranges);
        }

        // Determine coverage for each town
        for (int i = 0; i < x.Count; i++)
        {
            List<long> coverage = new List<long> { i };
            bool isCovered = false;

            for (int j = 0; j < cloudRange.Count; j++)
            {
                if (x[i] >= cloudRange[j][0] && x[i] <= cloudRange[j][1])
                {
                    coverage.Add(j); // Add cloud index
                    isCovered = true;
                }
            }

            if (isCovered)
            {
                LocationCoverage.Add(coverage);
            }
            else
            {
                sunny += p[i]; // Population of always sunny towns
            }
        }

        // List to accumulate populations uniquely covered by each cloud
        long[] cloudCoveragePopulation = new long[y.Count];

        // Populate cloudCoveragePopulation for each town covered by only one cloud
        for (int i = 0; i < LocationCoverage.Count; i++)
        {
            if (LocationCoverage[i].Count == 2) // Only one cloud covers this town
            {
                int townIndex = (int)LocationCoverage[i][0];
                int cloudIndex = (int)LocationCoverage[i][1];

                // Add this town's population to the cloud's unique coverage
                cloudCoveragePopulation[cloudIndex] += p[townIndex];
            }
        }

        // Find the maximum population uniquely covered by removing one cloud
        for (int i = 0; i < cloudCoveragePopulation.Length; i++)
        {
            if (cloudCoveragePopulation[i] > count)
            {
                count = cloudCoveragePopulation[i];
            }
        }

        Console.WriteLine("count: " + count);
        Console.WriteLine("result: " + (sunny + count));

        return (sunny + count);
    }*///time limit problem
    Unsolved

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> p = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pTemp => Convert.ToInt64(pTemp)).ToList();

        List<long> x = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(xTemp => Convert.ToInt64(xTemp)).ToList();

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> y = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(yTemp => Convert.ToInt64(yTemp)).ToList();

        List<long> r = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rTemp => Convert.ToInt64(rTemp)).ToList();

        long result = Result.maximumPeople(p, x, y, r);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/cloudy-day/problem?isFullScreen=true