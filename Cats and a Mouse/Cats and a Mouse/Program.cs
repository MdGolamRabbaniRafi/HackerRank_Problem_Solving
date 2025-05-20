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

    // Complete the catAndMouse function below.
    static string catAndMouse(int x, int y, int z)
    {

        if(Math.Abs(x-z)==Math.Abs(y-z))
        {
            return "Mouse C";
        }
        else if(Math.Abs(x - z) < Math.Abs(y - z))
        {
            return "Cat A";
        }
        else if (Math.Abs(x - z) > Math.Abs(y - z))
        {
            return "Cat B";
        }
        return "";

    }

    static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] xyz = Console.ReadLine().Split(' ');

            int x = Convert.ToInt32(xyz[0]);

            int y = Convert.ToInt32(xyz[1]);

            int z = Convert.ToInt32(xyz[2]);

            string result = catAndMouse(x, y, z);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

//https://www.hackerrank.com/challenges/cats-and-a-mouse/problem?isFullScreen=true