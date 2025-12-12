using System.Text;
using System.Text.RegularExpressions;

public class Solution1
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

    public int solution101103(int a, int b)
    {
        int answer = 0;
        int gcd = GCD(a, b);
        a = a / gcd;
        b = b / gcd;

        while (b % 2 == 0) b /= 2;
        while (b % 5 == 0) b /= 5;

        if (b == 1) answer = 1;
        else answer = 2;

        return answer;
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

    public int solution101303(int[,] dots)
    {
        float[,] store = new float[3, 2];

        var pairSets = new (int a, int b, int c, int d)[] {
            (0, 1, 2, 3),
            (0, 2, 1, 3),
            (0, 3, 1, 2)
        };
        int idx = 0;
        foreach (var p in pairSets)
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

    public int solution101404(int n)
    {
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

    public int solution102803(int n)
    {
        int answer = 0;
        bool[] eratos = Eratos(n);
        for (int i = 0; i < eratos.Length; i++)
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

    public int solution103005(int[] ingredient)
    {
        int answer = 0;
        List<int> store = new List<int>();

        for (int i = 0; i < ingredient.Length; i++)
        {
            store.Add(ingredient[i]);
            bool isHamberger = true;
            if (store.Count >= 4)
            {
                if (store[store.Count - 1] != 1) isHamberger = false;
                if (store[store.Count - 2] != 3) isHamberger = false;
                if (store[store.Count - 3] != 2) isHamberger = false;
                if (store[store.Count - 4] != 1) isHamberger = false;
                if (isHamberger)
                {
                    store.RemoveRange(store.Count - 4, 4);
                    answer += 1;
                }
            }
        }
        return answer;
    }

    public string solution103101(string X, string Y)
    {
        string answer = "";
        int[] storeX = X.Select(x => x - '0').ToArray();
        int[] storeY = Y.Select(x => x - '0').ToArray();
        Array.Sort(storeX);
        Array.Sort(storeY);
        List<int> intersect = new List<int>();
        int i = 0;
        int j = 0;
        while (i < storeX.Length && j < storeY.Length)
        {
            if (storeX[i] == storeY[j])
            {
                intersect.Add(storeX[i]);
                i++;
                j++;
            }
            else if (storeX[i] < storeY[j]) i++;
            else j++;
        }

        int[] store = intersect.ToArray();
        Array.Sort(store);
        Array.Reverse(store);

        if (store.Length == 0) answer = "-1";
        else if (store.All(x => x == 0)) answer = "0";
        else answer = string.Join("", store);
        return answer;
    }

    public string solution103102(string[] survey, int[] choices)
    {
        string answer = "";
        Dictionary<char, int> typeScore = new Dictionary<char, int>
        {
            { 'R', 0 },
            { 'T', 0 },
            { 'C', 0 },
            { 'F', 0 },
            { 'J', 0 },
            { 'M', 0 },
            { 'A', 0 },
            { 'N', 0 },
        };

        for (int i = 0; i < survey.Length; i++) Survey(survey[i], choices[i], typeScore);

        answer += typeScore['R'] >= typeScore['T'] ? 'R' : 'T';
        answer += typeScore['C'] >= typeScore['F'] ? 'C' : 'F';
        answer += typeScore['J'] >= typeScore['M'] ? 'J' : 'M';
        answer += typeScore['A'] >= typeScore['N'] ? 'A' : 'N';

        return answer;
    }

    private void Survey(string survey, int choice, Dictionary<char, int> typeScore)
    {
        var type1 = survey[0];
        var type2 = survey[1];
        switch (choice)
        {
            case 1:
                typeScore[type1] += 3;
                break;
            case 2:
                typeScore[type1] += 2;
                break;
            case 3:
                typeScore[type1] += 1;
                break;
            case 5:
                typeScore[type2] += 1;
                break;
            case 6:
                typeScore[type2] += 2;
                break;
            case 7:
                typeScore[type2] += 3;
                break;
        }
    }

    public int[] solution103103(string[] wallpaper)
    {
        int[] answer = new int[4];
        int closeWidth = int.MaxValue;
        int closeHeight = int.MaxValue;
        int farWidth = int.MinValue;
        int farHeight = int.MinValue;
        for (int i = 0; i < wallpaper.Length; i++)
        {
            if (wallpaper[i].Contains('#'))
            {
                if (closeHeight > i) closeHeight = i;
                if (farHeight < i) farHeight = i;

                var firstPos = wallpaper[i].IndexOf('#');
                var lastPos = wallpaper[i].LastIndexOf('#');

                if (closeWidth > firstPos) closeWidth = firstPos;
                if (farWidth < lastPos) farWidth = lastPos;
            }
        }
        answer[0] = closeHeight;
        answer[1] = closeWidth;
        answer[2] = farHeight + 1;
        answer[3] = farWidth + 1;
        return answer;
    }

    public int[] solution103104(string today, string[] terms, string[] privacies)
    {
        List<int> answer = new List<int>();

        string[] todayStringList = today.Split('.');
        int[] todayData = new int[3];
        for (int i = 0; i < todayStringList.Length; i++) todayData[i] = int.Parse(todayStringList[i]);

        Dictionary<char, int> termsData = new Dictionary<char, int>();
        for (int i = 0; i < terms.Length; i++)
        {
            string[] currTerm = terms[i].Split(" ");
            termsData.Add(currTerm[0][0], int.Parse(currTerm[1]));
        }

        var privaciesData = new List<(char term, int year, int month, int date)>();
        for (int i = 0; i < privacies.Length; i++)
        {
            string[] currPrivacy = privacies[i].Split('.', ' ');
            var term = currPrivacy[3][0];
            var year = int.Parse(currPrivacy[0]);
            var month = int.Parse(currPrivacy[1]);
            var date = int.Parse(currPrivacy[2]);
            privaciesData.Add((term, year, month, date));
        }

        for (int i = 0; i < privaciesData.Count; i++)
        {
            var adding = termsData[privaciesData[i].term];
            var year = privaciesData[i].year;
            var month = privaciesData[i].month;
            var date = privaciesData[i].date;

            month += adding;
            if (month > 12)
            {
                while (month > 12)
                {
                    year += 1;
                    month -= 12;
                }
            }
            date -= 1;
            if (date == 0)
            {
                date = 28;
                month -= 1;
            }

            privaciesData[i] = (privaciesData[i].term, year, month, date);
        }

        var todayYear = todayData[0];
        var todayMonth = todayData[1];
        var todayDate = todayData[2];
        for (int i = 0; i < privaciesData.Count; i++)
        {
            if (todayYear > privaciesData[i].year) answer.Add(i + 1);
            else if (todayYear == privaciesData[i].year)
            {
                if (todayMonth > privaciesData[i].month) answer.Add(i + 1);
                else if (todayMonth == privaciesData[i].month)
                {
                    if (todayDate > privaciesData[i].date) answer.Add(i + 1);
                }
            }
        }
        return answer.ToArray();
    }

    public int solution110301(int[] schedules, int[,] timelogs, int startday)
    {
        int answer = 0;
        for (int i = 0; i < schedules.Length; i++)
        {
            schedules[i] += 10;
            int minute = schedules[i] % 100;
            if (minute >= 60) schedules[i] += 40;
        }

        for (int i = 0; i < timelogs.GetLength(0); i++)
        {
            int count = 0;
            int currDay = startday;
            int time = schedules[i];
            for (int j = 0; j < timelogs.GetLength(1); j++)
            {
                if (timelogs[i, j] <= time && currDay != 6 && currDay != 7) count += 1;
                currDay += 1;
                if (currDay == 8) currDay = 1;
            }
            if (count == 5) answer += 1;
        }
        return answer;
    }

    public string[] solution110302(string[] players, string[] callings)
    {
        string[] answer = new string[players.Length];
        Dictionary<string, RunningData> run = new Dictionary<string, RunningData>();
        run.Add(players[0], new RunningData { frontName = null, afterName = players[1], ranking = 1 });
        for (int i = 1; i < players.Length - 1; i++) run.Add(players[i], new RunningData { frontName = players[i - 1], afterName = players[i + 1], ranking = i + 1 });
        run.Add(players[players.Length - 1], new RunningData { frontName = players[players.Length - 2], afterName = null, ranking = players.Length });

        for (int i = 0; i < callings.Length; i++)
        {
            var currPlayerName = callings[i];
            var currPlayer = run[currPlayerName];

            var frontPlayerName = currPlayer.frontName;
            var frontPlayer = run[frontPlayerName!];


            var frontOfFrontPlayerName = frontPlayer.frontName;
            RunningData frontOfFrontPlayer = default;
            if (!string.IsNullOrEmpty(frontOfFrontPlayerName))
            {
                frontOfFrontPlayer = run[frontOfFrontPlayerName];
            }

            var afterPlayerName = currPlayer.afterName;
            RunningData afterPlayer = default;
            if (!string.IsNullOrEmpty(afterPlayerName))
            {
                afterPlayer = run[afterPlayerName];
            }

            int currRank = currPlayer.ranking;
            currPlayer.ranking = frontPlayer.ranking;
            frontPlayer.ranking = currRank;

            currPlayer.frontName = frontOfFrontPlayerName;
            currPlayer.afterName = frontPlayerName;

            frontPlayer.frontName = currPlayerName;
            frontPlayer.afterName = afterPlayerName;

            if (!string.IsNullOrEmpty(frontOfFrontPlayerName))
            {
                frontOfFrontPlayer.afterName = currPlayerName;
                run[frontOfFrontPlayerName] = frontOfFrontPlayer;
            }

            if (!string.IsNullOrEmpty(afterPlayerName))
            {
                afterPlayer.frontName = frontPlayerName;
                run[afterPlayerName] = afterPlayer;
            }

            run[currPlayerName] = currPlayer;
            run[frontPlayerName!] = frontPlayer;
        }

        var sorted = run.OrderBy(x => x.Value.ranking).ToArray();
        int idx = 0;
        foreach (var elem in sorted)
        {
            answer[idx] = elem.Key;
            idx += 1;
        }
        return answer;
    }

    public struct RunningData
    {
        public string? frontName;
        public string? afterName;
        public int ranking;
    }

    public int[] solution110303(string[] park, string[] routes)
    {
        int[] answer = new int[2];
        int[] currPos = new int[2];

        int parkWidth = park[0].Length - 1;
        int parkHeight = park.Length - 1;

        for (int i = 0; i < park.Length; i++)
        {
            int idx = park[i].IndexOf('S');
            if (idx != -1)
            {
                currPos[0] = i;
                currPos[1] = idx;
                break;
            }
        }

        var routesData = new List<(char dir, int move)>();
        for (int i = 0; i < routes.Length; i++)
        {
            string[] currRoute = routes[i].Split(" ");
            var dir = currRoute[0][0];
            var move = int.Parse(currRoute[1]);
            routesData.Add((dir, move));
        }

        for (int i = 0; i < routesData.Count; i++)
        {
            if (!MoveChecker(park, parkWidth, parkHeight, currPos, routesData[i].dir, routesData[i].move)) continue;
            else
            {
                switch (routesData[i].dir)
                {
                    case 'E':
                        currPos[1] += routesData[i].move;
                        break;
                    case 'W':
                        currPos[1] -= routesData[i].move;
                        break;
                    case 'S':
                        currPos[0] += routesData[i].move;
                        break;
                    case 'N':
                        currPos[0] -= routesData[i].move;
                        break;
                }
            }
        }

        answer = currPos;
        return answer;
    }

    public bool MoveChecker(string[] park, int parkWidth, int parkHeight, int[] currPos, char dir, int move)
    {
        int[] targetPos = new int[] { currPos[0], currPos[1] };
        for (int i = 0; i < move; i++)
        {
            switch (dir)
            {
                case 'E':
                    targetPos[1] += 1;
                    break;
                case 'W':
                    targetPos[1] -= 1;
                    break;
                case 'S':
                    targetPos[0] += 1;
                    break;
                case 'N':
                    targetPos[0] -= 1;
                    break;
            }
            if (targetPos[0] < 0 || targetPos[0] > parkHeight) return false;
            else if (targetPos[1] < 0 || targetPos[1] > parkWidth) return false;
            else if (park[targetPos[0]][targetPos[1]] == 'X') return false;
        }
        return true;
    }

    public int[] solution110304(string[] id_list, string[] report, int k)
    {
        int[] answer = new int[id_list.Length];
        var reportData = new List<(string reporter, string reported)>();
        for (int i = 0; i < report.Length; i++)
        {
            var currReport = report[i].Split(' ');
            var reporter = currReport[0];
            var reported = currReport[1];
            reportData.Add((reporter, reported));
        }
        reportData = reportData.Distinct().ToList();

        Dictionary<string, int> reportedData = new Dictionary<string, int>();
        for (int i = 0; i < id_list.Length; i++) reportedData.Add(id_list[i], 0);
        for (int i = 0; i < reportData.Count; i++)
        {
            var reported = reportData[i].reported;
            reportedData[reported] += 1;
        }

        var ban = reportedData.Where(x => x.Value >= k).Select(x => x.Key).ToList();

        for (int i = 0; i < reportData.Count; i++)
        {
            for (int j = 0; j < ban.Count; j++)
            {
                var banned = ban[j];
                if (reportData[i].reported == banned)
                {
                    int idx = Array.IndexOf(id_list, reportData[i].reporter);
                    answer[idx] += 1;
                }
            }
        }
        return answer;
    }
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

    public int solution111701(string[,] clothes) {
        int answer = 1;
        Dictionary<string, HashSet<string>> store = new Dictionary<string, HashSet<string>>();
        for(int i = 0; i < clothes.GetLength(0); i++)
        {
            if(!store.ContainsKey(clothes[i, 1])) store.Add(clothes[i, 1], new HashSet<string>());
            store[clothes[i, 1]].Add(clothes[i, 0]);
        }

        foreach(var elem in store)
        {
            HashSet<string> set = elem.Value;
            var count = set.Count;
            answer *= count + 1;
        }
        answer -= 1;
        return answer;
    }

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

    public int solution112001(string word) {
        int answer = 0;
        string [] dict = new string[3905];
        string[] words = new string[] {"A", "E", "I", "O", "U"};

        int count = 0;
        foreach(string first in words)
        {
            dict[count] = first;
            count += 1;
            foreach(string second in words)
            {
                dict[count] = first + second;
                count += 1;
                foreach(string third in words)
                {
                    dict[count] = first + second + third;
                    count += 1;
                    foreach(string forth in words)
                    {
                        dict[count] = first + second + third + forth;
                        count += 1;
                        foreach(string fifth in words)
                        {
                            dict[count] = first + second + third + forth + fifth;
                            count += 1;
                        }
                    }
                }
            }
        }

        int pos = Array.IndexOf(dict, word) + 1;
        answer = pos;
        return answer;
    }

    // public int[] solution112401(int[] numbers) {
    //     int[] answer = new int[numbers.Length];
    //     for(int i = 0; i < numbers.Length; i++)
    //     {
    //         for(int j = i; j < numbers.Length; j++)
    //         {
    //             if(numbers[i] < numbers[j])
    //             {
    //                 answer[i] = numbers[j];
    //                 break;
    //             }
    //             else if(j == numbers.Length - 1) answer[i] = -1;
    //         }
    //     }
    //     return answer;
    // }

    // public int[] solution112401(int[] numbers) {
    //     int[] answer = new int[numbers.Length];
    //     Dictionary<int, int> store = new Dictionary<int, int>();
    //     for(int i = 0; i < numbers.Length; i++) store[numbers[i]] = i;
    //     Stack<int> stack = new Stack<int>();

    //     stack.Push(numbers[0]);
    //     for(int i = 1; i < numbers.Length; i++)
    //     {
    //         int curr = numbers[i];
    //         if(stack.Peek() < curr)
    //         {
    //             while(stack.Count > 0 && stack.Peek() < curr)
    //             {
    //                 int target = stack.Pop();
    //                 int idx = store[target];
    //                 answer[idx] = curr;
    //             }
    //         }
    //         stack.Push(curr);
    //     }

    //     int remain = stack.Count;
    //     for(int i = 0; i < remain; i++)
    //     {
    //         int target = stack.Pop();
    //         int idx = store[target];
    //         answer[idx] = -1;
    //     }
    //     return answer;
    // }

    public int[] solution112401(int[] numbers) {
        int[] answer = new int[numbers.Length];
        Stack<int> stack = new Stack<int>();

        for(int i = 0; i < numbers.Length; i++)
        {
            int idx = i;
            int curr = numbers[idx];

            while(stack.Count != 0)
            {
                if(numbers[stack.Peek()] >= curr) break;
                else
                {
                    answer[stack.Peek()] = curr;
                    stack.Pop();
                }
            }
            stack.Push(i);
        }

        int remain = stack.Count;
        for(int i = 0; i < remain; i++)
        {
            int target = stack.Pop();
            answer[target] = -1;
        }
        return answer;
    }

        // public int solution112402(int n, int k) {
    //     int answer = 0;
    //     string baseNum = ToBaseN(n, k);
    //     List<int> prime = new List<int>();

    //     StringBuilder stringBuilder = new StringBuilder();

    //     bool making = false;
    //     foreach(var elem in baseNum)
    //     {
    //         if(elem != '0')
    //         {
    //             making = true;
    //             stringBuilder.Append(elem);
    //         }
    //         else if(elem == '0' && making)
    //         {
    //             string curr = stringBuilder.ToString();
    //             prime.Add(int.Parse(curr));
    //             making = false;
    //             stringBuilder.Clear();
    //         }
    //     }

    //     if(stringBuilder.Length != 0)
    //     {
    //         string curr = stringBuilder.ToString();
    //         prime.Add(int.Parse(curr));
    //         stringBuilder.Clear();
    //     }

    //     int maxNum = prime.Max();
    //     bool[] eratos = Eratos(maxNum);

    //     for (int i = prime.Count - 1; i >= 0; i--)
    //     {
    //         int elem = prime[i];
    //         if (eratos[elem] == false)
    //         {
    //             prime.RemoveAt(i);
    //         }
    //     }

    //     string[] splited = baseNum.Split('0', StringSplitOptions.RemoveEmptyEntries);
    //     foreach(var elem in splited)
    //     {
    //         if(prime.Contains(int.Parse(elem))) answer += 1;
    //     }
    //     return answer;
    // }

    // public string ToBaseN(int number, int n)
    // {
    //     if (number == 0) return "0";
    //     string result = "";
    //     while (number > 0)
    //     {
    //         result = (number % n) + result;
    //         number /= n;
    //     }
    //     return result;
    // }

    // public bool[] Eratos(int n)
    // {
    //     bool[] eratos = Enumerable.Repeat(true, n + 1).ToArray();
    //     eratos[0] = false;
    //     eratos[1] = false;
    //     for (int i = 2; i * i <= n; i++)
    //     {
    //         if (!eratos[i]) continue;
    //         for (int j = i * i; j <= n; j += i)
    //         {
    //             eratos[j] = false;
    //         }
    //     }
    //     return eratos;
    // }

    public int solution112402(int n, int k) {
        int answer = 0;
        string baseNum = ToBaseN(n, k);
        List<string> prime = new List<string>();

        StringBuilder stringBuilder = new StringBuilder();

        bool making = false;
        foreach(var elem in baseNum)
        {
            if(elem != '0')
            {
                making = true;
                stringBuilder.Append(elem);
            }
            else if(elem == '0' && making)
            {
                string curr = stringBuilder.ToString();
                prime.Add(curr);
                making = false;
                stringBuilder.Clear();
            }
        }

        if(stringBuilder.Length != 0)
        {
            string curr = stringBuilder.ToString();
            prime.Add(curr);
            stringBuilder.Clear();
        }

        string[] splited = baseNum.Split('0', StringSplitOptions.RemoveEmptyEntries);

        foreach(var elem in splited)
        {
            if(prime.Contains(elem) && isPrime(long.Parse(elem))) answer += 1;
        }
        return answer;
    }

    public bool isPrime(long num)
    {
        if (num < 2) return false;
        for (long i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }

    public string ToBaseN(int number, int n)
    {
        if (number == 0) return "0";
        string result = "";
        while (number > 0)
        {
            result = (number % n) + result;
            number /= n;
        }
        return result;
    }

        // public int[] solution112601(int[] prices) {
    //     int[] answer = new int[prices.Length];
    //     bool[] confirmed = new bool[prices.Length];
    //     Stack<int> store = new Stack<int>();

    //     store.Push(prices[0]);
    //     for(int i = 1; i < prices.Length; i++)
    //     {
    //         int prev= store.Peek();
    //         store.Push(prices[i]);
    //         int curr = store.Peek();

    //         if(prev > curr)
    //         {
    //             int comparison = curr;
    //             int day = 0;
    //             int idx = i;

    //             foreach(var elem in store)
    //             {
    //                 if(!confirmed[idx] && elem > comparison)
    //                 {
    //                     answer[idx] = day;
    //                     confirmed[idx] = true;
    //                 }
    //                 day += 1;
    //                 idx -= 1;
    //             }
    //         }
    //     }

    //     int finish = 0;
    //     for(int i = prices.Length - 1; i >= 0; i--)
    //     {
    //         if(!confirmed[i]) answer[i] = finish;
    //         finish += 1;
    //     }
    //     return answer;
    // }
    public int[] solution112601(int[] prices) {
        int[] answer = new int[prices.Length];

        for(int i = 0; i < prices.Length - 1; i++)
        {
            int curr = prices[i];
            int sec = 0;
            for(int j =  i + 1; j < prices.Length; j++)
            {
                int comparison = prices[j];
                sec += 1;
                if(curr > comparison) break;
            }
            answer[i] = sec;
        }
        return answer;
    }

    public int solution112602(int[] order) {
        int answer = 0;
        Stack<int> stackBelt = new Stack<int>();

        int box = 1;
        int idx = 0;
        while(true)
        {
            if(idx >= order.Length) break;

            if (box <= order.Length)
            {
                if(order[idx] == box)
                {
                    answer += 1;   
                    idx += 1;
                    box += 1;
                }
                else if(stackBelt.Count > 0 && order[idx] == stackBelt.Peek())
                {
                    stackBelt.Pop();
                    answer += 1;  
                    idx += 1;
                }
                else
                {
                    stackBelt.Push(box);
                    box += 1;
                }
            }
            else
            {
                if(stackBelt.Count > 0 && order[idx] == stackBelt.Peek())
                {
                    stackBelt.Pop();
                    answer += 1;  
                    idx += 1;
                }
                else break;
            }
        }
        return answer;
    }

    // public int solution112701(string skill, string[] skill_trees) {
    //     int answer = 0;
    //     int[] skillArray = new int[skill.Length];
    //     for(int i = 0; i < skill_trees.GetLength(0); i++)
    //     {
    //         for(int j = 0; j < skillArray.Length; j++)
    //         {
    //             skillArray[j] = skill_trees[i].IndexOf(skill[j]);
    //         }

    //         bool isSorted = true;
    //         for (int j = 1; j < skillArray.Length; j++)
    //         {
    //             if (skillArray[j - 1].CompareTo(skillArray[j]) > 0) isSorted = false;
    //         }

    //         if(isSorted) answer += 1;
    //     }
    //     return answer;
    // }

    public int solution112701(string skill, string[] skill_trees) {
        int answer = 0;
        bool isValid = true;
        for(int i = 0; i < skill_trees.GetLength(0); i++)
        {
            int skillIdx = 0;
            foreach(var elem in skill_trees[i])
            {
                int idx = skill.IndexOf(elem);

                if(idx == -1) continue;
                if(idx == skillIdx) skillIdx += 1;
                else isValid = false;
            }

            if(isValid) answer += 1;
        }
        return answer;
    }

    public int solution112702(int x, int y, int n) {
        Queue<(int, int)> bfs = new Queue<(int, int)>();
        bool[] visited = new bool[y + 1];

        bfs.Enqueue((x, 0));
        visited[x] = true;

        while(bfs.Count > 0)
        {
            var (value, count) = bfs.Dequeue();
            if(value == y) return count;

            int[] nexts = {value + n, value * 2, value * 3};

            foreach (var next in nexts)
            {
                if (next > y) continue;
                if (visited[next]) continue;

                visited[next] = true;
                bfs.Enqueue((next, count + 1));
            }
        }
        return -1;
    }

    public int[] solution112703(int[] fees, string[] records) {
        var lowData = new List<(int time, string number, string type)>();
        foreach(var elem in records)
        {
            var currData = elem.Split(' ');

            var lowTime = currData[0].Split(':');
            var trueTime = (int.Parse(lowTime[0]) * 60) + int.Parse(lowTime[1]);

            var number = currData[1];
            var type = currData[2];
            lowData.Add((trueTime, number, type));
        }

        lowData = lowData.OrderBy(x => x.number).ThenBy(x => x.time).ToList();

        Dictionary<string, int> trueData = new Dictionary<string, int>();

        int currIdx = lowData.Count - 2;
        int prevIdx = lowData.Count - 1;
        while (currIdx >= 0 && prevIdx >= 1)
        {
            var prevNum = lowData[prevIdx].number;
            var currNum = lowData[currIdx].number;

            var prevType = lowData[prevIdx].type;
            var currType = lowData[currIdx].type;

            var prevTime = lowData[prevIdx].time;
            var currTime = lowData[currIdx].time;

            if(prevNum == currNum && prevType == "OUT" && currType == "IN")
            {
                if(!trueData.TryGetValue(currNum, out var Value)) trueData.Add(currNum, 0);
                trueData[currNum] += prevTime - currTime;
                lowData.RemoveAt(prevIdx);
                lowData.RemoveAt(currIdx);
                prevIdx -= 1;
                currIdx -= 1;
            }
            prevIdx -= 1;
            currIdx -= 1;
        }

        if(lowData.Count > 0)
        {
            int fullTime = (23 * 60) + 59;
            foreach(var elem in lowData)
            {
                if(!trueData.TryGetValue(elem.number, out var Value)) trueData.Add(elem.number, 0);
                var number = elem.number;
                var time = elem.time;
                trueData[number] += fullTime - time;
            }
        }

        var moneyData = trueData.ToList();
        moneyData = moneyData.OrderBy(x => x.Key).ToList();

        for(int i = 0; i < moneyData.Count; i++)
        {
            var number = moneyData[i].Key;
            var time = moneyData[i].Value;

            int fee;
            if(time <= fees[0]) fee = fees[1];
            else
            {
                int extra = time - fees[0];
                int unitCount = (int)Math.Ceiling(extra / (float)fees[2]);
                fee = fees[1] + unitCount * fees[3];
            }
            moneyData[i] = new KeyValuePair<string, int>(number, fee);
        }

        int[] answer = new int[moneyData.Count];
        for(int i = 0; i < answer.Length; i++)
        {
            answer[i] = moneyData[i].Value;
        }
        return answer;
    }

    // public long[] solution112801(long[] numbers) {
    //     long[] answer = new long[numbers.Length];
    //     for(int i = 0; i < numbers.Length; i++)
    //     {
    //         long curr = numbers[i];
    //         long next = curr + 1;
    //         while(true)
    //         {
    //             long numResult = curr ^ next;
    //             string baseTwo = Convert.ToString(numResult, 2);

    //             long count = baseTwo.Count(c => c == '1');
    //             if(count <= 2)
    //             {
    //                 answer[i] = next;
    //                 break;
    //             }
    //             next += 1;
    //         }
    //     }
    //     return answer;
    // }

    public long[] solution112801(long[] numbers) {
        long[] answer = new long[numbers.Length];
        for(int i = 0; i < numbers.Length; i++)
        {
            long curr = numbers[i];
            string baseTwo = Convert.ToString(curr, 2);
            if(baseTwo[baseTwo.Length - 1] == '0') answer[i] = curr += 1;
            else
            {
                int count = 0;
                int scope = baseTwo.Length - 1;
                while(true)
                {
                    if (scope < 0 || baseTwo[scope] == '0') break;
                    count += 1;
                    scope -= 1;
                }

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append('1');
                for(int j = 0; j < count - 1; j++)
                {
                    stringBuilder.Append('0');
                }
                string plusBaseTwo = stringBuilder.ToString();
                long plusNum = Convert.ToInt64(plusBaseTwo, 2);
                answer[i] = curr + plusNum;
            }
        }
        return answer;
    }

    public string solution112802(int[] numbers) {
        string answer = "";
        string[] store = numbers.Select(x => x.ToString()).ToArray();
        Array.Sort(store, (a, b) => string.Compare(b + a, a + b));
        answer = string.Join("", store);
        if (answer[0] == '0')
            return "0";
        return answer;
    }

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

    // public bool[] Eratos(int n)
    // {
    //     bool[] eratos = Enumerable.Repeat(true, n + 1).ToArray();
    //     eratos[0] = false;
    //     eratos[1] = false;
    //     for (int i = 2; i * i <= n; i++)
    //     {
    //         if (!eratos[i]) continue;
    //         for (int j = i * i; j <= n; j += i)
    //         {
    //             eratos[j] = false;
    //         }
    //     }
    //     return eratos;
    // }

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

    public int[] solution120301(int n) {
        List<int> answer = new List<int>();
        int[][] triangle = new int[n][];
        bool[][] visited = new bool[n][];
        int totalCount = 0;
        for(int i = n - 1; i >= 0; i--)
        {
            triangle[i] = new int[i + 1];
            visited[i] = new bool[i + 1];
            totalCount += visited[i].Length;
        }
        
        int state = 0;
        int visitedCount = 0;
        int num = 1;
        int row = 0;
        int col = 0;
        triangle[row][col] = num;
        visited[row][col] = true;
        visitedCount += 1;
        while (visitedCount < totalCount)
        {
            switch(state)
            {
                case 0:
                    num += 1;
                    row += 1;
                    triangle[row][col] = num;
                    visited[row][col] = true;
                    visitedCount += 1;
                    if(row + 1 >= n || visited[row + 1][col]) state = 1;
                    break;
                case 1:
                    num += 1;
                    col += 1;
                    triangle[row][col] = num;
                    visited[row][col] = true;
                    visitedCount += 1;
                    if(col + 1 >= n || visited[row][col + 1]) state = 2;
                    break;
                case 2:
                    num += 1;
                    row -= 1;
                    col -= 1;
                    triangle[row][col] = num;
                    visited[row][col] = true;
                    visitedCount += 1;
                    if(visited[row - 1][col - 1]) state = 0;
                    break;
            }
        }

        for (int i = 0; i < triangle.Length; i++)
        {
            for (int j = 0; j < triangle[i].Length; j++)
            {
                answer.Add(triangle[i][j]);
            }
        }
        return answer.ToArray();
    }

    public int[] solution120302(int[] sequence, int k) {
        int[] answer = new int[] {};
        List<int[]> store = new List<int[]>();
        int point1 = 0;
        int point2 = 0;
        int sum = 0;
        while(true)
        {
            if(sum >= k)
            {
                if(sum == k) store.Add(new int[] {point1, point2 - 1});
                sum -= sequence[point1];
                point1 += 1;
            }
            else
            {
                if(point2 == sequence.Length) break;
                sum += sequence[point2];
                point2 += 1;
            }
        }

        int minLen = store.Min(x => x[1] - x[0]);
        List<int[]> candidates = store.Where(elem => elem[1] - elem[0] == minLen).ToList();
        answer = candidates[0];
        return answer;
    }

    public int solution120303(int storey) {
        int answer = 0;
        int[] numArray = storey.ToString().Reverse().Select(x => x - '0').ToArray();

        int count = 0;
        int idx = 0;
        while (idx < numArray.Length)
        {
            int curr = numArray[idx];
            int next = (idx + 1 < numArray.Length) ? numArray[idx + 1] : 0;
            if(numArray[idx] == 0) idx += 1;
            else if (numArray[idx] == 10)
            {
                numArray[idx] = 0;
                if (idx + 1 < numArray.Length)
                {
                    numArray[idx + 1] += 1;
                }
                else
                {
                    count += 1;
                }
                idx += 1;
            }
            else if(numArray[idx] < 5)
            {
                numArray[idx] -= 1;
                count += 1;
            }
            else if(numArray[idx] > 5)
            {
                numArray[idx] += 1;
                count += 1;
            }
            else if (curr == 5)
            {
                if (next >= 5)
                {
                    numArray[idx] += 1;
                    count += 1;
                }
                else
                {
                    numArray[idx] -= 1;
                    count += 1;
                }
            }
        }
        answer = count;
        return answer;
    }

    public long solution120401(int[] weights) {
        long answer = 0;
        Dictionary<int, long> weightCount = new Dictionary<int, long>();
        foreach(var elem in weights)
        {
            if(!weightCount.TryGetValue(elem, out var Value)) weightCount.Add(elem, 0);
            weightCount[elem] += 1;
        }

        foreach(var elem in weightCount)
        {
            long count = elem.Value;
            answer += count * (count - 1) / 2;
        }

        foreach(var elem in weights)
        {
            if(weightCount.TryGetValue(elem * 2, out var Value2)) answer += weightCount[elem * 2];
            if(elem % 3 == 0 && weightCount.TryGetValue((elem * 2) / 3, out var Value3)) answer += weightCount[(elem * 2) / 3];
            if(elem % 4 == 0 && weightCount.TryGetValue((elem * 3) / 4, out var Value4)) answer += weightCount[(elem * 3) / 4];
        }
        return answer;
    }

    public int solution120402(int n, int[,] wires) {
        int answer = int.MaxValue;

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) graph[i] = new List<int>();
        for(int i = 0; i < wires.GetLength(0); i++)
        {
            var node1 = wires[i, 0];
            var node2 = wires[i, 1];
            graph[node1].Add(node2);
            graph[node2].Add(node1);
        }

        for(int i = 1; i < graph.GetLength(0); i++)
        {
            var root = graph[i];
            bool[] visited = new bool[graph.Length];
            visited[0] = true;
            visited[i] = true;
            var neighborList = new List<(int node, int size)>();
            foreach (var elem in root)
            {
                int count = DFS1204(elem, graph, visited);
                neighborList.Add((elem, count));
            }
            int biggest = neighborList.Max(x => x.size);
            int sum = neighborList.Sum(x => x.size);
            int others = sum + 1 - biggest;
            int candidate = Math.Abs(biggest - others);
            if(candidate < answer) answer = candidate;
        }
        return answer;
    }

    public int DFS1204(int start, List<int>[] graph, bool[] visited)
    {
        int count = 0;
        Stack<int> road = new Stack<int>();
        road.Push(start);
        visited[start] = true;
        while(road.Count > 0)
        {
            int curr = road.Pop();
            count += 1;
            foreach(var next in graph[curr])
            {
                if (visited[next]) continue;
                visited[next] = true;
                road.Push(next);
            }
        }
        return count;
    }

    public int solution120501(string[,] book_time) {
        int answer = 0;
        var timeData = new List<(int start, int end)>();
        for(int i = 0; i < book_time.GetLength(0); i++)
        {
            var start = book_time[i, 0].Split(':');
            var end = book_time[i, 1].Split(':');
            var startTime = int.Parse(start[0]) * 60 + int.Parse(start[1]);
            var endTime = int.Parse(end[0]) * 60 + int.Parse(end[1]) + 10;
            timeData.Add((startTime, endTime));
        }
        timeData = timeData.OrderBy(x => x.start).ToList();

        var rooms = new List<int>();
        foreach (var elem in timeData)
        {
            int start = elem.start;
            int end   = elem.end;
            if(rooms.Count == 0) rooms.Add(end);
            else
            {
                int roomNumber = rooms.FindIndex(x => x <= start);
                if(roomNumber != -1) rooms[roomNumber] = end;
                else rooms.Add(end);
            }
        }
        answer = rooms.Count;
        return answer;
    }

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
            int minDelete = delete.First().Key;

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