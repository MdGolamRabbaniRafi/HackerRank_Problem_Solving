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
     * Complete the 'acmTeam' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY topic as parameter.
     */
    static int BooleanAddition(string str1, string str2)
    {
        // Ensure both strings are of the same length
        if (str1.Length != str2.Length)
        {
            throw new ArgumentException("Binary strings must be of the same length.");
        }

        // Perform boolean addition (bitwise OR)
        char[] result = new char[str1.Length];
        int count = 0;

        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] == '1' || str2[i] == '1')
            {
                result[i] = '1';
            }
            else
            {
                result[i] = '0';
            }
            if (str1[i] == '1' || str2[i]=='1')
            {
          //      Console.WriteLine("str1["+i+"]:" + str1[i] + " str2["+i+"]:" + str2[i]);
                count++;
            }
        }

        return count;
    }
    public static List<int> acmTeam(List<string> topic)
    {
        List<int> result = new List<int>();
        int row =topic.Count;
        int count = 0;
        int ResultCount = 0;
        for (int i = 0; i < topic.Count; i++)
        {
            for (int j = i + 1; j < topic.Count; j++)
            {
                string cleanString = topic[i].Trim().Replace("\n", "").Replace("\r", "").Replace(" ", "");
                string cleanString2 = topic[j].Trim().Replace("\n", "").Replace("\r", "").Replace(" ", "");

                // Perform boolean addition for topic[i] and topic[j]
                int Result = BooleanAddition(cleanString, cleanString2);
                if(count<Result)
                {
                    ResultCount = 0;
                    count = Result;
                }
                if(count==Result && count!=0)
                {
                    ResultCount++;
                }
                if(count==0)
                {
                    ResultCount = 0;
                }
             //   Console.WriteLine($"Boolean addition of topic[{i}] and topic[{j}] = {Result}");
            }
        }
        // Console.WriteLine("Count:" + count + " ResultCount:" + ResultCount);

        /*  for (int i = 0; i < topic.Count; i++)
          {
              // Log the raw string
              Console.WriteLine("Raw string: [" + topic[i] + "]");

              // Clean the string by trimming and removing unwanted characters
              string cleanString = topic[i].Trim().Replace("\n", "").Replace("\r", "").Replace(" ", "");

              // Convert to character array
              char[] chars = cleanString.ToCharArray();

              // Log the cleaned string and its length
              Console.WriteLine("Cleaned string: [" + cleanString + "] with length: " + chars.Length);

              for (int j = 0; j < chars.Length; j++)
              {
                  if (chars[j] == '1')
                  {
                      Console.WriteLine("(" + i + "," + j + ")");
                  }
              }
          }*/

        result.Add(count);
        result.Add(ResultCount);





        return result;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            // Your code logic here
        


        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<string> topic = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string topicItem = Console.ReadLine();
            topic.Add(topicItem);
        }

        List<int> result = Result.acmTeam(topic);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/acm-icpc-team/problem?isFullScreen=true
