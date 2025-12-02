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

        string answer = solution.solution120202("1010", 2);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public int solution120101(int[] queue1, int[] queue2) {
        int answer = 0;
        Queue<long> q1 = new Queue<long>(queue1.Select(x => (long)x));
        Queue<long> q2 = new Queue<long>(queue2.Select(x => (long)x));

        long q1Sum = q1.Sum();
        long q2Sum = q2.Sum();
        long allSum = q1Sum + q2Sum;

        if (allSum % 2 != 0) return -1;

        long targetSum = allSum / 2;
        long maxCount = (q1.Count + q2.Count) * 2;

        while(q1Sum != q2Sum)
        {
            if(answer > maxCount) return -1;
            if(q1Sum > q2Sum)
            {
                long curr = q1.Dequeue();
                q2.Enqueue(curr);
                q1Sum -= curr;
                q2Sum += curr;
                answer += 1;
            }
            else if(q1Sum < q2Sum)
            {
                long curr = q2.Dequeue();
                q1.Enqueue(curr);
                q1Sum += curr;
                q2Sum -= curr;
                answer += 1;
            }
        }
        return answer;
    }

    public int[] solution120102(int[,] arr) {
        int[] answer = new int[2];
        List<int> store = new List<int>();
        int scope = arr.GetLength(0);
        int x = 0;
        int y = 0;

        Quad(x, y, scope, arr, store);

        answer[0] = store.Count(v => v == 0);
        answer[1] = store.Count(v => v == 1);
        return answer;
    }

    void Quad(int x, int y, int scope, int[,] arr, List<int> store)
    {
        if(CheckQuad(x, y, scope, arr))
        {
            store.Add(arr[x, y]);
            return;
        }

        scope /= 2;
        Quad(x, y, scope, arr, store);
        Quad(x, y + scope, scope, arr, store);
        Quad(x + scope, y, scope, arr, store);
        Quad(x + scope, y + scope, scope, arr, store);
    }

    bool CheckQuad(int x, int y, int scope, int[,] arr)
    {
        int first = arr[x, y];
        for (int i = x; i < x + scope; i++)
        {
            for (int j = y; j < y + scope; j++)
            {
                if (arr[i, j] != first)
                    return false;
            }
        }
        return true;
    }

    public int solution120103(string numbers) {
        int answer = 0;
        char[] able = numbers.ToCharArray();
        List<string> maked = new List<string>();
        bool[] used = new bool [able.Length];

        for(int i = 0; i < able.Length; i++)
        {
            string root = able[i].ToString();
            maked.Add(root);
            DFS1201(i, root, used, able, maked);
        }

        HashSet<int> makedNums = new HashSet<int>();
        foreach(var elem in maked)
        {
            var currNum = int.Parse(elem);
            makedNums.Add(currNum);
        }

        int maxNum = makedNums.Max();
        bool[] eratos = Eratos(maxNum);

        foreach(var elem in makedNums)
        {
            if(!eratos[elem]) continue;
            answer += 1;
        }
        return answer;
    }

    public void DFS1201(int node, string prev, bool[] used, char[] able, List<string> maked)
    {
        used[node] = true;

        for(int i = 0; i < able.Length; i++)
        {
            if(used[i]) continue;
            string make = prev + able[i];
            maked.Add(make);
            DFS1201(i, make, used, able, maked);
        }
        used[node] = false;
    }

    public bool[] Eratos(int n)
    {
        bool[] eratos = Enumerable.Repeat(true, n + 1).ToArray();
        eratos[0] = false;
        eratos[1] = false;
        for (int i = 2; i * i <= n; i++)
        {
            if (!eratos[i]) continue;
            for (int j = i * i; j <= n; j += i)
            {
                eratos[j] = false;
            }
        }
        return eratos;
    }

    public int solution120201(int bridge_length, int weight, int[] truck_weights) {
        int answer = 0;
        int time = 0;

        var bridgeData = (length: bridge_length, maxWeight: weight, currWeight: 0);
        Queue<int> waitingTruck = new Queue<int>(truck_weights);
        Queue<(int weight, int enterTime)> onBridge = new Queue<(int weight, int enterTime)>();

        while(waitingTruck.Count > 0 || onBridge.Count > 0)
        {
            time += 1;

            if(onBridge.Count > 0)
            {
                var currTruck = onBridge.Peek();
                if(time - currTruck.enterTime >= bridgeData.length)
                {
                    var outTruck = onBridge.Dequeue();
                    bridgeData.currWeight -= outTruck.weight;
                }
            }

            if(waitingTruck.Count == 0) continue;

            var nextTruck = waitingTruck.Peek();
            if(bridgeData.currWeight + nextTruck <= bridgeData.maxWeight)
            {
                var inTruckWeight = waitingTruck.Dequeue();
                bridgeData.currWeight += inTruckWeight;
                onBridge.Enqueue((inTruckWeight, time));
            }
        }
        answer = time;
        return answer;
    }

    public string solution120202(string number, int k) {
        string answer = "";
        int[] numArray = number.Select(x => x - '0').ToArray();
        Stack<int> store = new Stack<int>();
        
        store.Push(numArray[0]);
        int prev = store.Peek();
        for(int i = 1; i < numArray.Length; i++)
        {
            if(store.Count != 0) prev = store.Peek();
            int curr = numArray[i];

            if(k == 0 || prev >= curr || store.Count == 0) store.Push(curr);
            else if(prev < curr)
            {
                while(prev < curr)
                {
                    store.Pop();
                    k -= 1;
                    if(k == 0 || store.Count == 0) break;
                    prev = store.Peek();
                }
                store.Push(curr);
            }
        }

        while(k > 0)
        {
            store.Pop();
            k -= 1;
        }

        StringBuilder stringBuilder = new StringBuilder();
        while (store.Count > 0) stringBuilder.Append(store.Pop());
        char[] charArray = stringBuilder.ToString().ToCharArray();
        Array.Reverse(charArray);
        answer = new string(charArray);

        return answer;
    }
}

