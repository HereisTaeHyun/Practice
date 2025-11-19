using System;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Formats.Asn1;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Linq.Expressions;


internal static class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();

        int answer = solution.solution111904("ULURRDLLU");
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    int answer111903 = 0;
    public int solution111801(int k, int[,] dungeons) {
        int answer = 0;
        bool[] visit = new bool[dungeons.GetLength(0)];
        answer = DFS1118(k, visit, dungeons, answer);
        return answer;
    }
    public int DFS1118(int k, bool[] visit, int[,] dungeons, int prev)
    {
        int curr = prev;
        for(int i = 0; i < dungeons.GetLength(0); i++)
        {
            if(visit[i] || dungeons[i, 0] > k) continue;

            visit[i] = true;
            k -= dungeons[i, 1];
            curr = Math.Max(DFS1118(k, visit, dungeons, prev + 1), curr);
            visit[i] = false;
        }
        return curr;
    }

    public int[] solution111802(int[] progresses, int[] speeds) {
        int[] answer = new int[100];
        Dictionary<int, int> develop = new Dictionary<int, int>();
        for(int i = 0; i < progresses.Length; i++)
        {
            develop[i] = (100 - progresses[i]) / speeds[i];
            if((100 - progresses[i]) % speeds[i] > 0) develop[i] += 1;
        }

        int dayIdx = 0;
        int day = develop[dayIdx];
        int checkIdx = 0;
        foreach(var elem in develop)
        {
            int currDay = develop[checkIdx];

            if(currDay <= day) answer[dayIdx] += 1;
            else
            {
                day = currDay;
                dayIdx += 1;
                answer[dayIdx] += 1;
            }
            checkIdx += 1;
        }

        int count = answer.Count(x => x == 0);
        Array.Resize(ref answer, answer.Length - count);
        return answer;
    }

    public int solution111803(int[] priorities, int location) {
        int answer = 0;

        Queue<(int index, int priority)> store = new Queue<(int index, int priority)>();
        for (int i = 0; i < priorities.Length; i++) store.Enqueue((i, priorities[i]));

        bool activate = true;
        while(activate)
        {
            var curr = store.Peek();
            int priority = curr.priority;
            bool isMax = !store.Any(x => x.priority > priority);

            if(isMax)
            {
                curr = store.Dequeue();
                int idx = curr.index;
                answer += 1;
                if(idx == location) activate = false;
            }
            else
            {
                curr = store.Dequeue();
                store.Enqueue(curr);
            }
        }
        return answer;
    }

    public int solution111901(int[] topping) {
        int answer = 0;
        HashSet<int> left = new HashSet<int>();
        Dictionary<int, int> right = new Dictionary<int, int>();
        foreach(var elem in topping)
        {
            if(!right.ContainsKey(elem)) right.Add(elem, 0);
            right[elem] += 1;
        }

        foreach(var elem in topping)
        {
            left.Add(elem);
            right[elem] -= 1;
            if(right[elem] == 0) right.Remove(elem);
            if(left.Count == right.Count) answer += 1;
        }
        return answer;
    }

    public int solution111902(int[,] maps) {
        int answer = 0;
        int h = maps.GetLength(0);
        int w = maps.GetLength(1);

        int[] dx = {0, 0, 1, -1};
        int[] dy = {1, -1, 0, 0};

        bool[,] visited = new bool[h, w];
        var q = new Queue<(int y, int x, int dist)>();

        visited[0, 0] = true;
        q.Enqueue((0, 0, 1));

        while(q.Count > 0)
        {
            var (y, x, dist) = q.Dequeue();
            if (x == w - 1 && y == h - 1) return dist;

             for(int dir = 0; dir < 4; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];

                if (nx < 0 || ny < 0 || nx >= w || ny >= h) continue;
                if (visited[ny, nx]) continue;
                if (maps[ny, nx] == 0) continue;

                visited[ny, nx] = true;
                q.Enqueue((ny, nx, dist + 1));
            }
        }
        return answer;
    }

    // public void DFS1119(int x, int y, bool[,] visited, int[,] maps, List<int> store, int count)
    // {
    //     int h = maps.GetLength(0);
    //     int w = maps.GetLength(1);
    //     if (x == w - 1 && y == h - 1) store.Add(count);

    //     if (visited[y, x]) return;
        
    //     visited[y, x] = true;
    //     int[] dx = {0, 0, 1, -1};
    //     int[] dy = {1, -1, 0, 0};

    //     for(int dir = 0; dir < 4; dir++)
    //     {
    //         int nx = x + dx[dir];
    //         int ny = y + dy[dir];

    //         if (nx < 0 || ny < 0 || nx >= w || ny >= h) continue;
    //         if (visited[ny, nx]) continue;
    //         if (maps[ny, nx] == 0) continue;

    //         DFS1119(nx, ny, visited, maps, store, count + 1);
    //     }

    //     visited[y, x] = false;
    // }

    public int solution111903(int[] numbers, int target) {
        DFS1119(0, 0, numbers.Length, target, numbers);
        return answer111903;
    }

    public void DFS1119(int sum, int idx, int end, int target, int[] numbers)
    {
        if(idx < end)
        {
            DFS1119(sum + numbers[idx], idx + 1, end, target, numbers);
            DFS1119(sum - numbers[idx], idx + 1, end, target, numbers);
        }
        else if(sum == target) answer111903 += 1;
    }

    public int solution111904(string dirs) {
        int answer = 0;
        HashSet<Tuple<int, int, int, int>> path = new HashSet<Tuple<int, int, int, int>>();
        int currX = 5;
        int currY = 5;
        char[] commands = dirs.ToCharArray();

        foreach(var elem in commands)
        {
            if(Checker(currX, currY, elem, out int newX, out int newY))
            {
                path.Add(Tuple.Create(currX, currY, newX, newY));
                path.Add(Tuple.Create(newX, newY, currX, currY));;
                currX = newX;
                currY = newY;
            }
        }
        answer = path.Count / 2;
        return answer;
    }

    public bool Checker(int currX, int currY, char command, out int newX, out int newY)
    {
        newX = currX;
        newY = currY;

        switch(command)
        {
            case 'U': newY -= 1; break;
            case 'D': newY += 1; break;
            case 'L': newX -= 1; break;
            case 'R': newX += 1; break;
        }

        if (newX < 0 || newY < 0 || newX >= 11 || newY >= 11) return false;
        return true;
    }
}

