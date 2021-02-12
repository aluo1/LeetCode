// Question 119. Pascal's Triangle II (https://leetcode-cn.com/problems/pascals-triangle-ii/)

/// <summary>
/// 执行用时：240 ms, 在所有 C# 提交中击败了 59.22% 的用户
/// 内存消耗：25.7 MB, 在所有 C# 提交中击败了 31.37% 的用户
/// </summary>
public class Solution 
{
    public IList<int> GetRow(int rowIndex) 
    {
        IList<IList<int>> pascalTriangle = new List<IList<int>>{ new List<int>{ 1 }, new List<int>{ 1, 1 }};

        if (rowIndex <= 1) { return pascalTriangle[rowIndex]; }

        for (int i = 2; i < rowIndex; i++)
        {
            IList<int> previousRow = pascalTriangle[i - 1];
            IList<int> currentRow = new List<int>{ 1 };
            for (int j = 1; j < i; j++)
            {
                currentRow.Add(previousRow[j - 1] + previousRow[j]);
            }
            currentRow.Add(1);
            pascalTriangle.Add(currentRow);
        }

        return pascalTriangle[rowIndex];
    }
}