// Question 48. Rotate Image (https://leetcode-cn.com/problems/rotate-image/)

/**
 * Do not return anything, modify matrix in-place instead.
 *
 * 执行用时：88 ms, 在所有 TypeScript 提交中击败了 53.33% 的用户
 * 内存消耗：41.5 MB, 在所有 TypeScript 提交中击败了 6.82% 的用户
 */
function rotate(matrix: number[][]): void {
  const N: number = matrix.length;

  // Flip vertically.
  for (let i = 0; i < Math.round(N / 2); i++) {
    for (let j = 0; j < N; j++) {
      [matrix[i][j], matrix[N - 1 - i][j]] = [
        matrix[N - 1 - i][j],
        matrix[i][j],
      ];
    }
  }

  for (let i = 0; i < N; i++) {
    for (let j = 0; j < i; j++) {
      [matrix[i][j], matrix[j][i]] = [matrix[j][i], matrix[i][j]];
    }
  }
}

/**
 * 执行用时：88 ms, 在所有 TypeScript 提交中击败了 53.33% 的用户
 * 内存消耗：40.2 MB, 在所有 TypeScript 提交中击败了 36.36% 的用户
 * 
 * Acknowledgement: This solution borrows idea from method II
 * of the [official solution](https://leetcode-cn.com/problems/rotate-image/solution/xuan-zhuan-tu-xiang-by-leetcode-solution-vu3m/)
 *
 * @param {number[][]} matrix
 */
function rotate(matrix: number[][]): void {
  const N: number = matrix.length;

  // Rotate
  for (let i = 0; i < Math.floor(N / 2); i++) {
    for (let j = 0; j < Math.floor((N + 1) / 2); j++) {
      [
        matrix[i][j],
        matrix[N - j - 1][i],
        matrix[N - i - 1][N - j - 1],
        matrix[j][N - i - 1],
      ] = [
        matrix[N - j - 1][i],
        matrix[N - i - 1][N - j - 1],
        matrix[j][N - i - 1],
        matrix[i][j],
      ];
    }
  }
}
