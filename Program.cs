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
        
        int answer = solution.solution011202(new int[,] {{1, 2}, {2, 3}, {2, 1}}, 4, 4);
        // foreach(var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public string[] solution011201(int[,] line) {
        List<(long y, long x)> dots = new List<(long y, long x)>();
        for(long i = 0; i < line.GetLength(0) - 1; i++)
        {
            for(long j = i + 1; j < line.GetLength(0); j++)
            {
                long A = line[i, 0], B = line[i, 1], E = line[i, 2];
                long C = line[j, 0], D = line[j, 1], F = line[j, 2];

                long det = A * D - B * C;
                if (det == 0) continue;

                long candidateX = B * F - E * D;
                long candidateY = E * C - A * F;

                if(candidateX % det != 0 || candidateY % det != 0) continue;

                long x = candidateX / det;
                long y = candidateY / det;
                dots.Add((y, x));
            }
        }

        dots = dots.OrderByDescending(yPos => yPos.y).ThenBy(xPos => xPos.x).ToList();

        long minY = dots.Min(p => p.y);
        long maxY = dots.Max(p => p.y);
        long minX = dots.Min(p => p.x);
        long maxX = dots.Max(p => p.x);

        long width  = maxX - minX + 1;
        long height = maxY - minY + 1;

        string[] answer = new string[height];

        List<(long y, long x)> coordinates = new List<(long y, long x)>();
        foreach(var dot in dots)
        {
            long newY = maxY - dot.y;
            long newX = dot.x - minX;
            coordinates.Add((newY, newX));
        }

        int idx = 0;
        for(long i = 0; i < height; i++)
        {
            StringBuilder stringBuilder = new StringBuilder();
            long currY = coordinates[idx].y;
            if(i != currY)
            {
                for(long j = 0; j < width; j++)
                {
                    stringBuilder.Append('.');
                }
            }
            else if(i == currY)
            {
                List<long> xPoses = new List<long>();
                while (idx < coordinates.Count && coordinates[idx].y == currY)
                {
                    xPoses.Add(coordinates[idx].x);
                    idx += 1;
                }

                int xIdx = 0;
                for(long j = 0; j < width; j++)
                {
                    if(xIdx < xPoses.Count && xPoses[xIdx] == j)
                    {
                        stringBuilder.Append('*');
                        xIdx += 1;
                    }
                    else stringBuilder.Append('.');
                }
            }
            answer[i] = stringBuilder.ToString();
        }
        return answer;
    }

    // public int solution011202(int[,] info, int n, int m) {
    //     int answer = 0;
    //     List<(int a, int b)> robObject = new List<(int a, int b)>();
    //     for(int i = 0; i < info.GetLength(0); i++) robObject.Add((info[i, 0], info[i, 1]));
    //     robObject = robObject.OrderByDescending(x => (double)x.a / x.b).ThenBy(x => x.a).ThenBy(x => x.b).ToList();

    //     int a = 0;
    //     int b = 0;
    //     for(int i = 0; i < info.GetLength(0); i++)
    //     {
    //         if(info[i, 1] + b < m) b += info[i, 1];
    //         else a += info[i, 0];
    //     }

    //     answer = a;
    //     if(answer >= n) answer = - 1;
    //     return answer;
    // }
    // public int solution011202(int[,] info, int n, int m)
    // {
    //     int answer = int.MaxValue;
    //     int robCount = info.GetLength(0);
    //     int a = 0;
    //     int b = 0;
    //     bool[] visited = new bool[info.GetLength(0)];
    //     DFS0112(ref answer, 0, robCount, info, visited, a, b, n, m);

    //     if (answer == int.MaxValue) return -1;
    //     return answer;
    // }
    
    // public void DFS0112(ref int answer, int currCount, int robCount, int[,] info, bool[] visited, int a, int b, int n, int m)
    // {
    //     if(a >= n || b >= m) return;
    //     if(currCount == robCount)
    //     {
    //         answer = Math.Min(answer, a);
    //         return;
    //     }

    //     if(visited[currCount]) return;
    //     visited[currCount] = true; 
    //     int currA = a + info[currCount, 0];
    //     int currB = b + info[currCount, 1];
        
    //     DFS0112(ref answer, currCount + 1, robCount, info, visited, currA, b, n, m);
    //     DFS0112(ref answer, currCount + 1, robCount, info, visited, a, currB, n, m);

    //     visited[currCount] = false;
    // }

    public int solution011202(int[,] info, int n, int m)
    {
        int answer = int.MaxValue;
        int robCount = info.GetLength(0);
        HashSet<(int idx, int a, int b)> check = new HashSet<(int idx, int a, int b)>();
        DFS0112(ref answer, 0, robCount, info, check, 0, 0, n, m);

        if (answer >= n) return -1;
        return answer;
    }
    
    public void DFS0112(ref int answer, int currCount, int robCount, int[,] info, HashSet<(int idx, int a, int b)> check, int a, int b, int n, int m)
    {
        if(a >= n || b >= m) return;
        if(!check.Add((currCount, a, b))) return;


        check.Add((currCount, a, b));
        if(currCount == robCount)
        {
            answer = Math.Min(answer, a);
            return;
        }

        int currA = a + info[currCount, 0];
        int currB = b + info[currCount, 1];
        
        DFS0112(ref answer, currCount + 1, robCount, info, check, currA, b, n, m);
        DFS0112(ref answer, currCount + 1, robCount, info, check, a, currB, n, m);
    }
}