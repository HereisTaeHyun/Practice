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
        int answer = solution.solution121003(new int[,] {{2,2,6},{1,5,10},{4,2,9},{3,8,3}}, 2, 2, 3);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
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
}

