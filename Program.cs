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
        
        long answer = solution.solution122601(new int[,] {{3, 2}, {6, 4}, {4, 7}, {1, 4}},	new int[,] {{4, 2}, {1, 3}, {2, 4}});
        // long answer = solution.solution122601(new int[,] {{2, 2}, {2, 3}, {2, 7}, {6, 6}, {5, 2}},	new int[,] {{2, 3, 4, 5}, {1, 3, 4, 5}});
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public int solution122601(int[,] points, int[,] routes) {
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

        while(robots.Count > 0)
        {
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
}