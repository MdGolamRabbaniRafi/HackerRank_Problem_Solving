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
     * Complete the 'taumBday' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER b
     *  2. INTEGER w
     *  3. INTEGER bc
     *  4. INTEGER wc
     *  5. INTEGER z
     */

    public static long taumBday(int b, int w, int bc, int wc, int z)
    {
        long result = 0;

        // Calculate the direct cost of buying all black and white gifts
        long directCost = (long)b * bc + (long)w * wc;

        // Check if converting black gifts to white is cheaper
        if (bc > wc + z)
        {
            // If converting is cheaper, calculate cost of buying white gifts and converting black to white
            result = (long)w * wc + (long)b * (wc + z);
        }
        // Check if converting white gifts to black is cheaper
        else if (wc > bc + z)
        {
            // If converting is cheaper, calculate cost of buying black gifts and converting white to black
            result = (long)b * bc + (long)w * (bc + z);
        }
        else
        {
            // If direct buying is cheapest or if both conversion costs are equal
            result = directCost;
        }

        return result;
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
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int b = Convert.ToInt32(firstMultipleInput[0]);

            int w = Convert.ToInt32(firstMultipleInput[1]);

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int bc = Convert.ToInt32(secondMultipleInput[0]);

            int wc = Convert.ToInt32(secondMultipleInput[1]);

            int? z = null; // Nullable int

            // Check if the third input is present
            if (secondMultipleInput.Length > 2 && !string.IsNullOrWhiteSpace(secondMultipleInput[2]))
            {
                z = Convert.ToInt32(secondMultipleInput[2]); // Assign value to z if present
            }

            // If z is null, set it to 0
            int zValue = z ?? 0;

            long result = Result.taumBday(b, w, bc, wc, zValue);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}





//https://www.hackerrank.com/challenges/taum-and-bday/problem?isFullScreen=true
