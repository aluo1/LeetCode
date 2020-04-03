/// Question 724. Find Pivot Index
/// Difficulty: Easy
/// 执行用时: 200 ms, 在所有 C# 提交中击败了 67.82% 的用户
/// 内存消耗: 28.6 MB, 在所有 C# 提交中击败了 45.83% 的用户

public class Solution {
    public int PivotIndex(int[] nums) {        
        int sumOfArray = 0;
        for (int i = 0; i < nums.Length; i++) {
            sumOfArray += nums[i];
        }

        int sumOfSoFar = 0;
        for (int i = 0; i < nums.Length; i++) {
            int currentValue = nums[i];
            if (sumOfSoFar == sumOfArray - currentValue - sumOfSoFar) {
                return i;
            }
            
            sumOfSoFar += currentValue;
        }
        
        return -1;
    }
}