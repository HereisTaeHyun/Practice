using System;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Formats.Asn1;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Linq.Expressions;
using System.Diagnostics.Tracing;


internal static class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();

        int answer = solution.solution112602([5, 4, 3, 2, 1]);
        // foreach (var elem in answer) Console.WriteLine(elem);
        Console.WriteLine(answer);
    }
}

public class Solution
{
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
}

