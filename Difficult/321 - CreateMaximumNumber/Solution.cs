// Question 321. Create Maximum Number (https://leetcode-cn.com/problems/create-maximum-number/)

/// <summary>
/// 执行用时：288 ms, 在所有 C# 提交中击败了 87.50% 的用户
/// 内存消耗：32.4 MB, 在所有 C# 提交中击败了 14.29% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplication of the [official solution](https://leetcode-cn.com/problems/create-maximum-number/solution/pin-jie-zui-da-shu-by-leetcode-solution/)
/// </summary>
public class Solution 
{
    public int[] MaxNumber(int[] nums1, int[] nums2, int k) 
    {
        int M = nums1.Count();
        int N = nums2.Count();
        int[] maxSubsequence = new int[k];

        int start = Math.Max(0, k - N);
        int end = Math.Min(k, M);

        for (int i = start; i <= end; i++)
        {
            int[] subsequence1 = this.MaxSequence(nums1, i);
            int[] subsequence2 = this.MaxSequence(nums2, k - i);

            int[] currentMaxSubsequence = Merge(subsequence1, subsequence2);
            if (Compare(currentMaxSubsequence, 0, maxSubsequence, 0) > 0)
            {
                Array.Copy(currentMaxSubsequence, 0, maxSubsequence, 0, k);
            }
        }

        return maxSubsequence;
    }

    public int[] MaxSequence(int[] nums, int k)
    {
        int length = nums.Count();
        int[] stack = new int[k];
        int top = -1;
        int remain = length - k;

        for (int i = 0; i < length; i++)
        {
            int num = nums[i];
            while (top >= 0 && stack[top] < num && remain > 0)
            {
                top--;
                remain--;
            }

            if (top < k - 1)
            {
                stack[++top] = num;
            }
            else
            {
                remain--;
            }
        }

        return stack;
    }

    public int[] Merge(int[] subsequence1, int[] subsequence2)
    {
        int x = subsequence1.Count();
        int y = subsequence2.Count();

        if (x == 0) { return subsequence2; }
        if (y == 0) { return subsequence1; }

        int mergedLength = x + y;
        int[] merged = new int[mergedLength];
        int index1 = 0;
        int index2 = 0;
        
        for (int i = 0; i < mergedLength; i++)
        {
            if (this.Compare(subsequence1, index1, subsequence2, index2) > 0)
            {
                merged[i] = subsequence1[index1++];
            }
            else
            {
                merged[i] = subsequence2[index2++];
            }
        }

        return merged;
    }

    public int Compare(int[] subsequence1, int index1, int[] subsequence2, int index2)
    {
        int x = subsequence1.Count();
        int y = subsequence2.Count();

        while (index1 < x && index2 < y)
        {
            int difference = subsequence1[index1] - subsequence2[index2];
            if (difference != 0)
            {
                return difference;
            }

            index1++;
            index2++;
        }

        return (x - index1) - (y - index2);
    }
}