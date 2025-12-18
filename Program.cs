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
        
        int answer = solution.solution121804(["O.X", ".O.", "..X"]);
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

    public long solution121801(int k, int d) {
        long answer = 0;
        for(int y = 0; y <= d; y += k)
        {
            long x = (long)Math.Pow(d, 2) - (long)Math.Pow(y, 2);
            long count = (long)Math.Sqrt(x) / k + 1;
            answer += count;
        }
        return answer;
    }

    public int solution121802(int n) {
        int answer = 0;
        int[] chess = new int[n];
        nQueen(ref answer, n, 0, chess);
        return answer;
    }

    public void nQueen(ref int answer, int n, int row, int[] chess)
    {
        if(row == n)
        {
            answer += 1;
            return;
        }

        for(int i = 0; i < n; i++)
        {
            chess[row] = i;
            if(check(chess, row))
            {
                nQueen(ref answer, n, row + 1, chess);
            }
        }
    }
    public bool check(int[] chess, int row)
    {
        for(int i = 0; i < row; i++)
        {
            if(chess[i] == chess[row]) return false;
            if(Math.Abs(chess[i] - chess[row]) == Math.Abs(row - i)) return false;
        }
        return true;
    }

    public int solution121803(int[,] targets) {
        int answer = 0;
        int rows = targets.GetLength(0);
        int cols = targets.GetLength(1);

        int[][] temp = new int[rows][];
        for (int r = 0; r < rows; r++)
        {
            temp[r] = new int[cols];
            for (int c = 0; c < cols; c++) temp[r][c] = targets[r, c];
        }

        Array.Sort(temp, (a, b) => a[1].CompareTo(b[1]));

        int[,] sorted = new int[rows, cols];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
        sorted[r, c] = temp[r][c];

        int curr = 0;
        for(int i = 0; i < sorted.GetLength(0); i++)
        {
            if(sorted[i, 0] < curr) continue;
            curr = sorted[i, 1];
            answer += 1;
        }
        return answer;
    }

    public int solution121804(string[] board) {
        int answer = 0;
        int oCount = 0;
        int xCount = 0;
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; i < board[0].Length; j++)
            {
                if(board[i][j] == 'O') oCount += 1;
                else if (board[i][j] == 'X') xCount += 1;
            }
        }
        if(oCount == xCount)
        {
            
        }
        else if(oCount + 1 == xCount)
        {
            
        }
        return answer;
    }
}