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
        
        double[] answer = solution.solution121103(5, new int[,] {{0,0},{0,-1},{2,-3},{3,-3}});
        foreach (var elem in answer) Console.WriteLine(elem);
        // Console.WriteLine(answer);
    }
}

public class Solution
{
    public int[] solution121001(string[] maps) {
        List<int> answer = new List<int>();
        int h = maps.Length;
        int w = maps[0].Length;

        int[] dy = {1, -1, 0, 0};
        int[] dx = {0, 0, 1, -1};

        bool[,] visited = new bool[h, w];
        var queue = new Queue<(int y, int x)>();

        for(int y = 0; y < maps.Length; y++)
        {
            for(int x = 0; x < maps[0].Length; x++)
            {
                if(!char.IsDigit(maps[y][x])) continue;
                if(visited[y, x]) continue;

                queue.Enqueue((y, x));
                visited[y, x] = true;
                int count = maps[y][x] - '0';

                while(queue.Count > 0)
                {
                    var (currY, currX) = queue.Dequeue();

                    for(int dir = 0; dir < 4; dir++)
                    {
                        int ny = currY + dy[dir];
                        int nx = currX + dx[dir];

                        if (nx < 0 || ny < 0 || nx >= w || ny >= h) continue;
                        if (visited[ny, nx]) continue;
                        if(!char.IsDigit(maps[ny][nx])) continue;

                        visited[ny, nx] = true;
                        count += maps[ny][nx] - '0';
                        queue.Enqueue((ny, nx));
                    }
                }

                answer.Add(count);
            }
        }
        answer = answer.OrderBy(x => x).ToList();

        if(answer.Count == 0) answer.Add(-1);
        return answer.ToArray();
    }

    public int[] solution121002(int rows, int columns, int[,] queries) {
        List<int> answer = new List<int>();

        int num = 1;
        int[,] matrix = new int[rows, columns];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                matrix[i, j] = num;
                num += 1;
            }
        }

        int[] dy = { 0,  1, 0, -1 };
        int[] dx = { 1,  0,-1,  0 };

        for(int i = 0; i < queries.GetLength(0); i++)
        {
            int dir = 0;
            int top = queries[i, 0] - 1;
            int left = queries[i, 1] - 1;
            int bottom = queries[i, 2] - 1;
            int right = queries[i, 3] - 1;

            int y = top;
            int x = left;

            List<int> store = new List<int>();

            while(true)
            {
                if(dir == 0 && x == right) dir = 1;
                else if(dir == 1 && y == bottom) dir = 2;
                else if(dir == 2 && x == left) dir = 3;
                else if(dir == 3 && y == top) dir = 0;

                store.Add(matrix[y, x]);

                int ny = y + dy[dir];
                int nx = x + dx[dir];

                if (ny == top && nx == left) break;
                y = ny;
                x = nx;
            }

            int min = store.Min();
            answer.Add(min);

            dir = 0;
            y = top;
            x = left;
            int idx = store.Count - 1;
            while(true)
            {
                if(dir == 0 && x == right) dir = 1;
                else if(dir == 1 && y == bottom) dir = 2;
                else if(dir == 2 && x == left) dir = 3;
                else if(dir == 3 && y == top) dir = 0;

                matrix[y, x] = store[idx];
                idx = (idx + 1) % store.Count;

                int ny = y + dy[dir];
                int nx = x + dx[dir];

                if (ny == top && nx == left) break;
                y = ny;
                x = nx;
            }
        }
        return answer.ToArray();
    }

    public int solution121003(int[,] data, int col, int row_begin, int row_end) {
        int answer = 0;
        var sortedData = new List<int[]>();
        for(int i = 0; i < data.GetLength(0); i++)
        {
            int[] row = new int[data.GetLength(1)];
            for(int j = 0; j < data.GetLength(1); j++)
            {
                row[j] = data[i, j];
            }
            sortedData.Add(row);
        }

        int sortPoint1 = col - 1;
        int sortPoint2 = 0;
        sortedData = sortedData.OrderBy(row => row[sortPoint1]).ThenByDescending(row => row[sortPoint2]).ToList();

        List<int> S_I = new List<int>();
        int start = row_begin - 1;
        int end = row_end - 1;
        for(int i = start; i <= end; i++)
        {
            var currRow = sortedData[i];
            int S_Now = 0;
            foreach(var elem in currRow) S_Now += elem % (i + 1);
            S_I.Add(S_Now);
        }

        int hash = 0;
        foreach(var elem in S_I) hash ^= elem;
        answer = hash;
        return answer;
    }

    public int[] solution121101(string[,] places) {
        int[] answer = new int[] {1, 1, 1, 1, 1};

    int[,] able = new int[,]
    {
        { 0,  1 }, { 1,  0 }, { 0, -1 }, { -1,  0 },
        { 0,  2 }, { 1,  1 }, { 2,  0 }, { 1, -1 },
        { 0, -2 }, { -1, -1 }, { -2, 0 }, { -1, 1 },
    };

        for(int i = 0; i < places.GetLength(0); i++)
        {
            string[] room = new string[5];
            for(int j = 0; j < 5; j++) room[j] = places[i, j];
            bool safe = true;


            for(int y = 0; y < 5 && safe; y++)
            {
                for(int x = 0; x < 5 && safe; x++)
                {
                    if (room[y][x] != 'P') continue;

                    for(int pos = 0; pos < able.GetLength(0); pos++)
                    {
                        int ny = y + able[pos, 0];
                        int nx = x + able[pos, 1];

                        if (nx < 0 || ny < 0 || nx >= 5 || ny >= 5) continue;
                        if (room[ny][nx] != 'P') continue;

                        if(room[ny][nx] == 'P')
                        {
                            if (!IsSafe(room, y, x, ny, nx))
                            {
                                answer[i] = 0;
                                safe = false;
                                break;
                            }
                        }
                    }   
                }
            }
        }
        return answer;
    }

    public bool IsSafe(string[] room, int y, int x, int ny, int nx)
    {
        int dist = Math.Abs(x - nx) + Math.Abs(y - ny);;
        if (dist == 1) return false;
        if (dist == 2)
        {
            int dy = ny - y;
            int dx = nx - x;

            if (dy == 0 && Math.Abs(dx) == 2)
            {
                int mx = (x + nx) / 2;
                if (room[y][mx] != 'X') return false;
                return true;
            }

            if (dx == 0 && Math.Abs(dy) == 2)
            {
                int my = (y + ny) / 2;
                if (room[my][x] != 'X') return false;
                return true;
            }

            if (Math.Abs(dx) == 1 && Math.Abs(dy) == 1)
            {
                if (room[y][nx] != 'X' || room[ny][x] != 'X') return false;
                return true;
            }
        }
        return true;
    }

    public int[,] solution121102(int n) {
        List<int[]> store = new List<int[]>();
        Hanoi(n, 1, 2, 3, store);

        int[,] answer = new int[store.Count, 2];
        for(int i = 0; i < answer.GetLength(0); i++)
        {
            answer[i, 0] = store[i][0];
            answer[i, 1] = store[i][1];
        }
        return answer;
    }

    public void Hanoi(int n, int from, int lay, int to, List<int[]> store)
    {
        if(n == 1)
        {
            store.Add(new int[] {from, to});
            return;
        }
        Hanoi(n - 1, from, to, lay, store);
        store.Add(new int[] {from, to});
        Hanoi(n - 1, lay, from, to, store);
    }

    // 바닥은 0, 범위는 각 rangeX, 최대 높이, 최소 높이 구하여 각 사다리꼴의 크기를 합하면 됨
    public double[] solution121103(int k, int[,] ranges) {
        double[] answer = new double[ranges.GetLength(0)];
        List<int> collatz = new List<int>();
        int n = 0;
        while(k > 1)
        {
            if(k % 2 == 0)
            {
                collatz.Add(k);
                k /= 2;
            }
            else
            {
                collatz.Add(k);
                k = k * 3 + 1;
            }
            n += 1;
        }
        collatz.Add(1);

        for(int i = 0; i < ranges.GetLength(0); i++)
        {
            int rangeX1 = ranges[i, 0];
            int rangeX2 = n - ranges[i, 1];
            if(rangeX1 > rangeX2)
            {
                answer[i] = 1.0d;
                continue;
            }
        }
        return answer;
    }
}

