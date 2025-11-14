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

        int answer = solution.solution111403([0, 0, 0, 0, 0]);

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

    public int solution111204(int[] arr)
    {
        int answer = arr[0];
        for (int i = 1; i < arr.Length; i++) answer = LCM(answer, arr[i]);
        return answer;
    }

    public int LCM(int a, int b)
    {
        return a * b / GCD(a, b);
    }

    public int GCD(int a, int b)
    {
        if (b == 0) return a;
        else return GCD(b, a % b);
    }

    // public long solution111205(int n)
    // {
    //     long answer = 0;
    //     long countOne = n;
    //     long countTwo = 0;
    //     long len = countOne + countTwo;
    //     while (countOne >= 0)
    //     {
    //         answer += Factorial(len) / (Factorial(countOne) * Factorial(countTwo));
    //         answer %= 1234567;
    //         countOne -= 2;
    //         countTwo += 1;
    //         len = countOne + countTwo;
    //     }
    //     return answer;
    // }

    // public long Factorial(long num)
    // {
    //     if (num == 0 || num == 1) return 1;
    //     else return num * Factorial(num - 1);
    // }

    public long solution111205(int n)
    {
        long answer = 0;
        long[] fibo = new long[n + 2];
        fibo[1] = 1;
        fibo[2] = 2;
        for (int i = 3; i <= n; i++) fibo[i] = (fibo[i - 1] + fibo[i - 2]) % 1234567;
        answer = fibo[n];
        return answer;
    }

    public int[] solution111301(int n, string[] words)
    {
        int[] answer = new int[2];
        Dictionary<int, HashSet<string>> store = new Dictionary<int, HashSet<string>>();
        HashSet<string> used = new HashSet<string>();
        for (int i = 1; i <= n; i++) store.Add(i, new HashSet<string>());

        int idx = 1;
        char prev = words[0][words[0].Length - 1];
        char curr = '\0';
        store[idx].Add(words[0]);
        used.Add(words[0]);
        idx += 1;

        for (int i = 1; i < words.Length; i++)
        {
            curr = words[i][0];
            if (curr != prev || store[idx].Contains(words[i]) || used.Contains(words[i]))
            {
                answer[0] = idx;
                answer[1] = i / n + 1;
                break;
            }
            store[idx].Add(words[i]);
            used.Add(words[i]);
            prev = words[i][words[i].Length - 1];
            idx += 1;
            if (idx > n) idx = 1;
        }
        return answer;
    }
    
    public int solution111302(int n, int a, int b)
    {
        int answer = 1;
        int aIdx = a - 1;
        int bIdx = b - 1;
        while (Math.Abs(a - b) != 1 || aIdx / 2 != bIdx / 2)
        {
            aIdx = a - 1;
            bIdx = b - 1;

            aIdx /= 2;
            bIdx /= 2;

            if (a % 2 == 1) a -= aIdx;
            else if (a % 2 == 0) a -= aIdx + 1;;
            if (b % 2 == 1) b -= bIdx;
            else if (b % 2 == 0) b -= bIdx + 1;

            answer += 1;
        }
        return answer;
    }

    public int solution111303(int[] elements) {
        int answer = 0;
        List<int> able = new List<int>();

        for(int i = 0; i < elements.Length; i++)
        {
            int curr = elements[i];
            able.Add(curr);
            for(int j = 1; j < elements.Length; j++)
            {
                curr += elements[(i + j) % elements.Length];
                able.Add(curr);
            }
        }
        able.Sort();
        able = able.Distinct().ToList();
        answer = able.Count();
        return answer;
    }

    public int solution111304(string[] want, int[] number, string[] discount) {
        int answer = 0;
        Dictionary<string, int> store = new Dictionary<string, int>();
        for(int i = 0; i < want.Length; i++) store.Add(want[i], number[i]);

        for(int i = 0; i < discount.Length; i++)
        {
            Dictionary<string, int> able = new Dictionary<string, int>();
            for(int j = 0; j < want.Length; j++) able.Add(want[j], 0);

            int endDay = Math.Min(i + 10, discount.Length);
            for(int j = i; j < endDay; j++)
            {
                if(!able.TryGetValue(discount[j], out var Value)) able.Add(discount[j], 0);
                able[discount[j]] += 1;
            }

            if(able.Count == store.Count && !able.Except(store).Any()) answer += 1;
        }
        return answer;
    }

    public int solution111305(string s) {
        int answer = 0;
        StringBuilder stringBuilder = new StringBuilder(s);
        for(int i = 0; i < s.Length; i++)
        {
            char first = stringBuilder[0];
            stringBuilder.Remove(0, 1);
            stringBuilder.Append(first);

            bool isValid = true;
            Stack<Char> checker = new Stack<char>();
            foreach (var elem in stringBuilder.ToString())
            {
                if (elem == '(' || elem == '[' || elem == '{') checker.Push(elem);
                else if (elem == ')' || elem == ']' || elem == '}')
                {
                    if (checker.Count == 0)
                    {
                        isValid = false;
                        continue;
                    }
                    char top = checker.Pop();
                    if (elem == ')' && top != '(')
                    {
                        isValid = false;
                        continue;
                    }
                    if (elem == ']' && top != '[')
                    {
                        isValid = false;
                        continue;
                    }
                    if (elem == '}' && top != '{')
                    {
                        isValid = false;
                        continue;
                    }
                }
            }
            if (checker.Count != 0) isValid = false;

            if(isValid) answer += 1;
        }
        return answer;
    }

    public int[] solution111401(int n, long left, long right) {
        int[] answer = new int[right - left + 1];

        long idx = 0;
        for(long i = left; i <= right; i++)
        {
            long row = i / n;
            long col = i % n;
            long store = 0;

            if(row >= col) store = row + 1;
            else store = (row + 1) + (col - row);

            answer[idx] = (int)store;
            idx += 1;
        }
        return answer;
    }

    public int[,] solution111402(int[,] arr1, int[,] arr2) {
        int row = arr1.GetLength(0);
        int col = arr2.GetLength(1);

        int[,] answer = new int[row, col];
        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                for(int k = 0; k < arr1.GetLength(1); k++)
                {
                    int x = arr1[i, k];
                    int y = arr2[k, j];
                    answer[i, j] += x * y;
                }
            }
        }
        return answer;
    }

    public int solution111403(int[] citations) {
        int answer = 0;

        int candidate = 1;
        Dictionary<int, int> candidates = new Dictionary<int, int>();
        foreach(var elem in citations)
        {
            int count = citations.Count(x => x >= candidate);
            candidates[candidate] = count;
            candidate += 1;
        }

        candidate = 0;
        foreach(var elem in candidates)
        {
            int h = elem.Key;
            int num = elem.Value;
            if (h <= num && candidate < h) candidate = h;
        }
        answer = candidate;
        return answer;
    }
}

