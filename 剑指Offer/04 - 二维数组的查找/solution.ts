// 面试题04. 二维数组中的查找 (https://leetcode-cn.com/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof/)
// This question is identical to the [Q240](../Medium/240 - SearchA2DMatrixII).

/**
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 6.15% 的用户
 * 内存消耗：40.8 MB, 在所有 typescript 提交中击败了 9.09% 的用户
 *
 * @param {number[][]} matrix
 * @param {number} target
 * @returns {boolean}
 */
function findNumberIn2DArray(matrix: number[][], target: number): boolean {
  for (let i = 0; i < matrix.length; i++) {
    for (let j = 0; j < matrix[0].length; j++) {
      if (matrix[i][j] === target) {
        return true;
      }
    }
  }

  return false;
}

/**
 * This is hte best solution I borrowed from the [submitted solutions](https://leetcode-cn.com/submissions/detail/101851120/).
 *
 * 执行用时：92 ms, 在所有 typescript 提交中击败了 27.69% 的用户
 * 内存消耗：40.6 MB, 在所有 typescript 提交中击败了 68.18% 的用户
 *
 * @param {number[][]} matrix
 * @param {number} target
 * @returns {boolean}
 */
function findNumberIn2DArrayBestSolution(
  matrix: number[][],
  target: number
): boolean {
  const n: number = matrix.length;
  if (n === 0) {
    return false;
  }

  const m: number = matrix[0].length;
  if (m === 0) {
    return false;
  }

  // Starts from the bottom left
  let x: number = n - 1;
  let y: number = 0;

  while (true) {
    if (x < 0 || x >= n || y < 0 || y >= m) {
      return false;
    }

    const currentValue: number = matrix[x][y];
    if (currentValue > target) {
      x--;
    } else if (currentValue < target) {
      y++;
    } else {
      return true;
    }
  }
}
