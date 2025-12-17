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
        
        int answer = solution.solution121702(10, new int[,] {{1, 2, 3, 4, 5}, {6, 7, 8, 9, 10}, {3, 7, 8, 9, 10}, {2, 5, 7, 9, 10}, {3, 4, 5, 6, 7}}, [2, 3, 4, 3, 3]);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public string[] solution121701(string[,] plans) {
        List<string> answer = new List<string>();
        var lowAssignments = new List<(string name, int start, int use)>();
        for(int i = 0; i < plans.GetLength(0); i++)
        {
            string name = plans[i, 0];
            string[] startTimeString = plans[i, 1].Split(":");
            int startTime = (int.Parse(startTimeString[0]) * 60) + int.Parse(startTimeString[1]);
            int useTime = int.Parse(plans[i, 2]);
            lowAssignments.Add((name, startTime, useTime));
        }
        lowAssignments = lowAssignments.OrderBy(x => x.start).ToList();
        
        var assignments = new Queue<(string name, int start, int use)>();
        foreach(var elem in lowAssignments) assignments.Enqueue(elem);

        var postponed = new Stack<(string name, int delay)>();

        var first = assignments.Dequeue();
        var prevName = first.name;
        var prevUse = first.use;
        var time = first.start;

        while(assignments.Count >= 0)
        {
            var curr = assignments.Dequeue();
            var currName = curr.name;
            var currStart = curr.start;
            var currUse = curr.use;

            if(time + prevUse <= currStart)
            {
                answer.Add(prevName);
                time += prevUse;
                prevName = currName;;
                prevUse = currUse;
                while(postponed.Count > 0 && time < currStart)
                {
                    var remain = postponed.Pop();
                    if(time + remain.delay <= currStart)
                    {
                        answer.Add(remain.name);
                        time += remain.delay;
                    }
                    else if(time + remain.delay > currStart)
                    {
                        postponed.Push((remain.name, time + remain.delay - currStart));
                        time = currStart;
                    }
                }
                if (time < currStart) time = currStart;
            }
            else if(time + prevUse > currStart)
            {
                postponed.Push((prevName, time + prevUse - currStart));
                prevName = currName;
                prevUse = currUse;
                time = currStart;
            }
            if(assignments.Count == 0)
            {
                answer.Add(currName);
                break;
            }
        }
        while(postponed.Count > 0)
        {
            var next = postponed.Pop();
            answer.Add(next.name);
        }
        return answer.ToArray();
    }

    public int solution121702(int n, int[,] q, int[] ans) {
        int answer = 0;
        DFS1217(ref answer, n, q, new int[5], ans, 1, 0);
        return answer;
    }

    public void DFS1217(ref int answer, int n, int[,] q, int[] candidate, int[] ans, int start, int count)
    {
        if(count == 5)
        {
            HashSet<int> set = new HashSet<int>();
            for(int i = 0; i < 5; i++) set.Add(candidate[i]);
            for(int i = 0; i < q.GetLength(0); i++)
            {
                int sum = 0;
                for(int j = 0; j < q.GetLength(1); j++)
                {
                    if(set.Contains(q[i, j])) sum += 1;
                }
                if(sum != ans[i]) return;
            }
            answer += 1;
            return;
        }
        for(int i = start; i <= n; i++)
        {
            candidate[count] = i;
            DFS1217(ref answer, n, q, candidate, ans, i + 1, count + 1);
        } 
    }
}