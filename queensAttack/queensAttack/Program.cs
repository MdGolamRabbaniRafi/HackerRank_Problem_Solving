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
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

 /*   public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        int RQ = r_q;
        int CQ = c_q;
        int count = 0;
        bool check = false;
        for (int i = RQ-1;i>=1;i--)
        {
            if(CQ==n)
            {
                break;
            }
            CQ++;
            foreach (List<int> obs in obstacles)
            {
                if (obs[0] == i && obs[1]==CQ)
                {
                    check = true;
                    break;

                }
            }
            if(check)
            {
                break;
            }
            count++;
           // Console.WriteLine("(" + i + "," + CQ + ")");
        }
        check=false;
        CQ = c_q;

        for(int i=CQ-1;i>=1;i--)
        {
            if(RQ==n)
            {
                break;
            }
            RQ++;
            foreach (List<int> obs in obstacles)
            {
              //  Console.WriteLine("RQ:" + RQ + " obs[0]:" + obs[0] + " i:" + i + " obs[1]:" + obs[1]);
                if (obs[0] == RQ && obs[1] == i)
                {
                    check = true;

                    break;
                }
            }
            if (check)
            {
                break;
            }
            count++;

            //  Console.WriteLine("(" + RQ + "," + i + ")");

        }
        check = false;

        RQ = r_q;
        for(int i=RQ+1;i<=n;i++)
        {
            if(CQ==n)
            {
                break;
            }
            CQ++;
            foreach (List<int> obs in obstacles)
            {
                if (obs[0] == i && obs[1] == CQ)
                {
                    check = true;

                    break;
                }
            }
            if (check)
            {
                break;
            }
            count++;

            //  Console.WriteLine("(" + i + "," + CQ + ")");
        }
        check = false;

        CQ = c_q;
        for (int i = RQ - 1; i >=1; i--)
        {
            if (CQ == 1)
            {
                break;
            }
            CQ--;
            foreach (List<int> obs in obstacles)
            {
                if (obs[0] == i && obs[1] == CQ)
                {
                    check = true;

                    break;
                }
            }
            if (check)
            {
                break;
            }
            count++;

            // Console.WriteLine("(" + i + "," + CQ + ")");
        }
        check = false;

     //   Console.WriteLine("Up to Down");
        CQ=c_q;
        for(int i=RQ+1;i<=n;i++)
        {
            foreach (List<int> obs in obstacles)
            {
                if (obs[0] == i && obs[1] == CQ)
                {
                    check = true;

                    break;
                }
            }
            if (check)
            {
                break;
            }
            count++;

            //  Console.WriteLine("(" + i + "," + CQ + ")");
        }
        check = false;

        RQ = r_q;
        for (int i = RQ - 1; i >= 1; i--)
        {
            foreach (List<int> obs in obstacles)
            {
                if (obs[0] == i && obs[1] == CQ)
                {
                    check = true;

                    break;
                }
            }
            if (check)
            {
                break;
            }
            count++;

            //  Console.WriteLine("(" + i + "," + CQ + ")");
        }

       // Console.WriteLine("Left to Right");

        check = false;

        CQ = c_q;
        for (int i = CQ + 1; i <= n; i++)
        {
            foreach (List<int> obs in obstacles)
            {
                if (obs[0] == RQ && obs[1] == i)
                {
                    check = true;

                    break;
                }
            }
            if (check)
            {
                break;
            }
            count++;

            // Console.WriteLine("(" + RQ + "," + i + ")");
        }
        check = false;

        RQ = r_q;
        for (int i = CQ - 1; i >= 1; i--)
        {
            foreach (List<int> obs in obstacles)
            {
                if (obs[0] == RQ && obs[1] == i)
                {
                    check = true;
                    break;
                }
            }
            if (check)
            {
                break;
            }
            count++;

            //    Console.WriteLine("(" + RQ + "," + i + ")");
        }
       // Console.WriteLine("count:" + count);

        return count;
    }*/
    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        // Store obstacles in a HashSet for quick lookup
        HashSet<string> obstacleSet = new HashSet<string>();
        foreach (var obs in obstacles)
        {
            obstacleSet.Add($"{obs[0]},{obs[1]}");
        }

        int count = 0;
        int [][] directions= new int[][] {
        new int[]{1,0},
        new int[]{0,1},
        new int[]{-1,0},
        new int[]{-1,0},
        new int[]{-1,1},
        new int[]{0,-1},
        new int[]{1,1},
        new int[]{-1,-1},
        };
        foreach(var dir in directions)
        {
            int r = dir[0] + r_q;
            int c = dir[1] + c_q;
            while(r>=1 && r<=n && c<=n && c>=1)
            {
                if (obstacleSet.Contains($"{r},{c}"))
                {
                    break;
                }
                count++;
                r += dir[0];
                c += dir[1];
            }
        }


        return count;
    }


}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
        if (string.IsNullOrEmpty(outputPath))
        {
            outputPath = "output.txt"; // Fallback to a local file
        }

        TextWriter textWriter = new StreamWriter(outputPath, true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);
        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);
        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
//https://www.hackerrank.com/challenges/queens-attack-2/problem?isFullScreen=true
