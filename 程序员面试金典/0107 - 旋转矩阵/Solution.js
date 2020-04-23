/**
 * 面试题 01.07. 旋转矩阵 (https://leetcode-cn.com/problems/rotate-matrix-lcci/)
 * Difficulty: Medium
 *
 * 执行用时 : 60 ms, 在所有 JavaScript 提交中击败了 89.47% 的用户
 * 内存消耗 : 33.8 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * @param {number[][]} matrix
 * @return {void} Do not return anything, modify matrix in-place instead.
 */
var rotate = function (matrix) {
  let matrixLength = matrix.length;
  const transposed = [];

  for (let j = 0; j < matrixLength; j++) {
    const transposedRow = [];
    for (let i = 0; i < matrixLength; i++) {
      transposedRow[matrixLength - i - 1] = matrix[i][j];
    }
    transposed.push(transposedRow);
  }

  for (let i = 0; i < matrixLength; i++) {
    for (let j = 0; j < matrixLength; j++) {
      matrix[i][j] = transposed[i][j];
    }
  }
};
