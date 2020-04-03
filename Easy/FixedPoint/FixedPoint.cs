/// Question 1064. Fixed Point
/// Difficulty: Easy
/// 执行用时: 152 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗: 23.7 MB, 在所有 C# 提交中击败了 100.00% 的用户
public class Solution {
    public int FixedPoint(int[] A) {
        for (int i = 0; i < A.Length; i++) {
            if (i.Equals(A[i])) {
                return i;
            }
        }
        
        return -1;
    }
}