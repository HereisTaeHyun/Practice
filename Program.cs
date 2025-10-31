using System;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Formats.Asn1;
using System.Text.RegularExpressions;


internal static class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();

        int answer = solution.solution103005([2, 1, 1, 2, 3, 1, 2, 3, 1]);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public int Solution092401(int price)
    {
        int answer = 0;
        if (price >= 500000) answer = SaleCalculate(price, 0.2f);
        else if (price >= 300000) answer = SaleCalculate(price, 0.1f);
        else if (price >= 100000) answer = SaleCalculate(price, 0.05f);
        else answer = price;
        return answer;
    }

    private static int SaleCalculate(float price, float salePercent)
    {
        var sale = price * salePercent;
        float result = price -= sale;
        return (int)result;
    }

    public string solution092402(string rsp)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var elem in rsp)
        {
            if (elem == '2') sb.Append('0');
            else if (elem == '0') sb.Append('5');
            else if (elem == '5') sb.Append('2');
        }
        return sb.ToString();
    }

    public int solution092403(int[] box, int n)
    {
        int answer = 0;

        int ableWidth = box[0] / n;
        int ableLength = box[1] / n;
        int ableHeight = box[2] / n;

        answer = ableWidth * ableLength * ableHeight;
        return answer;
    }

    public int[] solution092404(string my_string)
    {
        List<int> answer = new List<int>();
        foreach (var elem in my_string)
        {
            if (elem - '0' >= 0 && elem - '0' <= 9)
            {
                answer.Add(elem - '0');
            }
        }
        answer.Sort();
        return answer.ToArray();
    }

    public int[] solution092501(int[] num_list, int n)
    {
        int count = n - 1;
        int[] answer = num_list[count..];
        return answer;
    }

    public int[] solution092502(int[] num_list, int n)
    {
        int start = n - 1;
        int len = num_list.Length - start;
        int[] answer = new int[len];
        Array.Copy(num_list, start, answer, 0, len);
        return answer;
    }

    public int solution092503(int[] numbers)
    {
        int answer = 0;
        int max = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] * numbers[j] > max)
                {
                    max = numbers[i] * numbers[j];
                }
            }
        }
        answer = max;
        return answer;
    }

    public string solution092504(string cipher, int code)
    {
        string answer = "";
        for (int i = 1; i <= cipher.Length; i++)
        {
            if (i % code == 0)
            {
                answer += cipher[i - 1];
            }
        }
        return answer;
    }

    public int solution092505(int n)
    {
        int answer = 0;
        if (n % 2 != 0)
        {
            for (int i = 0; i <= n; i += 2) answer += i;
        }
        else
        {
            for (int i = 0; i <= n; i += 2) answer += i * i;
        }
        return answer;
    }

    public string solution092506(string my_string, int k)
    {
        string answer = "";
        for (int i = 0; i < k; i++)
        {
            answer += my_string;
        }
        return answer;
    }

    public string solution092507(string my_string)
    {
        string answer = "";
        char[] store = my_string.ToLower().ToCharArray();
        Array.Sort(store);
        foreach (var elem in store)
        {
            answer += elem;
        }
        return answer;
    }

    public int solution092508(string my_string, string is_prefix)
    {
        if (is_prefix.Length > my_string.Length) return 0;
        int answer = 1;
        for (int i = 0; i < is_prefix.Length; i++)
        {
            if (my_string[i] != is_prefix[i])
            {
                answer = 0;
                break;
            }
        }
        return answer;
    }

    public int solution092509(int a, int b)
    {
        int answer = 0;
        string stringA = a.ToString();
        string stringB = b.ToString();

        int candidateA = int.Parse(stringA + stringB);
        int candidateB = int.Parse(stringB + stringA);
        return answer;
    }

    public int[] solution092510(int[] num_list)
    {
        int[] answer = new int[num_list.Length + 1];

        for (int i = 0; i < num_list.Length; i++)
            answer[i] = num_list[i];
        if (num_list[^1] > num_list[^2])
            answer[^1] = num_list[^1] - num_list[^2];
        else
            answer[^1] = num_list[^1] * 2;
        return answer;
    }

    public int solution092511(int a, int b, int c)
    {
        int answer = 0;
        int count = 0;
        int[] intArray = new[] { a, b, c };
        for (int i = 0; i < intArray.Length; i++)
        {
            for (int j = i + 1; j < intArray.Length; j++)
            {
                if (intArray[i] == intArray[j])
                {
                    count += 1;
                }
            }
        }

        switch (count)
        {
            case 0:
                answer = a + b + c;
                break;
            case 1:
                answer = (a + b + c) * (a * a + b * b + c * c);
                break;
            case 3:
                answer = (a + b + c) * (a * a + b * b + c * c) * (a * a * a + b * b * b + c * c * c);
                break;
        }
        return answer;
    }

    public int solution092512(int num, int k)
    {
        int answer = -1;
        string stringNum = num.ToString();
        for (int i = 0; i < stringNum.Length; i++)
        {
            Console.WriteLine(stringNum[i] == k);
            if (stringNum[i] == k)
            {
                answer = i;
                break;
            }
        }
        return answer;
    }

    public int solution092513(string myString, string pat)
    {
        int answer = 0;
        myString = myString.Replace('A', 'C');
        myString = myString.Replace('B', 'A');
        myString = myString.Replace('C', 'B');

        if (myString.Contains(pat))
            answer = 1;
        return answer;
    }

    public int solution092514(int[] num_list, int n)
    {
        int answer = 0;
        foreach (var elem in num_list)
        {
            if (elem == n)
                answer = 1;
        }
        return answer;
    }

    public int[] solution092601(int[] numbers, string direction)
    {
        LinkedList<int> answer = new LinkedList<int>();
        int store = 0;
        foreach (var elem in numbers) answer.AddLast(elem);
        if (direction == "right")
        {
            store = answer.Last!.Value;
            answer.RemoveLast();
            answer.AddFirst(store);
        }
        else if (direction == "left")
        {
            store = answer.First!.Value;
            answer.RemoveFirst();
            answer.AddLast(store);
        }
        return answer.ToArray();
    }

    public int[] solution092602(int[] arr, int[] delete_list)
    {
        List<int> answer = new List<int>();
        foreach (var elem in arr) answer.Add(elem);

        for (int i = 0; i < answer.Count; i++)
        {
            for (int j = 0; i < delete_list.Length; j++)
            {
                if (answer[i] == delete_list[j])
                    answer.Remove(i);
            }
        }
        return answer.ToArray();
    }

    public string solution092603(string[] str_list, string ex)
    {
        string answer = "";
        foreach (var elem in str_list)
        {
            if (elem.Contains(ex)) continue;
            else answer += elem;
        }
        return answer;
    }

    public int[,] solution092604(int n)
    {
        int[,] answer = new int[n, n];
        for (int i = 0; i < answer.GetLength(0); i++)
        {
            for (int j = 0; j < answer.GetLength(1); j++)
            {
                if (i == j) answer[i, j] = 1;
                else answer[i, j] = 0;
            }
        }
        return answer;
    }

    public int solution092605(string num_str)
    {
        int answer = 0;
        List<int> store = new List<int>();
        foreach (var elem in num_str) store.Add(elem - '0');
        return answer;
    }

    public int[] solution092605(int[] arr, int n)
    {
        int[] answer = arr;
        if (arr.Length % 2 == 0)
        {
            for (int i = 1; i < arr.Length; i += 2)
            {
                answer[i] = arr[i] + n;
            }
        }
        else
        {
            for (int i = 0; i < arr.Length; i += 2)
            {
                answer[i] = arr[i] + n;
            }
        }
        return answer;
    }
    public int[] solution092606(string myString)
    {
        List<int> answer = new List<int>();
        string[] splited = myString.Split('x');
        foreach (var elem in splited)
            answer.Add(elem.Length);
        return answer.ToArray();
    }

    public string[] solution092607(string my_string)
    {
        string[] answer = new string[] { };
        answer = my_string.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return answer;
    }

    public string solution092608(string my_string, int n)
    {
        string answer = "";
        for (int i = n; i < my_string.Length; i++) answer += my_string[i];
        return answer;
    }

    public int solution093001(int[] num_list)
    {
        int answer = 0;
        string storeOdd = "";
        string storeEven = "";
        for (int i = 0; i < num_list.Length; i++)
        {
            if (num_list[i] % 2 == 1) storeOdd += num_list[i];
            else if (num_list[i] % 2 == 0) storeEven += num_list[i];
        }
        answer = int.Parse(storeOdd) + int.Parse(storeEven);
        return answer;
    }

    public int solution093002(string my_string, string is_suffix)
    {
        int answer = 0;
        if (my_string.EndsWith(is_suffix)) answer = 1;
        return answer;
    }

    public int[] solution093003(int[] arr, int[,] queries)
    {
        int[] answer = new int[] { };
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            for (int j = 0; j <= queries.GetLength(1); j++)
            {
                arr[j] += 1;
            }
        }
        return answer;
    }

    public int[] solution093003(string[] intStrs, int k, int s, int l)
    {
        List<int> answer = new List<int>();
        foreach (var elem in intStrs)
        {
            string store = "";
            int candidate = 0;
            for (int i = s; i < l; i++)
            {
                store += elem[i];
            }
            candidate = int.Parse(store);
            if (candidate > k) answer.Add(candidate);
        }
        return answer.ToArray();
    }

    public int[] solution093004(int[] arr)
    {
        List<int> answer = new List<int>();
        foreach (var elem in arr) answer.Add(elem);

        int exponent = 1;
        while (exponent < answer.Count) exponent *= 2;

        if (exponent == answer.Count) return answer.ToArray();
        else
        {
            for (int i = answer.Count; i < exponent; i++)
            {
                answer.Add(0);
            }
        }
        return answer.ToArray();
    }

    public string solution093005(string letter)
    {
        string answer = "";
        string[] morse = {
            ".-", "a", "-...", "b", "-.-.", "c", "-..", "d", ".", "e", "..-.", "f",
            "--.", "g", "....", "h", "..", "i", ".---", "j", "-.-", "k", ".-..", "l",
            "--", "m", "-.", "n", "---", "o", ".--.", "p", "--.-", "q", ".-.", "r",
            "...", "s", "-", "t", "..-", "u", "...-", "v", ".--", "w", "-..-", "x",
            "-.--", "y", "--..", "z"
        };
        string[] words = letter.Split(" ");

        int morseIdx = 0;
        foreach (var elem in words)
        {
            morseIdx = Array.IndexOf(morse, elem);
            answer += morse[morseIdx + 1];
        }
        return answer;
    }

    public int solution093006(string before, string after)
    {
        int answer = 0;

        char[] store1 = before.ToCharArray();
        char[] store2 = after.ToCharArray();
        Array.Sort(store1);
        Array.Sort(store2);

        for (int i = 0; i < store1.Length; i++)
        {
            Console.WriteLine($"{store1[i]} : {store2[i]}");
        }

        if (store1.SequenceEqual(store2)) answer = 1;

        return answer;
    }

    public int solution093007(int i, int j, int k)
    {
        int start = i;
        int end = j;
        int target = k;
        int answer = 0;

        for (int num = start; num < end; num++)
        {
            char[] store = i.ToString().ToCharArray();

            foreach (var elem in store)
            {
                if (elem - '0' == target) answer++;
            }
        }
        return answer;
    }

    public int solution093008(string my_string)
    {
        int answer = 0;
        foreach (var elem in my_string)
        {
            if (elem < '0' || elem > '9') my_string = my_string.Replace(elem, ' ');
        }
        string[] store = my_string.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var elem in store) Console.WriteLine(elem);
        return answer;
    }

    public int[] solution100401(int[] arr)
    {
        List<int> answer = new List<int>();
        int start = 0;
        int end = 0;

        start = Array.IndexOf(arr, 2);
        end = Array.LastIndexOf(arr, 2);

        if (start == -1 || end == -1)
        {
            answer.Add(-1);
            return answer.ToArray();
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                answer.Add(arr[i]);
            }
            return answer.ToArray();
        }
    }
    public int solution100402(int n)
    {
        int answer = 0;
        int store = 1;
        int currIdx = 1;

        while (store < n)
        {
            currIdx += 1;
            store *= currIdx;
        }

        if (store == n) answer = currIdx;
        else answer = currIdx - 1;
        return answer;
    }

    public int[] solution100403(int n, int[] slicer, int[] num_list)
    {
        int[] answer = new int[] { };
        switch (n)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
        return answer;
    }

    public int[] solution100404(int[] arr, int[,] queries)
    {
        int[] answer = new int[] { };
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            for (int j = queries[i, 0]; j <= queries[i, 1]; j++)
            {
                if (j % queries[i, 2] == 0)
                {
                    arr[j] += 1;
                }
            }
        }
        answer = arr;
        return answer;
    }

    public int solution100405(int[] arr)
    {
        int answer = 0;
        int x = 0;

        while (true)
        {
            int[] store = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++) store[i] = arr[i];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 50 && arr[i] % 2 == 0)
                {
                    arr[i] = arr[i] / 2;
                }
                else if (arr[i] < 50 && arr[i] % 2 == 1)
                {
                    arr[i] = arr[i] * 2 + 1;
                }
            }
            if (store.SequenceEqual(arr))
            {
                break;
            }
            else
            {
                x++;
            }
        }
        answer = x;
        return answer;
    }

    public int solution100701(string s)
    {
        int answer = 0;
        string prevNum = "";
        string[] splited = s.Split(' ');
        foreach (var elem in splited)
        {
            if (elem == "Z")
            {
                answer -= int.Parse(prevNum);
            }
            else
            {
                answer += int.Parse(elem);
                prevNum = elem;
            }
        }
        return answer;
    }

    public int[] solution100702(string my_string)
    {
        int[] answer = new int[52];
        foreach (var elem in my_string)
        {
            if (elem >= 'A' && elem <= 'Z') answer[elem - 'A']++;
            else if (elem >= 'a' && elem <= 'z') answer[elem - 'a' + 26]++;
        }
        return answer;
    }

    public string solution100801(string my_string, int[,] queries)
    {
        string answer = "";
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            int start = queries[i, 0];
            int end = queries[i, 1];
            string subString = my_string.Substring(start, end - start + 1);
            string reverseString = new string(subString.Reverse().ToArray());

            var sb = new StringBuilder(my_string);
            sb.Remove(start, end - start + 1).Insert(start, reverseString);
            my_string = sb.ToString();
        }
        answer = my_string;
        return answer;
    }

    public int solution100802(string my_string)
    {
        int answer = 0;
        string[] store = my_string.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        answer = int.Parse(store[0]);
        for (int i = 0; i < store.Length; i++)
        {
            if (store[i] == "+") answer += int.Parse(store[i + 1]);
            if (store[i] == "-") answer -= int.Parse(store[i + 1]);
        }
        return answer;
    }

    public int solution100803(int[] numbers, int k)
    {
        int answer = 0;
        int currIdx = 0;
        for (int i = 1; i < k; i++)
        {
            currIdx += 2;
            if (currIdx > numbers.Length)
            {
                if (currIdx == numbers.Length + 1) currIdx = 1;
                else if (currIdx == numbers.Length + 2) currIdx = 2;
            }
        }
        answer = numbers[currIdx];
        return answer;
    }

    public int[] solution100804(int[] arr, int k)
    {
        int[] answer = new int[k];
        arr = arr.Distinct().ToArray();
        for (int i = 0; i < k; i++)
        {
            if (i < arr.Length) answer[i] = arr[i];
            else answer[i] = -1;
        }
        return answer;
    }

    public int solution100901(int balls, int share)
    {
        int answer = 0;
        long store = 1;

        for (int i = 1; i <= share; i++)
        {
            store = store * (balls - share + i) / i;
        }
        answer = (int)store;
        return answer;
    }

    public string[] solution100902(string[] picture, int k)
    {
        List<string> answer = new List<string>();
        foreach (var elem in picture)
        {
            StringBuilder store = new StringBuilder(elem.Length * k);
            for (int i = 0; i < elem.Length; i++) store.Append(elem[i], k);
            for (int i = 0; i <= k; i++) answer.Add(store.ToString());
        }
        return answer.ToArray();
    }

    public string solution100903(string my_string, string overwrite_string, int s)
    {
        string answer = "";
        char[] store1 = my_string.ToCharArray();
        char[] store2 = overwrite_string.ToCharArray();

        int idx = 0;
        for (int i = s; i <= s + store2.Length - 1; i++)
        {
            store1[i] = store2[idx];
            idx++;
        }
        answer = new string(store1);
        return answer;
    }

    public int[,] solution100904(int[,] arr)
    {
        int row = arr.GetLength(0);
        int col = arr.GetLength(1);
        int n = Math.Max(row, col);

        int[,] answer = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i >= arr.GetLength(0) || j >= arr.GetLength(1)) continue;
                if (arr[i, j] != answer[i, j]) answer[i, j] = arr[i, j];
            }
        }
        return answer;
    }

    public int[] solution100905(string[] keyinput, int[] board)
    {
        int[] answer = new int[2];

        int[] position = new int[2];
        int borderWidth = board[0] / 2;
        int borderHeight = board[1] / 2;
        foreach (var elem in keyinput)
        {
            switch (elem)
            {
                case "up":
                    {
                        int next = position[1] + 1;
                        if (Math.Abs(next) > borderHeight) continue;
                        position[1] = next;
                        break;
                    }
                case "down":
                    {
                        int next = position[1] - 1;
                        if (Math.Abs(next) > borderHeight) continue;
                        position[1] = next;
                        break;
                    }
                case "right":
                    {
                        int next = position[0] + 1;
                        if (Math.Abs(next) > borderWidth) continue;
                        position[0] = next;
                        break;
                    }
                case "left":
                    {
                        int next = position[0] - 1;
                        if (Math.Abs(next) > borderWidth) continue;
                        position[0] = next;
                        break;
                    }
            }
        }

        answer = position;
        return answer;
    }

    public int solution100906(string[] spell, string[] dic)
    {
        foreach (var wordElem in dic)
        {
            List<char> store = new List<char>();
            foreach (var spellElem in spell)
            {
                char currChar = spellElem[0];
                int count = wordElem.Count(x => x == currChar);
                if (count == 1) store.Add(currChar);
            }

            if (store.Count == wordElem.Length && store.Count == spell.Length) return 1;
        }
        return 2;
    }

    public int solution100907(int M, int N)
    {
        return M * N - 1;
    }

    public int solution100908(int[] rank, bool[] attendance)
    {
        int answer = 0;
        Dictionary<int, int> store = new Dictionary<int, int>();
        for (int i = 0; i < rank.Length; i++)
        {
            if (attendance[i] == true) store.Add(i, rank[i]);
        }
        store = store.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        int a = store.ElementAt(0).Key;
        int b = store.ElementAt(1).Key;
        int c = store.ElementAt(2).Key;
        answer = 10000 * a + 100 * b + c;
        return answer;
    }

    public int solution100909(int chicken)
    {
        int answer = 0;
        int count = 0;
        int coupon = chicken;
        int serciveChicken = 0;
        while (coupon >= 10)
        {
            count = coupon / 10;
            coupon = count + (coupon % 10);
            serciveChicken += count;
        }
        answer = serciveChicken;
        return answer;
    }

    public int[] solution100910(int[,] score)
    {
        int[] answer = new int[score.GetLength(0)];
        float[] average = new float[score.GetLength(0)];
        for (int i = 0; i < average.Length; i++)
        {
            average[i] = (score[i, 0] + score[i, 1]) / 2.0f;
        }
        float[] sorted = average.OrderByDescending(x => x).ToArray();

        int rank = 1;
        foreach (var elem in sorted.Distinct())
        {
            int[] idxs = average.Select((v, i) => (v: v, i: i))
                                .Where(x => x.v == elem)
                                .Select(t => t.i).ToArray();

            foreach (var idx in idxs)
            {
                if (idxs.Length == 1)
                    answer[idx] = rank;
                else
                    answer[idx] = rank;
            }
            rank += idxs.Length;
        }
        return answer;
    }

    public int solution101101(int n)
    {
        int answer = 0;
        int count = 0;
        while (count < n)
        {
            answer++;
            if (answer % 3 == 0 || answer.ToString().Contains('3')) continue;
            count++;
        }
        return answer;
    }

    public int solution101102(string A, string B)
    {
        int answer = 0;
        int count = A.Length;
        StringBuilder store = new StringBuilder(A);

        if (A == B) return answer;

        while (store.ToString() != B)
        {
            count--;
            answer++;
            if (count == 0)
            {
                break;
            }
            string tail = store.ToString(store.Length - 1, 1);
            store.Remove(store.Length - 1, 1);
            store.Insert(0, tail);
        }

        if (count == 0) answer = -1;
        return answer;
    }
    
    public int solution101103(int a, int b) {
        int answer = 0;
        int gcd = GCD(a, b);
        a = a / gcd;
        b = b / gcd;
        
        while(b % 2 == 0) b /=2;
        while(b % 5 == 0) b /=5;
        
        if(b == 1) answer = 1;
        else answer = 2;
        
        return answer;
    }

    public int GCD(int a, int b)
    {
        if (b == 0) return a;
        else return GCD(b, a % b);
    }

    public int[] solution101104(int[] numlist, int n)
    {
        int[] answer = new int[numlist.Length];
        Dictionary<int, int> numAndRange = new Dictionary<int, int>();
        foreach (var elem in numlist) numAndRange.Add(elem, Math.Abs(elem - n));
        numAndRange = numAndRange.OrderBy(elem => elem.Value).
            ThenByDescending(elem => elem.Key).ToDictionary(elem => elem.Key, elem => elem.Value);

        int i = 0;
        foreach (var key in numAndRange.Keys)
        {
            answer[i] = key;
            i++;
        }
        return answer;
    }

    public int[] solution101105(int[] arr, int[] query)
    {
        List<int> answer = arr.ToList();
        int i = 0;
        foreach (var elem in query)
        {
            if (i % 2 == 0) answer.RemoveRange(elem + 1, answer.Count - elem - 1);
            else if (i % 2 == 1) answer.RemoveRange(0, elem);
            i++;
        }
        return answer.ToArray();
    }

    public string solution101301(string polynomial)
    {
        string answer = "";
        polynomial = polynomial.Replace(" ", "");
        string[] store = polynomial.Split('+');

        int countX = 0;
        int countNum = 0;

        foreach (var elem in store)
        {
            if (elem.Contains('x'))
            {
                if (elem == "x") countX++;
                else
                {
                    string digit = new string(elem.Where(char.IsDigit).ToArray());
                    countX += int.Parse(digit);
                }
            }
            else countNum += int.Parse(elem);
        }

        // if (countX == 0 && countNum == 0) answer = $"x";

        if (countX == 1 && countNum == 0) answer = $"x";
        else if (countX == 0 && countNum != 0) answer = $"{countNum}";
        else if (countX == 1 && countNum != 0) answer = $"x + {countNum}";
        else if (countX != 0 && countNum == 0) answer = $"{countX}x";
        else answer = $"{countX}x + {countNum}";
        return answer;
    }

    public int solution101302(int[] array)
    {
        int answer = 0;
        var store = array.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var maxAndNum = store.Aggregate((a, b) => a.Value > b.Value ? a : b);

        int max = maxAndNum.Value;
        int count = store.Values.Count(x => x == max);

        if (count == 1) answer = maxAndNum.Key;
        else answer = -1;
        return answer;
    }
    
    public int solution101303(int[,] dots) {
        float[,] store = new float[3, 2];

        var pairSets = new (int a, int b, int c, int d)[] {
            (0, 1, 2, 3),
            (0, 2, 1, 3),
            (0, 3, 1, 2)
        };
        int idx = 0;
        foreach(var p in pairSets)
        {
            float m1 = Inclination(dots[p.a, 0], dots[p.b, 0], dots[p.a, 1], dots[p.b, 1]);
            float m2 = Inclination(dots[p.c, 0], dots[p.d, 0], dots[p.c, 1], dots[p.d, 1]);

            store[idx, 0] = m1;
            store[idx, 1] = m2;
            idx++;
        }

        for (int i = 0; i < store.GetLength(0); i++)
        {
            if (store[i, 0] == store[i, 1]) return 1;
        }
        return 0;
    }

    public float Inclination(int x1, int x2, int y1, int y2)
    {
        int dx = x2 - x1;
        int dy = y2 - y1;
        return (float)dy / dx;
    }

    public int[,] solution101401(int n)
    {
        int[,] answer = new int[n, n];
        int num = 1;
        for (int j = 0; j < n; j++)
        {
            answer[0, j] = num;
            num++;
        }
        for (int i = 1; i < n; i++)
        {
            answer[i, n - 1] = num;
            num++;
        }
        for (int j = n - 2; j >= 0; j--)
        {
            answer[n - 1, j] = num;
            num++;
        }

        int currI = n - 2;
        int currJ = 0;
        int count = 0;
        int k = 2;
        while (num <= n * n)
        {
            while (count < n - k)
            {
                Console.WriteLine($" currI : {currI}, currJ : {currJ}, num : {num}");
                answer[currI, currJ] = num;
                num++;
                currI--;
                count++;
            }
            currI++;
            currJ++;
            count = 0;
            while (count < n - k)
            {
                Console.WriteLine($" currI : {currI}, currJ : {currJ}, num : {num}");
                answer[currI, currJ] = num;
                num++;
                currJ++;
                count++;
            }
            currI++;
            currJ--;
            count = 0;
            k++;
            while (count < n - k)
            {
                Console.WriteLine($" currI : {currI}, currJ : {currJ}, num : {num}");
                answer[currI, currJ] = num;
                num++;
                currI++;
                count++;
            }
            currI--;
            currJ--;
            count = 0;
            while (count < n - k)
            {
                Console.WriteLine($" currI : {currI}, currJ : {currJ}, num : {num}");
                answer[currI, currJ] = num;
                num++;
                currJ--;
                count++;
            }
            currI--;
            currJ++;
            count = 0;
            k++;
        }

        return answer;
    }

    public int solution101402(string[] babbling)
    {
        int answer = 0;
        int count = 0;
        for (int i = 0; i < babbling.Length; i++)
        {
            var able = "aya|ye|woo|ma";
            babbling[i] = Regex.Replace(babbling[i], able, "");
            if (babbling[i].Length == 0) count++;
        }
        answer = count;
        return answer;
    }

    public int solution101403(string t, string p)
    {
        int answer = 0;
        int count = 0;
        for (int i = 0; i < t.Length - p.Length + 1; i++)
        {
            string store = "";
            store = t.Substring(i, p.Length);

            if (long.Parse(store) <= long.Parse(p)) count++;
        }
        answer = count;
        return answer;
    }

    public int solution101404(int n) {
        int answer = 0;
        string ternary = TernaryConverter(n);
        string reverseTernary = new string(ternary.Reverse().ToArray());

        int count = 0;
        int placeValue = 0;
        for (int i = reverseTernary.Length - 1; i >= 0; i--)
        {
            count += (reverseTernary[i] - '0') * (int)Math.Pow(3, placeValue);
            placeValue++;
        }
        answer = count;
        return answer;
    }

    public string TernaryConverter(int n)
    {
        string store = "";
        while (n > 0)
        {
            var curr = n % 3;
            store += curr;
            n /= 3;
        }
        store = new string(store.Reverse().ToArray());
        return store;
    }

    public int solution101701(int[] number)
    {
        int answer = 0;
        for (int i = 0; i < number.Length - 2; i++)
        {
            for (int j = i + 1; j < number.Length - 1; j++)
            {
                for (int k = j + 1; k < number.Length; k++)
                {
                    if (number[i] + number[j] + number[k] == 0) answer += 1;
                }
            }
        }
        return answer;
    }

    public string solution101702(string s)
    {
        string answer = "";
        string[] store = s.Split(" ");
        for (int i = 0; i < store.Length; i++)
        {
            char[] chars = store[i].ToCharArray();
            for (int j = 0; j < chars.Length; j++)
            {
                if (j % 2 == 0) chars[j] = char.ToUpper(chars[j]);
                else if (j % 2 == 1) chars[j] = char.ToLower(chars[j]);
            }
            store[i] = new string(chars);
        }
        foreach (var elem in store)
        {
            answer += elem;
            answer += " ";
        }
        answer = answer.Substring(0, answer.Length - 1);
        return answer;
    }

    public int solution101703(int[,] sizes)
    {
        int answer = 0;
        for (int i = 0; i < sizes.GetLength(0); i++)
        {
            int[] row = { sizes[i, 0], sizes[i, 1] };
            Array.Sort(row);
            Array.Reverse(row);
            sizes[i, 0] = row[0];
            sizes[i, 1] = row[1];
        }

        int rowMax = int.MinValue;
        int colMax = int.MinValue; ;
        for (int i = 0; i < sizes.GetLength(0); i++)
        {
            if (sizes[i, 0] > rowMax) rowMax = sizes[i, 0];
            if (sizes[i, 1] > colMax) colMax = sizes[i, 1];
        }
        answer = rowMax * colMax;
        return answer;
    }

    public int[] solution101704(string s)
    {
        int[] answer = new int[s.Length];

        Dictionary<char, int> store = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (store.ContainsKey(s[i]))
            {
                int prevPos = store[s[i]];
                answer[i] = i - prevPos;
                store[s[i]] = i;
            }
            else if (!store.ContainsKey(s[i]))
            {
                answer[i] = -1;
                store.Add(s[i], i);
            }
        }
        return answer;
    }

    public string solution101705(string s, int n)
    {
        string answer = "";
        char[] store = s.ToCharArray();
        for (int i = 0; i < store.Length; i++)
        {
            if ('a' <= store[i] && store[i] <= 'z')
            {
                store[i] = (char)('a' + (((store[i] - 'a') + n) % 26 + 26) % 26);
            }
            if ('A' <= store[i] && store[i] <= 'Z')
            {
                store[i] = (char)('A' + (((store[i] - 'A') + n) % 26 + 26) % 26);
            }
            else if (store[i] == ' ')
            {
                store[i] = ' ';
            }
        }
        answer = new string(store); ;
        return answer;
    }

    public int[] solution101801(int[] numbers)
    {
        List<int> answer = new List<int>();
        Array.Sort(numbers);
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int candidate = numbers[i] + numbers[j];
                if (answer.Contains(candidate)) continue;
                else if (!answer.Contains(candidate)) answer.Add(candidate);
            }
        }
        answer.Sort();
        return answer.ToArray();
    }

    public string solution101802(int[] food)
    {
        string answer = "";
        for (int i = 1; i < food.Length; i++)
        {
            while (food[i] > 1)
            {
                answer += i;
                food[i] -= 2;
            }
        }
        string store = new string(answer.Reverse().ToArray());
        answer += '0';
        answer += store;
        return answer;
    }

    public int solution101803(string s)
    {
        int answer = 0;
        s = s.Replace("zero", "0");
        s = s.Replace("one", "1");
        s = s.Replace("two", "2");
        s = s.Replace("three", "3");
        s = s.Replace("four", "4");
        s = s.Replace("five", "5");
        s = s.Replace("six", "6");
        s = s.Replace("seven", "7");
        s = s.Replace("eight", "8");
        s = s.Replace("nine", "9");
        answer = int.Parse(s);
        return answer;
    }

    public int[] solutio102101(int[] array, int[,] commands)
    {
        int[] answer = new int[commands.GetLength(0)];
        for (int curr = 0; curr < commands.GetLength(0); curr++)
        {
            List<int> store = new List<int>();
            int i = commands[curr, 0] - 1;
            int j = commands[curr, 1] - 1;
            int k = commands[curr, 2] - 1;
            for (int start = i; start <= j; start++) store.Add(array[start]);
            store.Sort();
            answer[curr] = store[k];
        }
        return answer;
    }

    public int solution102102(int a, int b, int n)
    {
        int answer = 0;
        while (n >= a)
        {
            answer += (n / a) * b;
            n = (n % a) + (n / a) * b;
        }
        return answer;
    }

    public string[] solution102701(string[] strings, int n)
    {
        return strings.OrderBy(x => x).OrderBy(x => x[n]).ToArray();
    }

    public int[] solution102702(int k, int[] score)
    {
        List<int> answer = new List<int>();
        List<int> store = new List<int>();
        for (int i = 0; i < score.Length; i++)
        {
            store.Add(score[i]);
            store.Sort();
            if (store.Count > k) store.RemoveAt(0);
            answer.Add(store[0]);
        }
        return answer.ToArray();
    }

    public string solution102703(string[] cards1, string[] cards2, string[] goal)
    {
        string answer = "No";
        List<String> cards1List = cards1.ToList();
        List<String> cards2List = cards2.ToList();
        List<String> goalList = goal.ToList();
        foreach (var elem in goal)
        {
            if (cards1List.Count != 0 && cards1List[0] == elem)
            {
                cards1List.RemoveAt(0);
                goalList.RemoveAt(0);
            }
            else if (cards2List.Count != 0 && cards2List[0] == elem)
            {
                cards2List.RemoveAt(0);
                goalList.RemoveAt(0);
            }
        }
        if (goalList.Count == 0) answer = "Yes";
        return answer;
    }

    public int solution102704(int number, int limit, int power)
    {
        int answer = 0;
        int[] store = new int[number];
        for (int i = 1; i <= number; i++)
        {
            for (int j = i; j <= number; j += i)
            {
                store[j - 1]++;
            }
        }
        for (int i = 0; i < store.Length; i++)
        {
            if (store[i] > limit) store[i] = power;
        }
        answer = store.Sum();
        return answer;
    }

    public string solution102705(int a, int b)
    {
        string answer = "";
        var date = new DateTime(2016, a, b);
        DayOfWeek dow = date.DayOfWeek;
        int idx = (int)dow;
        if (idx == 0) answer = "SUN";
        else if (idx == 1) answer = "MON";
        else if (idx == 2) answer = "TUE";
        else if (idx == 3) answer = "WED";
        else if (idx == 4) answer = "THU";
        else if (idx == 5) answer = "FRI";
        else if (idx == 6) answer = "SAT";
        return answer;
    }

    public int[] solution102706(int[] answers)
    {
        List<int> answer = new List<int>();
        int[] case1 = { 1, 2, 3, 4, 5 };
        int[] case2 = { 2, 1, 2, 3, 2, 4, 2, 5 };
        int[] case3 = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };

        int[][] patterns = { case1, case2, case3 };
        int[] scores = new int[patterns.Length];

        for (int i = 0; i < answers.Length; i++)
        {
            int currAnswer = answers[i];
            for (int j = 0; j < patterns.GetLength(0); j++)
            {
                if (patterns[j][i % patterns[j].Length] == currAnswer)
                {
                    scores[j]++;
                }
            }
        }

        int maxScore = scores.Max();
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] == maxScore)
            {
                answer.Add(i + 1);
            }
        }
        answer.Sort();
        return answer.ToArray();
    }

    public int solution102707(int n, int m, int[] section)
    {
        int answer = 0;
        int[] wall = new int[n];
        foreach (var elem in section) wall[elem - 1] = 1;
        for (int i = 0; i < wall.Length;)
        {
            if (wall[i] == 0)
            {
                i++;
            }
            else if (wall[i] == 1)
            {
                for (int j = i; j < i + m; j++)
                {
                    if (j >= wall.Length) break;
                    wall[j] = 0;
                }
                answer += 1;
                i += m;
            }
        }
        return answer;
    }

    public int solution102801(int k, int m, int[] score)
    {
        int answer = 0;
        List<int> store = score.ToList();
        store.Sort();
        while (store.Count >= m)
        {
            int[] box = new int[m];
            for (int i = 0; i < m; i++)
            {
                int apple = store[store.Count - 1];
                store.RemoveAt(store.Count - 1);
                box[i] = apple;
            }
            int min = box.Min();
            answer += min * box.Length;
            if (store.Count < m) break;
        }
        return answer;
    }

    public int solution102802(int[] nums)
    {
        int answer = 0;
        bool[] eratos = Enumerable.Repeat(true, 3001).ToArray();
        eratos[0] = false;
        eratos[1] = false;
        for (int i = 2; i * i <= 3000; i++)
        {
            if (!eratos[i]) continue;
            for (int j = i * i; j <= 3000; j += i)
            {
                eratos[j] = false;
            }
        }

        for (int i = 0; i < nums.Length - 2; i++)
        {
            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    int currNum = nums[i] + nums[j] + nums[k];
                    if (eratos[currNum]) answer += 1;
                }
            }
        }
        return answer;
    }
    
    public int solution102803(int n) {
        int answer = 0;
        bool[] eratos = Eratos(n);
        for(int i = 0; i < eratos.Length; i++)
        {
            if (eratos[i]) answer += 1;
        }
        return answer;
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

    public int solution102901(string[] babbling)
    {
        int answer = 0;
        var able = new[] { "aya", "ye", "woo", "ma" };
        var pattern = "(" + string.Join("|", able.Select(Regex.Escape)) + ")";
        string[][] splitted = babbling.Select(s => Regex.Split(s, pattern)
                      .Where(x => x.Length > 0)
                      .ToArray()).ToArray();

        var ableWord = new HashSet<string> { "aya", "ye", "woo", "ma" }; ;
        for (int i = 0; i < splitted.Length; i++)
        {
            if (splitted[i].Length > 1)
            {
                bool ableSaying = true;
                for (int j = 1; j < splitted[i].Length; j++)
                {
                    var prevWord = splitted[i][j - 1];
                    var currWord = splitted[i][j];

                    if (prevWord == currWord) ableSaying = false;
                    if (!ableWord.Contains(currWord) || !ableWord.Contains(prevWord)) ableSaying = false;
                }
                if (ableSaying) answer++;
            }
            else if (splitted[i].Length == 1)
            {
                var currWord = splitted[i][0];
                bool ableSaying = true;
                if (!ableWord.Contains(currWord)) ableSaying = false;
                if (ableSaying) answer++;
            }
        }
        return answer;
    }

    public string solution102902(string s, string skip, int index)
    {
        string answer = "";
        char[] store = s.ToCharArray();
        char[] skipArray = skip.ToCharArray();
        for (int i = 0; i < store.Length; i++)
        {
            for (int j = 0; j < index;)
            {
                if ('a' <= store[i] && store[i] <= 'z')
                    store[i] = (char)('a' + (((store[i] - 'a') + 1) % 26 + 26) % 26);
                if ('A' <= store[i] && store[i] <= 'Z')
                    store[i] = (char)('A' + (((store[i] - 'A') + 1) % 26 + 26) % 26);
                if (!skipArray.Contains(store[i])) j++;
            }
        }
        answer = new string(store);
        return answer;
    }

    public int[] solution103001(int[] lottos, int[] win_nums)
    {
        int[] answer = new int[2];
        int min = 0;
        int max = 0;
        int count = win_nums.Intersect(lottos).Count();
        int countZero = lottos.Count(x => x == 0);
        min = Lotto(count);
        max = Lotto(count + countZero);

        answer[0] = max;
        answer[1] = min;
        return answer;
    }

    public int Lotto(int n)
    {
        int num = 0;
        switch (n)
        {
            case 6:
                num = 1;
                break;
            case 5:
                num = 2;
                break;
            case 4:
                num = 3;
                break;
            case 3:
                num = 4;
                break;
            case 2:
                num = 5;
                break;
            default:
                num = 6;
                break;
        }
        return num;
    }

    public int solution103002(string s)
    {
        int answer = 1;
        char currChar = s[0];
        int countSame = 1;
        int countOther = 0;

        for (int i = 1; i < s.Length; i++)
        {
            if (countSame == countOther)
            {
                currChar = s[i];
                answer += 1;
            }

            if (currChar == s[i]) countSame += 1;
            else if (currChar != s[i]) countOther += 1;
        }
        return answer;
    }

    public int[] solution103003(string[] keymap, string[] targets)
    {
        int[] answer = new int[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            int click = 0;
            for (int j = 0; j < targets[i].Length; j++)
            {
                int min = int.MaxValue;
                char currChar = targets[i][j];
                for (int k = 0; k < keymap.Length; k++)
                {
                    int pos = keymap[k].IndexOf(currChar);
                    if (pos != -1 && pos + 1 < min)
                    {
                        min = pos + 1;
                    }
                }
                if (min != int.MaxValue) click += min;
                else if (min == int.MaxValue)
                {
                    click = -1;
                    break;
                }
            }
            answer[i] = click;
        }
        return answer;
    }

    public int solution103004(int n, int[] lost, int[] reserve)
    {
        int answer = 0;

        Array.Sort(reserve);
        int[] have = reserve.Except(lost).ToArray();
        int removedCount = reserve.Intersect(lost).Count();

        Array.Sort(lost);
        int lostNum = lost.Length;
        lost = lost.Except(reserve).ToArray();
        List<int> lostList = lost.ToList();

        int able = 0;
        for (int i = 0; i < have.Length; i++)
        {
            if (lostList.Contains(have[i] - 1))
            {
                able += 1;
                lostList.Remove(have[i] - 1);
            }
            else if (lostList.Contains(have[i] + 1))
            {
                able += 1;
                lostList.Remove(have[i] + 1);
            }
        }
        answer = n - lostNum + able + removedCount;
        return answer;
    }

    // public int solution103005(int[] ingredient) {
    //     int answer = 0;
    //     StringBuilder stringBuilder = new StringBuilder();
    //     string hamberger = "1231";
    //     for (int i = 0; i < ingredient.Length; i++) stringBuilder.Append(ingredient[i]);

    //     while(stringBuilder.ToString().Contains(hamberger))
    //     {
    //         int idx = stringBuilder.ToString().IndexOf(hamberger);
    //         stringBuilder.Remove(idx, hamberger.Length);
    //         answer += 1;
    //     }
    //     return answer;
    // }
    public int solution103005(int[] ingredient) {
        int answer = 0;
        List<int> store = new List<int>();
        
        for(int i = 0; i < ingredient.Length; i++)
        {
            store.Add(ingredient[i]);
            bool isHamberger = true;
            if(store.Count >= 4)
            {
                if (store[store.Count - 1] != 1) isHamberger = false;
                if (store[store.Count - 2] != 3) isHamberger = false;
                if (store[store.Count - 3] != 2) isHamberger = false;
                if (store[store.Count - 4] != 1) isHamberger = false;
                if(isHamberger)
                {
                    store.RemoveRange(store.Count - 4, 4);
                    answer += 1;
                }
            }
        }
        return answer;
    }
}

