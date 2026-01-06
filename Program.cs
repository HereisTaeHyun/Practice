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
        
        string[] answer = solution.solution010602(new int[,] {{2, -1, 4}, {-2, -1, 4}, {0, -1, 1}, {5, -8, -12}, {5, 8, 12}});
        
        foreach(var elem in answer) Console.WriteLine(elem);
        // Console.WriteLine(answer);
    }
}

public class Solution
{
    public int solution010601(int[,] points, int[,] routes) {
        int answer = 0;
        
        List<Robot> robots = new List<Robot>();
        for(int i = 0; i < routes.GetLength(0); i++)
        {
            var sIdx = routes[i, 0] - 1;
            var start = new int[] {points[sIdx, 0], points[sIdx, 1]};
            var lastCol = routes.GetLength(1) - 1;
            var eIdx = routes[i, lastCol] - 1;
            var end = new int[] { points[eIdx, 0], points[eIdx, 1] };
            Robot robot = new Robot(start, end);
            robots.Add(robot);
        }


            for(int i = 0; i < routes.GetLength(0); i++)
            {
                for(int j = 1; j < routes.GetLength(1); j++)
                {
                    var robot = robots[i];

                    var cIdx = routes[i, j - 1] - 1;
                    var curr = new int[] {points[cIdx, 0], points[cIdx, 1]};
                    var nIdx = routes[i, j] - 1;
                    var next = new int[] {points[nIdx, 0], points[nIdx, 1]};
                    robot.FindWay(curr, next);
                }
            }

            int maxTime = robots.Max(r => r.way.Count);
            for(int time = 0; time < maxTime; time++)
            {
                Dictionary<(int y, int x), int> coordinate = new Dictionary<(int y, int x), int>();
                for (int robot = 0; robot < robots.Count; robot++)
                {
                    if (time >= robots[robot].way.Count) continue;
                    var pos = robots[robot].way[time];
                    if(!coordinate.TryGetValue(pos, out var Value)) coordinate.Add(pos, 0);
                    coordinate[pos] += 1;
                }
                var accident = coordinate.Count(x => x.Value >= 2);
                answer += accident;
            }
        
        return answer;
    }

    public class Robot
    {
        public int[] start;
        public int[] end;

        public Robot(int[] start, int[] end)
        {
            this.start = (int[])start.Clone();
            this.end = (int[])end.Clone();
        }

        public List<(int y, int x)> way = new List<(int y, int x)>();
        public void FindWay(int[] curr, int[] next)
        {
            var pos = (int[])curr.Clone();
            if(way.Count == 0) way.Add((pos[0], pos[1]));
            while(pos[0] != next[0])
            {
                if(pos[0] < next[0])
                {
                    pos[0] += 1;
                    way.Add((pos[0], pos[1]));
                }
                else if(pos[0] > next[0])
                {
                    pos[0] -= 1;
                    way.Add((pos[0], pos[1]));
                }
            }
            while(pos[1] != next[1])
            {
                if(pos[1] < next[1])
                {
                    pos[1] += 1;
                    way.Add((pos[0], pos[1]));
                }
                else if(pos[1] > next[1])
                {
                    pos[1] -= 1;
                    way.Add((pos[0], pos[1]));
                }
            }
        }
    }

    public string[] solution010602(int[,] line) {
        string[] answer = new string[] {};
        return answer;
    }
}