/// Question 633. Sum of Square Numbers
/// Difficulty: Easy
/// 执行用时: 68 ms, 在所有 C# 提交中击败了 61.54% 的用户
/// 内存消耗: 12.7 MB, 在所有 C# 提交中击败了 44.44% 的用户

public class Solution {
    public bool JudgeSquareSum(int c) {
        int sqrtOfC = (int) Math.Ceiling(Math.Sqrt(c));
                
        for (int i = 0; i <= sqrtOfC; i++) {
            int remainingValue = c - i * i;
            double sqrtOfRemaining = Math.Sqrt(remainingValue);
            if (Math.Ceiling(sqrtOfRemaining) == sqrtOfRemaining && 
                Math.Floor(sqrtOfRemaining) == sqrtOfRemaining) {
                return true;
            }
        }

        return false;
    }
}