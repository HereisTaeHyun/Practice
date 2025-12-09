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
        int answer = solution.solution120903(	7, 3, [4, 2, 4, 5, 3, 3, 1]);
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

    // public int solution120901(int N, int[,] road, int K)
    // {
    //     int answer = 0;

    //     int[] dist = new int[N + 1];
    //     for(int i = 0; i < dist.Length; i++) dist[i] = int.MaxValue;
    //     dist[1] = 0;

    //     List<(int node, int cost)>[] graph = new List<(int node, int cost)>[N + 1];
    //     for (int i = 0; i <= N; i++) graph[i] = new List<(int node, int cost)>();
    //     for(int i = 0; i < road.GetLength(0); i++)
    //     {
    //         var node1 = road[i, 0];
    //         var node2 = road[i, 1];
    //         var cost = road[i, 2];

    //         graph[node1].Add((node2, cost));
    //         graph[node2].Add((node1, cost));
    //     }

    //     bool[] visited = new bool[N + 1];
    //     visited[0] = true;

    //     for(int i = 0; i < N; i++)
    //     {
    //         int currNode = -1;
    //         int currDist = int.MaxValue;
    //         for(int j = 1; j <= N; j++)
    //         {
    //             if(!visited[j] && dist[j] < currDist)
    //             {
    //                 currDist = dist[j];
    //                 currNode = j;
    //             }
    //         }

    //         if(currNode == -1) break;

    //         visited[currNode] = true;

    //         foreach(var elem in graph[currNode])
    //         {
    //             int next = elem.node;
    //             int cost = elem.cost;
    //             int nextDist = currDist + cost;
    //             if(nextDist < dist[next])
    //             {
    //                 dist[next] = nextDist;
    //             }
    //         }
    //     }

    //     for (int i = 1; i <= N; i++) if (dist[i] <= K) answer++;
    //     return answer;
    // }

    // public int solution120901(int N, int[,] road, int K)
    // {
        // int answer = 0;

        // int[] dist = new int[N + 1];
        // for(int i = 0; i < dist.Length; i++) dist[i] = int.MaxValue;
        // dist[1] = 0;

        // List<(int node, int cost)>[] graph = new List<(int node, int cost)>[N + 1];
        // for (int i = 0; i <= N; i++) graph[i] = new List<(int node, int cost)>();
        // for(int i = 0; i < road.GetLength(0); i++)
        // {
        //     var node1 = road[i, 0];
        //     var node2 = road[i, 1];
        //     var cost = road[i, 2];

        //     graph[node1].Add((node2, cost));
        //     graph[node2].Add((node1, cost));
        // }

        // PriorityQueue<(int node, int cost), int> priorityQueue = new PriorityQueue<(int node, int cost), int>();
        // priorityQueue.Enqueue((1, 0), 0);

        // while(priorityQueue.Count > 0)
        // {
        //     var (currNode, currDist) = priorityQueue.Dequeue();
        //     if(currDist > dist[currNode]) continue;

        //     foreach(var elem in graph[currNode])
        //     {
        //         int next = elem.node;
        //         int cost = elem.cost;
        //         int nextDist = currDist + cost;
        //         if(nextDist < dist[next])
        //         {
        //             dist[next] = nextDist;
        //             priorityQueue.Enqueue((next, nextDist), nextDist);
        //         }
        //     }
        // }

        // foreach(var elem in dist)
        // {
        //     if(elem <= K) answer += 1;
        // }
        // return answer;
    // }

    public int solution120902(string[] board) {
        int answer = -1;
        int h = board.Length;
        int w = board[0].Length;

        int startY = -1;
        int startX = -1;
        for(int y = 0; y < h; y++)
        {
            int x = board[y].IndexOf('R');
            if(x != -1)
            {
                startY = y;
                startX = x;
                break;
            }
        }

        int[] dx = {0, 0, 1, -1};
        int[] dy = {1, -1, 0, 0};

        var queue = new Queue<(int y, int x, int count)>();
        queue.Enqueue((startY, startX, 0));
        bool[,] visited = new bool[h, w];

        queue.Enqueue((startY, startX, 0));
        visited[startY, startX] = true;

        while(queue.Count > 0)
        {
            var (y, x, count) = queue.Dequeue();
            if (board[y][x] == 'G') return count;

            for(int dir = 0; dir < 4; dir++)
            {
                int nx = x;
                int ny = y;
                while(true)
                {
                    int tx = nx + dx[dir];
                    int ty = ny + dy[dir];

                    if (tx < 0 || ty < 0 || tx >= w || ty >= h) break;
                    if (board[ty][tx] == 'D') break;

                    nx = tx;
                    ny = ty;
                }
                if (nx == x && ny == y) continue;
                if (visited[ny, nx]) continue;
                visited[ny, nx] = true;
                queue.Enqueue((ny, nx, count + 1));
            }
        }
        return answer;
    }

    public int solution120903(int n, int k, int[] enemy) {

        if(enemy.Length <= k) return k;
        int answer = k;
        int deletedSum = 0;
        int enemySum = 0;
        SortedDictionary<int, int> delete = new SortedDictionary<int, int>();
        for(int i = 0; i < k; i++)
        {
            if(!delete.ContainsKey(enemy[i])) delete.Add(enemy[i], 0);
            delete[enemy[i]] += 1;
            deletedSum += enemy[i];
            enemySum += enemy[i];
        }
        for(int i = k; i < enemy.Length; i++)
        {
            int currEnemy = enemy[i];
            int minDelete = delete.First().Key;;

            if(currEnemy > minDelete)
            {
                delete[minDelete] -= 1;
                if(delete[minDelete] == 0) delete.Remove(minDelete);
                if(!delete.ContainsKey(currEnemy)) delete.Add(currEnemy, 0);
                delete[currEnemy] += 1;

                deletedSum -= minDelete;
                deletedSum += currEnemy;
            }
            enemySum += currEnemy;

            if(n < enemySum - deletedSum) break;
            else answer += 1;
        }
        return answer;
    }
}

