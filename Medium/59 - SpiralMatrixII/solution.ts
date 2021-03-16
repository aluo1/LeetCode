// Question 59. Spiral Matrix II (https://leetcode-cn.com/problems/spiral-matrix-ii/)

/**
 * 执行用时：84 ms, 在所有 TypeScript 提交中击败了 81.25% 的用户
 * 内存消耗：39.4 MB, 在所有 TypeScript 提交中击败了 87.50% 的用户
 *
 * Acknowledgement: This solution is similar to the method II of the
 * [official solution](https://leetcode-cn.com/problems/spiral-matrix-ii/solution/luo-xuan-ju-zhen-ii-by-leetcode-solution-f7fp/)
 * @param {number} n
 * @returns {number[][]}
 */
function generateMatrix(n: number): number[][] {
  let matrix: number[][] = [];
  for (let i = 0; i < n; i++) {
    matrix.push([].fill(0, 0, n));
  }

  let left: number = 0;
  let right: number = n - 1;
  let top: number = 0;
  let bottom: number = n - 1;
  let value: number = 1;

  while (left <= right && top <= bottom) {
    // upper bound.
    for (let j = left; j <= right; j++) {
      matrix[top][j] = value++;
    }
    top++;

    // right bound.
    for (let i = top; i <= bottom; i++) {
      matrix[i][right] = value++;
    }
    right--;

    // lower bound.
    for (let j = right; j >= left; j--) {
      matrix[bottom][j] = value++;
    }
    bottom--;

    // left bound.
    for (let i = bottom; i >= top; i--) {
      matrix[i][left] = value++;
    }
    left++;
  }

  return matrix;
}
