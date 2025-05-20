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
     * Complete the 'strangeCounter' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts LONG_INTEGER t as parameter.
     */

    public static long strangeCounter(long t)
    {
        /*  long count = 3;
         long i = count;
          long j = 1;
         while(j!=t)
         {
              if (i==1)
              {
                  count = count * 2;
                  i = count;
                  j++;
                  continue;

              }
              j++;
              i--;

          }
          return i;*///this is taking too much time.
      /*  long timer = 1;
        long value = 3;
        int i = 0;
        long nextTimer;
        while (timer!=t)
        {
            if(timer==t)
            {
                Console.WriteLine(value);
                return value;
            }
            nextTimer = timer+value;
           
            if(t<nextTimer&&t>timer)
            {
                long count = value;
                Console.WriteLine("count:"+count);

                for (long j=timer;j<nextTimer;j++)
                {
                    if(j==t)
                    {
                        Console.WriteLine("count:" + count+" j:"+j+" timer:"+timer+" nextTimer:"+nextTimer);

                        Console.WriteLine(count);
                        return count;
                    }
                    count--;


                }


            }
            
            value = value * 2;
            timer= nextTimer;

        }
        Console.WriteLine(value);
        return value;*/
        long timer = 1;
        long value = 3;
        long result = 0;
        while (t >= timer+value)
        {
            timer = timer + value;
            value = value * 2;
        }
        result = value+timer-t;
        Console.WriteLine(result);
        return result;


     
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        long t = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.strangeCounter(t);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/strange-code/problem?isFullScreen=true