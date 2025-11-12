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

        int answer = solution.solution111203(5000);

        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public string solution110801(string video_len, string pos, string op_start, string op_end, string[] commands)
    {
        string answer = "";
        int[] vidoeData = video_len.Split(':').Select(int.Parse).ToArray();
        int[] vidoePosData = pos.Split(':').Select(int.Parse).ToArray();
        int[] opStartData = op_start.Split(':').Select(int.Parse).ToArray();
        int[] opEndData = op_end.Split(':').Select(int.Parse).ToArray();
        int[] resultData = new int[2];

        int videoSec = 60 * vidoeData[0] + vidoeData[1];
        int currPosSec = 60 * vidoePosData[0] + vidoePosData[1];
        int opStartSec = 60 * opStartData[0] + opStartData[1];
        int opEndSec = 60 * opEndData[0] + opEndData[1];

        foreach (var elem in commands)
        {
            if (opStartSec <= currPosSec && currPosSec <= opEndSec) currPosSec = opEndSec;

            if (elem == "next") currPosSec += 10;
            else if (elem == "prev") currPosSec -= 10;

            if (currPosSec < 0) currPosSec = 0;
            else if (currPosSec > videoSec) currPosSec = videoSec;
        }

        if (opStartSec <= currPosSec && currPosSec <= opEndSec) currPosSec = opEndSec;

        while (currPosSec >= 60)
        {
            currPosSec -= 60;
            resultData[0] += 1;
        }
        resultData[1] = currPosSec;


        if (resultData[0] < 10) answer += '0';
        answer += resultData[0];
        answer += ':';
        if (resultData[1] < 10) answer += '0';
        answer += resultData[1];

        return answer;
    }

    public int solution111001(int n, int w, int num)
    {
        int answer = 0;

        int rows = 0;
        int cols = 0;
        if (n % w == 0)
        {
            rows = n / w;
            cols = w;
        }
        else
        {
            rows = n / w + 1;
            cols = w;
        }
        int[,] store = new int[rows, cols];

        int idx = 1;
        for (int i = 0; i < store.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < store.GetLength(1); j++)
                {
                    store[i, j] = idx;
                    idx++;
                    if (idx > n) break;
                }
            }
            else if (i % 2 == 1)
            {
                for (int j = store.GetLength(1) - 1; j >= 0; j--)
                {
                    store[i, j] = idx;
                    idx++;
                    if (idx > n) break;
                }
            }
        }

        bool find = false;
        int x = 0;
        int y = 0;
        for (int i = 0; i < store.GetLength(0); i++)
        {
            if (find) break;
            for (int j = 0; j < store.GetLength(1); j++)
            {
                if (store[i, j].Equals(num))
                {
                    x = i;
                    y = j;
                    find = true;
                }
            }
        }

        answer = store.GetLength(0) - x;
        if (store[store.GetLength(0) - 1, y] == 0) answer -= 1;
        return answer;
    }

    public int solution111002(string[] friends, string[] gifts)
    {
        int answer = 0;
        var data = new Dictionary<string, (Dictionary<string, GiftData> giftData, int score, int willGifted)>();

        foreach (var elem in friends) data[elem] = (new Dictionary<string, GiftData>(), 0, 0);

        for (int i = 0; i < friends.Length; i++)
        {
            var from = friends[i];
            var dict = data[from].giftData;
            for (int j = 0; j < friends.Length; j++)
            {
                if (friends[i] == friends[j]) continue;

                var to = friends[j];
                if (!dict.ContainsKey(to)) dict.Add(to, new GiftData(0, 0));
            }
        }
        for (int i = 0; i < gifts.Length; i++)
        {
            var currGiftData = gifts[i].Split(" ");
            var give = currGiftData[0];
            var recieve = currGiftData[1];

            var giveData = data[give].giftData;
            var recieveData = data[recieve].giftData;

            giveData[recieve].give += 1;
            recieveData[give].recieve += 1;
        }

        for (int i = 0; i < friends.Length; i++)
        {
            var currGiftData = data[friends[i]].giftData;
            int giveCount = 0;
            int recieveCount = 0;
            foreach (var elem in currGiftData.Values)
            {
                giveCount += elem.give;
                recieveCount += elem.recieve;
            }

            data[friends[i]] = (currGiftData, giveCount - recieveCount, 0);
        }

        for (int i = 0; i < friends.Length; i++)
        {
            var currData = data[friends[i]];
            var currGiftData = currData.giftData;

            for (int j = 0; j < friends.Length; j++)
            {
                if (friends[i] == friends[j]) continue;

                var targetData = data[friends[j]];

                if (currGiftData[friends[j]].give > currGiftData[friends[j]].recieve) currData.willGifted += 1;
                else if(currGiftData[friends[j]].give == currGiftData[friends[j]].recieve)
                {
                    if (currData.score > targetData.score) currData.willGifted += 1;
                    else if (currData.score == targetData.score) continue;
                }
                else if (currGiftData[friends[j]].give == 0 && currGiftData[friends[j]].recieve == 0)
                {
                    if (currData.score > targetData.score) currData.willGifted += 1;
                    else if (currData.score == targetData.score) continue;
                }
            }

            data[friends[i]] = (currGiftData, currData.score, currData.willGifted);
        }

        int max = int.MinValue;
        for (int i = 0; i < friends.Length; i++)
        {
            var currData = data[friends[i]];
            if (max < currData.willGifted) max = currData.willGifted;
        }
        answer = max;

        return answer;
    }

    public class GiftData
    {
        public int give;
        public int recieve;

        public GiftData(int give, int recieve)
        {
            this.give = give;
            this.recieve = recieve;
        }
    }

    public string solution111101(string s)
    {
        string answer = "";
        string[] store = s.Split(' ');
        int[] intStore = new int[store.Length];
        for (int i = 0; i < store.Length; i++) intStore[i] = int.Parse(store[i]);

        int min = intStore.Min();
        int max = intStore.Max();

        answer = min + " " + max;
        return answer;
    }

    public bool solution111102(string s)
    {
        bool answer = true;
        Stack<char> store = new Stack<char>();

        foreach (var elem in s)
        {
            if (elem == '(') store.Push(elem);
            else if (elem == ')')
            {
                if (store.Count == 0) return false;
                store.Pop();
            }
        }

        if (store.Count != 0) answer = false;
        return answer;
    }

    public int solution111103(int[] A, int[] B)
    {
        int answer = 0;
        Array.Sort(A);
        Array.Sort(B);
        B = B.Reverse().ToArray();
        for (int i = 0; i < A.Length; i++) answer += A[i] * B[i];
        return answer;
    }

    public string solution111104(string s)
    {
        string answer = "";
        s = s.ToLower();

        for (int i = 0; i < s.Length;)
        {
            if (i == 0) answer += char.ToUpper(s[i]);
            else if (s[i] == ' ')
            {
                if (i == s.Length - 1) answer += s[i];
                else if (s[i + 1] != ' ')
                {
                    answer += ' ';
                    answer += char.ToUpper(s[i + 1]);
                    i++;
                }
                else answer += ' ';
            }
            else answer += s[i];
            i++;
        }
        return answer;
    }

    public int[] solution111105(string s)
    {
        int[] answer = new int[2];
        int count = 0;
        int store = 0;
        while (s != "1")
        {
            count = s.Count(x => x == '0');
            s = s.Replace("0", "");
            answer[1] += count;

            store = s.Length;
            s = Convert.ToString(store, 2);
            answer[0] += 1;
        }
        return answer;
    }

    public int solution111106(int n)
    {
        int answer = 0;
        string binaryN = Convert.ToString(n, 2);
        int count = binaryN.ToString().Count(x => x == '1');
        bool active = true;

        int store = n;
        int currCount = 0;
        while (active)
        {
            store += 1;
            string currBinary = Convert.ToString(store, 2);
            currCount = currBinary.ToString().Count(x => x == '1');
            if (count == currCount) active = false;
        }
        answer = store;
        return answer;
    }

    public int solution111107(int n)
    {
        int answer = 0;
        long a = 0;
        long b = 1;
        long c = 1;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        answer = (int)(c % 1234567);
        return answer;
    }

    public int[] solution111201(int brown, int yellow)
    {
        int[] answer = new int[2];
        int size = brown + yellow;
        for (int h = 3; h <= size; h++)
        {
            int w = size / h;
            if ((w - 2) * (h - 2) == yellow)
            {
                answer[0] = w;
                answer[1] = h;
                return answer;
            }
        }
        return answer;
    }

    public int solution111202(int k, int[] tangerine)
    {
        int answer = 0;
        var tangerineCount = tangerine.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var sorted = tangerineCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

        int idx = 0;
        int count = 0;
        while (count < k)
        {
            count += sorted[idx].Value;
            answer += 1;
            idx += 1;
        }
        return answer;
    }
    
    public int solution111203(int n)
    {
        int answer = 0;
        List<int> point = new List<int>();
        int store = n;
        point.Add(store);
        while (store != 1)
        {
            store /= 2;
            point.Add(store);
        }

        int currPos = 0;
        for (int i = point.Count - 1; i >= 0; i--)
        {
            if (currPos * 2 == point[i]) currPos *= 2;
            else if (currPos != point[i])
            {
                currPos *= 2;
                answer += point[i] - currPos;
                currPos += point[i] - currPos;
            }
        }
        return answer;
    }
}

