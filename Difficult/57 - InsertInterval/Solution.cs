// Question 57. Insert Interval (https://leetcode-cn.com/problems/insert-interval/)

using System;

/// <summary>
/// 执行用时：308 ms, 在所有 C# 提交中击败了 50.00% 的用户
/// 内存消耗：33.3 MB, 在所有 C# 提交中击败了 7.14% 的用户
/// </summary>
public class Solution
{
    private const int INTERVAL_START_INDEX = 0;
    private const int INTERVAL_END_INDEX = 1;

    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        int originalSize = intervals.Count();

        if (originalSize == 0) { return new int[1][] { newInterval }; }

        var intervalsList = new List<int[]>(intervals);

        int[] headInterval = intervals[0];
        if (headInterval[INTERVAL_START_INDEX] > newInterval[INTERVAL_END_INDEX])
        {
            intervalsList.Insert(0, newInterval);
            return intervalsList.ToArray();
        }

        int[] tailInterval = intervals[originalSize - 1];
        if (tailInterval[INTERVAL_END_INDEX] < newInterval[INTERVAL_START_INDEX])
        {
            intervalsList.Add(newInterval);
            return intervalsList.ToArray();
        }

        var newList = new List<int[]>();
        var merged = false;
        for (var i = 0; i < originalSize; i++)
        {
            int[] currentInterval = intervals[i];

            // We have not yet reach the intersected section.
            if (currentInterval[INTERVAL_END_INDEX] < newInterval[INTERVAL_START_INDEX])
            {
                newList.Add(currentInterval);
                continue;
            }

            // We have finish the merge process, time to break the loop to speed up.
            if (currentInterval[INTERVAL_START_INDEX] > newInterval[INTERVAL_END_INDEX])
            {
                newList.Add(newInterval);
                newList.AddRange(intervalsList.GetRange(i, originalSize - i));
                merged = true;
                break;
            }

            newInterval = new int[2] {
                Math.Min(newInterval[INTERVAL_START_INDEX], currentInterval[INTERVAL_START_INDEX]),
                Math.Max(newInterval[INTERVAL_END_INDEX], currentInterval[INTERVAL_END_INDEX])
            };

            // System.Console.WriteLine($"i = {i}, newInterval = [{newInterval[0]},{newInterval[1]}], currentInterval = [{currentInterval[0]},{currentInterval[1]}]");
        }

        if (!merged) { newList.Add(newInterval); }

        return newList.ToArray();
    }
}