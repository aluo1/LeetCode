/// Question 434. Number of Segments in a String
/// Difficulty: Easy
/// 执行用时: 108 ms, 在所有 C# 提交中击败了 82.50% 的用户
/// 内存消耗: 20.5 MB, 在所有 C# 提交中击败了 6.25% 的用户

public class Solution {
    public int CountSegments(string s) {
        string separator = " ";
        if (string.IsNullOrEmpty(s)) {
            return 0;
        } 
                
        return s.Trim()
                .Split(separator)
                .Where(segment => !string.IsNullOrEmpty(segment) 
                               && !string.IsNullOrWhiteSpace(segment) 
                               && !segment.Equals(separator))
                .Count();
    }
}