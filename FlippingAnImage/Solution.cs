/// Question 832. Flipping an Image
/// Difficulty: Easy
/// 执行用时: 288 ms, 在所有 C# 提交中击败了 87.93% 的用户
/// 内存消耗: 32.1 MB, 在所有 C# 提交中击败了 6.25% 的用户

public class Solution {
    public int[][] FlipAndInvertImage(int[][] A) {
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