// Question 832. Flipping an Image (https://leetcode-cn.com/problems/flipping-an-image/)

/// <summary>
/// 执行用时: 288 ms, 在所有 C# 提交中击败了 87.93% 的用户
/// 内存消耗: 32.1 MB, 在所有 C# 提交中击败了 6.25% 的用户
/// </summary>
public class Solution 
{
    public int[][] FlipAndInvertImage(int[][] A) 
    {
        int rowCount = A.Length;
        int columnCount = A[0].Length;

        int[][] flippedInvertedImage = new int[rowCount][];

        for (int i = 0; i < A.Length; i++) {
            int[] flippedInvertedRow = new int[columnCount];
            
            for (int j = 0; j < columnCount; j++) {
                if (A[i][columnCount-1-j] > 0) {
                    flippedInvertedRow[j] = 0;
                } else {
                    flippedInvertedRow[j] = 1;
                }
            }
            flippedInvertedImage[i] = flippedInvertedRow;
        }

        return flippedInvertedImage;
    }
}

/// <summary>
/// 执行用时：284 ms, 在所有 C# 提交中击败了 78.46% 的用户
/// 内存消耗：31.9 MB, 在所有 C# 提交中击败了 50.00% 的用户
/// </summary>
public class SolutionIn2021
{
    public int[][] FlipAndInvertImage(int[][] A) 
    {
        int M = A.Length;
        int N = A[0].Length;

        for (int i = 0; i < A.Length; i++) 
        {            
            int j;
            for (j = 0; j < N / 2; j++) 
            {
                var flippedIndex = N - j - 1;
                
                // System.Console.WriteLine($"Before swap, A[{i}][{j}] = {A[i][j]}, A[{i}][{flippedIndex}] = {A[i][flippedIndex]}");
                var temp = A[i][j];
                A[i][j] = 1 - A[i][flippedIndex];
                A[i][flippedIndex] = 1 - temp;
                // System.Console.WriteLine($"After swap, A[{i}][{j}] = {A[i][j]}, A[{i}][{flippedIndex}] = {A[i][flippedIndex]}\n");
            }

            if (N % 2 != 0)
            {
                j = N / 2;
                var flippedIndex = N - j - 1;
                
                // System.Console.WriteLine($"Before swap, A[{i}][{j}] = {A[i][j]}, A[{i}][{flippedIndex}] = {A[i][flippedIndex]}");
                var temp = A[i][j];
                A[i][j] = 1 - A[i][flippedIndex];
                A[i][flippedIndex] = 1 - temp;
                // System.Console.WriteLine($"After swap, A[{i}][{j}] = {A[i][j]}, A[{i}][{flippedIndex}] = {A[i][flippedIndex]}\n");       
            }
        }

        return A;
    }
}