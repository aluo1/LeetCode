/// Question 1013. Partition Array Into Three Parts With Equal Sum (https://leetcode-cn.com/problems/partition-array-into-three-parts-with-equal-sum/)
/// Difficulty: Easy
/// 执行用时: 180 ms, 在所有 C# 提交中击败了 48.72% 的用户
/// 内存消耗: 36.3 MB, 在所有 C# 提交中击败了 25.00% 的用户
/// 
/// Acknowledgement: Idea is borrowed from this page (https://leetcode-cn.com/problems/partition-array-into-three-parts-with-equal-sum/solution/java-shi-yong-shuang-zhi-zhen-by-sugar-31/).

public class Solution
{
    public bool CanThreePartsEqualSum(int[] A)
    {
        int arrayLength = A.Length;
        if (arrayLength == 0) { return false; }

        int sumOfArray = A.Sum();
        if (sumOfArray % 3 != 0) { return false; }

        int sumOfParts = sumOfArray / 3;

        int leftIndex = 0;
        int leftSum = A[leftIndex];

        int rightIndex = arrayLength - 1;
        int rightSum = A[rightIndex];

        while (leftIndex + 1 < rightIndex)
        {
            if (leftSum == sumOfParts && rightSum == sumOfParts)
            {
                return true;
            }

            if (leftSum != sumOfParts)
            {
                leftSum += A[++leftIndex];
            }

            if (rightSum != sumOfParts)
            {
                rightSum += A[--rightIndex];
            }
        }

        return false;
    }
}