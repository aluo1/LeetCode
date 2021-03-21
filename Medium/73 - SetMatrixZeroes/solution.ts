// Question 73. Set Matrix Zeroes (https://leetcode-cn.com/problems/set-matrix-zeroes/)

/**
 *  Do not return anything, modify matrix in-place instead.
 *
 * 执行用时：116 ms, 在所有 TypeScript 提交中击败了 56.36% 的用户
 * 内存消耗：40.9 MB, 在所有 TypeScript 提交中击败了 98.18% 的用户
 *
 * Acknowledgement: This solution if the TypeScript-version duplicate of method II of
 * the [official solution](https://leetcode-cn.com/problems/set-matrix-zeroes/solution/ju-zhen-zhi-ling-by-leetcode-solution-9ll7/)
 */
function setZeroes(matrix: number[][]): void {
  let firstRowHas0 = false;
  let firstColumnHas0 = false;

  const M = matrix.length;
  const N = matrix[0].length;

  // Check if first row has 0
  for (let j = 0; j < N; j++) {
    if (!matrix[0][j]) {
      firstRowHas0 = true;
      break;
    }
  }

  // Check if first column has 0
  for (let i = 0; i < M; i++) {
    if (!matrix[i][0]) {
      firstColumnHas0 = true;
      break;
    }
  }

  // Use 1st row and 1st column as the row to store if following row/column has 0.
  for (let i = 1; i < M; i++) {
    for (let j = 1; j < N; j++) {
      if (!matrix[i][j]) {
        matrix[0][j] = 0;
        matrix[i][0] = 0;
      }
    }
  }

  // Read from 1st row and 1st column to set following row/columns.
  for (let i = 1; i < M; i++) {
    for (let j = 1; j < N; j++) {
      if (!matrix[i][0] || !matrix[0][j]) {
        matrix[i][j] = 0;
      }
    }
  }

  // Set first row if flag is true.
  if (firstRowHas0) {
    for (let j = 0; j < N; j++) {
      matrix[0][j] = 0;
    }
  }

  // Set first column if flag is true.
  if (firstColumnHas0) {
    for (let i = 0; i < M; i++) {
      matrix[i][0] = 0;
    }
  }
}
