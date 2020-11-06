// Question 1356. Sort Integers by The Number of 1 Bits (https://leetcode-cn.com/problems/sort-integers-by-the-number-of-1-bits/)

using System;

/// <summary>
/// 执行用时：312 ms, 在所有 C# 提交中击败了 45.95% 的用户
/// 内存消耗：32.6 MB, 在所有 C# 提交中击败了 18.92% 的用户
/// </summary>
public class Solution 
{
    public int[] SortByBits(int[] arr) 
    {
        if (arr.Count() == 0) { return arr; }

        var digitMapping = this.GetOneCountMapping(arr);

        Array.Sort(arr, (a, b) => 
        {
            var aDigitCount = digitMapping[a];
            var bDigitCount = digitMapping[b];

            // System.Console.WriteLine($"a = {a}, aDigitCount = {aDigitCount}, b = {b}, bDigitCount = {bDigitCount}");

            if (aDigitCount != bDigitCount)
            {
                return aDigitCount.CompareTo(bDigitCount);
            } 
            else 
            {
                return a.CompareTo(b);
            }
        });

        return arr;
    }

    private Dictionary<int, int> GetOneCountMapping(int[] arr)
    {
        Dictionary<int, int> digitMapping = new Dictionary<int, int>();

        foreach (var num in arr)
        {            
            // System.Console.WriteLine($"number of 1 in {decimalInBinary}'s representation = {this.Get1NumOfBinaryRepresentation(num)}");
            digitMapping[num] = this.Get1NumOfBinaryRepresentation(num);
        }

        return digitMapping;
    }

    private int Get1NumOfBinaryRepresentation(int decimalRepresentation)
    {
        int oneCount = 0;
        while (decimalRepresentation != 0)
        {            
            oneCount += decimalRepresentation % 2;
            decimalRepresentation /= 2;
        }

        return oneCount;
    }
}