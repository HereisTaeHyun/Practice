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


internal static class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] fees = { 1, 461, 1, 10 };

        string[] records =
        {
            "00:00 1234 IN"
        };

        int[] answer = solution.solution112703(fees, records);
        foreach (var elem in answer) Console.WriteLine(elem);
        // Console.WriteLine(answer);
    }
}

public class Solution
{
    // public int[] solution112601(int[] prices) {
    //     int[] answer = new int[prices.Length];
    //     bool[] confirmed = new bool[prices.Length];
    //     Stack<int> store = new Stack<int>();

    //     store.Push(prices[0]);
    //     for(int i = 1; i < prices.Length; i++)
    //     {
    //         int prev= store.Peek();
    //         store.Push(prices[i]);
    //         int curr = store.Peek();

    //         if(prev > curr)
    //         {
    //             int comparison = curr;
    //             int day = 0;
    //             int idx = i;

    //             foreach(var elem in store)
    //             {
    //                 if(!confirmed[idx] && elem > comparison)
    //                 {
    //                     answer[idx] = day;
    //                     confirmed[idx] = true;
    //                 }
    //                 day += 1;
    //                 idx -= 1;
    //             }
    //         }
    //     }

    //     int finish = 0;
    //     for(int i = prices.Length - 1; i >= 0; i--)
    //     {
    //         if(!confirmed[i]) answer[i] = finish;
    //         finish += 1;
    //     }
    //     return answer;
    // }
    public int[] solution112601(int[] prices) {
        int[] answer = new int[prices.Length];

        for(int i = 0; i < prices.Length - 1; i++)
        {
            int curr = prices[i];
            int sec = 0;
            for(int j =  i + 1; j < prices.Length; j++)
            {
                int comparison = prices[j];
                sec += 1;
                if(curr > comparison) break;
            }
            answer[i] = sec;
        }
        return answer;
    }

    public int solution112602(int[] order) {
        int answer = 0;
        Stack<int> stackBelt = new Stack<int>();

        int box = 1;
        int idx = 0;
        while(true)
        {
            if(idx >= order.Length) break;

            if (box <= order.Length)
            {
                if(order[idx] == box)
                {
                    answer += 1;   
                    idx += 1;
                    box += 1;
                }
                else if(stackBelt.Count > 0 && order[idx] == stackBelt.Peek())
                {
                    stackBelt.Pop();
                    answer += 1;  
                    idx += 1;
                }
                else
                {
                    stackBelt.Push(box);
                    box += 1;
                }
            }
            else
            {
                if(stackBelt.Count > 0 && order[idx] == stackBelt.Peek())
                {
                    stackBelt.Pop();
                    answer += 1;  
                    idx += 1;
                }
                else break;
            }
        }
        return answer;
    }

    // public int solution112701(string skill, string[] skill_trees) {
    //     int answer = 0;
    //     int[] skillArray = new int[skill.Length];
    //     for(int i = 0; i < skill_trees.GetLength(0); i++)
    //     {
    //         for(int j = 0; j < skillArray.Length; j++)
    //         {
    //             skillArray[j] = skill_trees[i].IndexOf(skill[j]);
    //         }

    //         bool isSorted = true;
    //         for (int j = 1; j < skillArray.Length; j++)
    //         {
    //             if (skillArray[j - 1].CompareTo(skillArray[j]) > 0) isSorted = false;
    //         }

    //         if(isSorted) answer += 1;
    //     }
    //     return answer;
    // }

    public int solution112701(string skill, string[] skill_trees) {
        int answer = 0;
        bool isValid = true;
        for(int i = 0; i < skill_trees.GetLength(0); i++)
        {
            int skillIdx = 0;
            foreach(var elem in skill_trees[i])
            {
                int idx = skill.IndexOf(elem);

                if(idx == -1) continue;
                if(idx == skillIdx) skillIdx += 1;
                else isValid = false;
            }

            if(isValid) answer += 1;
        }
        return answer;
    }

    public int solution112702(int x, int y, int n) {
        Queue<(int, int)> bfs = new Queue<(int, int)>();
        bool[] visited = new bool[y + 1];

        bfs.Enqueue((x, 0));
        visited[x] = true;

        while(bfs.Count > 0)
        {
            var (value, count) = bfs.Dequeue();
            if(value == y) return count;

            int[] nexts = {value + n, value * 2, value * 3};

            foreach (var next in nexts)
            {
                if (next > y) continue;
                if (visited[next]) continue;

                visited[next] = true;
                bfs.Enqueue((next, count + 1));
            }
        }
        return -1;
    }

    public int[] solution112703(int[] fees, string[] records) {
        var lowData = new List<(int time, string number, string type)>();
        foreach(var elem in records)
        {
            var currData = elem.Split(' ');

            var lowTime = currData[0].Split(':');
            var trueTime = (int.Parse(lowTime[0]) * 60) + int.Parse(lowTime[1]);

            var number = currData[1];
            var type = currData[2];
            lowData.Add((trueTime, number, type));
        }

        lowData = lowData.OrderBy(x => x.number).ThenBy(x => x.time).ToList();

        Dictionary<string, int> trueData = new Dictionary<string, int>();

        int currIdx = lowData.Count - 2;
        int prevIdx = lowData.Count - 1;
        while (currIdx >= 0 && prevIdx >= 1)
        {
            var prevNum = lowData[prevIdx].number;
            var currNum = lowData[currIdx].number;

            var prevType = lowData[prevIdx].type;
            var currType = lowData[currIdx].type;

            var prevTime = lowData[prevIdx].time;
            var currTime = lowData[currIdx].time;

            if(prevNum == currNum && prevType == "OUT" && currType == "IN")
            {
                if(!trueData.TryGetValue(currNum, out var Value)) trueData.Add(currNum, 0);
                trueData[currNum] += prevTime - currTime;
                lowData.RemoveAt(prevIdx);
                lowData.RemoveAt(currIdx);
                prevIdx -= 1;
                currIdx -= 1;
            }
            prevIdx -= 1;
            currIdx -= 1;
        }

        if(lowData.Count > 0)
        {
            int fullTime = (23 * 60) + 59;
            foreach(var elem in lowData)
            {
                if(!trueData.TryGetValue(elem.number, out var Value)) trueData.Add(elem.number, 0);
                var number = elem.number;
                var time = elem.time;
                trueData[number] += fullTime - time;
            }
        }

        var moneyData = trueData.ToList();
        moneyData = moneyData.OrderBy(x => x.Key).ToList();

        for(int i = 0; i < moneyData.Count; i++)
        {
            var number = moneyData[i].Key;
            var time = moneyData[i].Value;

            int fee;
            if(time <= fees[0]) fee = fees[1];
            else
            {
                int extra = time - fees[0];
                int unitCount = (int)Math.Ceiling(extra / (float)fees[2]);
                fee = fees[1] + unitCount * fees[3];
            }
            moneyData[i] = new KeyValuePair<string, int>(number, fee);
        }

        int[] answer = new int[moneyData.Count];
        for(int i = 0; i < answer.Length; i++)
        {
            answer[i] = moneyData[i].Value;
        }
        return answer;
    }
}

