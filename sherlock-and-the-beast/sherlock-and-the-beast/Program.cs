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
     * Complete the 'decentNumber' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void decentNumber(int n)
    {
       // int fiveMul = 5;

        if(n%3==0)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("5");
            }
            Console.WriteLine();
        }
        else
        {
            // int HalfN = n / 2;
            int countThree = 0;
            int countFive = 0;
            int N = n;
            while(N>=3)
            {
                if(N%3==0)
                {
                    countThree = N;
                    countFive = n-N;
                    Console.WriteLine(N);

                    Console.WriteLine(countThree);

                    Console.WriteLine(countFive);
                    break;
                }
                N = N - 5;
            }
            if(countFive!=0&&countThree!=0)
            {
                for (int i = 0; i < countThree; i++)
                {
                    Console.Write("5");
                }
                for (int i = 0; i < countFive; i++)
                {
                    Console.Write("3");
                }
                Console.WriteLine();
            }
            else
            {
              //   countThree = 0;
               //  countFive = 0;
                N = n;
                while (N >= 5)
                {
                    if (N % 5 == 0)
                    {
                         countFive = N;
                         countThree = n - N;
                       // Console.WriteLine(N);

                      //  Console.WriteLine(countThree);

                      //  Console.WriteLine(countFive);
                        break;
                    }
                    N = N - 3;
                }
                if (countFive != 0 && countThree != 0)
                {
                    for (int i = 0; i < countThree; i++)
                    {
                        Console.Write("5");
                    }
                    for (int i = 0; i < countFive; i++)
                    {
                        Console.Write("3");
                    }
                    Console.WriteLine();
                }
                else if (n % 5 == 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("3");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("-1");
                }

            }



        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            Result.decentNumber(n);
        }
    }
}
//https://www.hackerrank.com/challenges/sherlock-and-the-beast/problem?isFullScreen=true