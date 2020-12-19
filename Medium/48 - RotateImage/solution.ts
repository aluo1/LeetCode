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
