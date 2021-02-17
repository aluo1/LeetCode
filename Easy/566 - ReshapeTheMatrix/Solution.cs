// Question 566. Reshape the Matrix (https://leetcode-cn.com/problems/reshape-the-matrix/)

/// <summary>
/// 执行用时：360 ms, 在所有 C# 提交中击败了 9.52% 的用户
/// 内存消耗：33.7 MB, 在所有 C# 提交中击败了 71.43% 的用户
/// </summary>
public class Solution 
{
    public int[][] MatrixReshape(int[][] nums, int r, int c) 
    {
        int row = nums.Count();
        int column = nums[0].Count();

        if ((row == r && column == c) || (row * column != r * c)) { return nums; }

        int[][] reshaped = new int[r][];
        int newRowIndex = 0;
        int newColumnIndex = 0;

        int[] currentRow = new int[c];
        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < column; j++)
            {
                currentRow[newColumnIndex++] = nums[i][j];
    
                if (newColumnIndex == c)
                {
                    reshaped[newRowIndex++] = currentRow;
                    currentRow = new int[c];
                    newColumnIndex = 0;
                }
            }
        }

        return reshaped;
    }
}