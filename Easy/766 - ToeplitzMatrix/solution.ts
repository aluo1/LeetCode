// Question 766. Toeplitz Matrix (https://leetcode-cn.com/problems/toeplitz-matrix/)

/**
 * 执行用时：96 ms, 在所有 TypeScript 提交中击败了 81.82% 的用户
 * 内存消耗：39.6 MB, 在所有 TypeScript 提交中击败了 100.00% 的用户
 *
 * @param {number[][]} matrix
 * @returns {boolean}
 */
function isToeplitzMatrix(matrix: number[][]): boolean {
  const M: number = matrix.length;
  const N: number = matrix[0].length;

  for (let i = 1; i < M; i++) {
    for (let j = 1; j < N; j++) {
      if (matrix[i][j] != matrix[i - 1][j - 1]) {
        return false;
      }
    }
  }

  return true;
}
