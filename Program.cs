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
        
        long answer = solution.solution122302(4,	5,	[1, 0, 3, 1, 2],	[0, 3, 0, 4, 0]);
        // int answer = solution.solution122203("AAAJZ");
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

    // public int solution122203(string name)
    // {
    //     int answer = 0;
    //     int[] target = name.Select(x => x - 'A').ToArray();
    //     int[] shift = new int[target.Length];
    //     for(int i = 0; i < shift.Length; i++) shift[i] = 'A' - 'A';

    //     int count = 0;
    //     int currIdx = 0;
    //     int nextIdx = 0;

    //     while(true)
    //     {
    //         if (target.SequenceEqual(shift)) break;

    //         int cand1 = currIdx;
    //         while (target[cand1] == shift[cand1]) cand1 = Wrapper(cand1 + 1, target.Length);
    //         int cand2 = currIdx;
    //         while (target[cand2] == shift[cand2]) cand2 = Wrapper(cand2 - 1, target.Length);

    //         int distToNext1 = Math.Abs(currIdx - cand1);
    //         int priceNext1 = Math.Min(distToNext1, name.Length - distToNext1);

    //         int distToNext2 = Math.Abs(currIdx - cand2);
    //         int priceNext2 = Math.Min(distToNext2, name.Length - distToNext2);

    //         int truePrice = Math.Min(priceNext1, priceNext2);
    //         nextIdx = (priceNext1 <= priceNext2) ? cand1 : cand2;

    //         count += truePrice;
    //         currIdx = nextIdx;

    //         int modifyDist = Math.Abs(target[currIdx] - shift[currIdx]);
    //         int modifyPrice = Math.Min(modifyDist, 26 - modifyDist);

    //         count += modifyPrice;
    //         shift[currIdx] = target[currIdx];
    //     }
    //     answer = count;
    //     return answer;
    // }
    // idx 이동은 length, 알파벳 이동은 26
    // public int Wrapper(int num, int size)
    // {
    //     return (num % size + size) % size;
    // }

        public int solution122301(string name)
    {
        int answer = 0;
        int[] target = name.Select(x => x - 'A').ToArray();
        for(int i = 0; i < target.Length; i++)
        {
            int modifyPrice = Math.Min(target[i], 26 - target[i]);
            answer += modifyPrice;
        }

        int move = name.Length - 1;
        for(int curr = 0; curr < target.Length; curr++)
        {
            int next = curr + 1;
            while(next < target.Length && target[next] == 0) next += 1;
            int turnCase = Math.Min(curr + curr + (name.Length - next), curr + (name.Length - next) + (name.Length - next));
            move = Math.Min(move, turnCase);
        }
        return answer + move;
    }

    // public long solution122302(int cap, int n, int[] deliveries, int[] pickups) {
    //     long answer = 0;
    //     int delivery = 0;
    //     int pickup = 0;
    //     for(int i = n - 1; i >= 0; i--)
    //     {
    //         int dist = i + 1;
    //         if(deliveries[i] != 0 || pickups[i] != 0)
    //         {
    //             int count = 0;
                
    //             while(deliveries[i] > delivery || pickups[i] > pickup)
    //             {
    //                 count += 1;
    //                 delivery += cap;
    //                 pickup += cap;
    //             }
    //             delivery -= deliveries[i];
    //             pickup -= pickups[i];
    //             answer += dist * (long)count * 2;
    //         }
    //     }
    //     return answer;
    // }

    public long solution122302(int cap, int n, int[] deliveries, int[] pickups) {
        long answer = 0;
        int delivery = 0;
        int pickup = 0;
        for(int i = n - 1; i >= 0; i--)
        {
            int dist = i + 1;
            if(deliveries[i] != 0 || pickups[i] != 0)
            {
                int count = 0;

                int usedD = Math.Min(delivery, deliveries[i]);
                deliveries[i] -= usedD;
                delivery -= usedD;

                int usedP = Math.Min(pickup, pickups[i]);
                pickups[i] -= usedP;
                pickup -= usedP;
                
                while(deliveries[i] > 0 || pickups[i] > 0)
                {
                    count += 1;
                    deliveries[i] -= cap;
                    pickups[i] -= cap;
                }
                if(deliveries[i] < 0 ) delivery += Math.Abs(deliveries[i]);
                if(pickups[i] < 0) pickup += Math.Abs(pickups[i]);
                answer += dist * (long)count * 2;
            }
            deliveries[i] = 0;
            pickups[i] = 0;
        }
        return answer;
    }
}