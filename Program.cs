using System;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Formats.Asn1;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


internal static class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();

        // string answer = solution.solution110801("34:33", "13:00", "00:55", "02:55", ["next", "prev"]);
        string answer = solution.solution110801("10:55", "00:05", "00:15", "06:55", ["prev", "next", "next"]);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public string solution110801(string video_len, string pos, string op_start, string op_end, string[] commands) {
        string answer = "";
        int[] vidoePosData = new int[5];
        for (int i = 0; i < pos.Length; i++)
        {
            if (pos[i] == ':') continue;
            vidoePosData[i] = pos[i] - '0';
        }

        foreach (var elem in commands)
        {
            if (elem == "next") vidoePosData[3] += 1;
            else if (elem == "prev") vidoePosData[3] -= 1;
        }
        
        for (int i = 0; i < vidoePosData.Length; i++)
        {
            if (i != 2) answer += vidoePosData[i];
            else if (i == 2) answer += ':';
        }
        return answer;
    }
}

