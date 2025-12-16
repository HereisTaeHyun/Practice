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
        
        string[] answer = solution.solution121701(new string[,] {{"korean", "11:40", "30"}, {"english", "12:10", "20"}, {"math", "12:30", "40"}});
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

    public int solution121601(string[] storage, string[] requests) {
        int answer = 0;
        int n = storage.Length;
        int m = storage[0].Length;

        bool[,] empty = new bool[n, m];

        Dictionary<char, List<Tuple<int,int>>> storageData = new Dictionary<char, List<Tuple<int, int>>>();
        for(int y = 0; y < n; y ++)
        {
            for(int x = 0; x < m; x ++)
            {
                char currCargo = storage[y][x];
                if (!storageData.ContainsKey(currCargo)) storageData.Add(currCargo, new List<Tuple<int, int>>());
                storageData[currCargo].Add(Tuple.Create(y, x));
            }
        }

        int[] dy = {1, -1, 0, 0};
        int[] dx = {0, 0, 1, -1};

        foreach(var command in requests)
        {
            var currCargo = command[0];
            if(!storageData.ContainsKey(currCargo)) continue;
            var cargoData = storageData[currCargo];
            if(command.Length == 1)
            {
                var removeIdx = new List<int>();
                var toEmpty = new List<Tuple<int,int>>();
                for (int i = 0; i < cargoData.Count; i++)
                {
                    Queue<(int y, int x)> road = new Queue<(int y, int x)>();
                    bool[,] visited = new bool[n, m];
                    int currY = cargoData[i].Item1;
                    int currX = cargoData[i].Item2;
                    road.Enqueue((currY, currX));

                    bool touchOutbound = false;
                    while (road.Count > 0 && !touchOutbound)
                    {
                        var pos = road.Dequeue();
                        int y = pos.y;
                        int x = pos.x;
                        
                        for(int dir = 0; dir < 4; dir++)
                        {
                            int ny = y + dy[dir];
                            int nx = x + dx[dir];
                            if (nx < 0 || ny < 0 || nx >= m || ny >= n)
                            {
                                touchOutbound = true;
                                break;
                            }

                            if (visited[ny, nx]) continue;
                            if(!empty[ny, nx]) continue;

                            visited[ny, nx] = true;
                            road.Enqueue((ny, nx));
                        }
                    }
                    if(touchOutbound)
                    {
                        removeIdx.Add(i);
                        toEmpty.Add(Tuple.Create(currY, currX));
                    }
                }

                for (int r = removeIdx.Count - 1; r >= 0; r--) cargoData.RemoveAt(removeIdx[r]);
                foreach (var p in toEmpty) empty[p.Item1, p.Item2] = true;
            }
            else if(command.Length == 2)
            {
                for (int i = cargoData.Count - 1; i >= 0; i--)
                {
                    int currY = cargoData[i].Item1;
                    int currX = cargoData[i].Item2;
                    cargoData.RemoveAt(i);
                    empty[currY, currX] = true;
                }
            }
        }
        foreach(var data in storageData) answer += data.Value.Count;
        return answer;
    }

    public string[] solution121701(string[,] plans) {
        string[] answer = new string[] {};
        return answer;
    }
}

