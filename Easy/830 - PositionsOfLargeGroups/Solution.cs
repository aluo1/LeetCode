// Question 830. Positions of Large Groups (https://leetcode-cn.com/problems/positions-of-large-groups/)

/// <summary>
/// 执行用时：276 ms, 在所有 C# 提交中击败了 66.67% 的用户
/// 内存消耗：32.3 MB, 在所有 C# 提交中击败了 53.33% 的用户
/// </summary>
public class Solution 
{
    public IList<IList<int>> LargeGroupPositions(string s) 
    {
        IList<IList<int>> largeGroups = new List<IList<int>>();

        int N = s.Count();
        if (N == 0) { return largeGroups; }

        char currentGroupChar = s[0];
        int startIndex;
        int endIndex;
        for (startIndex = 0, endIndex = 0; endIndex < N; endIndex++)
        {
            // System.Console.WriteLine($"startIndex = {startIndex}, endIndex = {endIndex}");
            if (s[endIndex] != currentGroupChar)
            {
                if (endIndex - startIndex >= 3)
                {
                    largeGroups.Add(new List<int>() { startIndex, endIndex - 1 });
                }
                startIndex = endIndex;
                currentGroupChar = s[endIndex];
            }
        }

        if (s[N - 1] == currentGroupChar && N - 1 - startIndex + 1 >= 3)
        {
            largeGroups.Add(new List<int>() { startIndex, N - 1 });
        }
        
        return largeGroups;
    }
}