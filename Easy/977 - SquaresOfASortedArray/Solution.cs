/// <summary>
/// Question 977. Squares of a Sorted Array (https://leetcode-cn.com/problems/squares-of-a-sorted-array/)
/// </summary>

public class Solution
{
    /// <summary>
    /// 执行用时：340 ms, 在所有 C# 提交中击败了 97.01% 的用户
    /// 内存消耗：39.9 MB, 在所有 C# 提交中击败了 28.81% 的用户
    /// 
    /// Acknowledgement: This solution borrows idea from the third method of the [official solution](https://leetcode-cn.com/problems/squares-of-a-sorted-array/solution/you-xu-shu-zu-de-ping-fang-by-leetcode-solution/)
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public int[] SortedSquares(int[] A)
    {
        int length = A.Count();

        if (length == 0) { return A; }

        int[] sorted = new int[length];
        int left = 0;
        int right = length - 1;
        int insertIndex = length - 1;
        int leftValue = A[left] * A[left];
        int rightValue = A[right] * A[right];

        while (left <= right)
        {
            if (rightValue >= leftValue)
            {
                sorted[insertIndex] = rightValue;
                insertIndex--;
                right--;
                if (right >= 0) { rightValue = A[right] * A[right]; }
            }
            else if (rightValue < leftValue)
            {
                sorted[insertIndex] = leftValue;
                insertIndex--;
                left++;

                if (left < length) { leftValue = A[left] * A[left]; }
            }

        }

        return sorted;
    }
}