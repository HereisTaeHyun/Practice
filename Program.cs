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


internal static class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int answer = solution.solution120803([0, 2, 3, 3, 1, 2, 0, 0, 0, 0, 4, 2, 0, 6, 0, 4, 2, 13, 3, 5, 10, 0, 1, 5], 3,	5);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public int solution120801(string[] maps) {
        int h = maps.Length;
        int w = maps[0].Length;

        int startY = -1;
        int startX = -1;

        for (int y = 0; y < h; y++)
        {
            int x = maps[y].IndexOf('S');
            if (x != -1)
            {
                startY = y;
                startX = x;
                break;
            }
        }

        int[] dx = {0, 0, 1, -1};
        int[] dy = {1, -1, 0, 0};

        var queue = new Queue<(int y, int x, int dist, char data)>();
        bool[,] visited = new bool[h, w];

        queue.Enqueue((startY, startX, 0, 'S'));
        visited[startY, startX] = true;

        while(queue.Count > 0)
        {
            var (y, x, dist, data) = queue.Dequeue();
            char currData = maps[y][x];
            if (currData == 'L')
            {
                queue = new Queue<(int y, int x, int dist, char data)>();
                visited = new bool[h, w];
                queue.Enqueue((y, x, dist, 'L'));
                break;
            }

            for(int dir = 0; dir < 4; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];

                if(nx < 0 || ny < 0 || nx >= w || ny >= h) continue;
                if(visited[ny, nx]) continue;

                char nextData = maps[ny][nx];
                if (nextData == 'X') continue;

                visited[ny, nx] = true;
                queue.Enqueue((ny, nx, dist + 1, nextData));
            }
        }

        while(queue.Count > 0)
        {
            var (y, x, dist, data) = queue.Dequeue();
            char currData = maps[y][x];
            if (currData == 'E') return dist;

            for(int dir = 0; dir < 4; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];

                if(nx < 0 || ny < 0 || nx >= w || ny >= h) continue;
                if(visited[ny, nx]) continue;

                char nextData = maps[ny][nx];
                if (nextData == 'X') continue;

                visited[ny, nx] = true;
                queue.Enqueue((ny, nx, dist + 1, nextData));
            }
        }
        return -1;
    }

    public int solution120802(int[] arrayA, int[] arrayB) {
        int answer = 0;
        int gcdOfA = arrayA.Aggregate((x, y) => GCD(x, y));
        int gcdOfB = arrayB.Aggregate((x, y) => GCD(x, y));

        if (arrayB.All(x => x % gcdOfA != 0)) answer = Math.Max(answer, gcdOfA);
        if (arrayA.All(x => x % gcdOfB != 0)) answer = Math.Max(answer, gcdOfB);

        return answer;
    }

    public int GCD(int a, int b)
    {
        if (b == 0) return a;
        else return GCD(b, a % b);
    }

    public int solution120803(int[] players, int m, int k) {
        int answer = 0;
        int server = 0;
        Queue<(int time, int minus)> serverDeleteTime = new Queue<(int time, int minus)>();
        for(int i = 0; i < players.Length; i++)
        {
            if (serverDeleteTime.Count > 0 && serverDeleteTime.Peek().time == i)
            {
                var delete = serverDeleteTime.Dequeue();
                server -= delete.minus;
            }
            int userCount = players[i];
            if(userCount < m) continue;

            int need = userCount / m;
            int plused = 0;
            while(server < need)
            {
                server += 1;
                answer += 1;
                plused += 1;
                if(server == need) serverDeleteTime.Enqueue((i + k, plused));
            }
        }
        return answer;
    }
}

