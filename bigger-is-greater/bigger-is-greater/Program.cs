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
using System.Runtime.InteropServices;

class Result
{

    /*
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */
    public static void swap(char[] ch, int i, int j)
    {
        char temp = ch[i];
        ch[i]= ch[j];
        ch[j]= temp;
    }
    public static string biggerIsGreater(string w)
    {
        char[] ch = w.ToCharArray();
        int smaller = -1;
        int found=-1;
        for(int i=ch.Length-2;i>=0;i--)
        {
            if (ch[i] < ch[i+1])
            {
                found = i;
                break;
            }
        }
        if(found==-1)
        {
            return "no answer";
        }

        for (int i=ch.Length-1;i>=found+1;i--)
        {

            if (ch[i] > ch[found] && (smaller == -1 || ch[i] < ch[smaller]))
            {
                //Console.WriteLine("ch[found]:" + ch[found] + " ch[i]:" + ch[i]);

                smaller = i;
            }
        }
       // Console.WriteLine("smaller:" + smaller + " found:" + found);
        swap(ch, found, smaller );
        foreach(char c in ch)
        {
            Console.Write(c);
        }
        Array.Reverse(ch, found + 1, ch.Length - (found + 1));
        string charsStr = new string(ch);
      //  Console.WriteLine("charsStr:" + charsStr);



        return charsStr;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);
            Console.WriteLine(result);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/bigger-is-greater/problem?isFullScreen=true