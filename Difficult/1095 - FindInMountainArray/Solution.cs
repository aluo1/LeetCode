/// Question 1095. Find in Mountain Array (https://leetcode-cn.com/problems/find-in-mountain-array/)

/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution
{
    // 执行用时: 124 ms, 在所有 C# 提交中击败了 25.00% 的用户
    // 内存消耗: 25.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public int FindInMountainArray(int target, MountainArray mountainArr)
    {
        int start = 0;
        int end = mountainArr.Length() - 1;

        while (start < end)
        {
            // Use this approach instead of (start + end) / 2 to avoid overflow.
            int middle = start + (end - start) / 2;

            if (mountainArr.Get(middle) < mountainArr.Get(middle + 1))
            {
                start = middle + 1;
            }
            else
            {
                end = middle - 1;
            }
        }

        int peak = start;

        Console.WriteLine($"peak = {peak}");

        int indexOfTarget = this.BinarySearchMountainArray(mountainArr, target, 0, peak);
        if (indexOfTarget != -1)
        {
            return indexOfTarget;
        }

        return this.BinarySearchMountainArray(mountainArr, target, peak + 1, mountainArr.Length() - 1, false);
    }

    private int BinarySearchMountainArray(MountainArray mountainArr, int target, int start, int end, bool left = true)
    {
        while (start <= end)
        {
            // Use this approach instead of (start + end) / 2 to avoid overflow.
            int middle = start + (end - start) / 2;

            int currentValue = mountainArr.Get(middle);

            if (currentValue == target)
            {
                return middle;
            }
            else if (currentValue > target)
            {
                if (left)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
            else
            {
                if (left)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
        }

        return -1;
    }

}