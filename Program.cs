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

        int answer = solution.solution111803([2, 3, 1, 2], 3);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public int solution111801(int k, int[,] dungeons) {
        int answer = 0;
        bool[] visit = new bool[dungeons.GetLength(0)];
        answer = dfs(k, visit, dungeons, answer);
        return answer;
    }
    public int dfs(int k, bool[] visit, int[,] dungeons, int prev)
    {
        int curr = prev;
        for(int i = 0; i < dungeons.GetLength(0); i++)
        {
            if(visit[i] || dungeons[i, 0] > k) continue;

            visit[i] = true;
            k -= dungeons[i, 1];
            curr = Math.Max(dfs(k, visit, dungeons, prev + 1), curr);
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
}

