using System;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Formats.Asn1;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Linq.Expressions;
using System.Diagnostics.Tracing;
using System.Collections;
using System.IO.Compression;
using System.Runtime.InteropServices;


internal static class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        
        int answer = solution.solution122203("JEROEN");
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    int maxDiff = int.MinValue;
    int[] apeach;
    int[] ryan;
    int[] best;
    public int[] solution122201(int n, int[] info) {
        int[] answer = new int[] {};
        apeach = (int[])info.Clone();
        ryan = new int[apeach.Length];

        DFS1222(n, 0, n);

        if(best == null) answer = new int[]{ -1 };
        else answer = best;
        return answer;
    }

    public void DFS1222(int n, int idx, int arrows)
    {
        if(idx == 11)
        {
            ryan[10] += arrows;
            Calculate();
            ryan[10] -= arrows;
            return;
        }
        
        ryan[idx] = 0;
        DFS1222(n, idx + 1, arrows);

        int need = apeach[idx] + 1;
        if (need <= arrows)
        {
            ryan[idx] = need;
            DFS1222(n, idx + 1, arrows - need);
            ryan[idx] = 0;
        }
    }
    public void Calculate()
    {
        int ryanScore = 0;
        int apeachScore = 0;
        for(int i = 0; i < 11; i++)
        {
            if(ryan[i] > apeach[i]) ryanScore += 10 - i;
            else if(apeach[i] > 0) apeachScore += 10 - i;
        }

        int diff = ryanScore - apeachScore;

        if(diff > 0 && diff >= maxDiff)
        {
            if(diff > maxDiff)
            {
                maxDiff = diff;
                best = (int[])ryan.Clone();
            }
            else if (diff == maxDiff && BetterLowScore(ryan))
            {
                maxDiff = diff;
                best = (int[])ryan.Clone();
            }
        }
    }

    bool BetterLowScore(int[] cand)
    {
        for (int i = 10; i >= 0; i--)
        {
            if (cand[i] != best[i]) return cand[i] > best[i];
        }
        return false;
    }

    public int solution122202(int[] cards) {
        int answer = 0;

        int currMax = int.MinValue;
        for(int i = 0; i < cards.Length; i++)
        {
            bool[] opened = new bool[cards.Length];
            List<int> group1 = new List<int>();

            var currCardNum = cards[i];
            opened[i] = true;
            group1.Add(currCardNum);
            var nextCardIdx = currCardNum - 1;

            while(opened[nextCardIdx] != true)
            {
                currCardNum = cards[nextCardIdx];
                opened[nextCardIdx] = true;
                group1.Add(currCardNum);
                nextCardIdx = currCardNum - 1;
            }

            for(int j = 0; j < cards.Length; j++)
            {
                if(opened[j] == true) continue;
                List<int> group2 = new List<int>();

                currCardNum = cards[j];
                opened[j] = true;
                group2.Add(currCardNum);
                nextCardIdx = currCardNum - 1;

                while(opened[nextCardIdx] != true)
                {
                    currCardNum = cards[nextCardIdx];
                    opened[nextCardIdx] = true;
                    group2.Add(currCardNum);
                    nextCardIdx = currCardNum - 1;
                }

                int candidate = group1.Count * group2.Count;
                if(candidate > currMax) currMax = candidate;
            }
        }
        answer = currMax;
        if(answer == int.MinValue) answer = 0;
        return answer;
    }

    public int solution122203(string name) {
        int answer = 0;
        int[] target = name.Select(x => x - 'A').ToArray();
        int[] store = new int[target.Length];
        for(int i = 0; i < store.Length; i++) store[i] = 'A' - 'A';
        
        return answer;
    }

    public int Wrapper(int num)
    {
        return (num % 26 + 26) % 26;
    }
}