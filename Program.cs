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
        
        int[] answer = solution.solution121503(new int[,] {{40, 10000}, {25, 10000}},	[7000, 9000]);
        foreach (var elem in answer) Console.WriteLine(elem);
        // Console.WriteLine(answer);
    }
}

public class Solution
{
    public int solution121501(int[] diffs, int[] times, long limit) {
        int answer = 0;

        int left = 1;
        int right = diffs.Max();
        while(left <= right)
        {
            long sum = 0;
            int currLevel = (left + right) / 2;

            for(int i = 0; i < diffs.Length; i++)
            {
                int diff = diffs[i];
                int time = times[i];

                if(diff <= currLevel) sum += time;
                else if(diff > currLevel)
                {
                    if(i == 0) sum += (long) (diff - currLevel) * time + time;
                    else sum += (long) (diff - currLevel) * (time + times[i - 1]) + time;
                }
            }

            if(sum <= limit)
            {
                answer = currLevel;
                right = currLevel - 1;
            }
            else
            {
                left = currLevel + 1;
            }
        }
        return answer;
    }

    public long solution121502(int w, int h) {
        long answer = 0;

        int height = Math.Max(w, h);
        int width = Math.Min(w, h);
        long all = (long)width * height;

        int gcd = GCD(height, width);
        long deleted =  ((height / gcd) * (width / gcd)) - ((height / gcd) - 1) * ((width / gcd) - 1);

        answer = all - deleted * gcd;
        return answer;
    }

    public int GCD(int a, int b)
    {
        if (b == 0) return a;
        else return GCD(b, a % b);
    }

    public int[] solution121503(int[,] users, int[] emoticons) {
        int[] answer = new int[2];

        List<(int buy, int money)> userData = new List<(int buy, int money)>();
        for(int i = 0; i < users.GetLength(0); i++) userData.Add((users[i, 0], users[i, 1]));

        Dictionary<string, (int subscriber, int take)> data = new Dictionary<string, (int subscriber, int take)>();

        int[] onSale = new int[emoticons.Length];
        for(int i = 0; i < onSale.Length; i++) onSale[i] = 10;

        int subscriber = 0;
        int take = 0;
        for(int i = 0; i < userData.Count; i++)
        {
            int usedMoney = 0;
            for(int j = 0; j < emoticons.Length; j++)
            {
                if(userData[i].buy <= onSale[j]) usedMoney += (int)(emoticons[j] - (emoticons[j] * (float)onSale[j] / 100));
            }
            if(usedMoney >= userData[i].money) subscriber += 1;
            else take += usedMoney;
        }
        data.TryAdd("1010", (subscriber, take));

        DFS1215(userData, onSale, data, emoticons);

        var best = data.OrderByDescending(x => x.Value.subscriber).ThenByDescending(x => x.Value.take).First();
        answer[0] = best.Value.subscriber;
        answer[1] = best.Value.take;
        return answer;
    }

    public void DFS1215(List<(int buy, int money)> userData, int[] onSale, Dictionary<string, (int subscriber, int take)> data, int[] emoticons)
    {
        for(int i = 0; i < onSale.Length; i++)
        {
            int[] newSale = (int[])onSale.Clone();
            if(newSale[i] >= 40) continue;
            newSale[i] += 10;

            StringBuilder sb = new StringBuilder();
            for(int j = 0; j < onSale.Length; j++) sb.Append(newSale[j]);
            string key = sb.ToString();

            if(data.ContainsKey(key)) continue;
            
            int subscriber = 0;
            int take = 0;
            for(int j = 0; j < userData.Count; j++)
            {
                int usedMoney = 0;
                for(int k = 0; k < emoticons.Length; k++)
                {
                    if(userData[j].buy <= newSale[k]) usedMoney += (int)(emoticons[k] - (emoticons[k] * (float)newSale[k] / 100));
                }
                if(usedMoney >= userData[j].money) subscriber += 1;
                else take += usedMoney;
            }
            data.TryAdd(key, (subscriber, take));
            DFS1215(userData, newSale, data, emoticons);
        }
    }
}

