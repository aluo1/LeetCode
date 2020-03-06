
/// 面试题57 - II. 和为s的连续正数序列
/// Difficulty: Easy

public class Solution {
    public int[][] FindContinuousSequence(int target) {
        return FindContinuousSequenceFirstTry(target);
    }

    public int[][] FindContinuousSequenceFirstTry(int target) {
        /// 执行用时: 1876 ms, 在所有 C# 提交中击败了 11.11% 的用户
        /// 内存消耗: 28.4 MB, 在所有 C# 提交中击败了 100.00% 的用户

        List<int[]> consecutiveIntList = new List<int[]>();

        int halfOfTarget = target % 2 == 0 ? target / 2 : (target / 2) + 1;
        for (int i = 1; i <= halfOfTarget; i++) {
            List<int> consecutiveInts = new List<int>();
            for (int j = i; true; j++) {
                consecutiveInts.Add(j);
                int currentSum = consecutiveInts.Sum();
                if (currentSum == target && consecutiveInts.Count >= 2) {
                    consecutiveIntList.Add(consecutiveInts.ToArray());
                    break;
                } else if (currentSum > target) {
                    break;
                }
            }
        }

        return consecutiveIntList.ToArray();
    }

    public int[][] FindContinuousSequenceSecondTry(int target) {
        // Placeholder.
    }
}