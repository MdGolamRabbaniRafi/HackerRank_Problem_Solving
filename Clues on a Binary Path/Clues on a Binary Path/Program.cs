using System;
using System.Collections.Generic;

class Program
{
    const int N = 99;

    static int n, m, l;
    static List<(int to, int bit)>[] g = new List<(int, int)>[N + 1];

    static void Main()
    {
        var input = Console.ReadLine().Split();
        n = int.Parse(input[0]);
        m = int.Parse(input[1]);
        l = int.Parse(input[2]);

        for (int i = 0; i <= n; i++)
            g[i] = new List<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            input = Console.ReadLine().Split();
            int u = int.Parse(input[0]);
            int v = int.Parse(input[1]);
            int c = int.Parse(input[2]);
            g[u].Add((v, c));
            g[v].Add((u, c));
        }

        int maxMoves = (l + 1) / 2;
        int lengthOfFirstPart = l - maxMoves;

        // BFS from all starts: f[start][ver][len] = set of masks
        // We'll only keep masks for given len to reduce memory

        var f = new Dictionary<(int start, int ver, int len), HashSet<int>>();

        // Initialize BFS queue with (start, ver, len, mask)
        var queue = new Queue<(int start, int ver, int len, int mask)>();

        for (int i = 1; i <= n; i++)
        {
            f[(i, i, 0)] = new HashSet<int> { 0 };
            queue.Enqueue((i, i, 0, 0));
        }

        while (queue.Count > 0)
        {
            var (start, ver, len, mask) = queue.Dequeue();

            if (len == maxMoves)
                continue;

            foreach (var (to, bit) in g[ver])
            {
                int newMask = mask;
                if (bit == 1)
                    newMask |= (1 << len);

                var key = (start, to, len + 1);
                if (!f.TryGetValue(key, out var maskSet))
                {
                    maskSet = new HashSet<int>();
                    f[key] = maskSet;
                }

                if (!maskSet.Contains(newMask))
                {
                    maskSet.Add(newMask);
                    queue.Enqueue((start, to, len + 1, newMask));
                }
            }
        }

        // canMake[j][mask] = true if f[i,j,maxMoves][mask] == true for some i
        var canMake = new Dictionary<(int j, int mask), bool>();

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                var key = (i, j, maxMoves);
                if (f.TryGetValue(key, out var maskSet))
                {
                    foreach (var mask in maskSet)
                    {
                        canMake[(j, mask)] = true;
                    }
                }
            }
        }

        // Now BFS for the first part lengthOfFirstPart starting only from start=1
        var fFirstPart = new Dictionary<(int ver, int len), HashSet<int>>();
        var qFirst = new Queue<(int ver, int len, int mask)>();

        fFirstPart[(1, 0)] = new HashSet<int> { 0 };
        qFirst.Enqueue((1, 0, 0));

        while (qFirst.Count > 0)
        {
            var (ver, len, mask) = qFirst.Dequeue();

            if (len == lengthOfFirstPart)
                continue;

            foreach (var (to, bit) in g[ver])
            {
                int newMask = mask;
                if (bit == 1)
                    newMask |= (1 << len);

                var key = (to, len + 1);
                if (!fFirstPart.TryGetValue(key, out var maskSet))
                {
                    maskSet = new HashSet<int>();
                    fFirstPart[key] = maskSet;
                }
                if (!maskSet.Contains(newMask))
                {
                    maskSet.Add(newMask);
                    qFirst.Enqueue((to, len + 1, newMask));
                }
            }
        }

        // Combine results from first part and second part
        var used = new HashSet<int>();

        foreach (var ((ver, len), maskSet1) in fFirstPart)
        {
            if (len != lengthOfFirstPart) continue;

            foreach (var m1 in maskSet1)
            {
                // For canMake at ver for second part
                for (int m2 = 0; m2 < (1 << maxMoves); m2++)
                {
                    if (canMake.TryGetValue((ver, m2), out _))
                    {
                        int combined = (m1 << maxMoves) | m2;
                        used.Add(combined);
                    }
                }
            }
        }

        Console.WriteLine(used.Count);
    }
}
