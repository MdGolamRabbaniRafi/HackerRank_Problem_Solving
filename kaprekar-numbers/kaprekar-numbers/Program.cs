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
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER q
     */

    public static void kaprekarNumbers(int p, int q)
    {
        bool check = false;
        for(int i=p;i<=q;i++)
        {
            long j = i;
            string s = (j*j).ToString();
            int middle = 0;

                middle = s.Length / 2;
            
            string part1 = s.Substring(0, middle); // From the start to index (not inclusive)
            string part2 = s.Substring(middle);
            /* Console.WriteLine("i:" + i);
             Console.WriteLine("middle:" + middle);
             Console.WriteLine("s.length/2:"+ s.Length / 2);
             Console.WriteLine("part1:"+part1);
             Console.WriteLine("part2:" + part2);*/
            long num1 = string.IsNullOrEmpty(part1) ? 0 : long.Parse(part1);
            long num2 = string.IsNullOrEmpty(part2) ? 0 : long.Parse(part2);

            long result = num1 + num2;
           // Console.WriteLine("result:" + result);

            if (result==i)
            {
                Console.Write(i);
                Console.Write(" ");
                check= true;
            }


        }
        if(!check)
        {
            Console.WriteLine("INVALID RANGE");
        }

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Result.kaprekarNumbers(p, q);
    }
}





//https://www.hackerrank.com/challenges/kaprekar-numbers/problem?isFullScreen=true