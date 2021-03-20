// Question 54. Spiral Matrix (https://leetcode-cn.com/problems/spiral-matrix/)

/// <summary>
/// 执行用时：264 ms, 在所有 C# 提交中击败了 97.71% 的用户
/// 内存消耗：29.7 MB, 在所有 C# 提交中击败了 34.31% 的用户
/// 
/// Acknowledgement: This solution borrows some idea from the 
/// [official solution](https://leetcode-cn.com/problems/spiral-matrix/solution/luo-xuan-ju-zhen-by-leetcode-solution/)
/// </summary>
public class Solution 
{
    public IList<int> SpiralOrder(int[][] matrix) 
    {
        int m = matrix.Count();
        int n = matrix[0].Count();

        IList<int> elementsInSpiral = new List<int>();
        
        int left = 0;
        int right = n - 1;
        int top = 0;
        int bottom = m - 1;

        while (top <= bottom && left <= right)
        {
            // upper bound.
            for (int j = left; j <= right; j++) {
                int element = matrix[top][j];
                elementsInSpiral.Add(element);
            }

            // right bound.
            for (int i = top + 1; i <= bottom; i++) {
                int element = matrix[i][right];
                elementsInSpiral.Add(element);
            }

            if (left < right && top < bottom) 
            {
                // lower bound.
                for (int j = right - 1; j > left; j--) {
                    int element = matrix[bottom][j];
                    elementsInSpiral.Add(element);
                }

                // left bound.
                for (int i = bottom; i > top; i--) {
                    int element = matrix[i][left];
                    elementsInSpiral.Add(element);
                }
            }

            top++;
            right--;
            bottom--;
            left++;

            System.Console.WriteLine($"top = {top}, bottom = {bottom}, left = {left}, right = {right}");
            System.Console.WriteLine($"elementsInSpiral = [{string.Join(", ", elementsInSpiral)}]");
        }

        return elementsInSpiral;
    }
}
