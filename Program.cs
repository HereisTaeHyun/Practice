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
        // string answer = solution.solution110801("10:55", "00:05", "00:15", "06:55", ["prev", "next", "next"]);
        string answer = solution.solution110801("10:00", "00:03", "00:00", "00:05", ["prev", "next"]);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
    public string solution110801(string video_len, string pos, string op_start, string op_end, string[] commands) {
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
}

