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
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    /* public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
     {
         // Remove duplicates from the ranked list
       /*  List<int> result = ranked.Distinct().ToList();
         List<int> ranks = new List<int>();

         // Traverse player scores
         for (int i = 0; i < player.Count; i++)
         {
             int playerScore = player[i];
             if (playerScore >= result[0])
             {
                 ranks.Add(1);
             }
             else if (playerScore < result[result.Count - 1])
             {
                 ranks.Add(result.Count + 1);
             }
             else
             {
                 int rank = result.Count + 1; 
                 for (int j = result.Count - 1; j >= 0; j--)
                 {
                     if (playerScore < result[j])
                     {
                         rank = j + 2; 
                         break;
                     }
                 }
                 ranks.Add(rank);
             }
         }

         return ranks; //time lmit problem

     }*/
    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        List<int> result = ranked.Distinct().ToList();
        List<int> ranks = new List<int>();

        int rankIndex = result.Count - 1;

        for (int i = 0; i < player.Count; i++)
        {
            int playerScore = player[i];

            while (rankIndex >= 0 && playerScore >= result[rankIndex])
            {
                rankIndex--;
            }
            ranks.Add(rankIndex + 2);
        }

        return ranks;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "output.txt";
        TextWriter textWriter = new StreamWriter(outputPath, true);
        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem?isFullScreen=true#!