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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {
        string[] hour = ["one", "two", "three", "four","five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"];
        string[] tenMin = ["", "","twenty", "thirty", "fourty", "fifty"];
        string time = "";
        string finalHour = "";
        string finalMin = "";

        string Hour = hour[h - 1];
        string NextHour= hour[h];
        int n = m;
        if (m > 30)
        {
            finalHour = " to "+NextHour;
            n = 60 - m;
        }
        else
        {
            finalHour = " past "+Hour;

        }
        if(m==0)
        {
            Console.WriteLine(Hour + " o' clock");

            return Hour + " o' clock";
        }
        else if(m==30) {
            Console.WriteLine("half past " + Hour);

            return "half past " + Hour;

        }
        else if (m == 15)
        {
            Console.WriteLine("quarter past " + Hour);

            return "quarter past " + Hour;

        }
        else if(m==45)
        {
            Console.WriteLine("quarter to " + NextHour);

            return "quarter to " + NextHour;
        }
        int dividant = n / 10;
        int reminder =n% 10;



        if(dividant>1)
        {
            if(reminder!=0)
            {
                finalMin =  tenMin[dividant]+' '+hour[reminder-1]+" minutes";
            }
            else
            {
                finalMin = tenMin[dividant]+ " minutes";
            }
        }
        else if(n<20)
        {
            if(n<10)
            {
                if(m>30)
                {
                    finalMin = hour[n - 1] + " minutes";

                }
                else
                {
                    finalMin = hour[n - 1] + " minute";
                }

            }
            else
            {
                finalMin = hour[n - 1] + " minutes";

            }

        }
        time = finalMin + finalHour;
        Console.WriteLine (time);
        return time;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}


//https://www.hackerrank.com/challenges/the-time-in-words/problem?isFullScreen=true