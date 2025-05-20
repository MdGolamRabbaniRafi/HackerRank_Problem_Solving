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

    // Complete the getMinimumCost function below.
    static void BubbleSortDescending(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] < arr[j + 1]) // Change the comparison for descending order
                {
                    // Swap arr[j] and arr[j + 1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    static int getMinimumCost(int k, int[] c)
    {
        BubbleSortDescending(c);

        int priceMultiplication = 1;
        int count = 0;
        int totalPrice = 0;
        
        while(count<c.Length)
        {

            if ((count+1)%k==0)
            {
                totalPrice = totalPrice + c[count] * priceMultiplication;
                count++;

                priceMultiplication++;
                continue;
            }

            totalPrice = totalPrice + c[count]* priceMultiplication;
          //  Console.WriteLine("count:" + count);

          //  Console.WriteLine("priceMultiplication:" + priceMultiplication);
           // Console.WriteLine("c[count]* priceMultiplication:" + c[count] * priceMultiplication);

            count++;
        }
      //  Console.WriteLine("count:"+count);
       // Console.WriteLine("priceMultiplication:" + priceMultiplication);


        Console.WriteLine("totalPrice:"+totalPrice);
        return totalPrice;


    }

    static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int minimumCost = getMinimumCost(k, c);

        textWriter.WriteLine(minimumCost);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/greedy-florist/problem?isFullScreen=true