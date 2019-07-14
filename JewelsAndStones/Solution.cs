/// Question 771. Jewels and Stones
/// Difficulty: Easy
/// 执行用时: 140 ms, 在所有 C# 提交中击败了 41.50% 的用户
/// 内存消耗: 21.1 MB, 在所有 C# 提交中击败了 21.13% 的用户

public class Solution {
    public int NumJewelsInStones(string J, string S) {
        int jewelsCount = 0;
        foreach (char s in S) {
            // The follwoing code requires the package System.Linq, which is not allowed in 
            // Leetcode, therefore we comment it out.
            /*
            if (J.Contains(j)) {
                jewelsCount++;
            }
            */
            
            if (J.IndexOf(s) >= 0) {
                jewelsCount++;
            }
        }
        return jewelsCount;
    }
}