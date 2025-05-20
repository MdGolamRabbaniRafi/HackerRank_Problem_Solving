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
     * Complete the 'reverseShuffleMerge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */
    public static string Swap(string s, int a, int b)
    {
        char[] chars = s.ToCharArray();
        char temp = chars[a];
        chars[a] = chars[b];
        chars[b] = temp;
        return new string(chars);
    }

    /*  public static List<string> Shuffle(string s)
      {
          string s3 = s;
          List<string> result = new List<string>();
          result.Add(s3);
          for (int i = 0;i<s.Length;i++)
          {
              for(int j=0;j<s.Length;j++)
              {
                  string s4= Swap(s3, j, i);
                  if(!result.Contains(s4))
                  {
                      result.Add(s4);
                  }



              }
            //  result.Add(s2);
          }
          return result;
      }*/
    public static string reverseShuffleMerge(string s)
    {
        List<char> chars = s.ToList();
        List<char> UnusedChar = new List<char>();
        List<int> UnusedCharInt = new List<int>();
        List<int> UsedCharInt = new List<int>();

        List<int> required = new List<int>();

        // Initial count setup
        for (int i = 0; i < chars.Count; i++)
        {
            if (!UnusedChar.Contains(chars[i]))
            {
                UnusedChar.Add(chars[i]);
                UnusedCharInt.Add(0);
                UsedCharInt.Add(0);
            }
            int index = UnusedChar.IndexOf(chars[i]);
            UnusedCharInt[index]++;
        }

        // Calculate required count
        for (int i = 0; i < UnusedChar.Count; i++)
        {
            required.Add(UnusedCharInt[i] / 2);
        }

        List<char> Newchars = new List<char>();
        Newchars.Add(chars[chars.Count - 1]);
        UnusedCharInt[UnusedChar.IndexOf(chars[chars.Count - 1])]--;
        UsedCharInt[UnusedChar.IndexOf(chars[chars.Count - 1])]++;

        // Modified loop
        for (int i = chars.Count - 2; i >= 0; i--)
        {
            int currentIndex = UnusedChar.IndexOf(chars[i]);

            // Check if we already have enough of this character in Newchars
            if (UsedCharInt[currentIndex] >= required[currentIndex])
            {
                UnusedCharInt[currentIndex]--;
                continue;
            }

            // Maintain lexicographic order with removal of larger characters
            while (Newchars.Count > 0 && chars[i] < Newchars[Newchars.Count - 1] &&
                   UsedCharInt[UnusedChar.IndexOf(Newchars[Newchars.Count - 1])] + UnusedCharInt[UnusedChar.IndexOf(Newchars[Newchars.Count - 1])] - 1 >= required[UnusedChar.IndexOf(Newchars[Newchars.Count - 1])])
            {
                char removedChar = Newchars[Newchars.Count - 1];
                Newchars.RemoveAt(Newchars.Count - 1);
                UsedCharInt[UnusedChar.IndexOf(removedChar)]--;
            }

            // Add the character to Newchars
            Newchars.Add(chars[i]);
            UsedCharInt[currentIndex]++;
            UnusedCharInt[currentIndex]--;
        }

        string result = new string(Newchars.ToArray());
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
        string s = Console.ReadLine();

        string result = Result.reverseShuffleMerge(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

//https://www.hackerrank.com/challenges/reverse-shuffle-merge/problem?isFullScreen=true