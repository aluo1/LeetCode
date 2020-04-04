/// 118. Pascal's Triangle - 杨辉三角
/// Difficulty: Easy
/// 执行用时: 268 ms, 在所有 C# 提交中击败了 22.35% 的用户
/// 内存消耗: 25.9 MB, 在所有 C# 提交中击败了 7.69% 的用户

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> triangleRows = new List<IList<int>>();
        if (numRows == 0) { return triangleRows; }

        triangleRows.Add(new List<int> { 1 });
        if (numRows == 1) { return triangleRows; }

        triangleRows.Add(new List<int> { 1, 1 });
        if (numRows == 2) { return triangleRows; }

        for (int i = 2; i < numRows; i++)
        {
            List<int> newRow = new List<int> { 1 };
            List<int> rowAbove = new List<int>(triangleRows[i - 1]);

            for (int j = 1; j < i; j++)
            {
                newRow.Add(rowAbove[j - 1] + rowAbove[j]);
            }

            newRow.Add(1);
            triangleRows.Add(newRow);
        }

        return triangleRows;
    }
}